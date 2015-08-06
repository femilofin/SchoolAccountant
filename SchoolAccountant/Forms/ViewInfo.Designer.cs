using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolAccountant.Forms
{
    partial class ViewInfo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblClasStarted = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblFeesPaid = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblTermStarted = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblPresentClass = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.lblPresentSession = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.tboFirstName = new System.Windows.Forms.TextBox();
            this.tboLastName = new System.Windows.Forms.TextBox();
            this.tboMiddleName = new System.Windows.Forms.TextBox();
            this.dtpBirthDate = new System.Windows.Forms.DateTimePicker();
            this.dtpDateStarted = new System.Windows.Forms.DateTimePicker();
            this.lblOutstandingFees = new System.Windows.Forms.Label();
            this.cboPresentArm = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Middle Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Class Started";
            // 
            // lblClasStarted
            // 
            this.lblClasStarted.AutoSize = true;
            this.lblClasStarted.Location = new System.Drawing.Point(142, 115);
            this.lblClasStarted.Name = "lblClasStarted";
            this.lblClasStarted.Size = new System.Drawing.Size(35, 13);
            this.lblClasStarted.TabIndex = 9;
            this.lblClasStarted.Text = "label6";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 8;
            // 
            // lblFeesPaid
            // 
            this.lblFeesPaid.AutoSize = true;
            this.lblFeesPaid.Location = new System.Drawing.Point(142, 234);
            this.lblFeesPaid.Name = "lblFeesPaid";
            this.lblFeesPaid.Size = new System.Drawing.Size(35, 13);
            this.lblFeesPaid.TabIndex = 11;
            this.lblFeesPaid.Text = "label5";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 234);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "Fees Paid";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(332, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Last Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(330, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 13);
            this.label13.TabIndex = 2;
            this.label13.Text = "Date of Birth";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(332, 234);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 6;
            this.label15.Text = "Outstanding Fee";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(332, 115);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(68, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "Term Started";
            // 
            // lblTermStarted
            // 
            this.lblTermStarted.AutoSize = true;
            this.lblTermStarted.Location = new System.Drawing.Point(437, 115);
            this.lblTermStarted.Name = "lblTermStarted";
            this.lblTermStarted.Size = new System.Drawing.Size(35, 13);
            this.lblTermStarted.TabIndex = 9;
            this.lblTermStarted.Text = "label6";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(38, 193);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 13);
            this.label19.TabIndex = 10;
            this.label19.Text = "Present Class";
            // 
            // lblPresentClass
            // 
            this.lblPresentClass.AutoSize = true;
            this.lblPresentClass.Location = new System.Drawing.Point(143, 193);
            this.lblPresentClass.Name = "lblPresentClass";
            this.lblPresentClass.Size = new System.Drawing.Size(35, 13);
            this.lblPresentClass.TabIndex = 11;
            this.lblPresentClass.Text = "label5";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(218, 280);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(335, 280);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(38, 156);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(67, 13);
            this.label21.TabIndex = 6;
            this.label21.Text = "Date Started";
            // 
            // lblPresentSession
            // 
            this.lblPresentSession.AutoSize = true;
            this.lblPresentSession.Location = new System.Drawing.Point(437, 156);
            this.lblPresentSession.Name = "lblPresentSession";
            this.lblPresentSession.Size = new System.Drawing.Size(83, 13);
            this.lblPresentSession.TabIndex = 16;
            this.lblPresentSession.Text = "Present Session";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(332, 156);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(73, 13);
            this.label24.TabIndex = 14;
            this.label24.Text = "Session/Term";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(336, 193);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 13);
            this.label25.TabIndex = 15;
            this.label25.Text = "Present Arm";
            // 
            // tboFirstName
            // 
            this.tboFirstName.Location = new System.Drawing.Point(142, 27);
            this.tboFirstName.Name = "tboFirstName";
            this.tboFirstName.Size = new System.Drawing.Size(141, 20);
            this.tboFirstName.TabIndex = 18;
            // 
            // tboLastName
            // 
            this.tboLastName.Location = new System.Drawing.Point(437, 27);
            this.tboLastName.Name = "tboLastName";
            this.tboLastName.Size = new System.Drawing.Size(141, 20);
            this.tboLastName.TabIndex = 19;
            // 
            // tboMiddleName
            // 
            this.tboMiddleName.Location = new System.Drawing.Point(142, 71);
            this.tboMiddleName.Name = "tboMiddleName";
            this.tboMiddleName.Size = new System.Drawing.Size(141, 20);
            this.tboMiddleName.TabIndex = 20;
            // 
            // dtpBirthDate
            // 
            this.dtpBirthDate.Location = new System.Drawing.Point(437, 71);
            this.dtpBirthDate.Name = "dtpBirthDate";
            this.dtpBirthDate.Size = new System.Drawing.Size(141, 20);
            this.dtpBirthDate.TabIndex = 21;
            // 
            // dtpDateStarted
            // 
            this.dtpDateStarted.Location = new System.Drawing.Point(142, 152);
            this.dtpDateStarted.Name = "dtpDateStarted";
            this.dtpDateStarted.Size = new System.Drawing.Size(141, 20);
            this.dtpDateStarted.TabIndex = 22;
            // 
            // lblOutstandingFees
            // 
            this.lblOutstandingFees.AutoSize = true;
            this.lblOutstandingFees.Location = new System.Drawing.Point(437, 234);
            this.lblOutstandingFees.Name = "lblOutstandingFees";
            this.lblOutstandingFees.Size = new System.Drawing.Size(35, 13);
            this.lblOutstandingFees.TabIndex = 23;
            this.lblOutstandingFees.Text = "label2";
            // 
            // cboPresentArm
            // 
            this.cboPresentArm.FormattingEnabled = true;
            this.cboPresentArm.Location = new System.Drawing.Point(440, 189);
            this.cboPresentArm.Name = "cboPresentArm";
            this.cboPresentArm.Size = new System.Drawing.Size(141, 21);
            this.cboPresentArm.TabIndex = 24;
            // 
            // ViewInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 342);
            this.Controls.Add(this.cboPresentArm);
            this.Controls.Add(this.lblOutstandingFees);
            this.Controls.Add(this.dtpDateStarted);
            this.Controls.Add(this.dtpBirthDate);
            this.Controls.Add(this.tboMiddleName);
            this.Controls.Add(this.tboLastName);
            this.Controls.Add(this.tboFirstName);
            this.Controls.Add(this.lblPresentSession);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblPresentClass);
            this.Controls.Add(this.lblFeesPaid);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblTermStarted);
            this.Controls.Add(this.lblClasStarted);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label1);
            this.Name = "ViewInfo";
            this.Text = "View Student Info";
            this.Load += new System.EventHandler(this.ViewInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label4;
        private Label label8;
        private Label lblClasStarted;
        private Label label9;
        private Label lblFeesPaid;
        private Label label10;
        private Label label11;
        private Label label13;
        private Label label15;
        private Label label17;
        private Label lblTermStarted;
        private Label label19;
        private Label lblPresentClass;
        private Button btnEdit;
        private Button btnClose;
        private Label label21;
        private Label lblPresentSession;
        private Label label24;
        private Label label25;
        private TextBox tboFirstName;
        private TextBox tboLastName;
        private TextBox tboMiddleName;
        private DateTimePicker dtpBirthDate;
        private DateTimePicker dtpDateStarted;
        private Label lblOutstandingFees;
        private ComboBox cboPresentArm;
    }
}