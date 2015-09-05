using System.ComponentModel;

namespace SchoolAccountant.Forms
{
    partial class FeeHistory
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
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvFeeHistory = new System.Windows.Forms.DataGridView();
            this.lblStudentName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeHistory)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(279, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // dgvFeeHistory
            // 
            this.dgvFeeHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeeHistory.Location = new System.Drawing.Point(0, 41);
            this.dgvFeeHistory.Name = "dgvFeeHistory";
            this.dgvFeeHistory.Size = new System.Drawing.Size(611, 421);
            this.dgvFeeHistory.TabIndex = 1;
            this.dgvFeeHistory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFeeHistory_CellContentClick);
            // 
            // lblStudentName
            // 
            this.lblStudentName.AutoSize = true;
            this.lblStudentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentName.Location = new System.Drawing.Point(12, 13);
            this.lblStudentName.Name = "lblStudentName";
            this.lblStudentName.Size = new System.Drawing.Size(41, 13);
            this.lblStudentName.TabIndex = 2;
            this.lblStudentName.Text = "label1";
            // 
            // FeeHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 521);
            this.Controls.Add(this.lblStudentName);
            this.Controls.Add(this.dgvFeeHistory);
            this.Controls.Add(this.btnClose);
            this.Name = "FeeHistory";
            this.Text = "FeeHistory";
            this.Load += new System.EventHandler(this.FeeHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeHistory)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvFeeHistory;
        private System.Windows.Forms.Label lblStudentName;
    }
}