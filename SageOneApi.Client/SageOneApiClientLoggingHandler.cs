using System;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal class SageOneApiClientLoggingHandler : SageOneApiClientBaseHandler
    {
        private readonly Action<string> _logMessage;

        public SageOneApiClientLoggingHandler(Action<string> logMessage, SageOneApiClientConfig config, ISageOneApiClientHandler apiClient) : base(apiClient, config)
        {
            _logMessage = logMessage;
        }

        public override T GetSingle<T>(Dictionary<string, string> queryParameters)
        {
            var result = base.GetSingle<T>(queryParameters);

            logDownloadMessage<T>();

            return result;
        }

        public override T GetCore<T>(Dictionary<string, string> queryParameters)
        {
            var result = base.GetCore<T>(queryParameters);

            logDownloadMessage<T>();

            return result;
        }

        public override IEnumerable<T> GetAllCore<T>(Dictionary<string, string> queryParameters)
        {
            var result = base.GetAllCore<T>(queryParameters);

            logDownloadMessage<T>();

            return result;
        }

        private void logDownloadMessage<T>()
        {
            _logMessage($"Downloaded {typeof(T).Name}");
        }
    }
}
