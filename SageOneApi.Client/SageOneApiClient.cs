using System;

namespace SageOneApi.Client
{
    public class SageOneApiClient : SageOneApiClientBaseHandler
    {
        public SageOneApiClient(
            Uri baseUri,
            string accessToken,
            string subscriptionId,
            string resourceOwnerId,
            Func<string> renewRefreshAndAccessToken) : base(
                new SageOneApiClientPagingHandler(
                    new SageOneApiClientExceptionHandler(
                        new SageOneApiClientTransferHandler(baseUri, accessToken, subscriptionId, resourceOwnerId, renewRefreshAndAccessToken))))
        { }
    }
}
