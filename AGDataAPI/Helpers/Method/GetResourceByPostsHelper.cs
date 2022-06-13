using AGDataAPI.Helpers.NonMethod;
using AGDataAPI.Models.Enums;
using Newtonsoft.Json.Linq;
using System.Net;
using Xunit;

namespace AGDataAPI.Helpers.Method
{
    public class GetResourceByPostsHelper
    {
        public static ApiResponse JsonResponse { get; set; }
        public GetResourceByPostsHelper GetResourceByPosts(int postId)
        {
            var url = RequestHelper.CreateRequest(RequestTypeEnum.GetResourceByPosts);
            string completeUrl = string.Format(url, postId);
            JsonResponse = RequestHelper.Get(completeUrl);

            return this;
        }

        public GetResourceByPostsHelper VerifySuccess(string expectedResponse, bool verifyStatusCode = true)
        {
            if (verifyStatusCode)
            {
                Assert.Equal(HttpStatusCode.OK.ToString(), JsonResponse.StatusCode);
            }

            if (JsonResponse.Data != null) {
                Assert.Equal(expectedResponse, JsonResponse.Data);
            }
            return this;
        }
    }
}
