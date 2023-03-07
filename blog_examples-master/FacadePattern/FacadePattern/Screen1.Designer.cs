namespace FacadePattern
{
    partial class Screen1
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
            this.cboEmployee = new FacadePattern.EmployeeCombobox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboEmployee
            // 
            this.cboEmployee.FormattingEnabled = true;
            this.cboEmployee.HasNull = false;
            this.cboEmployee.Location = new System.Drawing.Point(104, 24);
            this.cboEmployee.Name = "cboEmployee";
            this.cboEmployee.Size = new System.Drawing.Size(150, 21);
            this.cboEmployee.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Enployee";
            // 
            // Screen1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 73);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboEmployee);
            this.Name = "Screen1";
            this.Text = "Screen1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EmployeeCombobox cboEmployee;
        private System.Windows.Forms.Label label1;
    }
}