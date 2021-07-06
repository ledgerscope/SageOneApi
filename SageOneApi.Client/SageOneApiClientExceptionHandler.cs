using SageOneApi.Client.Constants;
using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using SageOneApi.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    internal class SageOneApiClientExceptionHandler : SageOneApiClientBaseHandler
    {
        private const int _retryLimit = 3;

        public SageOneApiClientExceptionHandler(
            SageOneApiClientConfig config,
            ISageOneApiClientHandler apiClient) : base(apiClient, config)
        {
        }

        public override async Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await get<T>(id, queryParameters, cancellationToken);
        }

        public override async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getSingle<T>(queryParameters, cancellationToken);
        }

        public override async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getCore<T>(queryParameters, cancellationToken);
        }

        public override async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getAllCore<T>(queryParameters, cancellationToken);
        }

        public override async Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getAllSummary<T>(pageNumber, queryParameters, cancellationToken);
        }

        private async Task<T> get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return await base.Get<T>(id, queryParameters, cancellationToken);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;
                return await handleKnownExceptions(ex, () => get<T>(id, queryParameters, cancellationToken, retryNumber), retryNumber);
            }
        }

        private async Task<T> getSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneSingleAccountingEntity
        {
            try
            {
                return await base.GetSingle<T>(queryParameters, cancellationToken);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getSingle<T>(queryParameters, cancellationToken, retryNumber), retryNumber);
            }
        }

        private async Task<T> getCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneCoreEntity
        {
            try
            {
                return await base.GetCore<T>(queryParameters, cancellationToken);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getCore<T>(queryParameters, cancellationToken, retryNumber), retryNumber);
            }
        }

        private async Task<IEnumerable<T>> getAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneCoreEntity
        {
            try
            {
                return await base.GetAllCore<T>(queryParameters, cancellationToken);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getAllCore<T>(queryParameters, cancellationToken, retryNumber), retryNumber);
            }
        }

        private async Task<GetAllResponse<T>> getAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return await base.GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getAllSummary<T>(pageNumber, queryParameters, cancellationToken, retryNumber), retryNumber);
            }
        }

        private Task<bool> renewRefreshAndAccessToken(int retryNumber = 0)
        {
            try
            {
                base.RenewRefreshAndAccessToken();

                return Task.FromResult(true);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return handleKnownExceptions(ex, () => renewRefreshAndAccessToken(retryNumber), retryNumber);
            }
        }

        private async Task<T> handleKnownExceptions<T>(SageOneApiRequestFailedException ex, Func<Task<T>> retry, int retryNumber)
        {
            if (ex.Response == null)
            {
                throw new ApiException("No Response Received", ex);
            }
            else
            {
                var response = ex.Response;

                //Check for 429 before retryLimit as it could be due to the amount of data
                if (response.StatusCode.ToString() == "429")
                {
                    response.Headers.TryGetValues("Retry-After", out var retryAfterHeaderValues);

                    var seconds = (int.Parse(retryAfterHeaderValues.First()) + 1) * (retryNumber + 1);

                    Thread.Sleep(TimeSpan.FromSeconds(seconds));

                    return await retry();
                }
                else if (retryNumber >= _retryLimit)
                {
                    respondToExceptionMessage(ex, (responseTxt) => throw new ApiException(responseTxt, ex));
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    respondToExceptionMessage(ex, (responseTxt) =>
                    {
                        if (responseTxt.Contains(ApiMessage.NoActiveSubscription))
                        {
                            throw new IncompatibleEditionException("Incompatible Edition to use endpoint", ex);
                        }
                    });

                    await renewRefreshAndAccessToken();

                    return await retry();
                }
                // too many requests or too much data
                else if (response.StatusCode == HttpStatusCode.GatewayTimeout
                    || response.StatusCode == HttpStatusCode.ServiceUnavailable
                    || response.StatusCode.ToString() == "525")
                {
                    Thread.Sleep(TimeSpan.FromMinutes(5));

                    return await retry();
                }
                else if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new InsufficientUserPermissionException("Insufficient User Permission to access endpoint", ex);
                }
            }

            throw ex;
        }

        private void respondToExceptionMessage(SageOneApiRequestFailedException ex, Action<string> responseAction)
        {
            responseAction(ex.ResponseContent);
        }
    }
}
