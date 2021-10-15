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

			while (isDownloadRequired && pageNumber <= pageLimit)
			{
				GetAllResponse<T> summaryResponse;

				try
				{
					summaryResponse = await base.GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken);

					entities.AddRange(summaryResponse.Items);

					itemsDownloaded += summaryResponse.Items.Length;
				}
				catch (SageOneApiRequestFailedException ex)
				{
					if (ex.Response.StatusCode != HttpStatusCode.InternalServerError) throw;
					if (!queryParameters.ContainsKey("attributes")) throw;

					queryParameters.Remove("attributes");

					summaryResponse = await base.GetAllFromPage<T>(pageNumber, queryParameters, cancellationToken);

					queryParameters.Add("attributes", "all");

					foreach (var item in summaryResponse.Items)
					{
						T fullItem = null;

						try
						{
							fullItem = await base.Get<T>(item.Id, queryParameters, cancellationToken);

							itemsDownloaded++;
						}
						catch (SageOneApiRequestFailedException ex1)
						{
							if (ex1.Response.StatusCode == HttpStatusCode.InternalServerError)
							{
								_progressUpdate.Report(new ProgressUpdate($"Failed to download {typeof(T).Name} record ({item.Id})"));

								continue;
							}
							else
							{
								throw;
							}
						}

						entities.Add(fullItem);
					}
				}

				_progressUpdate.Report(new ProgressUpdate(
					$"Downloaded {itemsDownloaded}/{summaryResponse.Total} {typeof(T).Name} records",
					itemsDownloaded,
					summaryResponse.Total,
					typeof(T).Name));

				isDownloadRequired = summaryResponse.Next != null;

				pageNumber++;
			}

			return entities;
		}
	}
}