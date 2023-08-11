using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    internal interface ISageOneApiClientHandler
    {
        Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity;
        Task<byte[]> GetAttachmentFile(string attachmentId, CancellationToken cancellationToken);
        Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity;
        Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity;
        Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string>? queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity;
        Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity;
        Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, int? pageLimit, CancellationToken cancellationToken) where T : SageOneAccountingEntity;
        Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity;
        void RenewRefreshAndAccessToken();
    }
}
