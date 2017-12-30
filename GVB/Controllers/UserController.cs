using GVB.Models;
using GVB.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using OfficeOpenXml.Core.ExcelPackage;

namespace GVB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        public Employee myEmployee = new GVB.Models.Employee();

        public Employee GetEmployee()
        {
            if (User.Identity.IsAuthenticated)
            {
                string myEmail = User.Identity.Name;
                myEmployee = db.Employee.SqlQuery(
                            "SELECT * " +
                            "From Employee " +
                            "where Employee.EmpEmail = '" + myEmail + "'"
                            ).FirstOrDefault();
                if (myEmployee == null)
                {
                    myEmployee.EmployeeID = 2;
                    return myEmployee;
                }
                else
                {
                    return myEmployee;
                }
            }
            else
            {
                myEmployee.EmployeeID = 2;
                return myEmployee;
            }
        }

        public ActionResult ChooseFeedlot()
        {
            var feedlot = db.Feedlot;
           
            return View(feedlot.ToList());
        }


        public ActionResult Admin()
        {
            return View();
        }


        public ActionResult Advanced()
        {
            return View();
        }


        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult ClearData()
        {
            return View();
        }
    
        public ActionResult ExportData()
        {
            SqlConnection Con = new SqlConnection();
            string Path = ConfigurationManager.ConnectionStrings["GVBDBContext"].ConnectionString;
            Con.ConnectionString = Path;
            DataTable DtNew = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("Select * From Deceased", Con);
            Adp.Fill(DtNew);

            if (DtNew.Rows.Count > 0)
            {
                string FilePath = Server.MapPath("~/Content/ExcelExportfile.xlsx");
                FileInfo Files = new FileInfo(FilePath);
                ExcelPackage excel = new ExcelPackage(Files);
                var sheetcreate =  excel.Workbook.Worksheets.Add("DeceasedData");
                for (int i = 0; i < DtNew.Columns.Count; i++)
                {
                    sheetcreate.Cell(1, i + 1).Value = DtNew.Columns[i].ColumnName.ToString();
                }
                for (int i = 0; i < DtNew.Rows.Count; i++)
                {
                    for (int j = 0; j < DtNew.Columns.Count; j++)
                    {
                        sheetcreate.Cell(i + 2, j + 1).Value = DtNew.Rows[i][j].ToString();
                    }
                }
                excel.Save();
            }

            return View();
        }
    }
}