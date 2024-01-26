using System.Net;
using ClientLibrary.Helpers;
using ClientLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Web;
using Newtonsoft.Json;

namespace ClientLibrary.Services;

public static class UserServiceExtensions
{
    public static void AddUserService(this IServiceCollection services, IConfiguration configuration)
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
        services.AddHttpClient<IUserService, UserService>();
    }
}
public class UserService : IUserService
{
    private readonly HttpClient _httpClient;
    private readonly ITokenAcquisition _tokenAcquisition;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly string _Scope;
    private readonly string _BaseAddress;

    public UserService(ITokenAcquisition tokenAcquisition, HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor contextAccessor)
    {
        _httpClient = httpClient;
        _tokenAcquisition = tokenAcquisition;
        _contextAccessor = contextAccessor;
        _Scope = configuration["UserRecords:Scope"];
        _BaseAddress = configuration["UserRecords:BaseAddress"];
    }

    public async Task<User> GetAsync()
    {
        await _httpClient.PrepareAuthenticatedClient(_tokenAcquisition, _Scope);

        var response = await _httpClient.GetAsync($"{_BaseAddress}/users/current");
        if (response.StatusCode == HttpStatusCode.OK)
        {
            var content = await response.Content.ReadAsStringAsync();
            User user = JsonConvert.DeserializeObject<User>(content);

            return user;
        }

        throw new HttpRequestException($"Invalid status code in the HttpResponseMessage: {response.StatusCode}.");
    }
}
