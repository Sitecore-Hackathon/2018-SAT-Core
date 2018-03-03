using Google.Apis.Auth.OAuth2.Mvc;
using Hackathon.Website.Services;

namespace Hackathon.Website.Controllers
{
    public class AuthCallbackController : Google.Apis.Auth.OAuth2.Mvc.Controllers.AuthCallbackController
    {
        protected override FlowMetadata FlowData => new AppFlowMetadata();
    }
}