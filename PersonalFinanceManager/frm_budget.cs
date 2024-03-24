using PersonalFinanceManager.Dtos.Budget;
using PersonalFinanceManager.Query;
using PersonalFinanceManager.Services;
using PersonalFinanceManager.Services.Features.Budget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager
{
    public partial class frm_budget : Form
    {
        private frm_dashboard homeForm;
        private readonly BudgetService _budgetService;
        public frm_budget(frm_dashboard home)
        {
            homeForm = home;
            InitializeComponent();
            _budgetService = new BudgetService();
        }
        TextBox Txb;
        private void btn_addbudget_ClickV1(object sender, EventArgs e)
        {
            bool messageShown = validate.TextCheck(groupBox1);
            if (messageShown)
                return;

            dgv_budget.DataSource = null;
            DateTime Date = dtpk_budget.Value;
            string formattedDate = Date.ToString("yyyy-MM-dd");
            Decimal amount;
            if (Decimal.TryParse(txt_amount.Text, out amount))
            {
                amount = Decimal.Parse(txt_amount.Text);
            }
            else
            {
                MessageBox.Show("Please enter a valid decimal number.", "Invalid Fromat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int insertedId = -1;
            try
            {
                string message = "New budget added successfully!";
                DB.sql = "EXEC AddExpenditureBudget @month = '" + formattedDate + "',@amount = '" + amount + "',@insertedId = @insertedId OUTPUT";
                DB.DoInsert(message, out insertedId);
                if (insertedId != -1)
                {
                    DB.sql = "SELECT month, amount FROM expenditure_budgets WHERE id = " + insertedId;
                    DataTable dt = DB.GetDataTable();
                    dgv_budget.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_addbudget_Click(object sender, EventArgs e)
        {
            try
            {
                bool messageShown = validate.TextCheck(groupBox1);
                if (messageShown)
                    goto result;

                dgv_budget.DataSource = null;
                string formattedDate = dtpk_budget.Value.ToString("yyyy-MM-dd");
                decimal amount;
                if (!decimal.TryParse(txt_amount.Text, out amount))
                {
                    MessageBox.Show("Please enter a valid decimal number.", "Invalid Fromat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto result;
                }
                amount = txt_amount.Text.ToInt32();
                var result = AddExpenditureBudget(formattedDate, amount);
                if (result.Id == -1) goto result;
                GetBudgetLst(result.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        result:
            return;
        }

        private AddExpenditureBudgetModel AddExpenditureBudget(string formattedDate, decimal amount)
        {
            var result = _budgetService.AddExpenditureBudget(formattedDate, amount);
            return result;
        }

        private void GetBudgetLst(int result)
        {
            string message = "New budget added successfully!";
            MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            var budgetLst = _budgetService.GetExpenditureBudget(result);
            dgv_budget.DataSource = budgetLst;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnl_search.Controls.Clear();
            dgv_budget.DataSource = null;
            TextBox txb = new TextBox();
            pnl_search.Controls.Add(txb);
            Txb = txb;
            txb.KeyPress -= keycontrol.AllowOnlyLetters;
            txb.KeyPress -= keycontrol.AllowOnlyNumbers;
            if (comboBox1.SelectedIndex == 0)
            {
                txb.KeyPress += keycontrol.AllowOnlyNumbers;
            };
            if (comboBox1.SelectedIndex == 1)
            {
                txb.KeyPress += keycontrol.AllowOnlyLetters;
            };
            txb.TextChanged += Txb_TextChanged;
        }
        private void Txb_TextChanged(Object sender, EventArgs e)
        {
            dgv_budget.DataSource = comboBox1.SelectedIndex == 0 ?
                GetBudgetByYear() : GetBudgetByMonthOfCurrentYear();
        }

        private List<BudgetReportModel> GetBudgetByMonthOfCurrentYear()
        {
            var budgetLst = new List<BudgetReportModel>();
            if (!string.IsNullOrEmpty(Txb.Text))
            {
                budgetLst = _budgetService.GetBudgetByMonthOfCurrentYear(Txb.Text.Trim());
                //month = Txb.Text.Trim();
                //DB.sql = "EXEC GetBudgetByMonthOfCurrentYear @monthName = " + month;
            }
            return budgetLst;
        }

        private List<BudgetReportModel> GetBudgetByYear()
        {
            var budgetLst = new List<BudgetReportModel>();
            int year;
            if (int.TryParse(Txb.Text, out year))
            {
                budgetLst = _budgetService.GetBudgetByYear(year.ToString());
                //string yearpattern = year.ToString();
                //DB.sql = "EXEC GetBudgetByYear @yearPattern = " + yearpattern;
            }
            return budgetLst;
        }

        private void frm_budget_Load(object sender, EventArgs e)
        {
            //dgv_budget.DataSource = null;
            //DB.sql = "EXEC LoadAllBudgets";
            //DataTable dt = DB.GetDataTable();
            //dgv_budget.DataSource = dt;
            dgv_budget.DataSource = _budgetService.LoadAllBudgets();
        }

        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            keycontrol.KeyDownEnterNextButtonClick(sender, e, btn_addbudget);
        }
    }
}
