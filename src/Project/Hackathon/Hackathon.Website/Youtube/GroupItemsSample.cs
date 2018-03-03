using System;
using Google.Apis.YouTubeAnalytics.v1;
using Google.Apis.YouTubeAnalytics.v1.Data;

namespace Hackathon.Website.Youtube
{
  
    public static class GroupItemsSample
    {

        public class GroupItemsDeleteOptionalParms
        {
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
        
        }
 
        /// <summary>
        /// Removes an item from a group. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groupItems/delete
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="id">The id parameter specifies the YouTube group item ID for the group that is being deleted.</param>
        /// <param name="optional">Optional paramaters.</param>
        public static void Delete(YouTubeAnalyticsService service, string id, GroupItemsDeleteOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (id == null)
                    throw new ArgumentNullException(id);

                // Building the initial request.
                var request = service.GroupItems.Delete(id);

                // Applying optional parameters to the request.                
                request = (GroupItemsResource.DeleteRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                 request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request GroupItems.Delete failed.", ex);
            }
        }
        public class GroupItemsInsertOptionalParms
        {
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
        
        }
 
        /// <summary>
        /// Creates a group item. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groupItems/insert
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="body">A valid Youtubeanalytics v1 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>GroupItemResponse</returns>
        public static GroupItem Insert(YouTubeAnalyticsService service, GroupItem body, GroupItemsInsertOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");

                // Building the initial request.
                var request = service.GroupItems.Insert(body);

                // Applying optional parameters to the request.                
                request = (GroupItemsResource.InsertRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request GroupItems.Insert failed.", ex);
            }
        }
        public class GroupItemsListOptionalParms
        {
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
        
        }
 
        /// <summary>
        /// Returns a collection of group items that match the API request parameters. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groupItems/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="groupId">The id parameter specifies the unique ID of the group for which you want to retrieve group items.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>GroupItemListResponseResponse</returns>
        public static GroupItemListResponse List(YouTubeAnalyticsService service, string groupId, GroupItemsListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (groupId == null)
                    throw new ArgumentNullException(groupId);

                // Building the initial request.
                var request = service.GroupItems.List(groupId);

                // Applying optional parameters to the request.                
                request = (GroupItemsResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request GroupItems.List failed.", ex);
            }
        }
    }
}