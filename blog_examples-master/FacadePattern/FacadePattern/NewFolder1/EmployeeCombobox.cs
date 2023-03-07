using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    /// <summary>
    /// Custom control
    /// </summary>
    public partial class EmployeeCombobox : System.Windows.Forms.ComboBox
    {
        /// <summary>
        /// Allow add null row or not
        /// </summary>
        public bool HasNull { get; set; }

        /// <summary>
        /// Facade method
        /// </summary>
        public void FillData()
        {
            //Select data
            this.SelectData();

            //Add null row
            this.AddNewRow();

            //Change language
            this.ChangeLanguage();
        }

        /// <summary>
        /// Select data from database
        /// and set to DataSource
        /// </summary>
        private void SelectData()
        {
            EmployeeService employeeService = new EmployeeService();
            base.DataSource = employeeService.SelectData();
        }

        /// <summary>
        /// Display value based on language
        /// </summary>
        private void ChangeLanguage()
        {
            base.ValueMember = "ID";
            switch (UserSession.Language)
            {
                case "en":
                    base.DisplayMember = "NameEN";
                    break;
                case "vi":
                    base.DisplayMember = "NameVN";
                    break;
                default:
                    base.DisplayMember = "NameEN";
                    break;
            }
        }

        /// <summary>
        /// Add null row
        /// </summary>
        private void AddNewRow()
        {
            if (this.HasNull)
            {
                DataRow row = ((DataTable)this.DataSource).NewRow();
                ((DataTable)this.DataSource).Rows.InsertAt(row, 0);
            }
        }
    }
}
