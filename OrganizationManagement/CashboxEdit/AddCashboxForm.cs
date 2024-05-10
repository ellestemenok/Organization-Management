using DatabaseLibrary;
using System;
using System.Windows.Forms;
namespace OrganizationManagement.CashboxEdit
{
    public partial class AddCashboxForm : Form
    {
        public AddCashboxForm()
        {
            InitializeComponent();
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            string name = "Кассовый отчет за " + date.ToShortDateString();
            if (Cashbox.Exists(date))
            {
                MessageBox.Show("Кассовый отчет за эту дату уже существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Cashbox.Insert(name, date);
                Close();
                CashboxEditForm editForm = new CashboxEditForm(Convert.ToInt32(DataDB.ExecuteScalarQuery($"SELECT \"CashboxID\" FROM public.\"Cashbox\" WHERE \"CashboxDate\" = '{date}'")));
                editForm.MdiParent = ActiveForm;
                editForm.Show();
            }
        }

        private void AddCashboxForm_Load(object sender, EventArgs e)
        {
            Autorization.OpenConnection();
        }
    }
}
