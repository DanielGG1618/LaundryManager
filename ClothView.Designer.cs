namespace LaundryManager
{
    partial class ClothView
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._washButton = new System.Windows.Forms.Button();
            this._wearButton = new System.Windows.Forms.Button();
            this._cooldownLabel = new System.Windows.Forms.Label();
            this._lastWashedLabel = new System.Windows.Forms.Label();
            this._nameLabel = new System.Windows.Forms.Label();
            this._deletingButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.BackgroundImage = global::LaundryManager.Properties.Resources.default_image_550;
            this._pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._pictureBox.InitialImage = global::LaundryManager.Properties.Resources.default_image_550;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Margin = new System.Windows.Forms.Padding(10);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Padding = new System.Windows.Forms.Padding(10);
            this._pictureBox.Size = new System.Drawing.Size(420, 420);
            this._pictureBox.TabIndex = 0;
            this._pictureBox.TabStop = false;
            // 
            // _washButton
            // 
            this._washButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._washButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._washButton.Location = new System.Drawing.Point(0, 645);
            this._washButton.Name = "_washButton";
            this._washButton.Size = new System.Drawing.Size(420, 90);
            this._washButton.TabIndex = 1;
            this._washButton.Text = "I have washed it today";
            this._washButton.UseVisualStyleBackColor = true;
            this._washButton.Click += new System.EventHandler(this.OnWashButtonClick);
            // 
            // _wearButton
            // 
            this._wearButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._wearButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._wearButton.Location = new System.Drawing.Point(0, 555);
            this._wearButton.Name = "_wearButton";
            this._wearButton.Size = new System.Drawing.Size(420, 90);
            this._wearButton.TabIndex = 2;
            this._wearButton.Text = "I have worn it today";
            this._wearButton.UseVisualStyleBackColor = true;
            this._wearButton.Click += new System.EventHandler(this.OnWearButtonClick);
            // 
            // _cooldownLabel
            // 
            this._cooldownLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._cooldownLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cooldownLabel.Location = new System.Drawing.Point(0, 510);
            this._cooldownLabel.Name = "_cooldownLabel";
            this._cooldownLabel.Size = new System.Drawing.Size(420, 45);
            this._cooldownLabel.TabIndex = 3;
            this._cooldownLabel.Text = "Wore 0 times out of 7";
            this._cooldownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lastWashedLabel
            // 
            this._lastWashedLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._lastWashedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._lastWashedLabel.Location = new System.Drawing.Point(0, 465);
            this._lastWashedLabel.Name = "_lastWashedLabel";
            this._lastWashedLabel.Size = new System.Drawing.Size(420, 45);
            this._lastWashedLabel.TabIndex = 4;
            this._lastWashedLabel.Text = "Last washed: 16 sep, 0 days ago";
            this._lastWashedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _nameLabel
            // 
            this._nameLabel.BackColor = System.Drawing.Color.Transparent;
            this._nameLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._nameLabel.Location = new System.Drawing.Point(0, 420);
            this._nameLabel.Name = "_nameLabel";
            this._nameLabel.Size = new System.Drawing.Size(420, 45);
            this._nameLabel.TabIndex = 5;
            this._nameLabel.Text = "NO NAME";
            this._nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _deletingButton
            // 
            this._deletingButton.FlatAppearance.BorderSize = 0;
            this._deletingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._deletingButton.ForeColor = System.Drawing.Color.Red;
            this._deletingButton.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this._deletingButton.IconColor = System.Drawing.Color.Maroon;
            this._deletingButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this._deletingButton.IconSize = 40;
            this._deletingButton.Location = new System.Drawing.Point(12, 12);
            this._deletingButton.Name = "_deletingButton";
            this._deletingButton.Size = new System.Drawing.Size(48, 48);
            this._deletingButton.TabIndex = 6;
            this._deletingButton.UseVisualStyleBackColor = true;
            this._deletingButton.Click += new System.EventHandler(this.DeletingButtonClick);
            // 
            // ClothView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this._deletingButton);
            this.Controls.Add(this._nameLabel);
            this.Controls.Add(this._lastWashedLabel);
            this.Controls.Add(this._cooldownLabel);
            this.Controls.Add(this._wearButton);
            this.Controls.Add(this._washButton);
            this.Controls.Add(this._pictureBox);
            this.Name = "ClothView";
            this.Size = new System.Drawing.Size(420, 735);
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Button _washButton;
        private System.Windows.Forms.Button _wearButton;
        private System.Windows.Forms.Label _cooldownLabel;
        private System.Windows.Forms.Label _lastWashedLabel;
        private System.Windows.Forms.Label _nameLabel;
        private FontAwesome.Sharp.IconButton _deletingButton;
    }
}
