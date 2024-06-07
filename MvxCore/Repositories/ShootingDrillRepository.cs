using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using MvxCore.Helpers;
using MvxCore.Models;
using MvxCore.Services;
using Newtonsoft.Json;

namespace MvxCore.Repositories;

public class ShootingDrillRepository : IShootingDrillRepository
{
    private readonly HttpClient _httpClient;
    private readonly IAuthenticationService _auth;
    private readonly string _Scope;
    private readonly string _BaseAddress;

    public ShootingDrillRepository(IAuthenticationService auth, HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _auth = auth;
        _Scope = configuration["UserRecords:Scope"];
        _BaseAddress = configuration["UserRecords:BaseAddress"];
    }

    public async Task<List<ShootingDrill>> GetAsync()
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/shootingdrills");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var shootingDrills = JsonConvert.DeserializeObject<IEnumerable<ShootingDrill>>(content).ToList();

            return shootingDrills;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task<List<ShootingDrill>> GetByUserIdAsync(int id)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/users/{id}/shootingdrills");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var shootingDrills = JsonConvert.DeserializeObject<IEnumerable<ShootingDrill>>(content).ToList();

            return shootingDrills;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task AddAsync(ShootingDrill drill)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var jsonRequest = JsonConvert.SerializeObject(drill);
        var jsoncontent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_BaseAddress}/shootingdrills", jsoncontent);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }
}
