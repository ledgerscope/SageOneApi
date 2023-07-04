using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Responses;
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
            return await GetAll<T>(queryParameters, null, cancellationToken);
        }

        public override async Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, int? pageLimit, CancellationToken cancellationToken)
        {
            var pageNumber = 1;
            var itemsDownloaded = 0;
            var isDownloadRequired = true;
            var entities = new List<T>();

            while (isDownloadRequired && (pageLimit is null || pageNumber <= pageLimit))
            {
                var summaryResponse = await GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken);

                entities.AddRange(summaryResponse.Items);

                itemsDownloaded += summaryResponse.Items.Length;

                _progressUpdate.Report(new ProgressUpdate(
                    $"Downloaded {itemsDownloaded}/{summaryResponse.Total} {typeof(T).Name} records",
                    itemsDownloaded,
                    summaryResponse.Total,
                    typeof(T).Name));

                //Next URL isn't guaranteed to be populated
                isDownloadRequired = summaryResponse.Total > itemsDownloaded;

                pageNumber++;
            }

            return entities;
        }
    }
}