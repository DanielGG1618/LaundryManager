namespace LaundryManager
{
    partial class AdditionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._pictureBox = new System.Windows.Forms.PictureBox();
            this._additionButton = new System.Windows.Forms.Button();
            this._nameTextBox = new System.Windows.Forms.TextBox();
            this._openImageDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // _pictureBox
            // 
            this._pictureBox.BackgroundImage = global::LaundryManager.Properties.Resources.default_image_550;
            this._pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this._pictureBox.Dock = System.Windows.Forms.DockStyle.Top;
            this._pictureBox.InitialImage = global::LaundryManager.Properties.Resources.default_image_550;
            this._pictureBox.Location = new System.Drawing.Point(0, 0);
            this._pictureBox.Margin = new System.Windows.Forms.Padding(10);
            this._pictureBox.Name = "_pictureBox";
            this._pictureBox.Padding = new System.Windows.Forms.Padding(10);
            this._pictureBox.Size = new System.Drawing.Size(420, 420);
            this._pictureBox.TabIndex = 1;
            this._pictureBox.TabStop = false;
            this._pictureBox.Click += new System.EventHandler(this.PictureBoxClick);
            // 
            // _additionButton
            // 
            this._additionButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._additionButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._additionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._additionButton.Location = new System.Drawing.Point(0, 466);
            this._additionButton.Name = "_additionButton";
            this._additionButton.Size = new System.Drawing.Size(420, 90);
            this._additionButton.TabIndex = 3;
            this._additionButton.Text = "Add this item";
            this._additionButton.UseVisualStyleBackColor = true;
            // 
            // _nameTextBox
            // 
            this._nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._nameTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._nameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._nameTextBox.Location = new System.Drawing.Point(0, 421);
            this._nameTextBox.Name = "_nameTextBox";
            this._nameTextBox.Size = new System.Drawing.Size(420, 45);
            this._nameTextBox.TabIndex = 7;
            this._nameTextBox.Text = "Name";
            this._nameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _openImageDialog
            // 
            this._openImageDialog.DefaultExt = "png";
            this._openImageDialog.FileName = "_openImageDialog";
            this._openImageDialog.Filter = "Image Files|*.BMP;*.JPG;*.GIF;*.JPEG;*.PNG";
            // 
            // AdditionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(420, 556);
            this.Controls.Add(this._nameTextBox);
            this.Controls.Add(this._additionButton);
            this.Controls.Add(this._pictureBox);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(444, 620);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(444, 620);
            this.Name = "AdditionForm";
            this.Text = "AdditionForm";
            ((System.ComponentModel.ISupportInitialize)(this._pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox _pictureBox;
        private System.Windows.Forms.Button _additionButton;
        private System.Windows.Forms.TextBox _nameTextBox;
        private System.Windows.Forms.OpenFileDialog _openImageDialog;
    }
}