using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public override async Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) 
        {
            var pageNumber = 1;
            var itemsDownloaded = 0;
            var isDownloadRequired = true;
            var entities = new List<T>(); 

            while (isDownloadRequired)
            {
                var summaryResponse = await base.GetAllFromPage<T>(pageNumber++, queryParameters, cancellationToken);

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
