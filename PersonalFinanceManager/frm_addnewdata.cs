using PersonalFinanceManager.Dtos.AddNewData;
using PersonalFinanceManager.Query;
using PersonalFinanceManager.Services;
using PersonalFinanceManager.Services.Features.AddNewData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager
{
    public partial class frm_addnewdata : Form
    {
        public frm_income IncomeForm { get; set; }
        public frm_expense ExpenseForm { get; set; }

        private readonly AddNewDataService _addNewDataService;

        public frm_addnewdata()
        {
            InitializeComponent();
            _addNewDataService = new AddNewDataService();
        }

        public string labelName
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            keycontrol.KeyDownEnterNextButtonClick(sender, e, button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    //string nextsql;
                    //string data = textBox1.Text.ToString();
                    //DB.sql = "EXEC InsertDescription @name = '" + data + "';";
                    var result = _addNewDataService.AddDescription(textBox1.Text);
                    switch (label1.Text)
                    {
                        case "Income Title :":
                        case "Expense Title :":
                            IncomeTitleComboBox();
                            break;
                        case "From :":
                        case "To :":
                            FlowToFromComboBox(textBox1.Text);
                            break;
                        case "IncomeType :":
                        case "Payment :":
                            CashFlowComboBox(textBox1.Text);
                            break;
                        default:
                            throw new Exception($"Not Found label1.Text{label1.Text}");
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        private void IncomeTitleComboBox()
        {
            var descriptionLst = _addNewDataService.IncomeTitleComboBox();
            if (descriptionLst is null) return;
            if (label1.Text == "Income Title :")
            {
                IncomeForm.Cob1.Items.Clear();
                IncomeForm.Cob1.Items.AddRange(descriptionLst.ToArray());
            }
            else
            {
                ExpenseForm.Cob1.Items.Clear();
                ExpenseForm.Cob1.Items.AddRange(descriptionLst.ToArray());
            }
        }

        private void FlowToFromComboBox(string description)
        {
            var flowToFormLst = _addNewDataService.FlowToFromComboBox(description);
            if (flowToFormLst is null) return;

            if (label1.Text == "From :")
            {
                IncomeForm.Cob2.Items.Clear();
                IncomeForm.Cob2.Items.AddRange(flowToFormLst.ToArray());
            }
            else
            {
                ExpenseForm.Cob2.Items.Clear();
                ExpenseForm.Cob2.Items.AddRange(flowToFormLst.ToArray());
            }
        }

        private void CashFlowComboBox(string description)
        {
            var cashFlowLst = _addNewDataService.CashFlowComboBox(description);
            if (cashFlowLst is null) return;

            if (label1.Text == "IncomeType :")
            {
                IncomeForm.Cob3.Items.Clear();
                IncomeForm.Cob3.Items.AddRange(cashFlowLst.ToArray());
            }
            else
            {
                ExpenseForm.Cob3.Items.Clear();
                ExpenseForm.Cob3.Items.AddRange(cashFlowLst.ToArray());
            }
        }
    }
}
