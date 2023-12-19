using System.Web;
using System.Web.Helpers;
using System.Web.Optimization;

namespace WebAplication_ProximaGen
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

            bundles.Add(new ScriptBundle("~/bundles/js-principal").Include(
                        "~/assets/js/vendor-all.min.js",
                        "~/assets/js/plugins/bootstrap.min.js",
                        "~/assets/js/plugins/feather.min.js",
                        "~/assets/js/pcoded.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-sweetalert").Include(
                       "~/assets/js/sweetalert2@11.js",
                       "~/assets/js/templateAlert.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-charts").Include(
                        "~/assets/js/plugins/apexcharts.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js-dashboard").Include(
                        "~/assets/js/pages/dashboard-sale.js"));

            //bundles.Add(new Bundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/fonts/feather.css",
                      "~/assets/fonts/fontawesome.css",
                      "~/assets/fonts/material.css",
                      "~/assets/css/style.css"));
        }
    }
}
