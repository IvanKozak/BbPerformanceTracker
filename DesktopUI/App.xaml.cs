using System.IO;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Desktop;
using MvvmCross.Core;
using MvvmCross.Platforms.Wpf.Views;

namespace DesktopUI;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : MvxApplication
{
    protected override void RegisterSetup()
    {
        this.RegisterSetupType<Setup>();
    }
    /// <summary>
    /// B2C tenant name
    /// </summary>
    private static readonly string TenantName = "ivcoauth";
    private static readonly string Tenant = $"{TenantName}.onmicrosoft.com";
    private static readonly string AzureAdB2CHostname = $"{TenantName}.b2clogin.com";

    /// <summary>
    /// ClientId for the application which initiates the login functionality (this app)  
    /// </summary>
    private static readonly string ClientId = "e520723d-abf0-4be7-8e2d-3a74bd4e8a36";

    /// <summary>
    /// Should be one of the choices on the Azure AD B2c / [This App] / Authentication blade
    /// </summary>
    private static readonly string RedirectUri = $"https://{TenantName}.b2clogin.com/oauth2/nativeclient";

    /// <summary>
    /// From Azure AD B2C / UserFlows blade
    /// </summary>
    public static string PolicySignUpSignIn = "B2C_1_susi";
    public static string PolicyEditProfile = "B2C_1_edit";
    public static string PolicyResetPassword = "B2C_1_reset";

    /// <summary>
    /// Note: AcquireTokenInteractive will fail to get the AccessToken if "Admin Consent" has not been granted to this scope.  To achieve this:
    /// 
    /// 1st: Azure AD B2C / App registrations / [API App] / Expose an API / Add a scope
    /// 2nd: Azure AD B2C / App registrations / [This App] / API Permissions / Add a permission / My APIs / [API App] / Select & Add Permissions
    /// 3rd: Azure AD B2C / App registrations / [This App] / API Permissions / ... (next to add a permission) / Grant Admin Consent for [tenant]
    /// </summary>
    public static string[] ApiScopes = { $"https://ivcoauth.onmicrosoft.com/f76eca94-4ce8-4e43-8d72-ccedb7fcdfb2/access_as_user" };

    /// <summary>
    /// URL for API which will receive the bearer token corresponding to this authentication
    /// </summary>
    public static string ApiEndpoint = "https://localhost:7183";

    // Shouldn't need to change these:
    private static string AuthorityBase = $"https://{AzureAdB2CHostname}/tfp/{Tenant}/";
    public static string AuthoritySignUpSignIn = $"{AuthorityBase}{PolicySignUpSignIn}";
    public static string AuthorityEditProfile = $"{AuthorityBase}{PolicyEditProfile}";
    public static string AuthorityResetPassword = $"{AuthorityBase}{PolicyResetPassword}";

    public static IPublicClientApplication PublicClientApp { get; private set; }

    static App()
    {
        PublicClientApp = PublicClientApplicationBuilder.Create(ClientId)
            .WithB2CAuthority(AuthoritySignUpSignIn)
            .WithRedirectUri(RedirectUri)
            .WithWindowsEmbeddedBrowserSupport()
            .WithLogging(Log, LogLevel.Info, true)
            .Build();

        TokenCacheHelper.Bind(PublicClientApp.UserTokenCache);
    }

    private static void Log(LogLevel level, string message, bool containsPii)
    {
        string logs = $"{level} {message}{Environment.NewLine}";
        File.AppendAllText(System.Reflection.Assembly.GetExecutingAssembly().Location + ".msalLogs.txt", logs);
    }
}

