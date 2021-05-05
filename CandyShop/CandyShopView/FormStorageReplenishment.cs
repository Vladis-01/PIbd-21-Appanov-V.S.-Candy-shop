using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;
using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using CandyShopBusinessLogic.ViewModels;

namespace CandyShopView
{
    public partial class FormStorageReplenishment : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public int SweetId
        {
            get
            {
                return Convert.ToInt32(comboBoxSweet.SelectedValue);
            }
            set
            {
                comboBoxSweet.SelectedValue = value;
            }
        }

        public int Storage
        {
            get
            {
                return Convert.ToInt32(comboBoxSweet.SelectedValue);
            }
            set
            {
                comboBoxSweet.SelectedValue = value;
            }
        }

        public int Count
        {
            get
            {
                return Convert.ToInt32(textBoxCount.Text);
            }
            set
            {
                textBoxCount.Text = value.ToString();
            }
        }

        private readonly StorageLogic _storageLogic;

        public FormStorageReplenishment(SweetLogic sweetLogic, StorageLogic storageLogic)
        {
            InitializeComponent();

            _storageLogic = storageLogic;

            List<SweetViewModel> listSweets = sweetLogic.Read(null);

            if (listSweets != null)
            {
                comboBoxSweet.DisplayMember = "SweetName";
                comboBoxSweet.ValueMember = "Id";
                comboBoxSweet.DataSource = listSweets;
                comboBoxSweet.SelectedItem = null;
            }

            List<StorageViewModel> listStorages = storageLogic.Read(null);

            if (listStorages != null)
            {
                comboBoxName.DisplayMember = "StorageName";
                comboBoxName.ValueMember = "Id";
                comboBoxName.DataSource = listStorages;
                comboBoxName.SelectedItem = null;
            }
        }

        private void buttonSave_Click_1(object sender, EventArgs e)
        {
            if (comboBoxName.SelectedValue == null)
            {
                MessageBox.Show("Выберите склад", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxSweet.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Неизвестное количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _storageLogic.Replenishment(new ReplenishStorageBindingModel
            {
                StorageId = Convert.ToInt32(comboBoxName.SelectedValue),
                SweetId = Convert.ToInt32(comboBoxSweet.SelectedValue),
                Count = Convert.ToInt32(textBoxCount.Text)
            });

            DialogResult = DialogResult.OK;

            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

