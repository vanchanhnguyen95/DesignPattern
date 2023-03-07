using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;

namespace FacadePattern
{
    public class EmployeeService
    {
        public System.Data.DataTable SelectData()
        {
            DataTable dtResult = new DataTable();
            using (FacadePatternEntities context = new FacadePatternEntities())
            {
                dtResult = context.Employees
                    .Select(emp => new
                    {
                        emp.ID,
                        emp.NameEN,
                        emp.NameVN,
                    })
                    .ToDataTable();
            }
            return dtResult;
        }
    }
}
