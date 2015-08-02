namespace SchoolAccountant.Forms
{
    partial class DashBoard
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslTableStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslShowAll = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.dgvViewStudent = new System.Windows.Forms.DataGridView();
            this.label19 = new System.Windows.Forms.Label();
            this.tboSearchMS = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboFeeStatusMS = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cboArmMS = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cboClassMS = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tboOutstandingFeeAS = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cboPresentArmAS = new System.Windows.Forms.ComboBox();
            this.dtpBirthDateAS = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboPresentTermAS = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboPresentClassAS = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClearTextBoxes = new System.Windows.Forms.Button();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tboMiddleNameAS = new System.Windows.Forms.TextBox();
            this.dtpStartDateAS = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tboLastNameAS = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboStartClassAS = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboStartTermAS = new System.Windows.Forms.ComboBox();
            this.tboFirstNameAS = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tboPasswordAU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tboUsernameAU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboFullNameAU = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudent)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(663, 638);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnRefresh);
            this.tabPage3.Controls.Add(this.statusStrip1);
            this.tabPage3.Controls.Add(this.btnPrint);
            this.tabPage3.Controls.Add(this.dgvViewStudent);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.tboSearchMS);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this.cboFeeStatusMS);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this.cboArmMS);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.cboClassMS);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(655, 612);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Manage Students";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(251, 549);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslTableStatus,
            this.tsslShowAll});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(655, 22);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslTableStatus
            // 
            this.tsslTableStatus.Name = "tsslTableStatus";
            this.tsslTableStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // tsslShowAll
            // 
            this.tsslShowAll.IsLink = true;
            this.tsslShowAll.Name = "tsslShowAll";
            this.tsslShowAll.Size = new System.Drawing.Size(53, 17);
            this.tsslShowAll.Text = "Show All";
            this.tsslShowAll.Click += new System.EventHandler(this.tsslShowAll_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(388, 549);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // dgvViewStudent
            // 
            this.dgvViewStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvViewStudent.Location = new System.Drawing.Point(11, 31);
            this.dgvViewStudent.Name = "dgvViewStudent";
            this.dgvViewStudent.Size = new System.Drawing.Size(635, 501);
            this.dgvViewStudent.TabIndex = 8;
            this.dgvViewStudent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvViewStudent_CellContentClick);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(385, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(41, 13);
            this.label19.TabIndex = 7;
            this.label19.Text = "Search";
            // 
            // tboSearchMS
            // 
            this.tboSearchMS.Location = new System.Drawing.Point(434, 4);
            this.tboSearchMS.Name = "tboSearchMS";
            this.tboSearchMS.Size = new System.Drawing.Size(212, 20);
            this.tboSearchMS.TabIndex = 6;
            this.tboSearchMS.TextChanged += new System.EventHandler(this.tboSearchMS_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(217, 8);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Fee Status";
            // 
            // cboFeeStatusMS
            // 
            this.cboFeeStatusMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFeeStatusMS.FormattingEnabled = true;
            this.cboFeeStatusMS.Location = new System.Drawing.Point(284, 4);
            this.cboFeeStatusMS.Name = "cboFeeStatusMS";
            this.cboFeeStatusMS.Size = new System.Drawing.Size(95, 21);
            this.cboFeeStatusMS.TabIndex = 4;
            this.cboFeeStatusMS.SelectedIndexChanged += new System.EventHandler(this.cboFeeStatusMS_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(116, 8);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Arm";
            // 
            // cboArmMS
            // 
            this.cboArmMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboArmMS.FormattingEnabled = true;
            this.cboArmMS.Location = new System.Drawing.Point(150, 4);
            this.cboArmMS.Name = "cboArmMS";
            this.cboArmMS.Size = new System.Drawing.Size(58, 21);
            this.cboArmMS.TabIndex = 2;
            this.cboArmMS.SelectedIndexChanged += new System.EventHandler(this.cboArmMS_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 8);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Class";
            // 
            // cboClassMS
            // 
            this.cboClassMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClassMS.FormattingEnabled = true;
            this.cboClassMS.Location = new System.Drawing.Point(49, 4);
            this.cboClassMS.Name = "cboClassMS";
            this.cboClassMS.Size = new System.Drawing.Size(58, 21);
            this.cboClassMS.TabIndex = 0;
            this.cboClassMS.SelectedIndexChanged += new System.EventHandler(this.cboClassMS_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tboOutstandingFeeAS);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cboPresentArmAS);
            this.tabPage1.Controls.Add(this.dtpBirthDateAS);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cboPresentTermAS);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cboPresentClassAS);
            this.tabPage1.Controls.Add(this.label14);
            this.tabPage1.Controls.Add(this.btnClearTextBoxes);
            this.tabPage1.Controls.Add(this.btnAddStudent);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tboMiddleNameAS);
            this.tabPage1.Controls.Add(this.dtpStartDateAS);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tboLastNameAS);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.cboStartClassAS);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cboStartTermAS);
            this.tabPage1.Controls.Add(this.tboFirstNameAS);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 612);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Student";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tboOutstandingFeeAS
            // 
            this.tboOutstandingFeeAS.Location = new System.Drawing.Point(460, 153);
            this.tboOutstandingFeeAS.Name = "tboOutstandingFeeAS";
            this.tboOutstandingFeeAS.Size = new System.Drawing.Size(159, 20);
            this.tboOutstandingFeeAS.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(460, 124);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Outstanding Fee";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(460, 255);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(64, 13);
            this.label20.TabIndex = 20;
            this.label20.Text = "Present Arm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Date of Birth";
            // 
            // cboPresentArmAS
            // 
            this.cboPresentArmAS.DropDownHeight = 120;
            this.cboPresentArmAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresentArmAS.DropDownWidth = 78;
            this.cboPresentArmAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPresentArmAS.FormattingEnabled = true;
            this.cboPresentArmAS.IntegralHeight = false;
            this.cboPresentArmAS.ItemHeight = 13;
            this.cboPresentArmAS.Location = new System.Drawing.Point(460, 284);
            this.cboPresentArmAS.Name = "cboPresentArmAS";
            this.cboPresentArmAS.Size = new System.Drawing.Size(157, 21);
            this.cboPresentArmAS.TabIndex = 19;
            // 
            // dtpBirthDateAS
            // 
            this.dtpBirthDateAS.Location = new System.Drawing.Point(29, 153);
            this.dtpBirthDateAS.Name = "dtpBirthDateAS";
            this.dtpBirthDateAS.Size = new System.Drawing.Size(158, 20);
            this.dtpBirthDateAS.TabIndex = 21;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(245, 255);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(70, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Present Term";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Last Name";
            // 
            // cboPresentTermAS
            // 
            this.cboPresentTermAS.DropDownHeight = 120;
            this.cboPresentTermAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresentTermAS.DropDownWidth = 78;
            this.cboPresentTermAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPresentTermAS.FormattingEnabled = true;
            this.cboPresentTermAS.IntegralHeight = false;
            this.cboPresentTermAS.ItemHeight = 13;
            this.cboPresentTermAS.Location = new System.Drawing.Point(245, 284);
            this.cboPresentTermAS.Name = "cboPresentTermAS";
            this.cboPresentTermAS.Size = new System.Drawing.Size(156, 21);
            this.cboPresentTermAS.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "First Name";
            // 
            // cboPresentClassAS
            // 
            this.cboPresentClassAS.DropDownHeight = 120;
            this.cboPresentClassAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresentClassAS.DropDownWidth = 78;
            this.cboPresentClassAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboPresentClassAS.FormattingEnabled = true;
            this.cboPresentClassAS.IntegralHeight = false;
            this.cboPresentClassAS.ItemHeight = 13;
            this.cboPresentClassAS.Location = new System.Drawing.Point(29, 284);
            this.cboPresentClassAS.Name = "cboPresentClassAS";
            this.cboPresentClassAS.Size = new System.Drawing.Size(158, 21);
            this.cboPresentClassAS.TabIndex = 15;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 255);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Present Class";
            // 
            // btnClearTextBoxes
            // 
            this.btnClearTextBoxes.Location = new System.Drawing.Point(541, 8);
            this.btnClearTextBoxes.Name = "btnClearTextBoxes";
            this.btnClearTextBoxes.Size = new System.Drawing.Size(78, 23);
            this.btnClearTextBoxes.TabIndex = 16;
            this.btnClearTextBoxes.Text = "Reset";
            this.btnClearTextBoxes.UseVisualStyleBackColor = true;
            this.btnClearTextBoxes.Click += new System.EventHandler(this.btnClearTextBoxes_Click);
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(274, 357);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(98, 23);
            this.btnAddStudent.TabIndex = 10;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(245, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Start Date";
            // 
            // tboMiddleNameAS
            // 
            this.tboMiddleNameAS.Location = new System.Drawing.Point(460, 88);
            this.tboMiddleNameAS.Name = "tboMiddleNameAS";
            this.tboMiddleNameAS.Size = new System.Drawing.Size(159, 20);
            this.tboMiddleNameAS.TabIndex = 3;
            // 
            // dtpStartDateAS
            // 
            this.dtpStartDateAS.Location = new System.Drawing.Point(245, 153);
            this.dtpStartDateAS.Name = "dtpStartDateAS";
            this.dtpStartDateAS.Size = new System.Drawing.Size(158, 20);
            this.dtpStartDateAS.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Middle Name";
            // 
            // tboLastNameAS
            // 
            this.tboLastNameAS.Location = new System.Drawing.Point(245, 88);
            this.tboLastNameAS.Name = "tboLastNameAS";
            this.tboLastNameAS.Size = new System.Drawing.Size(159, 20);
            this.tboLastNameAS.TabIndex = 2;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 189);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Start Term";
            // 
            // cboStartClassAS
            // 
            this.cboStartClassAS.DropDownHeight = 120;
            this.cboStartClassAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartClassAS.DropDownWidth = 78;
            this.cboStartClassAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStartClassAS.FormattingEnabled = true;
            this.cboStartClassAS.IntegralHeight = false;
            this.cboStartClassAS.ItemHeight = 13;
            this.cboStartClassAS.Location = new System.Drawing.Point(29, 218);
            this.cboStartClassAS.Name = "cboStartClassAS";
            this.cboStartClassAS.Size = new System.Drawing.Size(159, 21);
            this.cboStartClassAS.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Start Class";
            // 
            // cboStartTermAS
            // 
            this.cboStartTermAS.DropDownHeight = 120;
            this.cboStartTermAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartTermAS.DropDownWidth = 78;
            this.cboStartTermAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStartTermAS.FormattingEnabled = true;
            this.cboStartTermAS.IntegralHeight = false;
            this.cboStartTermAS.ItemHeight = 13;
            this.cboStartTermAS.Location = new System.Drawing.Point(245, 218);
            this.cboStartTermAS.Name = "cboStartTermAS";
            this.cboStartTermAS.Size = new System.Drawing.Size(158, 21);
            this.cboStartTermAS.TabIndex = 8;
            // 
            // tboFirstNameAS
            // 
            this.tboFirstNameAS.Location = new System.Drawing.Point(29, 88);
            this.tboFirstNameAS.Name = "tboFirstNameAS";
            this.tboFirstNameAS.Size = new System.Drawing.Size(159, 20);
            this.tboFirstNameAS.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAddUser);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tboPasswordAU);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.tboUsernameAU);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.tboFullNameAU);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(655, 612);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add User";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(128, 164);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 4;
            this.btnAddUser.Text = "Add User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Password";
            // 
            // tboPasswordAU
            // 
            this.tboPasswordAU.Location = new System.Drawing.Point(128, 118);
            this.tboPasswordAU.Name = "tboPasswordAU";
            this.tboPasswordAU.PasswordChar = '*';
            this.tboPasswordAU.Size = new System.Drawing.Size(163, 20);
            this.tboPasswordAU.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Username";
            // 
            // tboUsernameAU
            // 
            this.tboUsernameAU.Location = new System.Drawing.Point(128, 79);
            this.tboUsernameAU.Name = "tboUsernameAU";
            this.tboUsernameAU.Size = new System.Drawing.Size(163, 20);
            this.tboUsernameAU.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Full Name";
            // 
            // tboFullNameAU
            // 
            this.tboFullNameAU.Location = new System.Drawing.Point(128, 42);
            this.tboFullNameAU.Name = "tboFullNameAU";
            this.tboFullNameAU.Size = new System.Drawing.Size(163, 20);
            this.tboFullNameAU.TabIndex = 1;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 639);
            this.Controls.Add(this.tabControl1);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.Load += new System.EventHandler(this.DashBoard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvViewStudent)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboPasswordAU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboUsernameAU;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tboFullNameAU;
        private System.Windows.Forms.TextBox tboMiddleNameAS;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tboLastNameAS;
        private System.Windows.Forms.TextBox tboFirstNameAS;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboStartTermAS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboStartClassAS;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.Button btnClearTextBoxes;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpStartDateAS;
        private System.Windows.Forms.DataGridView dgvViewStudent;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tboSearchMS;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboFeeStatusMS;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox cboArmMS;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cboClassMS;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslTableStatus;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpBirthDateAS;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cboPresentArmAS;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboPresentTermAS;
        private System.Windows.Forms.ComboBox cboPresentClassAS;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tboOutstandingFeeAS;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripStatusLabel tsslShowAll;
        private System.Windows.Forms.Button btnRefresh;
    }
}