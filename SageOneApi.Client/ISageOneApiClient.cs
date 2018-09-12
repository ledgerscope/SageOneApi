using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    public interface ISageOneApiClient
    {
        T Get<T>(string id, Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity;
        T GetSingle<T>(Dictionary<string, string> queryParameters = null) where T : SageOneSingleAccountingEntity;
        T GetCore<T>(Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity;
        IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity;
        IEnumerable<T> GetAllCore<T>(Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity;
    }
}
