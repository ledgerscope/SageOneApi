using SageOneApi.Client.Models;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    public interface ISageOneApiClient
    {
        T Get<T>(string id, Dictionary<string, string> queryParameters = null) where T : SageOneEntity;
        T GetSingle<T>(Dictionary<string, string> queryParameters = null) where T : SageOneEntity;
        IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters = null) where T : SageOneEntity;
    }
}
