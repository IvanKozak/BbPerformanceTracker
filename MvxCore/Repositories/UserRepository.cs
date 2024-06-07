using System.Net;
using System.Text;
using Microsoft.Extensions.Configuration;
using MvxCore.Helpers;
using MvxCore.Models;
using MvxCore.Services;
using Newtonsoft.Json;

namespace MvxCore.Repositories;

public class UserRepository : IUserRepository
{
    private readonly HttpClient _httpClient;
    private readonly IAuthenticationService _auth;
    private readonly string _Scope;
    private readonly string _BaseAddress;

    public UserRepository(IAuthenticationService auth, HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _auth = auth;
        _Scope = configuration["UserRecords:Scope"];
        _BaseAddress = configuration["UserRecords:BaseAddress"];
    }

    public async Task<User> GetAsync()
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/users/current");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task<User> GetByIdAsync(int id)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/users/{id}");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            var user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task AddAsync(User user)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var jsonRequest = JsonConvert.SerializeObject(user);
        var jsoncontent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync($"{_BaseAddress}/users", jsoncontent);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }

    public async Task UpdateAsync(User user)
    {
        await _httpClient.PrepareAuthenticatedClient(_auth, _Scope);

        var jsonRequest = JsonConvert.SerializeObject(user);
        var jsoncontent = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync($"{_BaseAddress}/users", jsoncontent);

        if (response.StatusCode == HttpStatusCode.OK)
        {
            return;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }
}
