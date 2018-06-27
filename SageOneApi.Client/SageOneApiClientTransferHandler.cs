using Newtonsoft.Json;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace SageOneApi.Client
{
    internal class SageOneApiClientTransferHandler : ISageOneApiClientHandler
    {
        private Uri _baseUri;
        private string _accessToken;
        private string _subscriptionId;
        private string _resourceOwnerId;
        private readonly Func<string> _renewRefreshAndAccessToken;

        public SageOneApiClientTransferHandler(
            Uri baseUri,
            string accessToken,
            string subscriptionId,
            string resourceOwnerId,
            Func<string> renewRefreshAndAccessToken)
        {
            _baseUri = baseUri;
            _accessToken = accessToken;
            _subscriptionId = subscriptionId;
            _resourceOwnerId = resourceOwnerId;
            _renewRefreshAndAccessToken = renewRefreshAndAccessToken;
        }

        public T Get<T>(string id, Dictionary<string, string> queryParameters) where T : class
        {
            var webRequest = createWebRequestForSingleEntity<T>(id, queryParameters);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public T GetSingle<T>(Dictionary<string, string> queryParameters) where T : class
        {
            var webRequest = createWebRequestForSingleEntity<T>(queryParameters: queryParameters);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public IEnumerable<T> GetAll<T>(Dictionary<string, string> queryParameters) where T : class
        {
            var webRequest = createWebRequestForAllEntities<T>(pageNumber: 1, queryParameters: queryParameters);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<GetAllResponse>(jsonResponse);

            var entities = new List<T>();

            foreach (var item in response.items)
            {
                entities.Add(Get<T>(item.id, queryParameters));
            }

            return entities;
        }

        public GetAllResponse GetAllSummary<T>(int pageNumber, Dictionary<string, string> queryParameters) where T : class
        {
            var webRequest = createWebRequestForAllEntities<T>(pageNumber: pageNumber, queryParameters: queryParameters);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            return JsonConvert.DeserializeObject<GetAllResponse>(jsonResponse);
        }

        public void Insert<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void RenewRefreshAndAccessToken()
        {
            _accessToken = _renewRefreshAndAccessToken();
        }

        private void setHeaders(HttpWebRequest webRequest, string accessToken, string subscriptionId, string resourceOwnerId)
        {
            webRequest.Headers.Add("X-Site", resourceOwnerId);
            webRequest.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionId);
            webRequest.ContentType = "application/json";
            webRequest.Headers.Add("Authorization", $"Bearer {accessToken}");
        }

        private string getRequest(HttpWebRequest webRequest)
        {
            string responseData = "";

            responseData = getWebResponse(webRequest);

            webRequest = null;

            return responseData;
        }

        private string getWebResponse(HttpWebRequest webRequest)
        {
            string responseData;

            using (var response = webRequest.GetResponse())
            using (var responseReader = new StreamReader(response.GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
            }

            return responseData;
        }

        private HttpWebRequest createWebRequestForAllEntities<T>(int pageNumber = 1, int pageSize = 100, Dictionary<string, string> queryParameters = null) where T : class
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

            return WebRequest.Create(uri) as HttpWebRequest;
        }

        private HttpWebRequest createWebRequestForSingleEntity<T>(string entityId = null, Dictionary<string, string> queryParameters = null) where T : class
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

            return WebRequest.Create(uri) as HttpWebRequest;
        }

        private string createBaseUriPath<T>() where T : class
        {
            var targetEntity = getTargetEntityPathFrom(typeof(T));

            var urlPath = $"{_baseUri}/{targetEntity}";

            return urlPath;
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
            { typeof(Transaction) , "transactions"},
        };
    }
}
