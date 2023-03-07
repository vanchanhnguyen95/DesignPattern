using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacadePattern
{
    public partial class Screen1 : Form
    {
        public Screen1()
        {
            InitializeComponent();

            UserSession.Language = "vi";
            
            this.Load += Screen1_Load;
        }

        void Screen1_Load(object sender, EventArgs e)
        {
            //Init properties
            this.cboEmployee.HasNull = true;

            //Invoke facade method
            this.cboEmployee.FillData();
        }
    }
}
