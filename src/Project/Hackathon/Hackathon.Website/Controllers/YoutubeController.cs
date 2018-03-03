using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Services;
using Google.Apis.YouTubeAnalytics.v1;
using Hackathon.Website.Services;
using Hackathon.Website.Youtube;

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

                    var channel = "channel==UCWktOA8EqJ7DW29fsczM0ZA";
                    var metrics = "viewerPercentage";
                    var dimensions = "ageGroup,gender";
                    var filters = "video==0NIMC2HkDFM";
                    var data = service.Reports.Query(channel, "2016-01-01", "2018-01-01", metrics);
                    data.Dimensions = dimensions;
                    // data.Filters = filters;

                    var results = data.Execute();

                    // data = (ReportsResource.QueryRequest)SampleHelpers.ApplyOptionalParms(data, null);

                    // Requesting data.
                    // var test =  data.Execute();

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