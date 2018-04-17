using System;
using System.Net;
using System.Threading;
using SageOneApi.Client.Responses;

namespace SageOneApi.Client
{
    internal class SageOneApiClientExceptionHandler : SageOneApiClientBaseHandler
    {
        public SageOneApiClientExceptionHandler(ISageOneApiClientHandler apiClient) : base(apiClient) { }

        public override T Get<T>(string id)
        {
            try
            {
                return base.Get<T>(id);
            }
            catch (WebException ex)
            {
                return handleKnownExceptions(ex, () => base.Get<T>(id));
            }
        }

        public override GetAllResponse GetAllSummary<T>(int pageNumber)
        {
            try
            {
                return base.GetAllSummary<T>(pageNumber);
            }
            catch (WebException ex)
            {
                return handleKnownExceptions(ex, () => GetAllSummary<T>(pageNumber));
            }
        }

        private T handleKnownExceptions<T>(WebException ex, Func<T> retry) where T : class
        {
            var webResponse = (HttpWebResponse)ex.Response;

            if (webResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                RenewRefreshAndAccessToken();

                return retry();
            }

            // too many requests or too much data
            if (webResponse.StatusCode.ToString() == "429")
            {
                var secondsUntilNextRetry = webResponse.Headers["Retry-After"];

                Thread.Sleep((Convert.ToInt32(secondsUntilNextRetry) * 1000));

                return retry();
            }

            throw ex;
        }
    }
}
