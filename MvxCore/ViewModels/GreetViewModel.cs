using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxCore.Services;

namespace MvxCore.ViewModels;
public class GreetViewModel : MvxViewModel
{
    private readonly IAuthenticationService _auth;
    private readonly IConfiguration _config;
    private readonly IMvxNavigationService _navigation;

    public GreetViewModel(IAuthenticationService auth, IConfiguration config, IMvxNavigationService navigation)
    {
        _auth = auth;
        _config = config;
        _navigation = navigation;
        SignInCommand = new MvxAsyncCommand(SignIn);
    }
    public IMvxCommand SignInCommand { get; set; }

    private async Task SignIn()
    {
        AuthenticationResult authResult = null;
        authResult = await _auth.AcquireTokenInteractive([_config["UserRecords:Scope"]]);
        await _navigation.Navigate<ProfileViewModel, AuthenticationResult>(authResult);
        await _navigation.Close(this);
    }
}
