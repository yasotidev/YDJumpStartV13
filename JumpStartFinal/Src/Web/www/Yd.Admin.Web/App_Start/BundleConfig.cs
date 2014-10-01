using System.Web.Optimization;

namespace Yd.Admin.Web
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération (bluid) sur http://modernizr.com pour choisir uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            bundles.Add(new ScriptBundle("~/bundles/Vendorjs")
                .Include("~/Scripts/foundation.min.js")       
                .Include("~/Scripts/fastclick.js")  
                .Include("~/Scripts/placeholder.js")
                       );

            bundles.Add(new StyleBundle("~/Content/Vendorcss")
                .Include("~/Content/app.css")  
                .Include("~/Content/navs.css")       
                .Include("~/Content/buttons.css")   
                .Include("~/Content/footer.css")    
                .Include("~/Content/Yd-response.css")    
                .Include("~/Content/foundation.min.css")

                     );

            // Définissez EnableOptimizations sur False pour le débogage. Pour plus d'informations,
            // visitez http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = true;
        }
    }
}
