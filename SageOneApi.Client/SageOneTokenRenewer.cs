using SageOneApi.Client.Constants;
using SageOneApi.Client.Exceptions;
using SageOneApi.Client.Responses;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SageOneApi.Client
{
    public class SageOneTokenRenewer
    {
        private readonly SageOneApiClientConfig _config;
        private readonly IHttpClientFactory _httpClientFactory;

        public SageOneTokenRenewer(SageOneApiClientConfig config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<OAuth2TokenResponse> RenewRefreshAndAccessToken(string refreshToken, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(_config.ClientId, nameof(_config.ClientId));
            ArgumentNullException.ThrowIfNull(_config.ClientSecret, nameof(_config.ClientSecret));

            using (var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = _config.AccessTokenUri,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { AuthRequestParams.RefreshToken, refreshToken },
                    { AuthRequestParams.GrantType, AuthRequestParams.RefreshToken },
                    { AuthRequestParams.ClientId, _config.ClientId },
                    { AuthRequestParams.ClientSecret, _config.ClientSecret }
                })
            })
            using (var response = await _httpClientFactory.CreateClient().SendAsync(request, cancellationToken).ConfigureAwait(false))
            {
                if (!response.IsSuccessStatusCode)
                {
                    var responseString = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                    throw new SageOneApiRequestFailedException(response.StatusCode, response.Headers, responseString);
                }
                else
                {
                    using (var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false))
                    {
                        var tokenResponse = JsonDeserializer.DeserializeObject<OAuth2TokenResponse>(stream);

                        return tokenResponse;
                    }
                }
            }
        }
    }
}
