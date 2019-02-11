using System.Web;
using System.Web.Optimization;

namespace HrDashboard
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new StyleBundle("~/Css")
                .Include("~/Content/bower_components/bootstrap/dist/css/bootstrap.min.css")
                .Include("~/Content/dist/css/AdminLTE.min.css")
                .Include("~/Content/dist/css/skins/_all-skins.min.css")
                .Include("~/Content/typeahead.css")
                .Include("~/Content/datatables/css/datatables.bootstrap.min.css")
                .Include("~/Content/bower_components/bootstrap-datepicker/dist/css/bootstrap-datepicker.min.css")
                .Include("~/Content/plugins/iCheck/square/blue.css")
                .Include("~/Content/bower_components/font-awesome/css/font-awesome.min.css")
                .Include("~/Content/bower_components/Ionicons/css/ionicons.min.css")
                .Include("~/Content/toastr.min.css")
                );

            bundles.Add(new ScriptBundle("~/Js")
                .Include("~/Content/bower_components/jquery/dist/jquery.min.js")
                .Include("~/Scripts/typeahead.bundle.min.js")
                .Include("~/Scripts/typeahead.jquery.min.js")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Content/bower_components/bootstrap/dist/js/bootstrap.min.js")
                .Include("~/Content/bower_components/fastclick/lib/fastclick.js")
                .Include("~/Content/dist/js/adminlte.min.js")
                .Include("~/Content/dist/js/demo.js")
                .Include("~/Scripts/DataTables/jquery.datatables.min.js")
                .Include("~/Scripts/DataTables/datatables.bootstrap.min.js")
                .Include("~/Scripts/bootbox.min.js")
                .Include("~/Scripts/toastr.min.js")
                .Include("~/Scripts/Chart.min.js")
                .Include("~/Scripts/DataTables/dataRender/datatime.js")
                .Include("~/Content/bower_components/jquery-slimscroll/jquery.slimscroll.min.js")
                .Include("~/Content/plugins/input-mask/jquery.inputmask.js")
                .Include("~/Content/plugins/input-mask/jquery.inputmask.date.extensions.js")
                .Include("~/Content/plugins/input-mask/jquery.inputmask.extensions.js")
                .Include("~/Content/bower_components/bootstrap-datepicker/dist/js/bootstrap-datepicker.min.js")
                .Include("~/Scripts/moment.min.js")
                .Include("~/Scripts/ui-bootstrap.min.js")
                .Include("~/Content/jsPDF/dist/jspdf.min.js")
                );
            BundleTable.EnableOptimizations = false;
        }
    }
}
