using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTubeAnalytics.v1;
using Hackathon.Website.Services;

namespace Hackathon.Website.Controllers
{
    public class YoutubeController : Controller
    {
        public ActionResult Index()
        {
            return Content("Index");
        }

        public async Task<ActionResult> IndexAsync(CancellationToken cancellationToken)
        {
            try
            {
                var result =
                    await new AuthorizationCodeMvcApp(this, new AppFlowMetadata()).AuthorizeAsync(cancellationToken);

                if (result.Credential != null)
                {
                    var service = new YouTubeAnalyticsService(new BaseClientService.Initializer
                    {
                        HttpClientInitializer = result.Credential,
                        ApplicationName = Assembly.GetExecutingAssembly().GetName().Name
                    });

                    var data = service.Reports.Query("UCeNpzcxM-hUhnabwC7oZeYw", "2017-01-01", "2018-01-01", "likes");
                    return Content("OK");
                }


                return new RedirectResult(result.RedirectUri);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}