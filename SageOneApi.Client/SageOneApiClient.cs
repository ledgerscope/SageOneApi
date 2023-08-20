using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
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

        public IProgress<ProgressUpdate>? ProgressUpdate { get; set; }

        public SageOneApiClient(
            string accessToken,
            string refreshToken,
            string resourceOwnerId,
            Func<Func<string, Task<OAuth2TokenResponse>>, Task<string>> renewRefreshAndAccessToken,
            IProgress<ProgressUpdate>? progressUpdate = null,
            SageOneApiClientConfig? sageOneApiClientConfig = null)
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
                       new SageOneApiClientExceptionHandler(sageOneApiClientConfig,
                           new SageOneApiClientTransferHandler(accessToken, resourceOwnerId, renewRefreshAndAccessToken, sageOneApiClientConfig))));
        }

        public Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _sageOneApiClientHandler.Get<T>(id, queryParameters, cancellationToken);
        }

        public Task<byte[]> GetAttachmentFile(string attachmentId, CancellationToken cancellationToken)
        {
            return _sageOneApiClientHandler.GetAttachmentFile(attachmentId, cancellationToken);
        }

        public Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity
        {
            return _sageOneApiClientHandler.GetSingle<T>(queryParameters, cancellationToken);
        }

        public Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            return _sageOneApiClientHandler.GetCore<T>(queryParameters, cancellationToken);
        }

        public Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _sageOneApiClientHandler.GetAll<T>(queryParameters, cancellationToken);
        }

        public Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, int? pageLimit, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _sageOneApiClientHandler.GetAll<T>(queryParameters, pageLimit, cancellationToken);
        }

        public Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string>? queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            return _sageOneApiClientHandler.GetAllCore<T>(queryParameters, cancellationToken);
        }
    }
}
