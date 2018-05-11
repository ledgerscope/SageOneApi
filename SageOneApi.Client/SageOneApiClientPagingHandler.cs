using System;
using System.Collections.Generic;

namespace SageOneApi.Client
{
    internal class SageOneApiClientPagingHandler : SageOneApiClientBaseHandler
    {
        private Action<string> _logMessage;

        public SageOneApiClientPagingHandler(Action<string> logMessage, ISageOneApiClientHandler apiClient) : base(apiClient)
        {
            _logMessage = logMessage;
        }

        public override IEnumerable<T> GetAll<T>() 
        {
            var entities = new List<T>();
            var pageNumber = 1;
            var itemsDownloaded = 0;
            var isDownloadRequired = true; 

            while (isDownloadRequired)
            {
                var summaryResponse = GetAllSummary<T>(pageNumber++);

                foreach (var item in summaryResponse.items)
                {
                    var entity = Get<T>(item.id);

                    entities.Add(entity);
                }

                itemsDownloaded += summaryResponse.items.Length;

                _logMessage($"Downloaded {itemsDownloaded}/{summaryResponse.total} {typeof(T).Name}s");

                isDownloadRequired = summaryResponse.next != null;
            }

            return entities;
        }
    }
}
