using System;
using System.Collections.Generic;
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
			_progressUpdate.Report(new ProgressUpdate { Message = $"Downloaded {typeof(T).Name}" });
		}
	}
}
