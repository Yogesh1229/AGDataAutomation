using AGDataAPI.Helpers.Method;
using Xunit;

namespace AGDataAPI.Tests.Method.Resource.UpdateResource
{
    public class SuccessfulRequests
    {
        private UpdateResourceHelper helper = new UpdateResourceHelper();

        [Fact]
        [Trait("Resource", "UpdateResource")]
        public void AGData_API_UpdateResource_SuccessfulRequests_01_01_UpdateResourceWithAllParametersResultInSuccess()
        {
            string inputTestData = "{\"id\": 20, \"title\": \"Automation Engineer\", \"body\": \"this is an update request\", \"userId\": 50}";
            string expectedData = "{\n  \"id\": 5,\n  \"title\": \"Automation Engineer\",\n  \"body\": \"this is an update request\",\n  \"userId\": 50\n}";
            helper
                .UpdateResources(inputTestData, 5)
                .VerifySuccess(expectedData);
        }
    }
}
