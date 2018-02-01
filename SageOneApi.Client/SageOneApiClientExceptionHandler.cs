using System.Net;
using SageOneApi.Client.Responses;

namespace SageOneApi.Client
{
    public class SageOneApiClientExceptionHandler : SageOneApiClientBaseHandler
    {
        private readonly ISageOneApiClient _apiClient;
        private readonly string _dataId;

        public SageOneApiClientExceptionHandler(ISageOneApiClient apiClient) : base(apiClient)
        {
            _apiClient = apiClient;
        }

        public override T Get<T>(string id)
        {
            try
            {
                return _apiClient.Get<T>(id);
            }
            catch (WebException ex)
            {
                var webResponse = (HttpWebResponse)ex.Response;

                if (webResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    RenewRefreshAndAccessToken();

                    return _apiClient.Get<T>(id);
                }

                throw ex;
            }
        }

        public override GetAllResponse GetAllSummary<T>()
        {
            try
            {
                return _apiClient.GetAllSummary<T>();
            }
            catch (WebException ex)
            {
                var webResponse = (HttpWebResponse)ex.Response;
                
                if(webResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    RenewRefreshAndAccessToken();

                    return _apiClient.GetAllSummary<T>();
                }

                throw ex;
            }
        }
    }
}
