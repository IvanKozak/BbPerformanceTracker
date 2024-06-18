using Microsoft.Identity.Client;

namespace MvxCore.Services;
public interface IAuthenticationService
{
    Task<AuthenticationResult> AcquireTokenInteractive(string[] scopes);
    Task<AuthenticationResult> AcquireTokenSilent(string[] scopes);
    Task ClearTokenCache();
}
