using AGDataAPI.Models.Enums;
using QAAutomation.Common.Utility.Helpers;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace AGDataAPI.Helpers.NonMethod
{
    public class RequestHelper
    {
        public static string CreateRequest(RequestTypeEnum methodEnum, string methodParameters = "", string AGDataApiUrl = null)
        {
            AGDataApiUrl = AGDataApiUrl ?? ConfigurationHelper.getConfigValue("AppSettings", "AGDataApiUrl");

            var completeMethodUrl = AGDataApiUrl + ConfigurationHelper.getConfigValue("AppSettings", methodEnum.ToString()) + methodParameters;

            return completeMethodUrl;
        }

        public static ApiResponse Post(string url, string jsonContent)
        {
            return ProcessWebRequest(RequestMethod.POST, url, jsonContent);
        }

        public static ApiResponse Get(string url)
        {
            return ProcessWebRequest(RequestMethod.GET, url);
        }

        public static ApiResponse PUT(string url, string jsonContent)
        {
            return ProcessWebRequest(RequestMethod.PUT, url, jsonContent);
        }

        public static ApiResponse Delete(string url)
        {
            return ProcessWebRequest(RequestMethod.DELETE, url);
        }

        private static ApiResponse ProcessWebRequest(RequestMethod requestMethod, string url, string jsonBody = "")
        {
            return ProcessRequest(
            requestMethod: requestMethod,
            url: url,
            jsonBody: jsonBody);
        }

        public static ApiResponse ProcessRequest(RequestMethod requestMethod, string url, string jsonBody = "", string ContentType = null)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(url);

                switch (requestMethod)
                {
                    case RequestMethod.GET:
                        request.Method = "GET";
                        break;
                    case RequestMethod.POST:
                        request.Method = "POST";
                        break;
                    case RequestMethod.PUT:
                        request.Method = "PUT";
                        break;
                    case RequestMethod.DELETE:
                        request.Method = "DELETE";
                        break;
                    default:
                        //Verify.Fail("Incorrect Request Method.", true);
                        break;
                }

                var byteArray = Encoding.UTF8.GetBytes(jsonBody);
                request.ContentLength = byteArray.Length;

                if (jsonBody != "")
                {
                    request.ContentType = @"application/json";
                    request.Accept = @"application/json";

                    using (var dataStream = new StreamWriter(request.GetRequestStream()))
                    {
                        dataStream.Write(jsonBody);
                    }
                }

                if (jsonBody == "")
                {
                    request.Accept = @"application/json";
                }

                if (ContentType != null)
                {
                    request.ContentType = ContentType;
                }

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                        {
                            using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                            {
                                var testResponse = response;
                                return new ApiResponse()
                                {
                                    Data = reader.ReadToEnd(),
                                    StatusCode = response.StatusCode.ToString(),
                                    StatusDescription = response.StatusDescription,
                                };
                            }
                        }
                        return null;
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (var exResponse = (HttpWebResponse)ex.Response)
                    {
                        Console.Write("Errorcode: {0}", exResponse.StatusCode);

                        using (var responseStream = exResponse.GetResponseStream())
                        {
                            if (responseStream != null)
                            {
                                using (var reader = new StreamReader(responseStream, Encoding.UTF8))
                                {
                                    return new ApiResponse()
                                    {
                                        Data = reader.ReadToEnd(),
                                        StatusCode = exResponse.StatusCode.ToString(),
                                        StatusDescription = exResponse.StatusDescription,
                                    };
                                }
                            }
                            return null;
                        }
                    }
                }

                return new ApiResponse()
                {
                    Data = "There was a " + ex.Status + ": " + ex.Message,
                    StatusCode = null,
                    StatusDescription = null,
                };
            }

        }
    }

    public class ApiResponse
    {
        public string StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public string Data { get; set; }
    }
    public enum RequestMethod
    {
        GET,
        POST,
        PUT,
        DELETE,
    }
}
