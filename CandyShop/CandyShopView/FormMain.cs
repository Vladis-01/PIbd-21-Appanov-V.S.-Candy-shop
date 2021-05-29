using CandyShopBusinessLogic.BindingModels;
using CandyShopBusinessLogic.BusinessLogics;
using System;
using System.Windows.Forms;
using Unity;
using CandyShopBusinessLogic.ViewModels;
using System.Reflection;

namespace CandyShopView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly OrderLogic orderLogic;
        private readonly ReportLogic reportLogic;
        private readonly WorkModeling workModeling;
        private readonly BackUpAbstractLogic _backUpAbstractLogic;
        public FormMain(OrderLogic orderLogic, ReportLogic reportLogic, WorkModeling workModeling, BackUpAbstractLogic _backUpAbstractLogic)
        {
            InitializeComponent();
            this.orderLogic = orderLogic;
            this.reportLogic = reportLogic;
            this.workModeling = workModeling;
            this._backUpAbstractLogic = _backUpAbstractLogic;
            LoadData();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                Program.ConfigGrid(orderLogic.Read(null), dataGridView);
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
                    orderLogic.TakeOrderInWork(new ChangeStatusBindingModel
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
                    orderLogic.FinishOrder(new ChangeStatusBindingModel
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
                    orderLogic.PayOrder(new ChangeStatusBindingModel { OrderId = id });
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
                    MethodInfo method = reportLogic.GetType().GetMethod("SaveSweetsToWordFile");
                    method.Invoke(reportLogic, new object[] { new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }});
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

        private void storagesListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog { Filter = "docx|*.docx" })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    MethodInfo method = reportLogic.GetType().GetMethod("SaveStoragesToWordFile");
                    method.Invoke(reportLogic, new object[] { new ReportBindingModel
                        {
                            FileName = dialog.FileName
                        }});
                    MessageBox.Show("Done", "Success", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void sweetsByStoragesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportSweetsStorages>();
            form.ShowDialog();
        }

        private void ordersByDatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormReportOrdersByDates>();
            form.ShowDialog();
        }
        private void клиентыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormClients>();
            form.ShowDialog();
        }

        private void запускРаботToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workModeling.DoWork();
            LoadData();
        }

        private void исполнителиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormImplementers>();
            form.ShowDialog();
        }

        private void ПочтаStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormMails>();
            form.ShowDialog();
        }

        private void создатьБекапToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (_backUpAbstractLogic != null)
                {
                    var fbd = new FolderBrowserDialog();
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        _backUpAbstractLogic.CreateArchive(fbd.SelectedPath);
                        MessageBox.Show("Создать бекап", "Message",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
        }
    }
}

