using System.Windows.Interop;
using Microsoft.Identity.Client;
using MvxCore.Services;

namespace DesktopUI.Services;
public class WPFAuthenticationService : IAuthenticationService
{
    public async Task<AuthenticationResult> AcquireToken()
    {
        var app = App.PublicClientApp;
        return await app.AcquireTokenInteractive(App.ApiScopes).WithParentActivityOrWindow(new WindowInteropHelper(App.Current.MainWindow).Handle).ExecuteAsync();
    }
}
