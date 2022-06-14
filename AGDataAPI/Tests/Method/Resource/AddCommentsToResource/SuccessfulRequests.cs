using AGDataAPI.Helpers.Method;
using Xunit;

namespace AGDataAPI.Tests.Method.Resource.AddCommentsToResource
{
    public class SuccessfulRequests
    {
        private AddCommentsToResourceHelper helper = new AddCommentsToResourceHelper();

        [Fact]
        [Trait("API", "AddCommentsToResource")]
        public void AGData_API_AddCommentsToResource_SuccessfulRequests_01_01_RequestForAddingCommentsToResourceShouldResultInSuccess()
        {
            string inputTestData = "{\"postId\": 20, \"id\": 20, \"name\": \"Automation Engineer\", \"email\": \"test@test.com\", \"body\": \"this is a request\"}";
            string expectedData = "{\n  \"postId\": 20,\n  \"id\": 501,\n  \"name\": \"Automation Engineer\",\n  \"email\": \"test@test.com\",\n  \"body\": \"this is a request\"\n}";
            helper
                .AddCommentsToResources(inputTestData, 10)
                .VerifySuccess(expectedData);
        }
    }
}
