using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;
using CandyShopBusinessLogic.ViewModels;
namespace CandyShopView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic _orderLogic;
        private readonly PastryLogic _pastryLogic;
        private readonly ReportLogic _report;
        public FormMain(OrderLogic orderLogic, PastryLogic pastryLogic, ReportLogic report)
        {
            InitializeComponent();
            this._orderLogic = orderLogic;
            this._pastryLogic = pastryLogic;
            this._report = report;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                var ordersList = _orderLogic.Read(null);
                if (ordersList != null)
                {
                    dataGridView.DataSource = ordersList;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
        private void СладостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormSweets>();
            form.ShowDialog();
        }
        private void КондитерскиеИзделияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormPastrys>();
            form.ShowDialog();
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormCreateOrder>();
            form.ShowDialog();
            LoadData();
        }
        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
                    {
                        OrderId =
                   id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.FinishOrder(new ChangeStatusBindingModel
                    {
                        OrderId = id
                    });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonPayOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                try
                {
                    _orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }

        private void складыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStorages>();
            form.ShowDialog();
        }

        private void пополнитьСкладToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormStorageReplenishment>();
            form.ShowDialog();
        }

        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void SweetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _report.SavePastrysToWordFile(new ReportBindingModel
                    {
                        FileName =
                    dialog.FileName
                    });
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }
        private void SweetPastrysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportPastrySweets>();
            form.ShowDialog();
        }
        private void OrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrders>();
            form.ShowDialog();
        }

    }
}

