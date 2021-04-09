using CandyShopBusinessLogic.BusinessLogics;
using CandyShopBusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
namespace CandyShopView
{
    public partial class FormPastrySweet : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id
        {
            get { return Convert.ToInt32(comboBoxSweet.SelectedValue); }
            set { comboBoxSweet.SelectedValue = value; }
        }
        public string SweetName { get { return comboBoxSweet.Text; } }
        public int Count
        {
            get { return Convert.ToInt32(textBoxCount.Text); }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }
        public FormPastrySweet(SweetLogic logic)
        {
            InitializeComponent();
            List<SweetViewModel> list = logic.Read(null);
            if (list != null)
            {
                comboBoxSweet.DisplayMember = "SweetName";
                comboBoxSweet.ValueMember = "Id";
                comboBoxSweet.DataSource = list;
                comboBoxSweet.SelectedItem = null;
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxSweet.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
