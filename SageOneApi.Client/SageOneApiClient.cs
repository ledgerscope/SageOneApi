using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using System;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    public class SageOneApiClient : ISageOneApiClient
    {
        private ISageOneApiClientHandler _sageOneApiClientHandler;

        public SageOneApiClient(
            Uri baseUri,
            string accessToken,
            string subscriptionId,
            string resourceOwnerId,
            Func<string> renewRefreshAndAccessToken, 
            Action<string> logMessage = null)
        {
            logMessage = logMessage ?? (_ => { }); // nullLogMessage 

            _sageOneApiClientHandler =
               new SageOneApiClientPagingHandler(logMessage,
                   new SageOneApiClientExceptionHandler(logMessage,
                       new SageOneApiClientTransferHandler(baseUri, accessToken, subscriptionId, resourceOwnerId, renewRefreshAndAccessToken)));
        }

        public T Get<T>(string id, Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _sageOneApiClientHandler.Get<T>(id, queryParameters);
        }

        public T GetSingle<T>(Dictionary<string, string> queryParameters) where T : SageOneSingleAccountingEntity
        {
            return _sageOneApiClientHandler.GetSingle<T>(queryParameters);
        }

        public T GetCore<T>(Dictionary<string, string> queryParameters) where T : SageOneCoreEntity
        {
            return _sageOneApiClientHandler.GetCore<T>(queryParameters);
        }

        public IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : SageOneAccountingEntity
        {
            return _sageOneApiClientHandler.GetAll<T>(queryParameters);
        }
    }
}
