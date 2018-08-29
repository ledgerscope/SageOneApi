using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal abstract class SageOneApiClientBaseHandler : ISageOneApiClientHandler
    {
        private readonly ISageOneApiClientHandler _apiClient;

        protected SageOneApiClientBaseHandler(ISageOneApiClientHandler apiClient)
        {
            _apiClient = apiClient;
        }

        public virtual T Get<T>(string id, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _apiClient.Get<T>(id, queryParameters);
        }

        public virtual IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAll<T>(queryParameters);
        }

        public virtual GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _apiClient.GetAllSummary<T>(pageNumber, queryParameters);
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
