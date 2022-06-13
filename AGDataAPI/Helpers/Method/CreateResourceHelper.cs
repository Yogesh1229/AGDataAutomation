using AGDataAPI.Helpers.NonMethod;
using AGDataAPI.Models.Enums;
using Newtonsoft.Json;
using System.Net;
using Xunit;

namespace AGDataAPI.Helpers.Method
{
    public class CreateResourceHelper : BaseHelper
    {
        public CreateResourceHelper CreateResources(string inputTestData)
        {
            var url = RequestHelper.CreateRequest(RequestTypeEnum.CreateResources);
            JsonResponse = RequestHelper.Post(url, jsonContent: inputTestData);

            return this;
        }

        public CreateResourceHelper VerifySuccess(string expectedResponse, bool verifyStatusCode = true)
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
