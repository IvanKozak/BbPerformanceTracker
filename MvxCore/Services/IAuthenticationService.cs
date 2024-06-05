using Microsoft.Identity.Client;

namespace MvxCore.Services;
public interface IAuthenticationService
{
    Task<AuthenticationResult> AcquireToken();
}
