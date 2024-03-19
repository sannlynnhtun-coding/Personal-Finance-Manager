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

namespace housewife
{
    public partial class frm_budget : Form
    {
        private frm_home homeForm;
        public frm_budget(frm_home home)
        {
            homeForm = home;
            InitializeComponent();
        }
        TextBox Txb;
        private void btn_addbudget_Click(object sender, EventArgs e)
        {
            bool messageShown = validate.TextCheck(groupBox1);
            if (messageShown)
                return;

            dgv_budget.DataSource = null;
            DateTime Date = dtpk_budget.Value;
            string formattedDate = Date.ToString("yyyy-MM-dd");
            Decimal amount;
            if(Decimal.TryParse(txt_amount.Text, out amount))
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
                DB.sql= "EXEC AddExpenditureBudget @month = '"+formattedDate+"',@amount = '"+amount+"',@insertedId = @insertedId OUTPUT";
                DB.DoInsert(message, out insertedId);
                if(insertedId !=-1)
                {
                    DB.sql = "SELECT month, amount FROM expenditure_budgets WHERE id = " + insertedId;
                    DataTable dt = DB.GetDataTable();
                    dgv_budget.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            dgv_budget.DataSource = null;
            if (comboBox1.SelectedIndex == 0)
            {
                int year;
                if (int.TryParse(Txb.Text, out year))
                {
                    string yearpattern = year.ToString();
                    DB.sql = "EXEC GetBudgetByYear @yearPattern = " + yearpattern;
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                string month;
                if (!string.IsNullOrEmpty(Txb.Text))
                {
                    month = Txb.Text.Trim();
                    DB.sql = "EXEC GetBudgetByMonthOfCurrentYear @monthName = " + month;
                }
            }
            DataTable dt = DB.GetDataTable();
            dgv_budget.DataSource = dt;
        }

        private void frm_budget_Load(object sender, EventArgs e)
        {
            dgv_budget.DataSource = null;
            DB.sql = "EXEC LoadAllBudgets";
            DataTable dt = DB.GetDataTable();
            dgv_budget.DataSource= dt;
        }

        private void txt_amount_KeyDown(object sender, KeyEventArgs e)
        {
            keycontrol.KeyDownEnterNextButtonClick(sender, e,btn_addbudget);
        }
    }
}
