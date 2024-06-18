using System.IO;
using System.Windows.Interop;
using DesktopUI.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Desktop;
using MvxCore.Services;

namespace DesktopUI.Services;
public class WPFAuthenticationService : IAuthenticationService
{
    private readonly IConfiguration _config;
    private readonly IPublicClientApplication _publicClientApp;


    public WPFAuthenticationService(IConfiguration config)
    {
        _config = config;

        var instance = config.GetValue<string>("AzureAdB2C:Instance");
        var domain = config.GetValue<string>("AzureAdB2C:Domain");
        var authorityBase = $"{instance}/tfp/{domain}/";
        var signUpSignInPolicyId = config.GetValue<string>("AzureAdB2C:SignUpSignInPolicyId");
        var callbackPath = config.GetValue<string>("AzureAdB2C:CallbackPath");

        _publicClientApp = PublicClientApplicationBuilder.Create(config.GetValue<string>("AzureAdB2C:ClientId"))
            .WithB2CAuthority($"{authorityBase}{signUpSignInPolicyId}")
            .WithRedirectUri($"{instance}{callbackPath}")
            .WithWindowsEmbeddedBrowserSupport()
            .WithLogging(Log, LogLevel.Info, true)
            .Build();

        TokenCacheHelper.Bind(_publicClientApp.UserTokenCache);
    }
    public Task<AuthenticationResult> AcquireTokenInteractive(string[] scopes)
    {
        return _publicClientApp.AcquireTokenInteractive(scopes)
            .WithParentActivityOrWindow(new WindowInteropHelper(App.Current.MainWindow).Handle)
            .ExecuteAsync();
    }

    public async Task<AuthenticationResult> AcquireTokenSilent(string[] scopes)
    {
        var signUpSignInPolicyId = _config.GetValue<string>("AzureAdB2C:SignUpSignInPolicyId");
        var accounts = await _publicClientApp.GetAccountsAsync(signUpSignInPolicyId);
        return await _publicClientApp.AcquireTokenSilent(scopes, accounts.FirstOrDefault())
            .ExecuteAsync();
    }

    public async Task ClearTokenCache()
    {
        var accounts = await _publicClientApp.GetAccountsAsync();
        while (accounts.Any())
        {
            await _publicClientApp.RemoveAsync(accounts.First());
            accounts = await _publicClientApp.GetAccountsAsync();
        }
    }

    private static void Log(LogLevel level, string message, bool containsPii)
    {
        string logs = $"{level} {message}{Environment.NewLine}";
        File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".msalLogs.txt", logs);
    }
}
