using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
#if DEBUG
    // Making it non-abstract in the debug version makes it easier to step into the embedded PDB code when debugging it when used as a Nuget (a VS quirk).
    internal class SageOneApiClientBaseHandler : ISageOneApiClientHandler
#else
	internal abstract class SageOneApiClientBaseHandler : ISageOneApiClientHandler
#endif
    {
        private readonly ISageOneApiClientHandler _apiClient;
        protected readonly SageOneApiClientConfig _config;

        protected SageOneApiClientBaseHandler(ISageOneApiClientHandler apiClient, SageOneApiClientConfig config)
        {
            _apiClient = apiClient;
            _config = config;
        }

        public virtual Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _apiClient.Get<T>(id, queryParameters, cancellationToken);
        }

        public Task<byte[]> GetAttachmentFile(string attachmentId, CancellationToken cancellationToken)
        {
            return _apiClient.GetAttachmentFile(attachmentId, cancellationToken);
        }

        public virtual Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAll<T>(queryParameters, cancellationToken);
        }

        public virtual Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, int? pageLimit, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAll<T>(queryParameters, pageLimit, cancellationToken);
        }

        public virtual Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            return _apiClient.GetAllCore<T>(queryParameters, cancellationToken);
        }

        public virtual Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken);
        }

        public virtual Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            return _apiClient.GetCore<T>(queryParameters, cancellationToken);
        }

        public virtual Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity
        {
            return _apiClient.GetSingle<T>(queryParameters, cancellationToken);
        }

        public virtual void RenewRefreshAndAccessToken()
        {
            _apiClient.RenewRefreshAndAccessToken();
        }
    }
}
