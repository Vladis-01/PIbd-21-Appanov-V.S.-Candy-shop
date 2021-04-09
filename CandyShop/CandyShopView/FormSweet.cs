using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;
namespace CandyShopView
{
    public partial class FormSweet : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly SweetLogic logic;
        private int? id;
        public FormSweet(SweetLogic logic)
        {
            InitializeComponent();
            this.logic = logic;
        }
        private void FormSweet_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    var view = logic.Read(new SweetBindingModel { Id = id })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.SweetName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new SweetBindingModel
                {
                    Id = id,
                    SweetName = textBoxName.Text
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}

