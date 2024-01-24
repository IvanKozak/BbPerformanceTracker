using System.Diagnostics;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using ClientLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Newtonsoft.Json;

namespace ClientLibrary.Services;

public static class ShootingDrillServiceExtensions
{
    public static void AddShootingDrillService(this IServiceCollection services, IConfiguration configuration)
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        services.AddHttpClient<IShootingDrillService, ShootingDrillService>();
    }
}
public class ShootingDrillService : IShootingDrillService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenAcquisition _tokenAcquisition;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly string _Scope;
    private readonly string _BaseAddress;

    public ShootingDrillService(ITokenAcquisition tokenAcquisition, HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _httpClient = httpClient;
        _tokenAcquisition = tokenAcquisition;
        _contextAccessor = contextAccessor;
        _Scope = configuration["UserRecords:Scope"];
        _BaseAddress = configuration["UserRecords:BaseAddress"];
    }

    public async Task<List<ShootingDrill>> GetAsync()
    {
        await PrepareAuthenticatedClient();

        var response = await _httpClient.GetAsync($"{_BaseAddress}/shootingdrills");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            List<ShootingDrill> shootingDrills = JsonConvert.DeserializeObject<IEnumerable<ShootingDrill>>(content).ToList();

            return shootingDrills;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task AddAsync(ShootingDrill drill)
    {
        await PrepareAuthenticatedClient();

        var jsonRequest = JsonConvert.SerializeObject(drill);
        var jsoncontent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_BaseAddress}/shootingdrills", jsoncontent);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }


    private async Task PrepareAuthenticatedClient()
    {
        var accessToken = await _tokenAcquisition.GetAccessTokenForUserAsync(new[] { _Scope });
        Debug.WriteLine($"access token-{accessToken}");
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}
