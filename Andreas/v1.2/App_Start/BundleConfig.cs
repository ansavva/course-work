using System.Web.Optimization;

namespace Andreas.Apps
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                    "~/Scripts/pages/sideNav.js", 
                    "~/Scripts/apps.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/css/bootstrap.css",
                      "~/css/apps.css",
                      "~/node_modules/font-awesome/css/font-awesome.css"));
        }
    }
}
