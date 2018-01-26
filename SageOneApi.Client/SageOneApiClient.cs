using Newtonsoft.Json;
using SageOneApi.Client.Models;
using SageOneApi.Client.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace SageOneApi.Client
{
    public interface IApiClient
    {
        T Get<T>(string id) where T : class;
        IEnumerable<T> GetAll<T>() where T : class;
        void Insert<T>() where T : class;
        void Update<T>() where T : class;
    }

    public class SageOneApiClient : IApiClient
    {
        private Uri _baseUri;
        private string _accessToken;
        private string _subscriptionId;
        private string _resourceOwnerId;

        public SageOneApiClient(Uri baseUri, string accessToken, string subscriptionId, string resourceOwnerId)
        {
            _baseUri = baseUri;
            _accessToken = accessToken;
            _subscriptionId = subscriptionId;
            _resourceOwnerId = resourceOwnerId;
        }

        public T Get<T>(string id) where T : class
        {
            var webRequest = createWebRequest<T>(id);

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<T>(jsonResponse);

            return response;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {      
            var webRequest = createWebRequest<T>();

            setHeaders(webRequest, _accessToken, _subscriptionId, _resourceOwnerId);

            var jsonResponse = getRequest(webRequest);

            var response = JsonConvert.DeserializeObject<GetAllResponse>(jsonResponse);

            var entities = new List<T>();

            foreach(var item in response.items)
            {
                entities.Add(Get<T>(item.id));
            }

            return entities;
        }

        public void Insert<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public void Update<T>() where T : class
        {
            throw new NotImplementedException();
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
            catch (WebException webex)
            {
                string text;

                using (var sr = new StreamReader(webex.Response.GetResponseStream()))
                {
                    text = sr.ReadToEnd();
                }

                throw new Exception(text, webex);

            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }
            finally
            {
                webRequest.GetResponse().GetResponseStream().Close();
                responseReader.Close();
                responseReader = null;
            }

            return responseData;
        }

        private HttpWebRequest createWebRequest<T>(string entityId = null) where T : class
        {
            return WebRequest.Create(createUri<T>(entityId)) as HttpWebRequest;
        }

        private Uri createUri<T>(string entityId = null) where T : class
        {
            var targetEntity = getTargetEntityPathFrom(typeof(T).Name);

            var urlPath = $"{_baseUri}/{targetEntity}";

            urlPath = entityId != null ? $"{urlPath}/{entityId}" : urlPath;

            return new Uri(urlPath);
        }

        private string getTargetEntityPathFrom(string typeName)
        {
            switch (typeName)
            {
                case "Contact": return "contact";
                case "LedgerAccount": return "ledger_accounts";
            }

            throw new ArgumentException($"Working with entity '{typeName}' is currently unsupported");
        }
    }
}
