using System.Text;
using Microsoft.Identity.Client;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using MvxCore.Services;
using Newtonsoft.Json.Linq;

namespace MvxCore.ViewModels;
public class GreetViewModel : MvxViewModel
{
    private string _resultText;
    private string _tokenInfo;
    private bool _isSignedIn;
    private readonly IAuthenticationService _auth;

    public GreetViewModel(IAuthenticationService auth)
    {
        _auth = auth;

        SignInCommand = new MvxCommand(SignIn);
    }
    public IMvxCommand SignInCommand { get; set; }

    public string ResultText
    {
        get => _resultText;
        set => SetProperty(ref _resultText, value);
    }

    public string TokenInfo
    {
        get => _tokenInfo;
        set => SetProperty(ref _tokenInfo, value);
    }

    public bool IsSignedIn
    {
        get => _isSignedIn;
        set
        {
            SetProperty(ref _isSignedIn, value);
            RaisePropertyChanged(() => IsSignedOut);
        }
    }
    public bool IsSignedOut => !IsSignedIn;

    private async void SignIn()
    {
        AuthenticationResult authResult = null;
        try
        {
            ResultText = "";
            authResult = await _auth.AcquireToken();

            DisplayUserInfo(authResult);
            UpdateSignInState(true);
        }
        catch (Exception ex)
        {
            ResultText = $"Error Acquiring Token:{Environment.NewLine}{ex}";
        }

        DisplayUserInfo(authResult);
    }

    private void UpdateSignInState(bool signedIn)
    {
        if (signedIn)
        {
            IsSignedIn = true;
            //CallApiButton.Visibility = Visibility.Visible;
            //EditProfileButton.Visibility = Visibility.Visible;
            //SignOutButton.Visibility = Visibility.Visible;

            //SignInButton.Visibility = Visibility.Collapsed;
        }
        else
        {
            IsSignedIn = false;
            ResultText = "";
            TokenInfo = "";

            //CallApiButton.Visibility = Visibility.Collapsed;
            //EditProfileButton.Visibility = Visibility.Collapsed;
            //SignOutButton.Visibility = Visibility.Collapsed;

            //SignInButton.Visibility = Visibility.Visible;
        }
    }

    private void DisplayUserInfo(AuthenticationResult authResult)
    {
        if (authResult != null)
        {
            JObject user = ParseIdToken(authResult.IdToken);

            TokenInfo = "";
            TokenInfo += $"Name: {user["name"]?.ToString()}" + Environment.NewLine;
            TokenInfo += $"User Identifier: {user["oid"]?.ToString()}" + Environment.NewLine;
            TokenInfo += $"Street Address: {user["streetAddress"]?.ToString()}" + Environment.NewLine;
            TokenInfo += $"City: {user["city"]?.ToString()}" + Environment.NewLine;
            TokenInfo += $"State: {user["state"]?.ToString()}" + Environment.NewLine;
            TokenInfo += $"Country: {user["country"]?.ToString()}" + Environment.NewLine;
            TokenInfo += $"Job Title: {user["jobTitle"]?.ToString()}" + Environment.NewLine;

            if (user["emails"] is JArray emails)
            {
                TokenInfo += $"Emails: {emails[0].ToString()}" + Environment.NewLine;
            }
            TokenInfo += $"Identity Provider: {user["iss"]?.ToString()}" + Environment.NewLine;
        }
    }

    JObject ParseIdToken(string idToken)
    {
        // Parse the idToken to get user info
        idToken = idToken.Split('.')[1];
        idToken = Base64UrlDecode(idToken);
        return JObject.Parse(idToken);
    }

    private string Base64UrlDecode(string s)
    {
        s = s.Replace('-', '+').Replace('_', '/');
        s = s.PadRight(s.Length + (4 - s.Length % 4) % 4, '=');
        var byteArray = Convert.FromBase64String(s);
        var decoded = Encoding.UTF8.GetString(byteArray, 0, byteArray.Count());
        return decoded;
    }
}
