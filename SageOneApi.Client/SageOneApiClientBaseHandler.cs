using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    internal abstract class SageOneApiClientBaseHandler : ISageOneApiClientHandler
    {
        private readonly ISageOneApiClientHandler _apiClient;
        protected readonly SageOneApiClientConfig _config;

        protected SageOneApiClientBaseHandler(ISageOneApiClientHandler apiClient, SageOneApiClientConfig config)
        {
            _apiClient = apiClient;
            _config = config;
        }

        public virtual async Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return await _apiClient.Get<T>(id, queryParameters, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return await _apiClient.GetAll<T>(queryParameters, cancellationToken);
        }

        public virtual async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            return await _apiClient.GetAllCore<T>(queryParameters, cancellationToken);
        }

        public virtual async Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            return await _apiClient.GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken);
        }

        public virtual async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            return await _apiClient.GetCore<T>(queryParameters, cancellationToken);
        }

        public virtual async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity
        {
            return await _apiClient.GetSingle<T>(queryParameters, cancellationToken);
        }

        public virtual void RenewRefreshAndAccessToken()
        {
            _apiClient.RenewRefreshAndAccessToken();
        }
    }
}
