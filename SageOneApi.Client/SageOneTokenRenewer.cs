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
        private readonly IHttpClientFactory _httpClientFactory;

        public SageOneTokenRenewer(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<OAuth2TokenResponse> RenewRefreshAndAccessToken(string refreshToken, SageOneApiClientConfig config, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(config.ClientId, nameof(config.ClientId));
            ArgumentNullException.ThrowIfNull(config.ClientSecret, nameof(config.ClientSecret));

            using (var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = config.AccessTokenUri,
                Content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { AuthRequestParams.RefreshToken, refreshToken },
                    { AuthRequestParams.GrantType, AuthRequestParams.RefreshToken },
                    { AuthRequestParams.ClientId, config.ClientId },
                    { AuthRequestParams.ClientSecret, config.ClientSecret }
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
