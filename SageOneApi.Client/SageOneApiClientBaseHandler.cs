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

        public virtual T Get<T>(string id, Dictionary<string, string> queryParameters) where T : class
        {
            return _apiClient.Get<T>(id, queryParameters);
        }

        public virtual IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : class
        {
            return _apiClient.GetAll<T>(queryParameters);
        }

        public virtual GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters) where T : class
        {
            return _apiClient.GetAllSummary<T>(pageNumber, queryParameters);
        }

        public virtual void Insert<T>() where T : class
        {
            _apiClient.Insert<T>();
        }

        public void RenewRefreshAndAccessToken()
        {
            _apiClient.RenewRefreshAndAccessToken();
        }

        public virtual void Update<T>() where T : class
        {
            _apiClient.Update<T>();
        }
    }
}
