using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal interface ISageOneApiClientHandler
    {
        T Get<T>(string id, Dictionary<string, string> queryParameters) where T : SageOneEntity;
        T GetSingle<T>(Dictionary<string, string> queryParameters) where T : SageOneEntity;
        IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : SageOneEntity;
        GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters) where T : SageOneEntity;
        void RenewRefreshAndAccessToken();
    }
}
