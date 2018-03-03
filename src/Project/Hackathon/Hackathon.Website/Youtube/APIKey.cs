using System;
using Google.Apis.Services;
using Google.Apis.YouTubeAnalytics.v1;

namespace Hackathon.Website.Youtube
{
    /// <summary>
	/// When calling APIs that do not access private user data, you can use simple API keys. These keys are used to authenticate your 
    /// application for accounting purposes. The Google API Console documentation also describes API keys.
    /// https://support.google.com/cloud/answer/6158857
    /// </summary>
    public static class ApiKeyExample
    {
        /// <summary>
        /// Get a valid YoutubeanalyticsService for a public API Key.
        /// </summary>
        /// <param name="apiKey">API key from Google Developer console</param>
		/// <returns>YoutubeanalyticsService</returns>
        public static YouTubeAnalyticsService GetService(string apiKey)
        {
            try
            {
                if (string.IsNullOrEmpty(apiKey))
                    throw new ArgumentNullException("api Key");

                return new YouTubeAnalyticsService(new BaseClientService.Initializer()
                {
                    ApiKey = apiKey,
                    ApplicationName = string.Format("{0} API key example", System.Diagnostics.Process.GetCurrentProcess().ProcessName),
                });
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create new Youtubeanalytics Service", ex);
            }
        }
    }
}
