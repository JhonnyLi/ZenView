using System.Web;
using System.Web.Optimization;

namespace ZenView
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Vendor/jQuery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Vendor/jQuery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Vendor/Misc/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Vendor/Misc/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/Vendor/SignalR/jquery.signalr*"));

            bundles.Add(new ScriptBundle("~/bundles/react").Include(
#if DEBUG
                "~/Scripts/Vendor/ReactJs/react.development.js",
                "~/Scripts/Vendor/ReactJs/react-dom.development.js",
                "~/Scripts/Vendor/Redux/redux.js",
                "~/Scripts/Vendor/Redux/react-redux.js"
#else
                "~/Scripts/Vendor/ReactJs/react.production.min.js",
                "~/Scripts/Vendor/ReactJs/react-dom.production.min.js"
                "~/Scripts/Vendor/Redux/redux.min.js",
                "~/Scripts/Vendor/Redux/react-redux.min.js"
#endif
                ));

            bundles.Add(new ScriptBundle("~/bundles/sitescripts").Include(
                "~/Scripts/Main.js",
                "~/Scripts/redux.js",
                "~/Scripts/react.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Css/bundle.css"));
        }
    }
}
