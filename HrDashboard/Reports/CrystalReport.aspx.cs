using HrDashboard.ModelInitialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HrDashboard.Reports
{
    public partial class CrystalReport : System.Web.UI.Page
    {
        private HRContext context = new HRContext();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.ToolPanelView = CrystalDecisions.Web.ToolPanelViewType.None;
            CrystalReport1 crystalReport = new CrystalReport1();
            crystalReport.SetDataSource(context.Positions.ToList());
            CrystalReportViewer1.ReportSource = crystalReport;
            CrystalReportViewer1.RefreshReport();
        }
    }
}