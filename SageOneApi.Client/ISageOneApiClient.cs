using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Utils;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
	/// <summary>
	/// Methods for accessing the Sage API.
	/// </summary>
	/// <remarks>Compatible with Sage API v3.0</remarks>
	public interface ISageOneApiClient
	{
		Task<T> Get<T>(string id, CancellationToken cancellationToken = default, Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity;

		/// <summary>
		/// Retrieve <see cref="SageOneSingleAccountingEntity"/> item where there is only ever one of them per company.
		/// </summary>
		Task<T> GetSingle<T>(CancellationToken cancellationToken = default, Dictionary<string, string> queryParameters = null) where T : SageOneSingleAccountingEntity;

		/// <summary>
		/// Retrieve <see cref="SageOneCoreEntity"/> item where there is only ever one of them per company.
		/// </summary>
		Task<T> GetCore<T>(CancellationToken cancellationToken = default, Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity;

		/// <summary>
		/// Retrieve <see cref="SageOneAccountingEntity"/> items where there could be multiple items per company.
		/// </summary>
		Task<IEnumerable<T>> GetAll<T>(CancellationToken cancellationToken = default, Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity;

		/// <summary>
		/// Retrieve <see cref="SageOneCoreEntity"/> items where there could be multiple items per company.
		/// </summary>
		Task<IEnumerable<T>> GetAllCore<T>(CancellationToken cancellationToken = default, Dictionary<string, string> queryParameters = null) where T : SageOneCoreEntity;

		IProgress<ProgressUpdate> ProgressUpdate { get; set; }
	}
}
