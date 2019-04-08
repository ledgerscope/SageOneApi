using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using System.Collections.Generic;

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

        public virtual T Get<T>(string id, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _apiClient.Get<T>(id, queryParameters);
        }

        public virtual IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAll<T>(queryParameters);
        }

        public virtual IEnumerable<T> GetAllCore<T>(Dictionary<string, string> queryParameters) where T : SageOneCoreEntity
        {
            return _apiClient.GetAllCore<T>(queryParameters);
        }

        public virtual GetAllResponse<T> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAllFromPage<T>(pageNumber, queryParameters);
        }

        public virtual T GetCore<T>(Dictionary<string, string> queryParameters) where T : SageOneCoreEntity
        {
            return _apiClient.GetCore<T>(queryParameters);
        }

        public virtual T GetSingle<T>(Dictionary<string, string> queryParameters) where T : SageOneSingleAccountingEntity
        {
            return _apiClient.GetSingle<T>(queryParameters);
        }

        public virtual void RenewRefreshAndAccessToken()
        {
            _apiClient.RenewRefreshAndAccessToken();
        }
    }
}
