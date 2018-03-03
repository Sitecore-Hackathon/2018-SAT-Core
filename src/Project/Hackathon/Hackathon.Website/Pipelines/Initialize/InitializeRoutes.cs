using System.Web.Mvc;
using System.Web.Routing;

using Sitecore.Pipelines;

namespace Hackathon.Website.Pipelines.Initialize
{
    public class InitializeRoutes
    {
        public void Process(PipelineArgs args)
        {
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("Default-Mvc", "{controller}/{action}", new { controller = "Home", action = "Index" });
        }
    }
}