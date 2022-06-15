using AGDataAPI.Helpers.Method;
using Xunit;

namespace AGDataAPI.Tests.Method.Resource.GetResourceByPosts
{
    public class SuccessfulRequests
    {
        private GetResourceByPostsHelper helper = new GetResourceByPostsHelper();

        [Fact]
        [Trait("API", "GetResourceByPosts")]
        public void AGData_API_GetResourceByPosts_SuccessfulRequests_01_01_PostsIdWith1ShouldResultInSuccess()
        {
            string expectedData = "{\n  \"userId\": 1,\n  \"id\": 1,\n  \"title\": \"sunt aut facere repellat provident occaecati excepturi optio reprehenderit\",\n  \"body\": \"quia et suscipit\\nsuscipit recusandae consequuntur expedita et cum\\nreprehenderit molestiae ut ut quas totam\\nnostrum rerum est autem sunt rem eveniet architecto\"\n}";

            helper
                .GetResourceByPosts(1)
                .VerifySuccess(expectedData);
        }

        [Fact]
        [Trait("API", "GetResourceByPosts")]
        public void AGData_API_GetResourceByPosts_SuccessfulRequests_01_02_PostsIdWith2ShouldResultInSuccess()
        {
            string expectedData = "{\n  \"userId\": 1,\n  \"id\": 2,\n  \"title\": \"qui est esse\",\n  \"body\": \"est rerum tempore vitae\\nsequi sint nihil reprehenderit dolor beatae ea dolores neque\\nfugiat blanditiis voluptate porro vel nihil molestiae ut reiciendis\\nqui aperiam non debitis possimus qui neque nisi nulla\"\n}";
            helper
                .GetResourceByPosts(2)
                .VerifySuccess(expectedData);
        }
    }
}
