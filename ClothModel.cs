using System;
using System.Drawing;

namespace LaundryManager
{
    public class ClothModel
    {
        private int _id = -1;
        public string Name { get; private set; }
        public Image Image { get; private set; }

        private DateTime _lastWashDate;
        public DateTime LastWashDate 
        {
            get => _lastWashDate;
            private set
            {
                _lastWashDate = value;
                SQL.UpdateLastWashDate(_id, _lastWashDate);
            }
        }
        
        private DateTime _lastWearDate;
        public DateTime LastWearDate
        {
            get => _lastWearDate;
            private set
            {
                _lastWearDate = value;
                SQL.UpdateLastWearDate(_id, _lastWearDate);
            }
        }
        public int WashingCooldown { get; private set; }

        private int _currentCooldownState;
        public int CurrentCooldownState 
        {
            get
            {
                return _currentCooldownState;
            }
            set
            {
                _currentCooldownState = value;
                SQL.UpdateClothCooldownState(_id, _currentCooldownState);
            }
        }
        public bool WornToday => _lastWearDate >= DateTime.Today;
        public bool WashedToday => _lastWashDate >= DateTime.Today;  

        public event Action<int> Deleted;

        public ClothModel(int id, string name, Image image, DateTime lastWashDate, 
            DateTime lastWearDate, int washingCooldown, int currentCooldownState)
        {
            _id = id;
            Name = name;
            Image = image;
            LastWashDate = lastWashDate;
            LastWearDate = lastWearDate;
            WashingCooldown = washingCooldown;
            CurrentCooldownState = currentCooldownState;
        }

        public ClothModel(string name, Image image, int washingCooldown) 
        {
            Name = name;
            Image = image;
            WashingCooldown = washingCooldown;
        }

        public void Init()
        {
            LastWashDate = DateTime.Today;
            CurrentCooldownState = 0;
        }

        public void SetId(int id)
        {
            if (id != -1)
                return;

            _id = id;
        }

        public void OnWear()
        {
            LastWearDate = DateTime.Today;
            CurrentCooldownState += 1;
        }

        public void OnWash()
        {
            LastWashDate = DateTime.Today;
            CurrentCooldownState = 0;
        }

        public void OnDelete()
        {
            Deleted?.Invoke(_id);
        }       
    }
}
