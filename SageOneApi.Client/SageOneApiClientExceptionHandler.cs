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
        private const int retryLimit = 3;

        public SageOneApiClientExceptionHandler(Action<string> logMessage, ISageOneApiClientHandler apiClient) : base(apiClient)
        {
            _logMessage = logMessage;
        }

        public override T Get<T>(string id, Dictionary<string, string> queryParameters)
        {
            return getImpl<T>(id, queryParameters);
        }

        T getImpl<T>(string id, Dictionary<string, string> queryParameters, int retryNumber = 0) where T : class
        {
            try
            {
                return base.Get<T>(id, queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;
                return handleKnownExceptions(ex, () => getImpl<T>(id, queryParameters, retryNumber), retryNumber);
            }
        }

        public override T GetSingle<T>(Dictionary<string, string> queryParameters)
        {
            return getSingleImpl<T>(queryParameters);
        }

        T getSingleImpl<T>(Dictionary<string, string> queryParameters, int retryNumber = 0) where T : class
        {
            try
            {
                return base.GetSingle<T>(queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;
                return handleKnownExceptions(ex, () => getSingleImpl<T>(queryParameters, retryNumber), retryNumber);
            }
        }

        public override GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters)
        {
            return getAllSummaryImpl<T>(pageNumber, queryParameters);
        }

        GetAllResponse getAllSummaryImpl<T>(int pageNumber, Dictionary<string, string> queryParameters, int retryNumber = 0) where T : class
        {
            try
            {
                return base.GetAllSummary<T>(pageNumber, queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;
                return handleKnownExceptions(ex, () => getAllSummaryImpl<T>(pageNumber, queryParameters, retryNumber), retryNumber);
            }
        }

        private T handleKnownExceptions<T>(WebException ex, Func<T> retry, int retryNumber) where T : class
        {
            if (retryNumber < retryLimit)
            {
                var webResponse = (HttpWebResponse)ex.Response;

                if (webResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _logMessage("Renewing Auth Tokens");

                    RenewRefreshAndAccessToken();

                    return retry();
                }

                // too many requests or too much data
                else if (webResponse.StatusCode.ToString() == "429")
                {
                    var secondsUntilNextRetry = webResponse.Headers["Retry-After"];
                    int seconds = int.Parse(secondsUntilNextRetry) + 1;

                    Thread.Sleep(TimeSpan.FromSeconds(seconds));

                    return retry();
                }
                else if (webResponse.StatusCode == HttpStatusCode.GatewayTimeout || webResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(10));
                }
            }

            throw ex;
        }
    }
}
