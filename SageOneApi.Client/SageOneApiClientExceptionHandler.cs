using SageOneApi.Client.Constants;
using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
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
            return await get<T>(id, queryParameters, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getSingle<T>(queryParameters, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getCore<T>(queryParameters, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getAllCore<T>(queryParameters, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
        {
            return await getAllSummary<T>(pageNumber, queryParameters, cancellationToken).ConfigureAwait(false);
        }

        public override async Task<byte[]> GetAttachmentFile(string attachmentId, CancellationToken cancellationToken)
        {
            return await getAttachmentFile(attachmentId, cancellationToken).ConfigureAwait(false);
        }

        private async Task<byte[]> getAttachmentFile(string attachmentId, CancellationToken cancellationToken, int retryNumber = 0)
        {
            try
            {
                return await base.GetAttachmentFile(attachmentId, cancellationToken).ConfigureAwait(false);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;
                return await handleKnownExceptions(ex, () => getAttachmentFile(attachmentId, cancellationToken, retryNumber), retryNumber).ConfigureAwait(false);
            }
        }

        private async Task<T> get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return await base.Get<T>(id, queryParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;
                return await handleKnownExceptions(ex, () => get<T>(id, queryParameters, cancellationToken, retryNumber), retryNumber).ConfigureAwait(false);
            }
        }

        private async Task<T> getSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneSingleAccountingEntity
        {
            try
            {
                return await base.GetSingle<T>(queryParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getSingle<T>(queryParameters, cancellationToken, retryNumber), retryNumber).ConfigureAwait(false);
            }
        }

        private async Task<T> getCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneCoreEntity
        {
            try
            {
                return await base.GetCore<T>(queryParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getCore<T>(queryParameters, cancellationToken, retryNumber), retryNumber).ConfigureAwait(false);
            }
        }

        private async Task<IEnumerable<T>> getAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneCoreEntity
        {
            try
            {
                return await base.GetAllCore<T>(queryParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getAllCore<T>(queryParameters, cancellationToken, retryNumber), retryNumber).ConfigureAwait(false);
            }
        }

        private static readonly HashSet<HttpStatusCode> _retryCodes = new HashSet<HttpStatusCode>()
        {
            HttpStatusCode.InternalServerError,
            HttpStatusCode.BadGateway,
            HttpStatusCode.GatewayTimeout,
        };

        private async Task<GetAllResponse<T>> getAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken, int retryNumber = 0) where T : SageOneAccountingEntity
        {
            try
            {
                return await base.GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken).ConfigureAwait(false);
            }
            catch (SageOneApiRequestFailedException ex) when (queryParameters?.ContainsKey("attributes") is true && _retryCodes.Contains(ex.StatusCode))
            {
                var attributeValue = queryParameters["attributes"];

                queryParameters.Remove("attributes");

                var summaryResponse = await GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken).ConfigureAwait(false);

                queryParameters.Add("attributes", attributeValue);

                for (int i = 0; i < summaryResponse.Items.Length; i++)
                {
                    var item = summaryResponse.Items[i];

                    try
                    {
                        var fullItem = await Get<T>(item.Id, queryParameters, cancellationToken).ConfigureAwait(false);

                        summaryResponse.Items[i] = fullItem;
                    }
                    catch (Exception)
                    {
                        //TODO: Log
                        summaryResponse.Items[i] = item;
                    }
                }

                return summaryResponse;
            }
            catch (SageOneApiRequestFailedException ex) when (getPageSize(queryParameters) != 1 && _retryCodes.Contains(ex.StatusCode))
            {
                int originalPageSize = getPageSize(queryParameters);

                queryParameters[SageOneApiClientTransferHandler.ItemsPerPageKey] = "1";

                var offset = (pageNumber - 1) * originalPageSize;

                var items = new List<T>(originalPageSize);
                var total = -1;
                string? next = null;

                for (int i = 1; i <= originalPageSize; i++)
                {
                    var individualResponse = await getAllSummary<T>(offset + i, queryParameters, cancellationToken).ConfigureAwait(false);
                    items.AddRange(individualResponse.Items);
                    total = individualResponse.Total;
                    next = individualResponse.Next;
                }

                queryParameters[SageOneApiClientTransferHandler.ItemsPerPageKey] = originalPageSize.ToString();

                var response = new GetAllResponse<T>()
                {
                    ItemsPerPage = originalPageSize,
                    Page = pageNumber,
                    Total = total,
                    Items = [.. items],
                    Next = next,
                };

                return response;
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => getAllSummary<T>(pageNumber, queryParameters, cancellationToken, retryNumber), retryNumber).ConfigureAwait(false);
            }
        }

        private int getPageSize(Dictionary<string, string> queryParameters)
        {
            var originalPageSize = _config.PageSize;

            if (queryParameters?.TryGetValue(SageOneApiClientTransferHandler.ItemsPerPageKey, out var pageSizeStr) is true)
            {
                originalPageSize = int.Parse(pageSizeStr);
            }

            return originalPageSize;
        }

        private async Task<bool> renewRefreshAndAccessToken(int retryNumber = 0)
        {
            try
            {
                await base.RenewRefreshAndAccessToken(default);

                return true;
            }
            catch (SageOneApiRequestFailedException ex)
            {
                retryNumber++;

                return await handleKnownExceptions(ex, () => renewRefreshAndAccessToken(retryNumber), retryNumber);
            }
        }

        private async Task<T> handleKnownExceptions<T>(SageOneApiRequestFailedException ex, Func<Task<T>> retry, int retryNumber)
        {
            var response = ex;

            //Check for 429 before retryLimit as it could be due to the amount of data
            if (response.StatusCode.ToString() == "429")
            {
                int seconds = 5;
                if (response.Headers.TryGetValues("Retry-After", out var retryAfterHeaderValues))
                {
                    seconds = (int.Parse(retryAfterHeaderValues.First()) + 1) * (retryNumber + 1);
                }

                await Task.Delay(TimeSpan.FromSeconds(seconds)).ConfigureAwait(false);

                return await retry().ConfigureAwait(false);
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

                await renewRefreshAndAccessToken().ConfigureAwait(false);

                return await retry().ConfigureAwait(false);
            }
            // too many requests or too much data
            else if (response.StatusCode == HttpStatusCode.GatewayTimeout
                || response.StatusCode == HttpStatusCode.ServiceUnavailable
                || response.StatusCode.ToString() == "525")
            {
                await Task.Delay(TimeSpan.FromSeconds(5));

                return await retry().ConfigureAwait(false);
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new InsufficientUserPermissionException("Insufficient User Permission to access endpoint", ex);
            }

            throw ex;
        }

        private void respondToExceptionMessage(SageOneApiRequestFailedException ex, Action<string> responseAction)
        {
            responseAction(ex.ResponseContent);
        }
    }
}
