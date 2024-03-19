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

namespace housewife
{
    public partial class frm_addnewdata : Form
    {
        public frm_income IncomeForm { get; set; }
        public frm_expense ExpenseForm { get; set; }
        public frm_addnewdata()
        {
            InitializeComponent();
        }
        public string labelName 
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            keycontrol.KeyDownEnterNextButtonClick(sender, e,button1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                string nextsql;
                string data = textBox1.Text.ToString();
                DB.sql = "EXEC InsertDescription @name = '" + data + "';";
                if(label1.Text =="Income Title :" || label1.Text == "Expense Title :")
                {
                    nextsql  = "SELECT description FROM descriptions;";
                    SqlDataReader dr = DB.InsertTitles(nextsql);
                    if (dr != null)
                    {
                        if (label1.Text == "Income Title :")
                        {
                            IncomeForm.Cob1.Items.Clear();
                            while (dr.Read())
                            {
                                IncomeForm.Cob1.Items.Add(dr["description"].ToString());
                            }
                        }
                        else
                        {
                            ExpenseForm.Cob1.Items.Clear();
                            while (dr.Read())
                            {
                                ExpenseForm.Cob1.Items.Add((string)dr["description"].ToString());
                            }
                        }

                    }
                }              
                else if (label1.Text == "From :" || label1.Text =="To :")
                {
                    nextsql = "SELECT text FROM from_to_flow;";
                    DB.sql = "EXEC InsertFromToFlow @name = '" + data + "';";
                    SqlDataReader dr = DB.InsertTitles(nextsql);
                    if (dr != null)
                    {
                        if(label1.Text =="From :")
                        {
                            IncomeForm.Cob2.Items.Clear();
                            while(dr.Read())
                            {
                                IncomeForm.Cob2.Items.Add(dr["text"].ToString());
                            }
                        }
                        else
                        {
                            while (dr.Read())
                            {
                                ExpenseForm.Cob2.Items.Clear();
                                while(dr.Read())
                                {
                                    ExpenseForm.Cob2.Items.Add(dr["text"].ToString());
                                }
                            }
                        }
                       
                    }
                }
                else if (label1.Text == "IncomeType :" || label1.Text == "Payment :")
                {
                    nextsql = "SELECT text FROM cash_flow;";
                    DB.sql = "EXEC InsertCashFlow @name = '" + data + "';";
                    SqlDataReader dr = DB.InsertTitles(nextsql);
                    if (dr != null)
                    {
                        if(label1.Text == "IncomeType :")
                        {
                            IncomeForm.Cob3.Items.Clear();
                            while (dr.Read())
                            {
                                IncomeForm.Cob3.Items.Add(dr["text"].ToString());
                            }
                        }
                        else
                        {
                            ExpenseForm.Cob3.Items.Clear();
                            while (dr.Read())
                            {
                                ExpenseForm.Cob3.Items.Add(dr["text"].ToString());
                            }
                        }
                        
                    }
                }
            }
            this.Close();          
        }
    }
}
