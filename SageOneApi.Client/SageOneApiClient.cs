using Newtonsoft.Json;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace SageOneApi.Client
{
    public interface ISageOneApiClient
    {
        T Get<T>(string id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        GetAllResponse GetAllSummary<T>() where T : class;
        void Insert<T>() where T : class;
        void Update<T>() where T : class;
        void RenewRefreshAndAccessToken();
    }

    public class SageOneApiClient : ISageOneApiClient
    {
        private Uri _baseUri;
        private string _accessToken;
        private string _subscriptionId;
        private string _resourceOwnerId;
        private readonly Func<string> _renewRefreshAndAccessToken;

        public SageOneApiClient(Uri baseUri, string accessToken, string subscriptionId, string resourceOwnerId, Func<string> renewRefreshAndAccessToken)
        {
            _baseUri = baseUri;
            _accessToken = accessToken;
            _subscriptionId = subscriptionId;
            _resourceOwnerId = resourceOwnerId;
            _renewRefreshAndAccessToken = renewRefreshAndAccessToken;
        }

        public T Get<T>(string id) where T : class
        {
            var webRequest = createWebRequestForSingleEntity<T>(id);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            var webRequest = createWebRequestForAllEntities<T>(page: 1);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<GetAllResponse>(jsonResponse);

            var entities = new List<T>();

            foreach (var item in response.items)
            {
                entities.Add(Get<T>(item.id));
            }

            return entities;
        }

        public GetAllResponse GetAllSummary<T>() where T : class
        {
            var webRequest = createWebRequestForAllEntities<T>(page: 1);

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
            // Set the required header values on the web request
            webRequest.Headers.Add("X-Site", resourceOwnerId);
            webRequest.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionId);
            webRequest.ContentType = "application/json";

            string authorization = $"Bearer {accessToken}";
            webRequest.Headers.Add("Authorization", authorization);
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
            StreamReader responseReader = null;
            WebResponse response;
            string responseData = "";

            try
            {
                response = webRequest.GetResponse();
                responseReader = new StreamReader(response.GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }

        private HttpWebRequest createWebRequestForAllEntities<T>(int page = 1) where T : class
        {
            var uriPath = $"{createBaseUriPath<T>()}?page={page}&items_per_page=100";
            var uri = new Uri(uriPath);

            return WebRequest.Create(uri) as HttpWebRequest;
        }

        private HttpWebRequest createWebRequestForSingleEntity<T>(string entityId) where T : class
        {
            var uriPath = $"{createBaseUriPath<T>()}/{entityId}";
            var uri = new Uri(createBaseUriPath<T>());

            return WebRequest.Create(uri) as HttpWebRequest;
        }

        private string createBaseUriPath<T>() where T : class
        {
            var targetEntity = getTargetEntityPathFrom(typeof(T).Name);

            var urlPath = $"{_baseUri}/{targetEntity}";

            return urlPath;
        }

        private string getTargetEntityPathFrom(string typeName)
        {
            switch (typeName)
            {
                case "Contact": return "contacts";
                case "LedgerAccount": return "ledger_accounts";
            }

            throw new ArgumentException($"Working with entity '{typeName}' is currently unsupported");
        }
    }
}
