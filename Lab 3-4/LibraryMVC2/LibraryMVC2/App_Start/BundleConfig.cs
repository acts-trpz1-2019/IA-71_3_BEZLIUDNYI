using System.Web;
using System.Web.Optimization;

namespace LibraryMVC2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor/bootstrap").Include(
                                  "~/Content/vendor/js/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/jquery").Include(
                      "~/Content/vendor/js/jquery.validate*",
                      "~/Content/vendor/js/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/modernizr").Include(
                      "~/Content/vendor/js/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/vendor/bootstrap").Include(
                      "~/Content/vendor/css/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/vendor/site").Include(
                      "~/Content/vendor/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/custom/css").Include(
                      "~/Content/custom/css/styles.css"));
        }
    }
}
