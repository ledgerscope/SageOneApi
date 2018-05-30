using System;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    public interface ISageOneApiClient
    {
        T Get<T>(string id) where T : class;
        IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters = null) where T : class;
        void Insert<T>() where T : class;
        void Update<T>() where T : class;
    }

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

        public T Get<T>(string id) where T : class
        {
            return _sageOneApiClientHandler.Get<T>(id);
        }

        public IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : class
        {
            return _sageOneApiClientHandler.GetAll<T>(queryParameters);
        }

        public void Insert<T>() where T : class
        {
            _sageOneApiClientHandler.Insert<T>();
        }

        public void Update<T>() where T : class
        {
            _sageOneApiClientHandler.Update<T>();
        }
    }
}
