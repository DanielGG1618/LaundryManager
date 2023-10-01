using System;
using System.Windows.Forms;

namespace LaundryManager
{
    public partial class ClothView : UserControl
    {
        private ClothModel _model;

        public ClothView(ClothModel clothModel)
        {
            InitializeComponent();

            _model = clothModel;

            _pictureBox.BackgroundImage = _model.Image;
            _nameLabel.Text = _model.Name;
            _lastWashedLabel.Text = GetLastWashDateText(_model.LastWashDate);
            _cooldownLabel.Text = GetCooldownText(_model.CurrentCooldownState, _model.WashingCooldown);

            _wearButton.Enabled = _model.WornToday == false;
            _washButton.Enabled = _model.WashedToday == false;
        }

        private string GetLastWashDateText(DateTime date)
        {
            int delta = DateTime.Today.Subtract(date).Days;
            if (delta == 0)
                return $"Last washed: {date:dd.MM}, today";

            return $"Last washed: {date:dd.MM}, {delta} days ago";
        }

        private string GetCooldownText(int state, int cooldown)
        {
            return $"Wore {state} times out of {cooldown}";
        }

        private void OnWearButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Have you worn this?", "Are you sure?", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            {
                _model.OnWear();
                _cooldownLabel.Text = GetCooldownText(_model.CurrentCooldownState, _model.WashingCooldown);

                _wearButton.Enabled = false;
            }
        }

        private void OnWashButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "Have you washed this?", "Are you sure?", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
            { 
                _model.OnWash();
                _lastWashedLabel.Text = GetLastWashDateText(_model.LastWashDate);

                _washButton.Enabled = false;
            }
        }

        private void DeletingButtonClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show(
                "You want to delete this?", "Are you sure?", MessageBoxButtons.YesNoCancel);

            if (dialogResult == DialogResult.Yes)
                _model.OnDelete();
        }
    }
}
