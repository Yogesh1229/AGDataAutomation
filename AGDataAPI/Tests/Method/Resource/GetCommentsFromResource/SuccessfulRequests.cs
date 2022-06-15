using AGDataAPI.Helpers.Method;
using AventStack.ExtentReports;
using Xunit;

namespace AGDataAPI.Tests.Method.Resource.GetCommentsFromResource
{
    public class SuccessfulRequests
    {
        private GetCommentsFromResourceHelper helper = new GetCommentsFromResourceHelper();

        [Fact]
        [Trait("API", "GetCommentsFromResource")]
        public void AGData_API_GetCommentsFromResource_SuccessfulRequests_01_01_RequestToGetCommentFromResourceShouldResultInSuccess()
        {
            string expectedData = "[\n  {\n    \"postId\": 99,\n    \"id\": 491,\n    \"name\": \"eos enim odio\",\n    \"email\": \"Maxwell@adeline.me\",\n    \"body\": \"natus commodi debitis cum ex rerum alias quis\\nmaxime fugiat fugit sapiente distinctio nostrum tempora\\npossimus quod vero itaque enim accusantium perferendis\\nfugit ut eum labore accusantium voluptas\"\n  },\n  {\n    \"postId\": 99,\n    \"id\": 492,\n    \"name\": \"consequatur alias ab fuga tenetur maiores modi\",\n    \"email\": \"Amina@emmet.org\",\n    \"body\": \"iure deleniti aut consequatur necessitatibus\\nid atque voluptas mollitia\\nvoluptates doloremque dolorem\\nrepudiandae hic enim laboriosam consequatur velit minus\"\n  },\n  {\n    \"postId\": 99,\n    \"id\": 493,\n    \"name\": \"ut praesentium sit eos rerum tempora\",\n    \"email\": \"Gilda@jacques.org\",\n    \"body\": \"est eos doloremque autem\\nsimilique sint fuga atque voluptate est\\nminus tempore quia asperiores aliquam et corporis voluptatem\\nconsequatur et eum illo aut qui molestiae et amet\"\n  },\n  {\n    \"postId\": 99,\n    \"id\": 494,\n    \"name\": \"molestias facere soluta mollitia totam dolorem commodi itaque\",\n    \"email\": \"Kadin@walter.io\",\n    \"body\": \"est illum quia alias ipsam minus\\nut quod vero aut magni harum quis\\nab minima voluptates nemo non sint quis\\ndistinctio officia ea et maxime\"\n  },\n  {\n    \"postId\": 99,\n    \"id\": 495,\n    \"name\": \"dolor ut ut aut molestiae esse et tempora numquam\",\n    \"email\": \"Alice_Considine@daren.com\",\n    \"body\": \"pariatur occaecati ea autem at quis et dolorem similique\\npariatur ipsa hic et saepe itaque cumque repellendus vel\\net quibusdam qui aut nemo et illo\\nqui non quod officiis aspernatur qui optio\"\n  }\n]";

            helper
                .GetCommentsFromResource(99)
                .VerifySuccess(expectedData);
        }
    }
}
