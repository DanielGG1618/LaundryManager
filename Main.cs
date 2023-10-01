using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LaundryManager
{
    public partial class Main : Form
    {
        Dictionary<int, ClothView> _clothsViews = new Dictionary<int, ClothView>();

        public Main()
        {
            InitializeComponent();
        }

        private void OnMainLoad(object sender, EventArgs e)
        {
            InitCloths(SQL.GetAllCloths());
        }

        private void InitCloths(Dictionary<int, ClothModel> cloths)
        {
            foreach(var idClothModel in cloths)
            {
                ClothView clothView = new ClothView(idClothModel.Value);

                idClothModel.Value.Deleted += OnClothDeleted;

                _clothsViews.Add(idClothModel.Key, clothView);
                _flowLayoutPanel.Controls.Add(clothView);
            }
        }

        private void OnMainFormClosing(object sender, FormClosingEventArgs e)
        {
            SQL.Stop();
        }

        private void AdditionButtonClick(object sender, EventArgs e)
        {
            AdditionForm additionForm = new AdditionForm(); 
            DialogResult result = additionForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                AddItem(additionForm.GetCloth());
            }
        }

        private void AddItem(ClothModel clothModel)
        {
            clothModel.Init();

            int id = SQL.InsertCloth(clothModel);

            clothModel.SetId(id);

            ClothView clothView = new ClothView(clothModel);
            _flowLayoutPanel.Controls.Add(clothView);
        }

        private void OnClothDeleted(int id)
        {
            _flowLayoutPanel.Controls.Remove(_clothsViews[id]);
            SQL.DeleteClothId(id);
        }
    }
}
