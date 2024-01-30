using System.Net;
using System.Text;
using ClientLibrary.Helpers;
using ClientLibrary.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Newtonsoft.Json;

namespace ClientLibrary.Services;

public static class ThreeOnThreeMatchServiceExtensions
{
    public static void AddThreeOnThreeMatchService(this IServiceCollection services, IConfiguration configuration)
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        services.AddHttpClient<IThreeOnThreeMatchService, ThreeOnThreeMatchService>();
    }
}
public class ThreeOnThreeMatchService : IThreeOnThreeMatchService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenAcquisition _tokenAcquisition;
    private readonly string _Scope;
    private readonly string _BaseAddress;

    public ThreeOnThreeMatchService(ITokenAcquisition tokenAcquisition, HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _tokenAcquisition = tokenAcquisition;
        _Scope = configuration["UserRecords:Scope"];
        _BaseAddress = configuration["UserRecords:BaseAddress"];
    }

    public async Task<List<ThreeOnThreeMatch>> GetAsync()
    {
        await _httpClient.PrepareAuthenticatedClient(_tokenAcquisition, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/totmatches");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            List<ThreeOnThreeMatch> matches = JsonConvert.DeserializeObject<IEnumerable<ThreeOnThreeMatch>>(content).ToList();

            return matches;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task<List<ThreeOnThreeMatch>> GetByUserIdAsync(int id)
    {
        await _httpClient.PrepareAuthenticatedClient(_tokenAcquisition, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/users/{id}/totmatches");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            List<ThreeOnThreeMatch> matches = JsonConvert.DeserializeObject<IEnumerable<ThreeOnThreeMatch>>(content).ToList();

            return matches;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task AddAsync(ThreeOnThreeMatch match)
    {
        await _httpClient.PrepareAuthenticatedClient(_tokenAcquisition, _Scope);

        var jsonRequest = JsonConvert.SerializeObject(match);
        var jsoncontent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_BaseAddress}/totmatches", jsoncontent);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }
}
