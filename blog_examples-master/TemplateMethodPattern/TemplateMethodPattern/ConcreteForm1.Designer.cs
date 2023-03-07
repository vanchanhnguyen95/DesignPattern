namespace TemplateMethodPattern
{
    partial class ConcreteForm1
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
            this.txtEmpVN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmpEN = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEmpEN);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEmpVN);
            this.groupBox1.Size = new System.Drawing.Size(351, 165);
            // 
            // txtEmpVN
            // 
            this.txtEmpVN.Location = new System.Drawing.Point(144, 31);
            this.txtEmpVN.Name = "txtEmpVN";
            this.txtEmpVN.Size = new System.Drawing.Size(184, 20);
            this.txtEmpVN.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee Name (VN)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Employee Name (EN)";
            // 
            // txtEmpEN
            // 
            this.txtEmpEN.Location = new System.Drawing.Point(144, 57);
            this.txtEmpEN.Name = "txtEmpEN";
            this.txtEmpEN.Size = new System.Drawing.Size(184, 20);
            this.txtEmpEN.TabIndex = 2;
            // 
            // ConcreteForm1
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(351, 165);
            this.Name = "ConcreteForm1";
            this.Text = "ConcreteForm1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtEmpVN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmpEN;
        private System.Windows.Forms.Label label1;
    }
}