using System;
using System.Web.Mvc;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Auth.OAuth2.Mvc;
using Google.Apis.Util.Store;
using Google.Apis.YouTubeAnalytics.v1;

namespace Hackathon.Website.Services
{
    public class AppFlowMetadata : FlowMetadata
    {
        public AppFlowMetadata()
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = "249888438330-rnfin894g9up5lc1gdbelp7jpsl84anf.apps.googleusercontent.com",
                    ClientSecret = "3jETDqg-vx8Wl84M_UfgFDzh"
                },
                Scopes = new[] {YouTubeAnalyticsService.Scope.YtAnalyticsReadonly},
                DataStore = new FileDataStore("c:\\temp\\", true)
            };
            Flow = new GoogleAuthorizationCodeFlow(initializer);
        }           

        public override string GetUserId(Controller controller)
        {
            // In this sample we use the session to store the user identifiers.
            // That's not the best practice, because you should have a logic to identify
            // a user. You might want to use "OpenID Connect".
            // You can read more about the protocol in the following link:
            // https://developers.google.com/accounts/docs/OAuth2Login.
            var user = controller.Session["user"];
            if (user == null)
            {
                user = Guid.NewGuid();
                controller.Session["user"] = user;
            }
            return user.ToString();

        }

        public override IAuthorizationCodeFlow Flow { get; }
    }
}