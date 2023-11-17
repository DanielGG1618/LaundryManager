using LaundryManager.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LaundryManager
{
    public static class SQL
    {
        private static SqlConnection _connection;

        private static LaundryDataContext _laundryDataContext;

        private static Queue<string> _commandsQueue = new Queue<string>();

        public static void OpenConnection()
        {
            _connection = new SqlConnection(Settings.Default.LaundryConnectionString);
            _connection.Open();

            _laundryDataContext = new LaundryDataContext();

            DequeueCommands();
        }

        private static bool _isRunning;

        private static async void DequeueCommands()
        {
            _isRunning = true;

            while (_isRunning)
            {
                await Task.Delay(5000);

                if (_connection.State != ConnectionState.Open)
                    await new Task(_connection.Open);

                while (_commandsQueue.Count > 0)
                {
                    string commandText = _commandsQueue.Dequeue();

                    SqlCommand command = new SqlCommand(commandText, _connection);

                    try
                    {
                        await command.ExecuteNonQueryAsync();
                        command.Dispose();
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                }
            }
        }

        public static void Stop()
        {
            if (_commandsQueue.Count < 1)
                return;

            Queue<string> commandsQueue = new Queue<string>(_commandsQueue);

            if (_connection.State != ConnectionState.Open)
                _connection.Open();

            while (commandsQueue.Count > 0)
            {
                string commandText = commandsQueue.Dequeue();

                SqlCommand command = new SqlCommand(commandText, _connection);

                try
                {
                    command.ExecuteNonQuery();
                    command.Dispose();
                }

                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        public static Dictionary<int, ClothModel> GetAllCloths()
        {
            Dictionary<int, ClothModel> cloths = new Dictionary<int, ClothModel>();

            Cloth[] selected = _laundryDataContext.Cloths.ToArray();

            foreach (var cloth in selected)
            {
                ClothModel clothModel = ParseCloth(cloth, out int id);
                cloths.Add(id, clothModel);
            }

            return cloths;
        }

        public static ClothModel GetClothFromId(int id)
        {
            Cloth cloth = _laundryDataContext.Cloths.Where((Cloth c) => c.Id == id).First();

            return new ClothModel(cloth);
        }

        private static ClothModel ParseCloth(List<object> input, out int id)
        {
            string name;
            Image image = null;
            DateTime lastWashDate;
            DateTime lastWearDate;
            int washingCooldown;
            int currentCooldownState;

            id = (int)input[0];
            name = (string)input[1];

            if (!(input[2] is DBNull))
            {
                byte[] data = (byte[])input[2];
                MemoryStream ms = new MemoryStream(data);
                image = Image.FromStream(ms);
            }

            lastWashDate = (DateTime)input[3];
            lastWearDate = (DateTime)input[4];
            washingCooldown = (int)input[5];
            currentCooldownState = (int)input[6];

            ClothModel cloth = new ClothModel(id, name, image, lastWashDate,
                lastWearDate, washingCooldown, currentCooldownState);

            return cloth;
        }

        private static ClothModel ParseCloth(Cloth cloth, out int id)
        {
            id = cloth.Id;

            ClothModel clothModel = new ClothModel(cloth);

            return clothModel;
        }

        public static int InsertCloth(ClothModel cloth)
        {
            int id;

            string name = cloth.Name;
            Image image = cloth.Image;
            DateTime lastWashDate = cloth.LastWashDate;
            int washingCooldown = cloth.WashingCooldown;

            id = InsertCloth(name, image, lastWashDate, washingCooldown);

            return id;
        }

        public static int InsertCloth(string name, Image image, DateTime lastWashDate, int washingCooldown)
        {
            byte[] imageBytes = ImageToByteArray(image);

            string commandText = $"INSERT INTO Cloths (Name, Image, LastWashDate, WashingCooldown) " +
                $"OUTPUT Inserted.Id " +
                $"VALUES (@Name, @Image, @LastWashDate, @WashingCooldown)";          

            SqlCommand command = new SqlCommand(commandText, _connection);
            command.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = name;
            command.Parameters.Add("@Image", SqlDbType.Image, imageBytes.Length).Value = imageBytes;
            command.Parameters.Add("@LastWashDate", SqlDbType.DateTime).Value = lastWashDate;
            command.Parameters.Add("@WashingCooldown", SqlDbType.Int).Value = washingCooldown;

            int id = (int)command.ExecuteScalar();

            command.Dispose();

            return id;
        }

        public static void UpdateClothCooldownState(int id, int cooldownState)
        {
            string commandText = $"UPDATE Cloths SET CurrentCooldownState = '{cooldownState}' WHERE Id = '{id}'";
            EnqueueCommand(commandText);
        }

        public static void UpdateLastWashDate(int id, DateTime date)
        {
            string commandText = $"UPDATE Cloths SET LastWashDate = '{date.ToSQLstring()}' WHERE Id = '{id}'";
            EnqueueCommand(commandText);
        }

        public static void UpdateLastWearDate(int id, DateTime date)
        {
            string commandText = $"UPDATE Cloths SET LastWearDate = '{date.ToSQLstring()}' WHERE Id = '{id}'";
            EnqueueCommand(commandText);
        }

        public static void DeleteClothId(int id)
        {
            string command = $"DELETE FROM Cloths WHERE Id = {id}";
            EnqueueCommand(command);
        }

        private static byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private static List<object> Select(string text)
        {
            List<object> results = new List<object>();
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            SqlCommand command = new SqlCommand(text, _connection);

            IDataReader reader = command.ExecuteReader();
            while (reader.Read())
                for (int i = 0; i < reader.FieldCount; i++)
                    results.Add(reader.GetValue(i));

            reader.Close();

            command.Dispose();

            return results;
        }

        private static void EnqueueCommand(string text)
        {
            _commandsQueue.Enqueue(text);
        }

        private static void Command(string text)
        {
            SqlCommand command = new SqlCommand(text, _connection);
            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            command.ExecuteNonQuery();

            command.Dispose();
        }
    }
}
