using System.Web;
using System.Web.Optimization;

namespace WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Assets/global/plugins/jquery.min.js")
            //         "~/Scripts/jquery-{version}.js")
            );
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            "~/Scripts/jquery.validate*"));
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js",
            "~/Scripts/respond.js"));
            /////////////////////////////////////////////////////////
            //Core plugins
            bundles.Add(new ScriptBundle("~/bundles/ThemeCore").Include(
            "~/Assets/global/plugins/bootstrap/js/bootstrap.min.js",
            "~/Assets/global/plugins/js.cookie.min.js",
            "~/Assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js",
            "~/Assets/global/plugins/jquery.blockui.min.js",
            "~/Assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
            ));
            bundles.Add(new ScriptBundle("~/bundles/GlobalScripts").Include(
                "~/Scripts/Js/App/Main/main.js",
"~/assets/global/scripts/app.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/ThemeCoreLayout1").Include(
        "~/Assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js",
        "~/Assets/global/plugins/jquery.uniform.min.js"));
            //Page level Plugins
            bundles.Add(new ScriptBundle("~/bundles/PageLevelPlugins").Include(
            "~/Assets/global/plugins/bootstrap-daterangepicker/moment.min.js",
            "~/Assets/global/plugins/bootstrap-daterangepicker/daterangepicker.js",
            "~/Assets/global/plugins/morris/morris.min.js",
            "~/Assets/global/plugins/morris/raphael-min.js",
            "~/Assets/global/plugins/counterup/jquery.waypoints.min.js",
            "~/Assets/global/plugins/counterup/jquery.counterup.min.js",
            "~/Assets/global/plugins/fullcalendar/fullcalendar.min.js",
            "~/Assets/global/plugins/flot/jquery.flot.min.js",
            "~/Assets/global/plugins/flot/jquery.flot.resize.min.js",
            "~/Assets/global/plugins/flot/jquery.flot.categories.min.js"
            ));


            bundles.Add(new ScriptBundle("~/bundles/PageLevelPluginsLayout3").Include(
"~/Assets/global/plugins/select2/js/select2.full.min.js"));
            //Charts
            bundles.Add(new ScriptBundle("~/bundles/PageLevelPluginsCharts").Include(
            "~/Assets/global/plugins/amcharts/amcharts/amcharts.js",
            "~/Assets/global/plugins/amcharts/amcharts/serial.js",
            "~/Assets/global/plugins/amcharts/amcharts/pie.js",
            "~/Assets/global/plugins/amcharts/amcharts/radar.js",
            "~/Assets/global/plugins/amcharts/amcharts/themes/light.js",
            "~/Assets/global/plugins/amcharts/amcharts/themes/patterns.js",
            "~/Assets/global/plugins/amcharts/amcharts/themes/chalk.jas",
            "~/Assets/global/plugins/amcharts/ammap/ammap.js",
            "~/Assets/global/plugins/amcharts/ammap/maps/js/worldLow.js",
            "~/Assets/global/plugins/amcharts/amstockcharts/amstock.js",
            "~/Assets/global/plugins/jquery-easypiechart/jquery.easypiechart.min.js",
            "~/Assets/global/plugins/jquery.sparkline.min.js"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
            "~/Content/bootstrap.css",
            "~/Content/site.css"));
            bundles.Add(new ScriptBundle("~/Content/templateGlobalScriptsLayout3").Include(
            "~/Assets/layouts/layout3/scripts/layout.min.js",
            "~/Assets/layouts/layout3/scripts/demo.min.js"));
            bundles.Add(new ScriptBundle("~/Content/templateGlobalScriptsLayout1").Include(
            "~/Assets/layouts/layout1/scripts/layout.min.js",
            "~/Assets/layouts/layout1/scripts/demo.min.js"));
            bundles.Add(new ScriptBundle("~/Content/templateGlobalScripts").Include(
            "~/Assets/layouts/global/scripts/quick-sidebar.min.js",
            "~/Assets/layouts/global/scripts/quick-nav.min.js"));

            bundles.Add(new StyleBundle("~/Content/templateGlobalCss").Include(
            "~/Assets/global/plugins/font-awesome/css/font-awesome.min.css",
            "~/Assets/global/plugins/simple-line-icons/simple-line-icons.min.css",
            "~/Assets/global/plugins/bootstrap/css/bootstrap.min.css",
            "~/Assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"));
            bundles.Add(new StyleBundle("~/Content/templateGlobalCssTheme1").Include(
            "~/Assets/global/plugins/uniform/css/uniform.default.css"
            ));
            bundles.Add(new StyleBundle("~/Content/templatePageLevelCss").Include(
            "~/Assets/global/plugins/select2/css/select2.min.css",
            "~/Assets/global/plugins/select2/css/select2-bootstrap.min.css"
            ));
            bundles.Add(new StyleBundle("~/Content/templatePageLevelCssLayout1").Include(
            "~/Assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css",
            "~/Assets/global/plugins/morris/morris.css",
            "~/Assets/global/plugins/fullcalendar/fullcalendar.min.css",
            "~/Content/kendo/kendo.common.min.css",
            "~/Content/kendo/kendo.default.min.css",
            "~/Assets/global/plugins/jquery-multi-select/css/multi-select.css",
            "~/Assets/global/plugins/jstree/dist/themes/default/style.min.css",
            "~/Assets/global/plugins/bootstrap-toastr/toastr.min.css"
            ));





            bundles.Add(new StyleBundle("~/Content/templateThemeLayout1").Include(
            "~/Assets/layouts/layout1/css/layout.min.css",
            "~/Assets/layouts/layout1/css/themes/blue.min.css",
            "~/Assets/layouts/layout1/css/custom.min.css"));
            bundles.Add(new StyleBundle("~/Content/templateThemeLayout3").Include(
            "~/Assets/layouts/layout3/css/layout.min.css",
            "~/Assets/layouts/layout3/css/themes/blue-hoki.min.css",
            "~/Assets/layouts/layout3/css/custom.min.css"));
            bundles.Add(new StyleBundle("~/Content/templateThemeLayout5").Include(
            "~/Assets/layouts/layout5/css/layout.min.css",
            "~/Assets/layouts/layout5/css/themes/blue.min.css",
            "~/Assets/layouts/layout5/css/custom.min.css"));
            BundleTable.EnableOptimizations = false;
        }
    }
}
