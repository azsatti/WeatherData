namespace EnvironmentData.Utility
{
    using System;
    using System.Net;

    /// <summary>
    /// A version of web client with a timeout property. We can use make use of async methods if needed, but due to time constraint I am not doing so.
    /// </summary>
    public class WebClientWithTimeout : WebClient
    {
        public WebClientWithTimeout(int timeout = 0)
        {
            this.AllowAutoRedirect = true;
            this.Timeout = timeout;
        }

        public int Timeout { get; set; }

        public bool AllowAutoRedirect { get; set; }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var request = base.GetWebRequest(address);
            if (request != null)
            {
                request.Timeout = this.Timeout;

                var httpRequest = request as HttpWebRequest;

                if (httpRequest != null)
                {
                    httpRequest.AllowAutoRedirect = this.AllowAutoRedirect;
                }
            }

            return request;
        }
    }
}
