using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalFinanceManager
{
    public partial class frm_home : Form
    {
        private reporting rpt;
        public frm_home()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.KeyDown += frm_home_KeyDown;
            rdo_yearly.CheckedChanged += rdo_CheckedChangeClearControls;
            rdo_monthly.CheckedChanged += rdo_CheckedChangeClearControls;
        }

        private void frm_home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void balanceRefresh()
        {
            DB.sql = "EXEC LoadBalance;";
            DataTable dt = DB.GetDataTable();
            if (dt.Rows.Count > 0)
            {
                decimal amount = Convert.ToDecimal(dt.Rows[0]["amount"].ToString());
                lbl_balance.Text = amount.ToString("0.00") + " -MMK";
            }
        }
        private void frm_home_Load(object sender, EventArgs e)
        {
            lbl_name.Text = Program.name;
            rdo_yearly.Checked = true;
            balanceRefresh();

        }

        private void btn_Income_Click(object sender, EventArgs e)
        {
            frm_income income = new frm_income(this);
            income.ShowDialog();
        }
        private void btn_expense_Click(object sender, EventArgs e)
        {
            frm_expense expense = new frm_expense(this);
            expense.ShowDialog();
        }

        private void btn_refersh_Click(object sender, EventArgs e)
        {
            balanceRefresh();
        }

        private void frm_home_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                e.SuppressKeyPress = true;
                btn_refersh.PerformClick();
                e.Handled = true;
            }
        }

        private void btn_budget_Click(object sender, EventArgs e)
        {
            frm_budget budget = new frm_budget(this);
            budget.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_saving saving = new frm_saving(this);
            saving.ShowDialog();
        }

        private void rdo_CheckedChangeClearControls(object sender, EventArgs e)
        {
            dgv_report.DataSource = null;
            pnl_chart.Controls.Clear();
            cbo_title.SelectedItem = null;
            cbo_function.SelectedItem = null;
        }
        int condition;
        private void cbo_function_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbo_title.SelectedItem = null;
            cbo_title.Items.Clear();
            dgv_report.DataSource = null;
            pnl_chart.Controls.Clear();
            switch (cbo_function.SelectedIndex)
            {
                case 0://Income
                    cbo_title.Items.AddRange(new string[] { "Income Type", "Income Source", "Payment" });
                    condition = rdo_yearly.Checked ? 1 : 2;
                    break;
                case 1://Expense
                    cbo_title.Items.AddRange(new string[] { "Expense Type", "Expense Destination", "Payment" });
                    condition = rdo_yearly.Checked ? 3 : 4;
                    break;
                case 2://Budget
                    cbo_title.Items.AddRange(new string[] { "Overall", "Budget Exceed Expense" });
                    condition = rdo_yearly.Checked ? 5 : 6;
                    break;
                case 3://Saving
                    condition = rdo_yearly.Checked ? 7 : 8;
                    break;

                case 4://Withdrawal                   
                    condition = rdo_yearly.Checked ? 9 : 10;
                    break;

            }
            if (condition == 7 || condition == 8 || condition ==9 || condition ==10)
            {
                cbo_title.Items.AddRange(new string[] { "Overall","By User" } );
            }
        }

        private void cbo_title_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_report.DataSource = null;
            switch (condition)
            {
                case 1:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = "EXEC GetIncomeTypeAverageByYearly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 1:
                            DB.sql = "EXEC GetIncomeSourceAverageByYearly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 2:
                            DB.sql = "EXEC GetPaymentMethodAverageByYearly";
                            reporting.GetLineChart(pnl_chart);
                            break;                  
                    }
                    break;

                case 2:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = "EXEC GetIncomeTypeAverageByMonthly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 1:
                            DB.sql = "EXEC GetIncomeSourceAverageByMonthly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 2:
                            DB.sql = "EXEC GetPaymentMethodAverageByMonthly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                    }break;
                case 3:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = "EXEC GetExpenseTypeAverageByYearly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 1:
                            DB.sql = "EXEC GetExpenseDestinationAverageByYearly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 2:
                            DB.sql = "EXEC GetExpensePaymentMethodAverageByYearly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                    }break;
                case 4:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = "EXEC GetExpenseTypeAverageByMonthly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 1:
                            DB.sql = "EXEC GetExpenseDestinationAverageByMonthly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                        case 2:
                            DB.sql = "EXEC GetExpensePaymentMethodAverageByMonthly";
                            reporting.GetLineChart(pnl_chart);
                            break;
                    }break;
                case 5:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql =null;
                            MessageBox.Show("Not availabe currently.It might be coming soon!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            DB.sql = "EXEC GetExceedingBudgetMonthsByYearly";
                            reporting.GetBarChart(pnl_chart);
                            break;
                    }break;
                case 6:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = null;
                            MessageBox.Show("Not availabe currently.It might be coming soon!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        case 1:
                            DB.sql = "EXEC GetCurrentYearExceedingBudgetMonths";
                            reporting.GetBarChartMonth(pnl_chart);
                            break;
                    }break;
                case 7:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = null;
                            break;
                        case 1:
                            DB.sql = null;
                            break;
                    }break;    
                case 8:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = null;
                            break;
                        case 1:
                            DB.sql = null;
                            break;
                    }break;
                case 9:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = null;
                            break;
                        case 1:
                            DB.sql = null;
                            break;
                    }break; 
                case 10:
                    switch(cbo_title.SelectedIndex)
                    {
                        case 0:
                            DB.sql = null;
                            break;
                        case 1:
                            DB.sql = null;
                            break;
                    }break;

            }           
            DataTable dt = reporting.dataTable;
            dgv_report.DataSource= dt;
        }
    }
}
