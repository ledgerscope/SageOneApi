using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;

namespace SageOneApi.Client
{
    internal class SageOneApiClientExceptionHandler : SageOneApiClientBaseHandler
    {
        private readonly Action<string> _logMessage;
        private const int _retryLimit = 3;

        public SageOneApiClientExceptionHandler(Action<string> logMessage, ISageOneApiClientHandler apiClient) : base(apiClient)
        {
            _logMessage = logMessage;
        }

        public override T Get<T>(string id, Dictionary<string, string> queryParameters)
        {
            return get<T>(id, queryParameters);
        }

        public override T GetSingle<T>(Dictionary<string, string> queryParameters)
        {
            return getSingle<T>(queryParameters);
        }

        public override T GetCore<T>(Dictionary<string, string> queryParameters)
        {
            return getCore<T>(queryParameters);
        }

        public override IEnumerable<T> GetAllCore<T>(Dictionary<string, string> queryParameters)
        {
            return getAllCore<T>(queryParameters);
        }

        public override GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters)
        {
            return getAllSummary<T>(pageNumber, queryParameters);
        }

        private T get<T>(string id, Dictionary<string, string> queryParameters, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return base.Get<T>(id, queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => get<T>(id, queryParameters, retryNumber), retryNumber);
            }
        }

        private T getSingle<T>(Dictionary<string, string> queryParameters, int retryNumber = 0) where T : SageOneSingleAccountingEntity
        {
            try
            {
                return base.GetSingle<T>(queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => getSingle<T>(queryParameters, retryNumber), retryNumber);
            }
        }

        private T getCore<T>(Dictionary<string, string> queryParameters, int retryNumber = 0) where T : SageOneCoreEntity
        {
            try
            {
                return base.GetCore<T>(queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => getCore<T>(queryParameters, retryNumber), retryNumber);
            }
        }

        private IEnumerable<T> getAllCore<T>(Dictionary<string, string> queryParameters, int retryNumber = 0) where T : SageOneCoreEntity
        {
            try
            {
                return base.GetAllCore<T>(queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => getAllCore<T>(queryParameters, retryNumber), retryNumber);
            }
        }

        private GetAllResponse getAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return base.GetAllSummary<T>(pageNumber, queryParameters);
            }
            catch (WebException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => getAllSummary<T>(pageNumber, queryParameters, retryNumber), retryNumber);
            }
        }

        private bool renewRefreshAndAccessToken(int retryNumber = 0)
        {
            try
            {
                base.RenewRefreshAndAccessToken();

                return true;
            }

            catch (WebException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => renewRefreshAndAccessToken(retryNumber), retryNumber);
            }
        }

        private T handleKnownExceptions<T>(WebException ex, Func<T> retry, int retryNumber)
        {
            if (retryNumber >= _retryLimit || ex.Response == null) throw ex;

            var httpWebResponse = (HttpWebResponse)ex.Response;

            if (httpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
            {
                renewRefreshAndAccessToken();

                return retry();
            }

            // too many requests or too much data
            if (httpWebResponse.StatusCode.ToString() == "429")
            {
                var secondsUntilNextRetry = httpWebResponse.Headers["Retry-After"];
                int seconds = int.Parse(secondsUntilNextRetry) + 1;

                Thread.Sleep(TimeSpan.FromSeconds(seconds));

                return retry();
            }

            if (httpWebResponse.StatusCode == HttpStatusCode.GatewayTimeout || httpWebResponse.StatusCode == HttpStatusCode.ServiceUnavailable)
            {
                Thread.Sleep(TimeSpan.FromSeconds(10));

                return retry();
            }

            if(httpWebResponse.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new InsufficientUserPermissionException("Insufficient User Permission to access endpoint", ex);
            }

            throw ex;
        }
    }
}
