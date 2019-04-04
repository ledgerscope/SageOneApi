using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using SageOneApi.Client.Constants;
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

        public override GetAllResponse<T> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters)
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

        private GetAllResponse<T> getAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return base.GetAllFromPage<T>(pageNumber, queryParameters);
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
            if (ex.Response == null)
            {
                throw new ApiException("No Response Received", ex);
            }
            else
            {
                var httpWebResponse = (HttpWebResponse)ex.Response;

                //Check for 429 before retryLimit as it could be due to the amount of data
                if (httpWebResponse.StatusCode.ToString() == "429")
                {
                    var secondsUntilNextRetry = httpWebResponse.Headers["Retry-After"];
                    int seconds = (int.Parse(secondsUntilNextRetry) + 1) * (retryNumber + 1);

                    Thread.Sleep(TimeSpan.FromSeconds(seconds));

                    return retry();
                }
                else if (retryNumber >= _retryLimit)
                {
                    respondToExceptionMessage(ex, (responseTxt) =>
                    {
                        throw new ApiException(responseTxt, ex);
                    });
                }
                else if (httpWebResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    respondToExceptionMessage(ex, (responseTxt) =>
                    {
                        if (responseTxt.Contains(ApiMessage.NoActiveSubscription))
                        {
                            throw new IncompatibleEditionException("Incompatible Edition to use endpoint", ex);
                        }
                    });

                    renewRefreshAndAccessToken();

                    return retry();
                }
                // too many requests or too much data
                else if (httpWebResponse.StatusCode == HttpStatusCode.GatewayTimeout 
                    || httpWebResponse.StatusCode == HttpStatusCode.ServiceUnavailable
                    || httpWebResponse.StatusCode.ToString() == "525")
                {
                    Thread.Sleep(TimeSpan.FromMinutes(5));

                    return retry();
                }
                else if (httpWebResponse.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new InsufficientUserPermissionException("Insufficient User Permission to access endpoint", ex);
                }
            }

            throw ex;
        }

        private void respondToExceptionMessage(WebException ex, Action<string> responseAction)
        {
            using (var responseStream = ex.Response.GetResponseStream())
            {
                using (var streamReader = new StreamReader(responseStream))
                {
                    var responseTxt = streamReader.ReadToEnd();

                    responseAction(responseTxt);
                }
            }
        }
    }
}
