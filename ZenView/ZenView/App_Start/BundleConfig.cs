﻿using System.Web;
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

            bundles.Add(new ScriptBundle("~/bundles/sitescripts").Include(
                "~/Scripts/Main.js"
                //"~/Scripts/SignalR.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Css/Vendor/Bootstrap/bootstrap.css",
                      "~/Css/bundle.css"));
        }
    }
}