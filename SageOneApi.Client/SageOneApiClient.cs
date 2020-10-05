using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    public class SageOneApiClient : ISageOneApiClient
    {
        private readonly ISageOneApiClientHandler _sageOneApiClientHandler;

        public IProgress<ProgressUpdate> ProgressUpdate { get; set; }

        public SageOneApiClient(
            Uri baseUri,
            string accessToken,
            string subscriptionId,
            string resourceOwnerId,
            Func<string> renewRefreshAndAccessToken,
            IProgress<ProgressUpdate> progressUpdate = null,
            SageOneApiClientConfig sageOneApiClientConfig = null)
        {
            sageOneApiClientConfig = sageOneApiClientConfig ?? SageOneApiClientConfig.Default;

            var progressUpdater = new Progress<ProgressUpdate>((a) =>
            {
                ProgressUpdate?.Report(a);
                progressUpdate?.Report(a);
            });

            _sageOneApiClientHandler =
                new SageOneApiClientLoggingHandler(progressUpdater, sageOneApiClientConfig,
                   new SageOneApiClientPagingHandler(progressUpdater, sageOneApiClientConfig,
                       new SageOneApiClientExceptionHandler(progressUpdater, sageOneApiClientConfig,
                           new SageOneApiClientTransferHandler(baseUri, accessToken, subscriptionId, resourceOwnerId, renewRefreshAndAccessToken, sageOneApiClientConfig))));
        }

        public async Task<T> Get<T>(string id, CancellationToken cancellationToken, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return await _sageOneApiClientHandler.Get<T>(id, queryParameters, cancellationToken);
        }

        public async Task<T> GetSingle<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters) where T : SageOneSingleAccountingEntity
        {
            return await _sageOneApiClientHandler.GetSingle<T>(queryParameters, cancellationToken);
        }

        public async Task<T> GetCore<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters) where T : SageOneCoreEntity
        {
            return await _sageOneApiClientHandler.GetCore<T>(queryParameters, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAll<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return await _sageOneApiClientHandler.GetAll<T>(queryParameters, cancellationToken);
        }

        public async Task<IEnumerable<T>> GetAllCore<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity
        {
            return await _sageOneApiClientHandler.GetAllCore<T>(queryParameters, cancellationToken);
        }
    }
}
