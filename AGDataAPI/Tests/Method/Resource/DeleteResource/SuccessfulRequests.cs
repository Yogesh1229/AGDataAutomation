using AGDataAPI.Helpers.Method;
using Xunit;

namespace AGDataAPI.Tests.Method.Resource.DeleteResource
{
    public class SuccessfulRequests
    {
        private DeleteResourceHelper helper = new DeleteResourceHelper();

        [Fact]
        [Trait("API", "DeleteResource")]
        public void AGData_API_DeleteResource_SuccessfulRequests_01_01_PostsIdWith1ShouldResultInSuccess()
        {
            helper
                .DeleteResources(1)
                .VerifySuccess();
        }
    }
}
