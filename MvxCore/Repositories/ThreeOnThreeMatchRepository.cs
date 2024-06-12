using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using MvxCore.Helpers;
using MvxCore.Models;
using MvxCore.Services;
using Newtonsoft.Json;

namespace MvxCore.Repositories;

public class ThreeOnThreeMatchRepository : IThreeOnThreeMatchRepository
{
    private readonly HttpClient _httpClient;
    private readonly IAuthenticationService _auth;
    private readonly string _Scope;
    private readonly string _BaseAddress;

    public ThreeOnThreeMatchRepository(HttpClient httpClient, IAuthenticationService auth, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _auth = auth;
        _Scope = configuration["UserRecords:Scope"];
        _BaseAddress = configuration["UserRecords:BaseAddress"];
    }

    public async Task<List<ThreeOnThreeMatch>> GetAsync()
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/totmatches");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var matches = JsonConvert.DeserializeObject<IEnumerable<ThreeOnThreeMatch>>(content).ToList();

            return matches;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task<List<ThreeOnThreeMatch>> GetByUserIdAsync(int id)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/users/{id}/totmatches");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var matches = JsonConvert.DeserializeObject<IEnumerable<ThreeOnThreeMatch>>(content).ToList();

            return matches;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task AddAsync(ThreeOnThreeMatch match)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

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
