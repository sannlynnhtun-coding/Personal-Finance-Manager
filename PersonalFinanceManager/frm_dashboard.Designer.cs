namespace PersonalFinanceManager
{
    partial class frm_dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_dashboard));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbx_function = new System.Windows.Forms.GroupBox();
            this.btnSaving = new System.Windows.Forms.Button();
            this.btnBudget = new System.Windows.Forms.Button();
            this.btnExpense = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_refersh = new System.Windows.Forms.Button();
            this.lbl_balance = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdo_monthly = new System.Windows.Forms.RadioButton();
            this.rdo_yearly = new System.Windows.Forms.RadioButton();
            this.cbo_title = new System.Windows.Forms.ComboBox();
            this.cbo_function = new System.Windows.Forms.ComboBox();
            this.dgv_report = new System.Windows.Forms.DataGridView();
            this.pnl_chart = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.gbx_function.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_report)).BeginInit();
            this.pnlBody.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pnlTopBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_function
            // 
            this.gbx_function.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(67)))), ((int)(((byte)(220)))));
            this.gbx_function.Controls.Add(this.btnSaving);
            this.gbx_function.Controls.Add(this.btnBudget);
            this.gbx_function.Controls.Add(this.btnExpense);
            this.gbx_function.Controls.Add(this.btnIncome);
            this.gbx_function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbx_function.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gbx_function.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.gbx_function.ForeColor = System.Drawing.Color.White;
            this.gbx_function.Location = new System.Drawing.Point(10, 10);
            this.gbx_function.Margin = new System.Windows.Forms.Padding(4);
            this.gbx_function.Name = "gbx_function";
            this.gbx_function.Padding = new System.Windows.Forms.Padding(4);
            this.gbx_function.Size = new System.Drawing.Size(479, 912);
            this.gbx_function.TabIndex = 1;
            this.gbx_function.TabStop = false;
            this.gbx_function.Text = "Functions";
            // 
            // btnSaving
            // 
            this.btnSaving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(121)))), ((int)(((byte)(240)))));
            this.btnSaving.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaving.ForeColor = System.Drawing.Color.White;
            this.btnSaving.Image = global::PersonalFinanceManager.Properties.Resources.saving;
            this.btnSaving.Location = new System.Drawing.Point(239, 227);
            this.btnSaving.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaving.Name = "btnSaving";
            this.btnSaving.Size = new System.Drawing.Size(175, 157);
            this.btnSaving.TabIndex = 4;
            this.btnSaving.Text = "Saving";
            this.btnSaving.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSaving.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSaving.UseVisualStyleBackColor = false;
            this.btnSaving.Click += new System.EventHandler(this.OnFunctionClick);
            // 
            // btnBudget
            // 
            this.btnBudget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(121)))), ((int)(((byte)(240)))));
            this.btnBudget.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBudget.ForeColor = System.Drawing.Color.White;
            this.btnBudget.Image = global::PersonalFinanceManager.Properties.Resources.budget;
            this.btnBudget.Location = new System.Drawing.Point(56, 261);
            this.btnBudget.Margin = new System.Windows.Forms.Padding(4);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Size = new System.Drawing.Size(175, 123);
            this.btnBudget.TabIndex = 3;
            this.btnBudget.Text = "Budget";
            this.btnBudget.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnBudget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBudget.UseVisualStyleBackColor = false;
            this.btnBudget.Click += new System.EventHandler(this.OnFunctionClick);
            // 
            // btnExpense
            // 
            this.btnExpense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(121)))), ((int)(((byte)(240)))));
            this.btnExpense.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpense.ForeColor = System.Drawing.Color.White;
            this.btnExpense.Image = ((System.Drawing.Image)(resources.GetObject("btnExpense.Image")));
            this.btnExpense.Location = new System.Drawing.Point(239, 78);
            this.btnExpense.Margin = new System.Windows.Forms.Padding(4);
            this.btnExpense.Name = "btnExpense";
            this.btnExpense.Size = new System.Drawing.Size(175, 141);
            this.btnExpense.TabIndex = 2;
            this.btnExpense.Text = "Expense";
            this.btnExpense.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExpense.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnExpense.UseVisualStyleBackColor = false;
            this.btnExpense.Click += new System.EventHandler(this.OnFunctionClick);
            // 
            // btnIncome
            // 
            this.btnIncome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(121)))), ((int)(((byte)(240)))));
            this.btnIncome.Font = new System.Drawing.Font("Nirmala UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIncome.ForeColor = System.Drawing.Color.White;
            this.btnIncome.Image = ((System.Drawing.Image)(resources.GetObject("btnIncome.Image")));
            this.btnIncome.Location = new System.Drawing.Point(56, 78);
            this.btnIncome.Margin = new System.Windows.Forms.Padding(4);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(175, 175);
            this.btnIncome.TabIndex = 1;
            this.btnIncome.Text = "Income";
            this.btnIncome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnIncome.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnIncome.UseVisualStyleBackColor = false;
            this.btnIncome.Click += new System.EventHandler(this.OnFunctionClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btn_refersh);
            this.groupBox1.Controls.Add(this.lbl_balance);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Location = new System.Drawing.Point(23, 133);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(597, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btn_refersh
            // 
            this.btn_refersh.BackColor = System.Drawing.Color.White;
            this.btn_refersh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_refersh.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_refersh.Image = global::PersonalFinanceManager.Properties.Resources.icons8_refresh_20;
            this.btn_refersh.Location = new System.Drawing.Point(549, 12);
            this.btn_refersh.Margin = new System.Windows.Forms.Padding(4);
            this.btn_refersh.Name = "btn_refersh";
            this.btn_refersh.Size = new System.Drawing.Size(40, 32);
            this.btn_refersh.TabIndex = 0;
            this.btn_refersh.TabStop = false;
            this.btn_refersh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_refersh.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_refersh.UseVisualStyleBackColor = false;
            this.btn_refersh.Click += new System.EventHandler(this.btn_refersh_Click);
            // 
            // lbl_balance
            // 
            this.lbl_balance.AutoSize = true;
            this.lbl_balance.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_balance.Location = new System.Drawing.Point(211, 39);
            this.lbl_balance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_balance.Name = "lbl_balance";
            this.lbl_balance.Size = new System.Drawing.Size(0, 29);
            this.lbl_balance.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(58)))), ((int)(((byte)(183)))));
            this.label2.Location = new System.Drawing.Point(35, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "BALANCE :";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.rdo_monthly);
            this.groupBox2.Controls.Add(this.rdo_yearly);
            this.groupBox2.Controls.Add(this.cbo_title);
            this.groupBox2.Controls.Add(this.cbo_function);
            this.groupBox2.Font = new System.Drawing.Font("Nirmala UI", 15F);
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(23, 261);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(597, 190);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Report";
            // 
            // rdo_monthly
            // 
            this.rdo_monthly.AutoSize = true;
            this.rdo_monthly.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.rdo_monthly.ForeColor = System.Drawing.Color.Black;
            this.rdo_monthly.Location = new System.Drawing.Point(128, 47);
            this.rdo_monthly.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_monthly.Name = "rdo_monthly";
            this.rdo_monthly.Size = new System.Drawing.Size(94, 27);
            this.rdo_monthly.TabIndex = 6;
            this.rdo_monthly.TabStop = true;
            this.rdo_monthly.Text = "Monthly";
            this.rdo_monthly.UseVisualStyleBackColor = true;
            // 
            // rdo_yearly
            // 
            this.rdo_yearly.AutoSize = true;
            this.rdo_yearly.Font = new System.Drawing.Font("Nirmala UI", 10F);
            this.rdo_yearly.ForeColor = System.Drawing.Color.Black;
            this.rdo_yearly.Location = new System.Drawing.Point(29, 47);
            this.rdo_yearly.Margin = new System.Windows.Forms.Padding(4);
            this.rdo_yearly.Name = "rdo_yearly";
            this.rdo_yearly.Size = new System.Drawing.Size(75, 27);
            this.rdo_yearly.TabIndex = 5;
            this.rdo_yearly.TabStop = true;
            this.rdo_yearly.Text = "Yearly";
            this.rdo_yearly.UseVisualStyleBackColor = true;
            // 
            // cbo_title
            // 
            this.cbo_title.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_title.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_title.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_title.FormattingEnabled = true;
            this.cbo_title.Location = new System.Drawing.Point(296, 103);
            this.cbo_title.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_title.Name = "cbo_title";
            this.cbo_title.Size = new System.Drawing.Size(215, 28);
            this.cbo_title.TabIndex = 8;
            this.cbo_title.SelectedIndexChanged += new System.EventHandler(this.cbo_title_SelectedIndexChanged);
            // 
            // cbo_function
            // 
            this.cbo_function.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbo_function.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbo_function.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbo_function.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbo_function.FormattingEnabled = true;
            this.cbo_function.Items.AddRange(new object[] {
            "Income",
            "Expense",
            "Budget",
            "Saving",
            "Withdrawal"});
            this.cbo_function.Location = new System.Drawing.Point(52, 103);
            this.cbo_function.Margin = new System.Windows.Forms.Padding(4);
            this.cbo_function.Name = "cbo_function";
            this.cbo_function.Size = new System.Drawing.Size(215, 28);
            this.cbo_function.TabIndex = 7;
            this.cbo_function.SelectedIndexChanged += new System.EventHandler(this.cbo_function_SelectedIndexChanged);
            // 
            // dgv_report
            // 
            this.dgv_report.AllowUserToAddRows = false;
            this.dgv_report.AllowUserToDeleteRows = false;
            this.dgv_report.AllowUserToResizeColumns = false;
            this.dgv_report.AllowUserToResizeRows = false;
            this.dgv_report.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_report.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgv_report.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgv_report.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_report.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_report.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_report.EnableHeadersVisualStyles = false;
            this.dgv_report.GridColor = System.Drawing.Color.Gray;
            this.dgv_report.Location = new System.Drawing.Point(23, 478);
            this.dgv_report.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_report.Name = "dgv_report";
            this.dgv_report.ReadOnly = true;
            this.dgv_report.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_report.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_report.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_report.Size = new System.Drawing.Size(597, 154);
            this.dgv_report.TabIndex = 0;
            this.dgv_report.TabStop = false;
            // 
            // pnl_chart
            // 
            this.pnl_chart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnl_chart.BackColor = System.Drawing.Color.White;
            this.pnl_chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnl_chart.Location = new System.Drawing.Point(670, 133);
            this.pnl_chart.Margin = new System.Windows.Forms.Padding(4);
            this.pnl_chart.Name = "pnl_chart";
            this.pnl_chart.Size = new System.Drawing.Size(631, 499);
            this.pnl_chart.TabIndex = 0;
            // 
            // pnlBody
            // 
            this.pnlBody.Controls.Add(this.panel2);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(499, 0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Size = new System.Drawing.Size(1314, 932);
            this.pnlBody.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pnlTopBar);
            this.panel2.Controls.Add(this.pnl_chart);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.dgv_report);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1314, 932);
            this.panel2.TabIndex = 0;
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.Controls.Add(this.panel3);
            this.pnlTopBar.Controls.Add(this.label3);
            this.pnlTopBar.Controls.Add(this.button1);
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Location = new System.Drawing.Point(0, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            this.pnlTopBar.Padding = new System.Windows.Forms.Padding(0, 10, 10, 10);
            this.pnlTopBar.Size = new System.Drawing.Size(1314, 65);
            this.pnlTopBar.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Location = new System.Drawing.Point(1226, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(3, 45);
            this.label3.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(1229, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 45);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(67)))), ((int)(((byte)(220)))));
            this.panel1.Controls.Add(this.gbx_function);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(499, 932);
            this.panel1.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_name);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(945, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(281, 45);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 8F);
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(281, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_name
            // 
            this.lbl_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_name.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold);
            this.lbl_name.Location = new System.Drawing.Point(0, 18);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(281, 27);
            this.lbl_name.TabIndex = 2;
            this.lbl_name.Text = "User Name";
            this.lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frm_dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1813, 932);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1813, 932);
            this.Name = "frm_dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frm_home_FormClosed);
            this.Load += new System.EventHandler(this.frm_home_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_home_KeyDown);
            this.gbx_function.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_report)).EndInit();
            this.pnlBody.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_function;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Button btnExpense;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_balance;
        private System.Windows.Forms.Button btn_refersh;
        private System.Windows.Forms.Button btnBudget;
        private System.Windows.Forms.Button btnSaving;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbo_function;
        private System.Windows.Forms.ComboBox cbo_title;
        private System.Windows.Forms.DataGridView dgv_report;
        private System.Windows.Forms.Panel pnl_chart;
        private System.Windows.Forms.RadioButton rdo_monthly;
        private System.Windows.Forms.RadioButton rdo_yearly;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label label1;
    }
}