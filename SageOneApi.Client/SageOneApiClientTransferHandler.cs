using SageOneApi.Client.Constants;
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
        internal const string ItemsPerPageKey = "items_per_page";

        private string _accessToken;

        private readonly string _resourceOwnerId;
        private readonly Func<Task<string>> _renewRefreshAndAccessToken;
        private readonly SageOneApiClientConfig _config;

        public SageOneApiClientTransferHandler(
            string accessToken,
            string resourceOwnerId,
            Func<Task<string>> renewRefreshAndAccessToken,
            SageOneApiClientConfig config)
        {
            _accessToken = accessToken;
            _resourceOwnerId = resourceOwnerId;
            _renewRefreshAndAccessToken = renewRefreshAndAccessToken;
            _config = config;
        }

        public async Task<T> Get<T>(string id, Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(id, queryParameters);

            var response = await getResponse<T>(uri, cancellationToken).ConfigureAwait(false);

            return response;
        }

        public async Task<byte[]> GetAttachmentFile(string attachmentId, CancellationToken cancellationToken)
        {
            var uri = createWebRequestUriForAttachmentFile(attachmentId);

            var binaryResponse = await getBinaryResponse(uri, cancellationToken).ConfigureAwait(false);

            return binaryResponse;
        }

        public async Task<T> GetSingle<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneSingleAccountingEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

            var response = await getResponse<T>(uri, cancellationToken).ConfigureAwait(false);

            return response;
        }

        public async Task<T> GetCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

            var response = await getResponse<T>(uri, cancellationToken).ConfigureAwait(false);

            return response;
        }

        public async Task<IEnumerable<T>> GetAllCore<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneCoreEntity
        {
            var uri = createWebRequestUriForSingleEntity<T>(queryParameters: queryParameters);

            var response = await getResponse<T[]>(uri, cancellationToken).ConfigureAwait(false);

            return response;
        }

        public async Task<IEnumerable<T>> GetAll<T>(Dictionary<string, string> queryParameters, CancellationToken cancellationToken) where T : SageOneAccountingEntity
        {
            var uri = createWebRequestUriForAllEntities<T>(pageNumber: 1, queryParameters: queryParameters);

            var response = await getResponse<GetAllResponse<T>>(uri, cancellationToken).ConfigureAwait(false);

            var entities = new List<T>();

            foreach (var item in response.Items)
            {
                entities.Add(await Get<T>(item.Id, queryParameters, cancellationToken).ConfigureAwait(false));
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

            var jsonResponse = await getResponse<GetAllResponse<T>>(uri, cancellationToken).ConfigureAwait(false);

            return jsonResponse;
        }

        public async Task RenewRefreshAndAccessToken(CancellationToken cancellationToken)
        {
            _accessToken = await _renewRefreshAndAccessToken().ConfigureAwait(false);
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

        private async Task<T> getResponse<T>(Uri uri, CancellationToken cancellationToken)
        {
            T responseContent;

            using (var message = buildGetRequestMessage(uri))
            using (var response = await HttpClientFactory.Create().SendAsync(message, cancellationToken).ConfigureAwait(false))
            {
                using (var content = response.Content)
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var responseString = await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new SageOneApiRequestFailedException(response.StatusCode, response.Headers, responseString);
                    }
                    else
                    {
                        using (var stream = await content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                        {
                            responseContent = JsonDeserializer.DeserializeObject<T>(stream);
                        }
                    }
                }
            }

            return responseContent;
        }

        private async Task<byte[]> getBinaryResponse(Uri uri, CancellationToken cancellationToken)
        {
            byte[] binaryResponseContent;

            using (var message = buildGetBinaryRequestMessage(uri))
            using (var response = await HttpClientFactory.Create().SendAsync(message, cancellationToken).ConfigureAwait(false))
            {
                using (var content = response.Content)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        binaryResponseContent = await content.ReadAsByteArrayAsync(cancellationToken).ConfigureAwait(false);
                    }
                    else
                    {
                        var msg = await content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                        throw new SageOneApiRequestFailedException(response.StatusCode, response.Headers, msg);
                    }
                }
            }

            return binaryResponseContent;
        }

        private Uri createWebRequestUriForAllEntities<T>(int pageNumber,
            Dictionary<string, string>? queryParameters = null) where T : SageOneAccountingEntity
        {
            var sb = new StringBuilder()
                .Append(createBaseUriPath<T>())
                .Append($"?page={pageNumber}");

            bool isItemsPerPageAdded = false;
            if (queryParameters != null)
            {
                foreach (var item in queryParameters)
                {
                    if (item.Key.Equals(ItemsPerPageKey, StringComparison.InvariantCultureIgnoreCase))
                    {
                        isItemsPerPageAdded = true;
                    }
                    sb.Append('&').Append(item.Key).Append('=').Append(item.Value);
                }
            }

            if (!isItemsPerPageAdded)
            {
                sb.Append($"&{ItemsPerPageKey}={_config.PageSize}");
            }

            var uriPath = sb.ToString();
            var uri = new Uri(uriPath);

            return uri;
        }

        private int getPageSize(Dictionary<string, string> queryParameters)
        {
            if (queryParameters.TryGetValue(ItemsPerPageKey, out string strItemsPerPage))
            {
                if (int.TryParse(strItemsPerPage, out int itemsPerPage))
                {
                    return itemsPerPage;
                }
            }

            return _config.PageSize;
        }

        private Uri createWebRequestUriForSingleEntity<T>(string? entityId = null, Dictionary<string, string>? queryParameters = null)
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

            return _config.BaseUri + "/" + targetEntity;
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
            { typeof(JournalCode) , "journal_codes" },
            { typeof(ContactAllocation) , "contact_allocations" },
            { typeof(TaxRate) , "tax_rates" },
            { typeof(BankAccount) , "bank_accounts"},
            { typeof(BusinessSettings) , "business_settings" },
            { typeof(FinancialSettings) , "financial_settings" },
            { typeof(Transaction) , "transactions" },
            { typeof(TransactionType) , "transaction_types" },
            { typeof(BankReconciliation) , "bank_reconciliations" },
            { typeof(AnalysisType) , "analysis_types" },
            { typeof(Attachment) , "attachments" },

            { typeof(Business), "businesses" },
            { typeof(Me), "me" },
            { typeof(User), "user" },
        };
    }
}
