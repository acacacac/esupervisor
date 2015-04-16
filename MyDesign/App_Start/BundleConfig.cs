using System.Web;
using System.Web.Optimization;

namespace eSupervisor_Beta
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/sb-admin-2").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/bootstrap.min.js", 
                      "~/Scripts/metisMenu.min.js",
                      "~/Scripts/jquery.dataTables.min.js",
                      "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/sb-admin-2.js")); 

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/metisMenu.min.css",
                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/dataTables.responsive.css",
                      "~/Content/sb-admin-2.css",
                      "~/Content/font-awesome.css"));
        }
    }
}
