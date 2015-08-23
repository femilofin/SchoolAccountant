using System.ComponentModel;
using System.Windows.Forms;

namespace SchoolAccountant.Forms
{
    partial class PayFee
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
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblClass = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSession = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTerm = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tboBank = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkPrintReceipt = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rtboComment = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tboReceiptNo = new System.Windows.Forms.TextBox();
            this.tboAmount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tboChequeNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tboPaidBy = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(38, 35);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(34, 13);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "temp";
            // 
            // lblClass
            // 
            this.lblClass.AutoSize = true;
            this.lblClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClass.Location = new System.Drawing.Point(107, 75);
            this.lblClass.Name = "lblClass";
            this.lblClass.Size = new System.Drawing.Size(54, 13);
            this.lblClass.TabIndex = 1;
            this.lblClass.Text = "classtemp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Session";
            // 
            // cboSession
            // 
            this.cboSession.FormattingEnabled = true;
            this.cboSession.Location = new System.Drawing.Point(110, 117);
            this.cboSession.Name = "cboSession";
            this.cboSession.Size = new System.Drawing.Size(100, 21);
            this.cboSession.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(316, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Term";
            // 
            // cboTerm
            // 
            this.cboTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTerm.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboTerm.FormattingEnabled = true;
            this.cboTerm.Location = new System.Drawing.Point(364, 117);
            this.cboTerm.Name = "cboTerm";
            this.cboTerm.Size = new System.Drawing.Size(100, 21);
            this.cboTerm.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 26);
            this.label5.TabIndex = 2;
            this.label5.Text = "Amount\r\n(Naira)";
            // 
            // tboBank
            // 
            this.tboBank.Location = new System.Drawing.Point(94, 30);
            this.tboBank.Name = "tboBank";
            this.tboBank.Size = new System.Drawing.Size(304, 20);
            this.tboBank.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 488);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Comment";
            // 
            // chkPrintReceipt
            // 
            this.chkPrintReceipt.AutoSize = true;
            this.chkPrintReceipt.Location = new System.Drawing.Point(319, 169);
            this.chkPrintReceipt.Name = "chkPrintReceipt";
            this.chkPrintReceipt.Size = new System.Drawing.Size(82, 17);
            this.chkPrintReceipt.TabIndex = 3;
            this.chkPrintReceipt.Text = "Print receipt";
            this.chkPrintReceipt.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Class";
            // 
            // rtboComment
            // 
            this.rtboComment.Location = new System.Drawing.Point(110, 485);
            this.rtboComment.Name = "rtboComment";
            this.rtboComment.Size = new System.Drawing.Size(355, 96);
            this.rtboComment.TabIndex = 4;
            this.rtboComment.Text = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(236, 617);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Bank";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tboReceiptNo);
            this.groupBox1.Controls.Add(this.tboBank);
            this.groupBox1.Location = new System.Drawing.Point(41, 261);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 100);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bank Payment";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Receipt No";
            // 
            // tboReceiptNo
            // 
            this.tboReceiptNo.Location = new System.Drawing.Point(94, 64);
            this.tboReceiptNo.Name = "tboReceiptNo";
            this.tboReceiptNo.Size = new System.Drawing.Size(304, 20);
            this.tboReceiptNo.TabIndex = 2;
            // 
            // tboAmount
            // 
            this.tboAmount.Location = new System.Drawing.Point(110, 167);
            this.tboAmount.Name = "tboAmount";
            this.tboAmount.Size = new System.Drawing.Size(100, 20);
            this.tboAmount.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tboChequeNo);
            this.groupBox2.Location = new System.Drawing.Point(41, 383);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 74);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cheque";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(61, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Cheque No";
            // 
            // tboChequeNo
            // 
            this.tboChequeNo.Location = new System.Drawing.Point(94, 31);
            this.tboChequeNo.Name = "tboChequeNo";
            this.tboChequeNo.Size = new System.Drawing.Size(304, 20);
            this.tboChequeNo.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Paid By";
            // 
            // tboPaidBy
            // 
            this.tboPaidBy.Location = new System.Drawing.Point(110, 211);
            this.tboPaidBy.Name = "tboPaidBy";
            this.tboPaidBy.Size = new System.Drawing.Size(354, 20);
            this.tboPaidBy.TabIndex = 8;
            // 
            // PayFee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 702);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tboPaidBy);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tboAmount);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.chkPrintReceipt);
            this.Controls.Add(this.rtboComment);
            this.Controls.Add(this.cboTerm);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboSession);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblClass);
            this.Controls.Add(this.lblFullName);
            this.Name = "PayFee";
            this.Text = "Pay Fee";
            this.Load += new System.EventHandler(this.PayFee_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblFullName;
        private Label lblClass;
        private Label label3;
        private ComboBox cboSession;
        private Label label4;
        private ComboBox cboTerm;
        private Label label5;
        private TextBox tboBank;
        private Label label6;
        private CheckBox chkPrintReceipt;
        private Label label1;
        private RichTextBox rtboComment;
        private Button btnSubmit;
        private Label label2;
        private GroupBox groupBox1;
        private Label label7;
        private TextBox tboReceiptNo;
        private TextBox tboAmount;
        private GroupBox groupBox2;
        private Label label9;
        private TextBox tboChequeNo;
        private Label label8;
        private TextBox tboPaidBy;
    }
}