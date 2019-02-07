using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using HrDashboard.ModelInitialize;
using CrystalDecisions.Shared;
using HrDashboard.Reports;

namespace HrDashboard.Controllers
{
    [CustomAuthorize]
    public class HomeController : Controller
    {
        private HRContext context;
        public HomeController()
        {
            context = new HRContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }
        
        public ActionResult Index()
        {
            return View();
        }

        ConnectionInfo connectInfo = new ConnectionInfo()
        {
            ServerName = "192.168.1.18",
            DatabaseName = "HRDatabase",
            UserID = "sa",
            Password = "p@ssw0rd"
        };
        
        public ActionResult ExportReport()
        {
            CrystalReport1 rd = new CrystalReport1();
            rd.Load(Path.Combine(Server.MapPath("~/Reports/CrystalReport1.rpt")));
            rd.SetDatabaseLogon("sa", "p@ssw0rd");
            rd.SetDataSource(context.Positions.ToList());
            foreach (Table tbl in rd.Database.Tables)
            {
                tbl.LogOnInfo.ConnectionInfo = connectInfo;
                tbl.ApplyLogOnInfo(tbl.LogOnInfo);
            }

            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            ExportOptions CrExportOptions;
            PdfRtfWordFormatOptions pdfFormatOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = "D:\\";
            CrExportOptions = rd.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = pdfFormatOptions;
            }

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();

            Stream str = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            str.Seek(0, SeekOrigin.Begin);
            string savedFileName = string.Format("CrystalReport1_{0}", DateTime.Now);
            return File(str, "application/pdf", savedFileName);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult LogbookIndex()
        { return View(); }
    }
}