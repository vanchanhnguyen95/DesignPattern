using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemplateMethodPattern
{
    public partial class ConcreteForm1 : BaseForm
    {
        public ConcreteForm1()
        {
            InitializeComponent();

            base.Mode = TemplateMethodPattern.Mode.Add;
        }

        /// <summary>
        /// Implement BaseForm's InitControl method
        /// </summary>
        public override void InitControl()
        {
            this.txtEmpVN.TabIndex = 1;
            this.txtEmpEN.TabIndex = 2;

            this.txtEmpVN.Focus();
        }

        /// <summary>
        /// Implement BaseForm's SetControl method
        /// </summary>
        public override void SetControl()
        {
            if (base.Mode == TemplateMethodPattern.Mode.View)
            {
                this.txtEmpEN.Enabled = false;
                this.txtEmpVN.Enabled = false;
            }
            else
            {
                this.txtEmpEN.Enabled = true;
                this.txtEmpVN.Enabled = true;
            }
        }

        /// <summary>
        /// Implement BaseForm's SetData method
        /// </summary>
        public override void SetData()
        {
            if (base.Mode == TemplateMethodPattern.Mode.Add)
            {
                this.txtEmpVN.Text = string.Empty;
                this.txtEmpEN.Text = string.Empty;
            }
            else
            {
                this.txtEmpVN.Text = "kien.chu";
                this.txtEmpEN.Text = "ken";
            }
        }

    }
}
