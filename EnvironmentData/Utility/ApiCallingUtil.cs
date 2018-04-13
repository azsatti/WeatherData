namespace EnvironmentData.Utility
{
    using System.Net;
    using Interfaces;
    using PostSharp;
    using Properties;

    public class ApiCallingUtil : IApiCallingUtil
    {
        public string GetAndProcessApiData(string url, int? retryOverride = null)
        {
            return RetryGetDataFromApi(url, retryOverride);
        }

        private static string RetryGetDataFromApi(string url, int? retryOverride)
        {
            var responseString = string.Empty;

            var retryCount = retryOverride ?? Settings.Default.RetryCount;

            for (var i = 0; i < retryCount; i++)
            {
                try
                {
                    responseString = GetDataFromApi(url, retryCount == 1);

                    break;
                }
                catch (WebException)
                {
                    // throw the exception on the last attempt.
                    if (i == retryCount - 1)
                    {
                        throw;
                    }
                }
            }

            return responseString;
        }

        [LogException]
        private static string GetDataFromApi(string url, bool isSingleTry)
        {
            string downloadString;
            var timeout = isSingleTry ? Settings.Default.Timeout * 1000 : Settings.Default.Timeout * 1000 / 2;
            using (var client = new WebClientWithTimeout(timeout))
            {
                client.Proxy = new WebProxy { BypassList = new[] { url } };

                downloadString = client.DownloadString(url);
            }

            return downloadString;
        }
    }
}
