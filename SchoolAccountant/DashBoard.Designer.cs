namespace SchoolAccountant
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAddStudent = new System.Windows.Forms.Button();
            this.tboMiddleNameAS = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tboLastNameAS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboFirstNameAS = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboMonthAS = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cboYearAS = new System.Windows.Forms.ComboBox();
            this.cboDayAS = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cboStartClassAS = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpStartDateAS = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboStartTermAS = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tboPasswordAU = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tboUsernameAU = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tboFullNameAU = new System.Windows.Forms.TextBox();
            this.btnClearTextBoxes = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.tabControl1.Size = new System.Drawing.Size(663, 453);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClearTextBoxes);
            this.tabPage1.Controls.Add(this.btnAddStudent);
            this.tabPage1.Controls.Add(this.tboMiddleNameAS);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tboLastNameAS);
            this.tabPage1.Controls.Add(this.tboFirstNameAS);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(655, 427);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Add Student";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAddStudent
            // 
            this.btnAddStudent.Location = new System.Drawing.Point(273, 372);
            this.btnAddStudent.Name = "btnAddStudent";
            this.btnAddStudent.Size = new System.Drawing.Size(98, 23);
            this.btnAddStudent.TabIndex = 10;
            this.btnAddStudent.Text = "Add Student";
            this.btnAddStudent.UseVisualStyleBackColor = true;
            this.btnAddStudent.Click += new System.EventHandler(this.btnAddStudent_Click);
            // 
            // tboMiddleNameAS
            // 
            this.tboMiddleNameAS.Location = new System.Drawing.Point(460, 84);
            this.tboMiddleNameAS.Name = "tboMiddleNameAS";
            this.tboMiddleNameAS.Size = new System.Drawing.Size(159, 20);
            this.tboMiddleNameAS.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(458, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Middle Name";
            // 
            // tboLastNameAS
            // 
            this.tboLastNameAS.Location = new System.Drawing.Point(245, 84);
            this.tboLastNameAS.Name = "tboLastNameAS";
            this.tboLastNameAS.Size = new System.Drawing.Size(159, 20);
            this.tboLastNameAS.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(240, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Last Name";
            // 
            // tboFirstNameAS
            // 
            this.tboFirstNameAS.Location = new System.Drawing.Point(30, 84);
            this.tboFirstNameAS.Name = "tboFirstNameAS";
            this.tboFirstNameAS.Size = new System.Drawing.Size(159, 20);
            this.tboFirstNameAS.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(2, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(649, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Full Name";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboMonthAS);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.cboYearAS);
            this.groupBox2.Controls.Add(this.cboDayAS);
            this.groupBox2.Location = new System.Drawing.Point(3, 138);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(649, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Birth Date";
            // 
            // cboMonthAS
            // 
            this.cboMonthAS.DropDownHeight = 120;
            this.cboMonthAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMonthAS.DropDownWidth = 78;
            this.cboMonthAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboMonthAS.FormattingEnabled = true;
            this.cboMonthAS.IntegralHeight = false;
            this.cboMonthAS.ItemHeight = 13;
            this.cboMonthAS.Location = new System.Drawing.Point(242, 45);
            this.cboMonthAS.Name = "cboMonthAS";
            this.cboMonthAS.Size = new System.Drawing.Size(159, 21);
            this.cboMonthAS.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(239, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 6;
            this.label10.Text = "Month";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(26, 13);
            this.label9.TabIndex = 5;
            this.label9.Text = "Day";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(455, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Year";
            // 
            // cboYearAS
            // 
            this.cboYearAS.DropDownHeight = 150;
            this.cboYearAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboYearAS.FormattingEnabled = true;
            this.cboYearAS.IntegralHeight = false;
            this.cboYearAS.Location = new System.Drawing.Point(457, 45);
            this.cboYearAS.Name = "cboYearAS";
            this.cboYearAS.Size = new System.Drawing.Size(159, 21);
            this.cboYearAS.TabIndex = 6;
            // 
            // cboDayAS
            // 
            this.cboDayAS.DropDownHeight = 120;
            this.cboDayAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDayAS.DropDownWidth = 78;
            this.cboDayAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDayAS.FormattingEnabled = true;
            this.cboDayAS.IntegralHeight = false;
            this.cboDayAS.ItemHeight = 13;
            this.cboDayAS.Location = new System.Drawing.Point(27, 45);
            this.cboDayAS.Name = "cboDayAS";
            this.cboDayAS.Size = new System.Drawing.Size(159, 21);
            this.cboDayAS.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cboStartClassAS);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.dtpStartDateAS);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.cboStartTermAS);
            this.groupBox3.Location = new System.Drawing.Point(3, 238);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(649, 104);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Other Info";
            // 
            // cboStartClassAS
            // 
            this.cboStartClassAS.DisplayMember = "1";
            this.cboStartClassAS.DropDownHeight = 120;
            this.cboStartClassAS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStartClassAS.DropDownWidth = 78;
            this.cboStartClassAS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboStartClassAS.FormattingEnabled = true;
            this.cboStartClassAS.IntegralHeight = false;
            this.cboStartClassAS.ItemHeight = 13;
            this.cboStartClassAS.Location = new System.Drawing.Point(27, 55);
            this.cboStartClassAS.Name = "cboStartClassAS";
            this.cboStartClassAS.Size = new System.Drawing.Size(159, 21);
            this.cboStartClassAS.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Start Class";
            // 
            // dtpStartDateAS
            // 
            this.dtpStartDateAS.Location = new System.Drawing.Point(457, 55);
            this.dtpStartDateAS.Name = "dtpStartDateAS";
            this.dtpStartDateAS.Size = new System.Drawing.Size(159, 20);
            this.dtpStartDateAS.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(239, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Start Term";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(455, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "Start Date";
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
            this.cboStartTermAS.Location = new System.Drawing.Point(242, 55);
            this.cboStartTermAS.Name = "cboStartTermAS";
            this.cboStartTermAS.Size = new System.Drawing.Size(159, 21);
            this.cboStartTermAS.TabIndex = 8;
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
            this.tabPage2.Size = new System.Drawing.Size(655, 427);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "First Name";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(655, 427);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Manage Students";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // DashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 454);
            this.Controls.Add(this.tabControl1);
            this.Name = "DashBoard";
            this.Text = "DashBoard";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tboFirstNameAS;
        private System.Windows.Forms.ComboBox cboYearAS;
        private System.Windows.Forms.ComboBox cboDayAS;
        private System.Windows.Forms.ComboBox cboMonthAS;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpStartDateAS;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboStartTermAS;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboStartClassAS;
        private System.Windows.Forms.Button btnAddStudent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClearTextBoxes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;

    }
}