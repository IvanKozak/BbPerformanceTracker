using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.Identity.Web;

namespace ClientLibrary.Helpers;
public static class HttpClientHelpers
{

    public static async Task<HttpClient> PrepareAuthenticatedClient(this HttpClient httpClient,
        ITokenAcquisition tokenAcquisition, string scope)
    {
        var accessToken = await tokenAcquisition.GetAccessTokenForUserAsync(new[] { scope });
        Debug.WriteLine($"access token-{accessToken}");
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        return httpClient;
    }
}
