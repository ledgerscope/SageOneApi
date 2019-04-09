using System;
using System.Collections.Generic;
using System.Linq;
using SageOneApi.Client.Utils;

namespace SageOneApi.Client
{
    internal class SageOneApiClientPagingHandler : SageOneApiClientBaseHandler
    {
        private readonly IProgress<ProgressUpdate> _progressUpdate;

        public SageOneApiClientPagingHandler(IProgress<ProgressUpdate> progressUpdate, SageOneApiClientConfig config, ISageOneApiClientHandler apiClient) : base(apiClient, config)
        {
            _progressUpdate = progressUpdate;
        }

        public override IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) 
        {
            var pageNumber = 1;
            var itemsDownloaded = 0;
            var isDownloadRequired = true;
            var entities = new List<T>(); 

            while (isDownloadRequired)
            {
                var summaryResponse = base.GetAllFromPage<T>(pageNumber++, queryParameters);

                entities.AddRange(summaryResponse.Items);

                itemsDownloaded += summaryResponse.Items.Length;

                _progressUpdate.Report(new ProgressUpdate
	                {Message = $"Downloaded {itemsDownloaded}/{summaryResponse.Total} {typeof(T).Name} records"});

                isDownloadRequired = summaryResponse.Next != null;
            }

            return entities;
        }
    }
}
