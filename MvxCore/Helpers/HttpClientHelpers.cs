using System.Diagnostics;
using System.Net.Http.Headers;
using MvxCore.Services;

namespace MvxCore.Helpers;
public static class HttpClientHelpers
{

    public static async Task<HttpClient> PrepareAuthenticatedClient(this HttpClient httpClient,
        IAuthenticationService auth, string scope)
    {
        var result = await auth.AcquireTokenSilent([scope]);
        var accessToken = result.AccessToken;
        Debug.WriteLine($"access token-{accessToken}");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }
}
