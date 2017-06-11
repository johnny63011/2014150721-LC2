using System.Web;
using System.Web.Optimization;

namespace CajeroAutomatico.WebApi
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                 "~/Scripts/jquery-{version}.js",
          "~/Scripts/bootstrap.js",
          "~/Scripts/bootbox.js",
          "~/Scripts/datatables/jquery.datatables.js",
          "~/Scripts/datatables/datatables.bootstrap.js",

          "~/Scripts/respond.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));



            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
