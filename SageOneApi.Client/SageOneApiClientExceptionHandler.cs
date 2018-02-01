using System;
using System.Net;
using SageOneApi.Client.Responses;

namespace SageOneApi.Client
{
    public class SageOneApiClientExceptionHandler : SageOneApiClientBaseHandler
    {
        public SageOneApiClientExceptionHandler(ISageOneApiClient apiClient) : base(apiClient) { }

        public override T Get<T>(string id)
        {
            try
            {
                return base.Get<T>(id);
            }
            catch (WebException ex)
            {
                var webResponse = (HttpWebResponse)ex.Response;

                if (webResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    RenewRefreshAndAccessToken();

                    return base.Get<T>(id);
                }

                throw ex;
            }
        }

        public override GetAllResponse GetAllSummary<T>()
        {
            try
            {
                return base.GetAllSummary<T>();
            }
            catch (WebException ex)
            {
                var webResponse = (HttpWebResponse)ex.Response;
                
                if(webResponse.StatusCode == HttpStatusCode.Unauthorized)
                {
                    RenewRefreshAndAccessToken();

                    return base.GetAllSummary<T>();
                }

                throw ex;
            }
        }
    }
}
