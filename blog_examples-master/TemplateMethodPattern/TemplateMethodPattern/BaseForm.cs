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
    public enum Mode
    {
        View,
        Add,
        Edit,
    }

    public partial class BaseForm : Form
    {
        public Mode Mode { get; set; }

        public BaseForm()
        {
            InitializeComponent();

            this.Load += BaseForm_Load;
        }

        /// <summary>
        /// Form_Load event
        /// </summary>
        void BaseForm_Load(object sender, EventArgs e)
        {
            //invoke template method
            this.FormLoad();
        }

        /// <summary>
        /// Template method
        /// </summary>
        public void FormLoad()
        {
            this.InitControl();
            this.SetControl();
            this.SetAuthority();
            this.SetData();
        }

        /// <summary>
        /// Init control
        /// </summary>
        public virtual void InitControl() 
        {
            this.AcceptButton = this.btnSave;
            this.CancelButton = this.btnClose;

            this.btnSave.Click += btnSave_Click;
            this.btnClose.Click += btnClose_Click;
        }

        /// <summary>
        /// Set control's status
        /// </summary>
        public virtual void SetControl() { }

        /// <summary>
        /// Set data to control
        /// </summary>
        public virtual void SetData() { }

        /// <summary>
        /// Check authority and set button's status
        /// </summary>
        public virtual void SetAuthority()
        {
            this.btnSave.Enabled = HasAuthority("Search");
        }

        /// <summary>
        /// Check authoriry
        /// </summary>
        private bool HasAuthority(string authority)
        {
            return true;
        }

        /// <summary>
        /// btnSave_Click event
        /// </summary>
        void btnSave_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Save!");
        }

        void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

    }
}
