using Google.Apis.YouTubeAnalytics.v1;
using System;
using Google.Apis.YouTubeAnalytics.v1.Data;

namespace Hackathon.Website.Youtube
{
  
    public static class GroupsSample
    {

        public class GroupsDeleteOptionalParms
        {
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
        
        }
 
        /// <summary>
        /// Deletes a group. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groups/delete
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="id">The id parameter specifies the YouTube group ID for the group that is being deleted.</param>
        /// <param name="optional">Optional paramaters.</param>
        public static void Delete(YouTubeAnalyticsService service, string id, GroupsDeleteOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (id == null)
                    throw new ArgumentNullException(id);

                // Building the initial request.
                var request = service.Groups.Delete(id);

                // Applying optional parameters to the request.                
                request = (GroupsResource.DeleteRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                 request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Groups.Delete failed.", ex);
            }
        }
        public class GroupsInsertOptionalParms
        {
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
        
        }
 
        /// <summary>
        /// Creates a group. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groups/insert
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="body">A valid Youtubeanalytics v1 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>GroupResponse</returns>
        public static Group Insert(YouTubeAnalyticsService service, Group body, GroupsInsertOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");

                // Building the initial request.
                var request = service.Groups.Insert(body);

                // Applying optional parameters to the request.                
                request = (GroupsResource.InsertRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Groups.Insert failed.", ex);
            }
        }
        public class GroupsListOptionalParms
        {
            /// The id parameter specifies a comma-separated list of the YouTube group ID(s) for the resource(s) that are being retrieved. In a group resource, the id property specifies the group's YouTube group ID.
            public string Id { get; set; }  
            /// Set this parameter's value to true to instruct the API to only return groups owned by the authenticated user.
            public bool? Mine { get; set; }  
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
            /// The pageToken parameter identifies a specific page in the result set that should be returned. In an API response, the nextPageToken property identifies the next page that can be retrieved.
            public string PageToken { get; set; }  
        
        }
 
        /// <summary>
        /// Returns a collection of groups that match the API request parameters. For example, you can retrieve all groups that the authenticated user owns, or you can retrieve one or more groups by their unique IDs. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groups/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>GroupListResponseResponse</returns>
        public static GroupListResponse List(YouTubeAnalyticsService service, GroupsListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");

                // Building the initial request.
                var request = service.Groups.List();

                // Applying optional parameters to the request.                
                request = (GroupsResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Groups.List failed.", ex);
            }
        }
        public class GroupsUpdateOptionalParms
        {
            /// Note: This parameter is intended exclusively for YouTube content partners.The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This parameter is intended for YouTube content partners that own and manage many different YouTube channels. It allows content owners to authenticate once and get access to all their video and channel data, without having to provide authentication credentials for each individual channel. The CMS account that the user authenticates with must be linked to the specified YouTube content owner.
            public string OnBehalfOfContentOwner { get; set; }  
        
        }
 
        /// <summary>
        /// Modifies a group. For example, you could change a group's title. 
        /// Documentation https://developers.google.com/youtubeanalytics/v1/reference/groups/update
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated Youtubeanalytics service.</param>  
        /// <param name="body">A valid Youtubeanalytics v1 body.</param>
        /// <param name="optional">Optional paramaters.</param>
        /// <returns>GroupResponse</returns>
        public static Group Update(YouTubeAnalyticsService service, Group body, GroupsUpdateOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");

                // Building the initial request.
                var request = service.Groups.Update(body);

                // Applying optional parameters to the request.                
                request = (GroupsResource.UpdateRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Groups.Update failed.", ex);
            }
        }
    }
}