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
            this.tboSchoolName.Size = new System.Drawing.Size(400, 20);
            this.tboSchoolName.TabIndex = 3;
            // 
            // cboPresentSession
            // 
            this.cboPresentSession.FormattingEnabled = true;
            this.cboPresentSession.Location = new System.Drawing.Point(41, 129);
            this.cboPresentSession.Name = "cboPresentSession";
            this.cboPresentSession.Size = new System.Drawing.Size(140, 21);
            this.cboPresentSession.TabIndex = 4;
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
            this.cboPresentTerm.FormattingEnabled = true;
            this.cboPresentTerm.Location = new System.Drawing.Point(41, 200);
            this.cboPresentTerm.Name = "cboPresentTerm";
            this.cboPresentTerm.Size = new System.Drawing.Size(140, 21);
            this.cboPresentTerm.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(280, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date Started";
            // 
            // dtpSessionDateStarted
            // 
            this.dtpSessionDateStarted.Location = new System.Drawing.Point(283, 130);
            this.dtpSessionDateStarted.Name = "dtpSessionDateStarted";
            this.dtpSessionDateStarted.Size = new System.Drawing.Size(158, 20);
            this.dtpSessionDateStarted.TabIndex = 9;
            // 
            // dtpTermDateStarted
            // 
            this.dtpTermDateStarted.Location = new System.Drawing.Point(283, 201);
            this.dtpTermDateStarted.Name = "dtpTermDateStarted";
            this.dtpTermDateStarted.Size = new System.Drawing.Size(158, 20);
            this.dtpTermDateStarted.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Date Started";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(198, 266);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SchoolSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 323);
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
    }
}