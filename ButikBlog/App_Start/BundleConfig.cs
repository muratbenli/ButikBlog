using System.Web;
using System.Web.Optimization;

namespace ButikBlog
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // siteyi publish ettiğinde cdn linkini kullanıyor. js kodlarını internetten çekiyor

            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery", "https://code.jquery.com/jquery-3.4.1.min.js).Include").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                       "~/Content/fontawesome-all.css",
                      "~/Content/Site.css"));

            // debug mı release mi kontrol ediyor ona göre cdn kullanılmasına yardımcı oluyor
                #if DEBUG
                        BundleTable.EnableOptimizations = false;
                #else
                        BundleTable.EnableOptimizations = true;
                #endif


        }
    }
}
