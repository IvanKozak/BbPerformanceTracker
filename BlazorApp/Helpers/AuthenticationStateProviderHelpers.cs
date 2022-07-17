using ClassLibrary.DataRepositories;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorApp.Helpers;

public static class AuthenticationStateProviderHelpers
{
    public static async Task<User> GetUserFromAuth(this AuthenticationStateProvider authProvider, IUserRepository userRepo)
    {
        var authState = await authProvider.GetAuthenticationStateAsync();
        var objectId = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("objectidentifier"))?.Value;
        return await userRepo.GetFromAuthentication(objectId);
    }
}
