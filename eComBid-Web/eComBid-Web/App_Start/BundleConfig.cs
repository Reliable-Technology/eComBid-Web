using System.Web;
using System.Web.Optimization;

namespace eComBid_Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/plugins/jQuery/jQuery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/plugins/jQueryUI/jquery-ui.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery-migrate-1.2.1.min.js",
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
 bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                        "~/bootstrap/js/bootstrap.min.js"));
           

            bundles.Add(new ScriptBundle("~/bundles/jqueryplugins").Include(

                        "~/plugins/fastclick/fastclick.min.js",
                        "~/dist/js/app.min.js",
                        "~/plugins/input-mask/jquery.inputmask.js",
                        "~/plugins/input-mask/jquery.inputmask.extensions.js",
                        "~/plugins/datepicker/bootstrap-datepicker.js",
                        "~/dist/js/bootstrap-select.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryhomepage").Include(
                        "~/assets/js/jquery.min.js",
                        "~/assets/js/jquery.dropotron.min.js",
                        "~/assets/js/jquery.scrollgress.min.js",
                        "~/assets/js/skel.min.js",
                        "~/assets/js/util.js",
                        "~/assets/js/main.js"
                       ));
 bundles.Add(new ScriptBundle("~/bundles/iCheckjs").Include(
                        "~/plugins/iCheck/icheck.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/dropzonescripts").Include(
                        "~/Scripts/dropzone/dropzone.js"));
            #endregion

            #region Styles
            bundles.Add(new StyleBundle("~/bundles/basicstyles").Include(
                   "~/bootstrap/css/bootstrap.min.css",
                   "~/dist/css/AdminLTE.min.css",
                   "~/dist/css/skins/_all-skins.min.css",
                   "~/dist/css/Custom.css"
                   ));

            bundles.Add(new StyleBundle("~/bundles/pluginstyles").Include(
              "~/plugins/datepicker/datepicker3.css",
              "~/dist/css/bootstrap-select.min.css"
              ));

            bundles.Add(new StyleBundle("~/bundles/dropzonecss").Include(
                         "~/Scripts/dropzone/basic.css",
                         "~/Scripts/dropzone/dropzone.css"
                         ));

            bundles.Add(new StyleBundle("~/bundles/homepagecss").Include(
                         "~/assets/css/main.css"
                         ));

            bundles.Add(new StyleBundle("~/bundles/iCheckcss").Include(
                "~/plugins/iCheck/square/blue.css"
                ));

            #endregion
        }
    }
}