namespace SchoolAccountant.Forms
{
    partial class SchoolSetup
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
            this.label4 = new System.Windows.Forms.Label();
            this.tboSchoolName = new System.Windows.Forms.TextBox();
            this.cboPresentSession = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboPresentTerm = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpSessionDateStarted = new System.Windows.Forms.DateTimePicker();
            this.dtpTermDateStarted = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.tboSss = new System.Windows.Forms.TextBox();
            this.tboJss = new System.Windows.Forms.TextBox();
            this.tboSss3 = new System.Windows.Forms.TextBox();
            this.tboJss3 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.tboSss2 = new System.Windows.Forms.TextBox();
            this.tboJss2 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.tboSss1 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tboJss1 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "School Name";
            // 
            // tboSchoolName
            // 
            this.tboSchoolName.Location = new System.Drawing.Point(41, 59);
            this.tboSchoolName.Name = "tboSchoolName";
            this.tboSchoolName.Size = new System.Drawing.Size(571, 20);
            this.tboSchoolName.TabIndex = 0;
            // 
            // cboPresentSession
            // 
            this.cboPresentSession.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresentSession.FormattingEnabled = true;
            this.cboPresentSession.Location = new System.Drawing.Point(41, 129);
            this.cboPresentSession.Name = "cboPresentSession";
            this.cboPresentSession.Size = new System.Drawing.Size(140, 21);
            this.cboPresentSession.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Present Session";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Present Term";
            // 
            // cboPresentTerm
            // 
            this.cboPresentTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPresentTerm.FormattingEnabled = true;
            this.cboPresentTerm.Location = new System.Drawing.Point(41, 200);
            this.cboPresentTerm.Name = "cboPresentTerm";
            this.cboPresentTerm.Size = new System.Drawing.Size(140, 21);
            this.cboPresentTerm.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Start Date";
            // 
            // dtpSessionDateStarted
            // 
            this.dtpSessionDateStarted.Location = new System.Drawing.Point(256, 129);
            this.dtpSessionDateStarted.Name = "dtpSessionDateStarted";
            this.dtpSessionDateStarted.Size = new System.Drawing.Size(158, 20);
            this.dtpSessionDateStarted.TabIndex = 2;
            // 
            // dtpTermDateStarted
            // 
            this.dtpTermDateStarted.Location = new System.Drawing.Point(256, 200);
            this.dtpTermDateStarted.Name = "dtpTermDateStarted";
            this.dtpTermDateStarted.Size = new System.Drawing.Size(158, 20);
            this.dtpTermDateStarted.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(253, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Start Date";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(283, 603);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label29);
            this.groupBox2.Controls.Add(this.label28);
            this.groupBox2.Controls.Add(this.tboSss);
            this.groupBox2.Controls.Add(this.tboJss);
            this.groupBox2.Location = new System.Drawing.Point(41, 436);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(571, 124);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "New Intakes";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(212, 34);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(61, 13);
            this.label29.TabIndex = 10;
            this.label29.Text = "SSS (NGN)";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(22, 34);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(59, 13);
            this.label28.TabIndex = 10;
            this.label28.Text = "JSS (NGN)";
            // 
            // tboSss
            // 
            this.tboSss.Location = new System.Drawing.Point(215, 60);
            this.tboSss.Name = "tboSss";
            this.tboSss.Size = new System.Drawing.Size(135, 20);
            this.tboSss.TabIndex = 13;
            // 
            // tboJss
            // 
            this.tboJss.Location = new System.Drawing.Point(25, 60);
            this.tboJss.Name = "tboJss";
            this.tboJss.Size = new System.Drawing.Size(135, 20);
            this.tboJss.TabIndex = 12;
            // 
            // tboSss3
            // 
            this.tboSss3.Location = new System.Drawing.Point(446, 376);
            this.tboSss3.Name = "tboSss3";
            this.tboSss3.Size = new System.Drawing.Size(135, 20);
            this.tboSss3.TabIndex = 10;
            // 
            // tboJss3
            // 
            this.tboJss3.Location = new System.Drawing.Point(446, 302);
            this.tboJss3.Name = "tboJss3";
            this.tboJss3.Size = new System.Drawing.Size(135, 20);
            this.tboJss3.TabIndex = 7;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(443, 351);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(70, 13);
            this.label27.TabIndex = 12;
            this.label27.Text = "SSS 3 (NGN)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(443, 277);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(68, 13);
            this.label24.TabIndex = 13;
            this.label24.Text = "JSS 3 (NGN)";
            // 
            // tboSss2
            // 
            this.tboSss2.Location = new System.Drawing.Point(256, 376);
            this.tboSss2.Name = "tboSss2";
            this.tboSss2.Size = new System.Drawing.Size(135, 20);
            this.tboSss2.TabIndex = 9;
            // 
            // tboJss2
            // 
            this.tboJss2.Location = new System.Drawing.Point(256, 302);
            this.tboJss2.Name = "tboJss2";
            this.tboJss2.Size = new System.Drawing.Size(135, 20);
            this.tboJss2.TabIndex = 6;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(253, 351);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(73, 13);
            this.label26.TabIndex = 15;
            this.label26.Text = "SSS  2 (NGN)";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(253, 276);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(68, 13);
            this.label23.TabIndex = 16;
            this.label23.Text = "JSS 2 (NGN)";
            // 
            // tboSss1
            // 
            this.tboSss1.Location = new System.Drawing.Point(66, 376);
            this.tboSss1.Name = "tboSss1";
            this.tboSss1.Size = new System.Drawing.Size(135, 20);
            this.tboSss1.TabIndex = 8;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(63, 351);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(70, 13);
            this.label25.TabIndex = 17;
            this.label25.Text = "SSS 1 (NGN)";
            // 
            // tboJss1
            // 
            this.tboJss1.Location = new System.Drawing.Point(66, 302);
            this.tboJss1.Name = "tboJss1";
            this.tboJss1.Size = new System.Drawing.Size(135, 20);
            this.tboJss1.TabIndex = 5;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(63, 276);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(68, 13);
            this.label22.TabIndex = 18;
            this.label22.Text = "JSS 1 (NGN)";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(41, 248);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(571, 182);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add School Fees";
            // 
            // SchoolSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 673);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tboSss3);
            this.Controls.Add(this.tboJss3);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.tboSss2);
            this.Controls.Add(this.tboJss2);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.tboSss1);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.tboJss1);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpTermDateStarted);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpSessionDateStarted);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboPresentTerm);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPresentSession);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tboSchoolName);
            this.Name = "SchoolSetup";
            this.Text = "School Setup";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tboSchoolName;
        private System.Windows.Forms.ComboBox cboPresentSession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboPresentTerm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpSessionDateStarted;
        private System.Windows.Forms.DateTimePicker dtpTermDateStarted;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox tboSss;
        private System.Windows.Forms.TextBox tboJss;
        private System.Windows.Forms.TextBox tboSss3;
        private System.Windows.Forms.TextBox tboJss3;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox tboSss2;
        private System.Windows.Forms.TextBox tboJss2;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox tboSss1;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox tboJss1;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}