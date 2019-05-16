using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using SageOneApi.Client.Utils;

namespace SageOneApi.Client
{
	internal class SageOneApiClientLoggingHandler : SageOneApiClientBaseHandler
	{
		private readonly IProgress<ProgressUpdate> _progressUpdate;

		public SageOneApiClientLoggingHandler(IProgress<ProgressUpdate> progressUpdate, SageOneApiClientConfig config, ISageOneApiClientHandler apiClient) : base(apiClient, config)
		{
			_progressUpdate = progressUpdate;
		}

		public override async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
		{
			var result = await base.GetSingle<T>(queryParameters, cancellationToken);

			logDownloadMessage<T>();

			return result;
		}

		public override async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
		{
			var result = await base.GetCore<T>(queryParameters, cancellationToken);

			logDownloadMessage<T>();

			return result;
		}

		public override async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken)
		{
			var result = await base.GetAllCore<T>(queryParameters, cancellationToken);

			logDownloadMessage<T>();

			return result;
		}

		private void logDownloadMessage<T>()
		{
			_progressUpdate.Report(new ProgressUpdate($"Downloaded {typeof(T).Name}"));
		}
	}
}
