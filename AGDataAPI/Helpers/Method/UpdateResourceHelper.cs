using AGDataAPI.Helpers.NonMethod;
using AGDataAPI.Models.Enums;
using System.Net;
using Xunit;

namespace AGDataAPI.Helpers.Method
{
    public class UpdateResourceHelper
    {
        public static ApiResponse JsonResponse { get; set; }

        public UpdateResourceHelper UpdateResources(string inputTestData, int postId)
        {
            var url = RequestHelper.CreateRequest(RequestTypeEnum.UpdateResources);
            string completeUrl = string.Format(url, postId);
            JsonResponse = RequestHelper.PUT(completeUrl, jsonContent: inputTestData);

            return this;
        }

        public UpdateResourceHelper VerifySuccess(string expectedResponse, bool verifyStatusCode = true)
        {
            if (verifyStatusCode)
            {
                Assert.Equal(HttpStatusCode.OK.ToString(), JsonResponse.StatusCode);
            }

            if (JsonResponse.Data != null)
            {
                Assert.Equal(expectedResponse, JsonResponse.Data);
            }
            return this;
        }
    }
}
