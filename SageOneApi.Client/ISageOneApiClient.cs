using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    public interface ISageOneApiClient
    {
        Task<T> Get<T>(string id, CancellationToken cancellationToken, Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity;
        Task<T> GetSingle<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters = null) where T : SageOneSingleAccountingEntity;
        Task<T> GetCore<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity;
        Task<IEnumerable<T>> GetAll<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity;
        Task<IEnumerable<T>> GetAllCore<T>(CancellationToken cancellationToken, Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity;

        IProgress<ProgressUpdate> ProgressUpdate { get; set; }
    }
}
