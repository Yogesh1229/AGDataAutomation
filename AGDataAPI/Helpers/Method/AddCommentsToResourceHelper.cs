using AGDataAPI.Helpers.NonMethod;
using AGDataAPI.Models.Enums;
using System.Net;
using Xunit;

namespace AGDataAPI.Helpers.Method
{
    public class AddCommentsToResourceHelper
    {
        public static ApiResponse JsonResponse { get; set; }

        public AddCommentsToResourceHelper AddCommentsToResources(string inputTestData, int postId)
        {
            var url = RequestHelper.CreateRequest(RequestTypeEnum.AddCommentsToResource);
            string completeUrl = string.Format(url, postId);
            JsonResponse = RequestHelper.Post(completeUrl, jsonContent: inputTestData);

            return this;
        }

        public AddCommentsToResourceHelper VerifySuccess(string expectedResponse, bool verifyStatusCode = true)
        {
            if (verifyStatusCode)
            {
                Assert.Equal(HttpStatusCode.Created.ToString(), JsonResponse.StatusCode);
            }

            if (JsonResponse.Data != null)
            {
                Assert.Equal(expectedResponse, JsonResponse.Data);
            }
            return this;
        }
    }
}
