using SageOneApi.Client.Responses;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal interface ISageOneApiClientHandler
    {
        T Get<T>(string id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        GetAllResponse GetAllSummary<T>() where T : class;
        void Insert<T>() where T : class;
        void Update<T>() where T : class;
        void RenewRefreshAndAccessToken();
    }
}
