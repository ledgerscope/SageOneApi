using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Models;
using SageOneApi.Client.Models.Core;
using SageOneApi.Client.Responses;
using SageOneApi.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    public class SageOneApiClientTransferHandler : ISageOneApiClientHandler
    {
        private const string itemsPerPageKey = "items_per_page";

        private readonly Uri _baseUri;
        private string _accessToken;
        private readonly string _resourceOwnerId;
        private readonly Func<string> _renewRefreshAndAccessToken;
        private readonly SageOneApiClientConfig _config;

        public SageOneApiClientTransferHandler(
            Uri baseUri,
            string accessToken,
            string resourceOwnerId,
            Func<string> renewRefreshAndAccessToken,
            SageOneApiClientConfig config)
        {
            _baseUri = baseUri;
            _accessToken = accessToken;
            _resourceOwnerId = resourceOwnerId;
            _renewRefreshAndAccessToken = renewRefreshAndAccessToken;
            _config = config;
        }

        public async Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(id, queryParameters);

            var jsonResponse = await getResponse(uri, cancellationToken);

            var response = JsonDeserializer.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public async Task<byte[]> GetAttachmentFile(string attachmentId, CancellationToken cancellationToken)
        {
            var uri = createWebRequestUriForAttachmentFile(attachmentId);

            var binaryResponse = await getBinaryResponse(uri, cancellationToken);

            return binaryResponse;
        }

        public async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

            var jsonResponse = await getResponse(uri, cancellationToken);

            var response = JsonDeserializer.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

            var jsonResponse = await getResponse(uri, cancellationToken);

            var response = JsonDeserializer.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

            var jsonResponse = await getResponse(uri, cancellationToken);

            var response = JsonDeserializer.DeserializeObject<T[]>(jsonResponse);

            return response;
        }

        public async Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            var uri = createWebRequestUriForAllEntities<T>(pageNumber: 1, queryParameters: queryParameters);

            var jsonResponse = await getResponse(uri, cancellationToken);

            var response = JsonDeserializer.DeserializeObjects<T>(jsonResponse);

            var entities = new List<T>();

            foreach (var item in response.Items)
            {
                entities.Add(await Get<T>(item.Id, queryParameters, cancellationToken));
            }

            return entities;
        }

        public Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, int? pageLimit, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            throw new NotImplementedException("Page limit has no validity in a non-paging implementation.");
        }

        public async Task<GetAllResponse<T>> GetAllFromPage<T>(int pageNumber, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            var uri = createWebRequestUriForAllEntities<T>(pageNumber: pageNumber, queryParameters: queryParameters);

            var jsonResponse = await getResponse(uri, cancellationToken);

            return JsonDeserializer.DeserializeObjects<T>(jsonResponse);
        }

        public void RenewRefreshAndAccessToken()
        {
            _accessToken = _renewRefreshAndAccessToken();
        }

        private HttpRequestMessage buildGetRequestMessage(Uri uri)
        {
            var requestMessage = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = uri };

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            requestMessage.Headers.Add("X-Business", _resourceOwnerId);
            requestMessage.Headers.Add("Authorization", $"Bearer {_accessToken}");

            return requestMessage;
        }

        private HttpRequestMessage buildGetBinaryRequestMessage(Uri uri)
        {
            var requestMessage = new HttpRequestMessage { Method = HttpMethod.Get, RequestUri = uri };

            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

            requestMessage.Headers.Add("X-Business", _resourceOwnerId);
            requestMessage.Headers.Add("Authorization", $"Bearer {_accessToken}");

            return requestMessage;
        }

        private async Task<string> getResponse(Uri uri, CancellationToken cancellationToken)
        {
            string responseContent;
            var message = buildGetRequestMessage(uri);

            using (var response = await HttpClientFactory.Create().SendAsync(message, cancellationToken))
            {
                responseContent = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                    throw new SageOneApiRequestFailedException(response, responseContent);
            }

            return responseContent;
        }

        private async Task<byte[]> getBinaryResponse(Uri uri, CancellationToken cancellationToken)
        {
            byte[] binaryResponseContent;
            var message = buildGetBinaryRequestMessage(uri);

            using (var response = await HttpClientFactory.Create().SendAsync(message, cancellationToken))
            {
                if (response.IsSuccessStatusCode)
                {
                    binaryResponseContent = await response.Content.ReadAsByteArrayAsync();
                }
                else
                {
                    var msg = await response.Content.ReadAsStringAsync();
                    throw new SageOneApiRequestFailedException(response, msg);
                }
            }

            return binaryResponseContent;
        }

        private Uri createWebRequestUriForAllEntities<T>(int pageNumber,
            Dictionary<string, string> queryParameters = null) where T : SageOneAccountingEntity
        {
            var sb = new StringBuilder()
                .Append(createBaseUriPath<T>())
                .Append($"?page={pageNumber}");

            bool isItemsPerPageAdded = false;
            if (queryParameters != null)
            {
                foreach (var item in queryParameters)
                {
                    if (item.Key.Equals(itemsPerPageKey, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isItemsPerPageAdded = true;
                    }
                    sb.Append('&').Append(item.Key).Append('=').Append(item.Value);
                }
            }

            if (!isItemsPerPageAdded)
            {
                sb.Append($"&{itemsPerPageKey}={_config.PageSize}");
            }

            var uriPath = sb.ToString();
            var uri = new Uri(uriPath);

            return uri;
        }

        private int getPageSize(Dictionary<string, string> queryParameters)
        {
            if (queryParameters.TryGetValue(itemsPerPageKey, out string strItemsPerPage))
            {
                if (int.TryParse(strItemsPerPage, out int itemsPerPage))
                {
                    return itemsPerPage;
                }
            }

            return _config.PageSize;
        }

        private Uri createWebRequestUriForSingleEntity<T>(string entityId = null, Dictionary<string, string> queryParameters = null)
            where T : class
        {
            var sb = new StringBuilder()
                .Append(createBaseUriPath<T>())
                .Append('/')
                .Append(entityId);

            if (queryParameters != null && queryParameters.Any())
            {
                sb.Append('?');

                foreach (var item in queryParameters)
                {
                    sb.Append(item.Key).Append('=').Append(item.Value).Append('&');
                }
            }

            var uriPath = sb.ToString();
            var uri = new Uri(uriPath);

            return uri;
        }

        private Uri createWebRequestUriForAttachmentFile(string attachmentId)
        {
            var sb = new StringBuilder()
                .Append(createBaseUriPath<Attachment>())
                .Append('/')
                .Append(attachmentId)
                .Append("/file");

            var uriPath = sb.ToString();
            var uri = new Uri(uriPath);

            return uri;
        }

        private string createBaseUriPath<T>() where T : class
        {
            var targetEntity = getTargetEntityPathFrom(typeof(T));

            return $"{_baseUri}/{targetEntity}";
        }

        private string getTargetEntityPathFrom(Type type)
        {
            if (targetEntityPathByType.TryGetValue(type, out var retVal))
                return retVal;

            throw new ArgumentException($"Working with entity '{type.Name}' is currently unsupported");
        }

        private static readonly Dictionary<Type, string> targetEntityPathByType = new Dictionary<Type, string>()
        {
            { typeof(Contact), "contacts" },
            { typeof(LedgerAccount), "ledger_accounts" },
            { typeof(LedgerEntry), "ledger_entries" },
            { typeof(SalesInvoice) , "sales_invoices" },
            { typeof(SalesQuickEntry) , "sales_quick_entries" },
            { typeof(SalesCreditNote) , "sales_credit_notes" },
            { typeof(ContactPayment) , "contact_payments" },
            { typeof(PurchaseInvoice) , "purchase_invoices" },
            { typeof(PurchaseQuickEntry) , "purchase_quick_entries" },
            { typeof(PurchaseCreditNote) , "purchase_credit_notes" },
            { typeof(OtherPayment) , "other_payments" },
            { typeof(BankTransfer) , "bank_transfers" },
            { typeof(Journal) , "journals" },
            { typeof(ContactAllocation) , "contact_allocations" },
            { typeof(TaxRate) , "tax_rates" },
            { typeof(BankAccount) , "bank_accounts"},
            { typeof(BusinessSettings) , "business_settings" },
            { typeof(FinancialSettings) , "financial_settings" },
            { typeof(Transaction) , "transactions" },
            { typeof(BankReconciliation) , "bank_reconciliations" },
            { typeof(Attachment) , "attachments" },

            { typeof(Business), "businesses" },
            { typeof(Me), "me" },
            { typeof(User), "user" },
        };
    }
}
