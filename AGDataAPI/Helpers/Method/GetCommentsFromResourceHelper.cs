using AGDataAPI.Helpers.NonMethod;
using AGDataAPI.Models.Enums;
using System.Net;
using Xunit;

namespace AGDataAPI.Helpers.Method
{
    public class GetCommentsFromResourceHelper : BaseHelper
    {
        public GetCommentsFromResourceHelper GetCommentsFromResource(int postId)
        {
            var url = RequestHelper.CreateRequest(RequestTypeEnum.GetCommentsFromResource);
            string completeUrl = string.Format(url, postId);
            JsonResponse = RequestHelper.Get(completeUrl);

            return this;
        }

        public GetCommentsFromResourceHelper VerifySuccess(string expectedResponse, bool verifyStatusCode = true)
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
