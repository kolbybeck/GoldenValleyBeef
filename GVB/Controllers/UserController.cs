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
using OfficeOpenXml;

namespace GVB.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private GVBDBContext db = new GVBDBContext();

        public Employee myEmployee = new GVB.Models.Employee();
        public ExportDateRange Date = new GVB.Models.ExportDateRange();

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
                    myEmployee.EmployeeID = 3;
                    return myEmployee;
                }
                else
                {
                    return myEmployee;
                }
            }
            else
            {
                myEmployee.EmployeeID = 3;
                return myEmployee;
            }
        }

        [Authorize]
        public ActionResult ChooseFeedlot()
        {
            var feedlot = db.Feedlot;
           
            return View(feedlot.ToList());
        }

        [Authorize]
        public ActionResult Admin()
        {
            return View();
        }

        [Authorize]
        public ActionResult Reports()
        {
            return View();
        }

        [Authorize]
        public ActionResult ExportData()
        {

            Date = db.ExportDateRange.SqlQuery(
                                                "SELECT * " +
                                                "FROM ExportDateRange " +
                                                "WHERE ExportDateRange.ExportDateRangeID = (SELECT MAX(ExportDateRange.ExportDateRangeID)  AS DateRangeID " +
                                                                                            "FROM ExportDateRange)" 
                                                ).FirstOrDefault();
            
            DateTime dt = DateTime.Now;
            SqlConnection Con = new SqlConnection();
            string Path = ConfigurationManager.ConnectionStrings["GVBDBContext"].ConnectionString;
            Con.ConnectionString = Path;
            DataTable DtNew = new DataTable();
            SqlDataAdapter Adp = new SqlDataAdapter("SELECT Deceased.CattleNumber AS 'Cattle Number', " +
                                                    "Dairy.dName AS 'Dairy', Feedlot.fName AS 'Feedlot', " +
                                                    "Employee.EmpFname + ' ' + Employee.EmpLname AS 'Employee' , " +
                                                    "Deceased.DeceasedDate " +
                                                    "FROM Deceased INNER JOIN " +
                                                    "Dairy ON Deceased.DairyID = Dairy.DairyID INNER JOIN " +
                                                    "Feedlot ON Deceased.FeedlotID = Feedlot.FeedlotID INNER JOIN " +
                                                    "Employee ON Deceased.EmployeeID = Employee.EmployeeID " +
                                                    "WHERE Deceased.DeceasedDate BETWEEN '" + Date.StartDate + "' AND '" + Date.EndDate +
                                                    "' ORDER BY Deceased.DeceasedDate DESC", Con);
            Adp.Fill(DtNew);

            if (DtNew.Rows.Count > 0)
            {
                string FilePath = Server.MapPath("~/DeceasedCattle.xlsx");
                FileInfo Files = new FileInfo(FilePath);
                ExcelPackage excel = new ExcelPackage(Files);
                ExcelWorksheet ws =  excel.Workbook.Worksheets.Add("Deceased Cattle" + dt);
                for (int i = 0; i < DtNew.Columns.Count; i++)
                {
                    ws.Cells[1, i + 1].Value = DtNew.Columns[i].ColumnName.ToString();
                }
                for (int i = 0; i < DtNew.Rows.Count; i++)
                {
                    for (int j = 0; j < DtNew.Columns.Count; j++)
                    {
                        ws.Cells[i + 2, j + 1].Value = DtNew.Rows[i][j].ToString();
                    }
                }
                Response.Clear();
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment: filename=" + "DeceasedCattle.xlsx");
                Response.BinaryWrite(excel.GetAsByteArray());
                Response.End();
            }

            return View("Reports");
        }
    }
}