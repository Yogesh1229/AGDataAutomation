using AGDataAPI.Helpers.NonMethod;
using AGDataAPI.Models.Enums;
using System.Net;
using Xunit;

namespace AGDataAPI.Helpers.Method
{
    public class DeleteResourceHelper : BaseHelper
    {
        public DeleteResourceHelper DeleteResources(int postId)
        {
            var url = RequestHelper.CreateRequest(RequestTypeEnum.DeleteResources);
            string completeUrl = string.Format(url, postId);
            JsonResponse = RequestHelper.Delete(completeUrl);

            return this;
        }

        public DeleteResourceHelper VerifySuccess(bool verifyStatusCode = true)
        {
            if (verifyStatusCode)
            {
                Assert.Equal(HttpStatusCode.OK.ToString(), JsonResponse.StatusCode);
            }

            return this;
        }
    }
}
