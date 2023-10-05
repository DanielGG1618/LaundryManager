using System;
using System.Drawing;

namespace LaundryManager
{
    public class ClothModel
    {
        private int _id = -1;
        public string Name { get; private set; }
        public Image Image { get; private set; }
        public DateTime LastWashDate { get; private set; }
        public DateTime LastWearDate { get; private set; }
        public int WashingCooldown { get; private set; }
        public int CurrentCooldownState { get; private set; }
        public bool WornToday => LastWearDate >= DateTime.Today;
        public bool WashedToday => LastWashDate >= DateTime.Today;  

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
