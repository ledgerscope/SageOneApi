using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using SageOneApi.Client.Responses;

namespace SageOneApi.Client
{
    internal class SageOneApiClientExceptionHandler : SageOneApiClientBaseHandler
    {
        private readonly Action<string> _logMessage;

        public SageOneApiClientExceptionHandler(Action<string> logMessage, ISageOneApiClientHandler apiClient) : base(apiClient)
        {
            _logMessage = logMessage;
        }

        public override T Get<T>(string id, Dictionary<string, string> queryParameters)
        {
            try
            {
                return base.Get<T>(id, queryParameters);
            }
            catch (WebException ex)
            {
                return handleKnownExceptions(ex, () => base.Get<T>(id, queryParameters));
            }
        }

        public override GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters)
        {
            try
            {
                return base.GetAllSummary<T>(pageNumber, queryParameters);
            }
            catch (WebException ex)
            {
                return handleKnownExceptions(ex, () => base.GetAllSummary<T>(pageNumber, queryParameters));
            }
        }

        private T handleKnownExceptions<T>(WebException ex, Func<T> retry) where T : class
        {
            var webResponse = (HttpWebResponse)ex.Response;

            if (webResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                _logMessage("Renewing Auth Tokens");

                RenewRefreshAndAccessToken();

                return retry();
            }

            // too many requests or too much data
            if (webResponse.StatusCode.ToString() == "429")
            {
                var secondsUntilNextRetry = webResponse.Headers["Retry-After"];
                int seconds = int.Parse(secondsUntilNextRetry) + 1;

                Thread.Sleep(TimeSpan.FromSeconds(seconds));

                return retry();
            }

            throw ex;
        }
    }
}
