using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Google.Apis.YouTubeAnalytics.v1;

namespace Hackathon.Website.Youtube
{
    public static class Oauth2Example
    {
        /// <summary>
        /// ** Installed Aplication only ** 
        /// This method requests Authentcation from a user using Oauth2.  
        /// </summary>
        /// <param name="clientSecretJson">Path to the client secret json file from Google Developers console.</param>
        /// <param name="userName">Identifying string for the user who is being authentcated.</param>
        /// <param name="scopes">Array of Google scopes</param>
        /// <returns>YoutubeanalyticsService used to make requests against the Youtubeanalytics API</returns>
        public static YouTubeAnalyticsService GetYoutubeanalyticsService(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                //if (string.IsNullOrEmpty(userName))
                //    throw new ArgumentNullException("userName");
                //if (string.IsNullOrEmpty(clientSecretJson))
                //    throw new ArgumentNullException("clientSecretJson");
                //if (!File.Exists(clientSecretJson))
                //    throw new Exception("clientSecretJson file does not exist.");

                var cred = GetUserCredential(clientSecretJson, userName, scopes);
                return GetService(cred);

            }
            catch (Exception ex)
            {
                throw new Exception("Get Youtubeanalytics service failed.", ex);
            }
        }

        /// <summary>
        /// ** Installed Aplication only ** 
        /// This method requests Authentcation from a user using Oauth2.  
        /// Credentials are stored in System.Environment.SpecialFolder.Personal
        /// Documentation https://developers.google.com/accounts/docs/OAuth2
        /// </summary>
        /// <param name="clientSecretJson">Path to the client secret json file from Google Developers console.</param>
        /// <param name="userName">Identifying string for the user who is being authentcated.</param>
        /// <param name="scopes">Array of Google scopes</param>
        /// <returns>authencated UserCredential</returns>
        private static UserCredential GetUserCredential(string clientSecretJson, string userName, string[] scopes)
        {
            try
            {
                //if (string.IsNullOrEmpty(userName))
                //    throw new ArgumentNullException("userName");
                //if (string.IsNullOrEmpty(clientSecretJson))
                //    throw new ArgumentNullException("clientSecretJson");
                //if (!File.Exists(clientSecretJson))
                //    throw new Exception("clientSecretJson file does not exist.");

                // These are the scopes of permissions you need. It is best to request only what you need and not all of them               
                // using (var stream = new FileStream(clientSecretJson, FileMode.Open, FileAccess.Read))
                // {
                    var ceredentials = new ClientSecrets
                    {
                        ClientId = "249888438330-rnfin894g9up5lc1gdbelp7jpsl84anf.apps.googleusercontent.com",
                        ClientSecret = "3jETDqg-vx8Wl84M_UfgFDzh"
                    };

                    // Requesting Authentication or loading previously stored authentication for userName
                    var credential = GoogleWebAuthorizationBroker.AuthorizeAsync(ceredentials,
                                                                             scopes,
                                                                             userName,
                                                                             CancellationToken.None,
                                                                             new FileDataStore("c:\\temp\\", true)).Result;

                    credential.GetAccessTokenForRequestAsync();
                    return credential;
                // }
            }
            catch (Exception ex)
            {
                throw new Exception("Get user credentials failed.", ex);
            }
        }

        /// <summary>
        /// This method get a valid service
        /// </summary>
        /// <param name="credential">Authecated user credentail</param>
        /// <returns>YoutubeanalyticsService used to make requests against the Youtubeanalytics API</returns>
        private static YouTubeAnalyticsService GetService(UserCredential credential)
        {
            try
            {
                if (credential == null)
                    throw new ArgumentNullException("credential");

                // Create Youtubeanalytics API service.
                return new YouTubeAnalyticsService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Youtubeanalytics Oauth2 Authentication Sample"
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Get Youtubeanalytics service failed.", ex);
            }
        }
    }
}