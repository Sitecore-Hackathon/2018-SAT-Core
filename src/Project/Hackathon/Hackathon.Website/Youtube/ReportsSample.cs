using System;
using Google.Apis.YouTubeAnalytics.v1;
using Google.Apis.YouTubeAnalytics.v1.Data;

namespace Hackathon.Website.Youtube
{
  
    public static class ReportsSample
    {

        public class ReportsQueryOptionalParms
        {
            /// The currency to which financial metrics should be converted. The default is US Dollar (USD). If the result contains no financial metrics, this flag will be ignored. Responds with an error if the specified currency is not recognized.
            public string Currency { get; set; }  
            /// A comma-separated list of YouTube Analytics dimensions, such as views or ageGroup,gender. See the Available Reports document for a list of the reports that you can retrieve and the dimensions used for those reports. Also see the Dimensions document for definitions of those dimensions.
            public string Dimensions { get; set; }  
            /// A list of filters that should be applied when retrieving YouTube Analytics data. The Available Reports document identifies the dimensions that can be used to filter each report, and the Dimensions document defines those dimensions. If a request uses multiple filters, join them together with a semicolon (;), and the returned result table will satisfy both filters. For example, a filters parameter value of video==dMH0bHeiRNg;country==IT restricts the result set to include data for the given video in Italy.
            public string Filters { get; set; }  
            /// If set to true historical data (i.e. channel data from before the linking of the channel to the content owner) will be retrieved.
            public bool? IncludeHistoricalChannelData { get; set; }  
            /// The maximum number of rows to include in the response.
            public int? MaxResults { get; set; }  
            /// A comma-separated list of dimensions or metrics that determine the sort order for YouTube Analytics data. By default the sort order is ascending. The '-' prefix causes descending sort order.
            public string Sort { get; set; }  
            /// An index of the first entity to retrieve. Use this parameter as a pagination mechanism along with the max-results parameter (one-based, inclusive).
            public int? StartIndex { get; set; }  
        
        }
 
        /// <summary>
        /// Retrieve your YouTube Analytics reports. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/reports/query
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="ids">Identifies the YouTube channel or content owner for which you are retrieving YouTube Analytics data.- To request data for a YouTube user, set the ids parameter value to channel==CHANNEL_ID, where CHANNEL_ID specifies the unique YouTube channel ID.- To request data for a YouTube CMS content owner, set the ids parameter value to contentOwner==OWNER_NAME, where OWNER_NAME is the CMS name of the content owner.</param>
        /// <param name="start-date">The start date for fetching YouTube Analytics data. The value should be in YYYY-MM-DD format.</param>
        /// <param name="end-date">The end date for fetching YouTube Analytics data. The value should be in YYYY-MM-DD format.</param>
        /// <param name="metrics">A comma-separated list of YouTube Analytics metrics, such as views or likes,dislikes. See the Available Reports document for a list of the reports that you can retrieve and the metrics available in each report, and see the Metrics document for definitions of those metrics.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>ResultTableResponse</returns>
        public static ResultTable Query(YouTubeAnalyticsService service, string ids, string startDate, string endDate, string metrics, ReportsQueryOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (ids == null)
                    throw new ArgumentNullException(ids);
                if (startDate == null)
                    throw new ArgumentNullException(startDate);
                if (endDate == null)
                    throw new ArgumentNullException(endDate);
                if (metrics == null)
                    throw new ArgumentNullException(metrics);

                // Building the initial request.
                var request = service.Reports.Query(ids, startDate, endDate, metrics);

                // Applying optional parameters to the request.                
                request = (ReportsResource.QueryRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Reports.Query failed.", ex);
            }
        }
    }
}