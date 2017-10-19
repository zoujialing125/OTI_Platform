using System.Web;
using System.Web.Optimization;

namespace OTI_Booking_Platform
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/Bootstrap-Toggle/bootstrap-toggle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/Site.css",
                      "~/Content/bootstrap.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                      "~/Content/DataTables/css/select.bootstrap.min.css",
                      "~/Content/Bootstrap-Toggle/bootstrap-toggle.min.css"));

            bundles.Add(new StyleBundle("~/Theme-Sidebar/css").Include(
                      "~/Theme-Sidebar/css/AdminLTE.min.css",
                      "~/Theme-Sidebar/css/skins/_all-skins.min.css",
                      "~/Theme-Sidebar/plugins/Ionicons/css/ionicons.min.css",
                      "~/Theme-Sidebar/plugins/font-awesome/css/font-awesome.min.css"));

            bundles.Add(new ScriptBundle("~/Theme-Sidebar/js").Include(
                      "~/Theme-Sidebar/js/adminlte.min.js",
                      "~/Scripts/site-script.js"));

            bundles.Add(new ScriptBundle("~/DataTables/js").Include(
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                       "~/Scripts/DataTables/dataTables.select.min.js"));
        }
    }
}
