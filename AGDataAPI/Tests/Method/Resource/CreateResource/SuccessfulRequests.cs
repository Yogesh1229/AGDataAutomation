using AGDataAPI.Helpers.Method;
using Xunit;

namespace AGDataAPI.Tests.Method.Resource.CreateAResource
{
    public class SuccessfulRequests
    {
        private CreateResourceHelper helper = new CreateResourceHelper();

        [Fact]
        [Trait("Resource", "CreateResource")]
        public void AGData_API_CreateResource_SuccessfulRequests_01_01_ResourceCreationWithUserId1ResultInSuccess()
        {
            string inputTestData = "{\"title\": \"foo\", \"body\": \"bar\", \"userId\": 55}";
            string expectedData = "{\n  \"title\": \"foo\",\n  \"body\": \"bar\",\n  \"userId\": 55,\n  \"id\": 101\n}";
            helper
                .CreateResources(inputTestData)
                .VerifySuccess(expectedData);
        }

    }
}
