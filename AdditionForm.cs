using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace LaundryManager
{
    public partial class AdditionForm : Form
    {
        public AdditionForm()
        {
            InitializeComponent();
        }

        public ClothModel GetCloth()
        {
            string name = _nameTextBox.Text;
            Image image = _pictureBox.BackgroundImage;
            ClothModel cloth = new ClothModel(name, image);

            return cloth;
        }

        private void PictureBoxClick(object sender, EventArgs e)
        {
            DialogResult dialogResult = _openImageDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                Image image = Image.FromFile(_openImageDialog.FileName);
                Bitmap bitmap = new Bitmap(image);

                int minDimention = bitmap.Height < bitmap.Width ? bitmap.Height : bitmap.Width;
                int y = (bitmap.Height - minDimention) / 2;

                _pictureBox.BackgroundImage = bitmap.Clone(new Rectangle(0, y, minDimention, minDimention), 
                    System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            }
        }
    }
}
