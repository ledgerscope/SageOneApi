using Newtonsoft.Json;
using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Utils;

namespace SageOneApi.Client
{
	internal class SageOneApiClientTransferHandler : ISageOneApiClientHandler
	{
		private Uri _baseUri;
		private string _accessToken;
		private string _subscriptionId;
		private string _resourceOwnerId;
		private readonly Func<string> _renewRefreshAndAccessToken;
		private readonly SageOneApiClientConfig _config;

		public SageOneApiClientTransferHandler(
			Uri baseUri,
			string accessToken,
			string subscriptionId,
			string resourceOwnerId,
			Func<string> renewRefreshAndAccessToken,
			SageOneApiClientConfig config)
		{
			_baseUri = baseUri;
			_accessToken = accessToken;
			_subscriptionId = subscriptionId;
			_resourceOwnerId = resourceOwnerId;
			_renewRefreshAndAccessToken = renewRefreshAndAccessToken;
			_config = config;
		}

		public async Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
		{
			var uri = createWebRequestUriForSingleEntity<T>(id, queryParameters);

			var jsonResponse = await getResponse(uri, cancellationToken);

			var response = JsonConvert.DeserializeObject<T>(jsonResponse);

			return response;
		}

		public async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity
		{
			var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

			var jsonResponse = await getResponse(uri, cancellationToken);

			var response = JsonConvert.DeserializeObject<T>(jsonResponse);

			return response;
		}

		public async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
		{
			var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

			var jsonResponse = await getResponse(uri, cancellationToken);

			var response = JsonConvert.DeserializeObject<T>(jsonResponse);

			return response;
		}

		public async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
		{
			var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

			var jsonResponse = await getResponse(uri, cancellationToken);

			var response = JsonConvert.DeserializeObject<T[]>(jsonResponse);

			return response;
		}

		public async Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
		{
			var uri = createWebRequestUriForAllEntities<T>(pageNumber: 1, _config.PageSize, queryParameters: queryParameters);

			var jsonResponse = await getResponse(uri, cancellationToken);

			var response = JsonConvert.DeserializeObject<GetAllResponse<T>>(jsonResponse);

			var entities = new List<T>();

			foreach (var item in response.Items)
			{
				entities.Add(await Get<T>(item.Id, queryParameters, cancellationToken));
			}

			return entities;
		}

		public async Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
		{
			var uri = createWebRequestUriForAllEntities<T>(pageNumber: pageNumber, _config.PageSize, queryParameters: queryParameters);

			var jsonResponse = await getResponse(uri, cancellationToken);

			return JsonConvert.DeserializeObject<GetAllResponse<T>>(jsonResponse);
		}

		public void RenewRefreshAndAccessToken()
		{
			_accessToken = _renewRefreshAndAccessToken();
		}

		private HttpRequestMessage buildGetRequestMessage(Uri uri)
		{
			var requestMessage = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = uri};

			requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			requestMessage.Headers.Add("X-Site", _resourceOwnerId);
			requestMessage.Headers.Add("Ocp-Apim-Subscription-Key", _subscriptionId);
			requestMessage.Headers.Add("Authorization", $"Bearer {_accessToken}");

			return requestMessage;
		}

		private async Task<string> getResponse(Uri uri, CancellationToken cancellationToken)
		{
			string responseData;
			var message = buildGetRequestMessage(uri);

			using (var response = await HttpClientFactory.Create().SendAsync(message, cancellationToken))
			{
				if(!response.IsSuccessStatusCode)
					throw new SageOneApiRequestFailedException(response);

				responseData = await response.Content.ReadAsStringAsync();
			}

			return responseData;
		}

		private Uri createWebRequestUriForAllEntities<T>(int pageNumber, int pageSize,
			Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity
		{
			var sb = new StringBuilder()
				.Append(createBaseUriPath<T>())
				.Append("?page=")
				.Append(pageNumber)
				.Append("&items_per_page=")
				.Append(pageSize);

			if (queryParameters != null && queryParameters.Any())
			{
				foreach (var item in queryParameters)
				{
					sb.Append("&").Append(item.Key).Append("=").Append(item.Value);
				}
			}

			var uriPath = sb.ToString();
			var uri = new Uri(uriPath);

			return uri;
		}

		private Uri createWebRequestUriForSingleEntity<T>(string entityId = null, Dictionary<string, string> queryParameters = null)
			where T : class
		{
			var sb = new StringBuilder()
				.Append(createBaseUriPath<T>())
				.Append("/")
				.Append(entityId);

			if (queryParameters != null && queryParameters.Any())
			{
				sb.Append("?");

				foreach (var item in queryParameters)
				{
					sb.Append(item.Key).Append("=").Append(item.Value).Append("&");
				}
			}

			var uriPath = sb.ToString();
			var uri = new Uri(uriPath);

			return uri;
		}

		private string createBaseUriPath<T>() where T : class
		{
			var targetEntity = getTargetEntityPathFrom(typeof(T));

			string section = "accounts";

			if (typeof(T).IsSubclassOf(typeof(SageOneCoreEntity)))
			{
				section = "core";
			}

			return $"{_baseUri}/{section}/v3/{targetEntity}";
		}

		private string getTargetEntityPathFrom(Type type)
		{
			if (targetEntityPathByType.TryGetValue(type, out var retVal))
				return retVal;

			throw new ArgumentException($"Working with entity '{type.Name}' is currently unsupported");
		}

		static readonly Dictionary<Type, string> targetEntityPathByType = new Dictionary<Type, string>()
		{
			{ typeof(Contact), "contacts" },
			{ typeof(LedgerAccount), "ledger_accounts"},
			{ typeof(LedgerEntry), "ledger_entries"},
			{ typeof(SalesInvoice) , "sales_invoices"},
			{ typeof(SalesQuickEntry) , "sales_quick_entries"},
			{ typeof(SalesCreditNote) , "sales_credit_notes"},
			{ typeof(ContactPayment) , "contact_payments"},
			{ typeof(PurchaseInvoice) , "purchase_invoices"},
			{ typeof(PurchaseQuickEntry) , "purchase_quick_entries"},
			{ typeof(PurchaseCreditNote) , "purchase_credit_notes"},
			{ typeof(OtherPayment) , "other_payments"},
			{ typeof(BankTransfer) , "bank_transfers"},
			{ typeof(Journal) , "journals"},
			{ typeof(ContactAllocation) , "contact_allocations"},
			{ typeof(TaxRate) , "tax_rates"},
			{ typeof(BankAccount) , "bank_accounts"},
			{ typeof(BusinessSettings) , "business_settings"},
			{ typeof(FinancialSettings) , "financial_settings"},
			{ typeof(Transaction) , "transactions"},
			{ typeof(BankReconciliation) , "bank_reconciliations"},

			{ typeof(Business), "business" },
			{ typeof(Me), "me" },
			{ typeof(User), "user" },
		};
	}
}
