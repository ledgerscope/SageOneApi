using SageOneApi.Client.Responses;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal interface ISageOneApiClientHandler
    {
        T Get<T>(string id) where T : class;
        IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : class;
        GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters) where T : class;
        void Insert<T>() where T : class;
        void Update<T>() where T : class;
        void RenewRefreshAndAccessToken();
    }
}
