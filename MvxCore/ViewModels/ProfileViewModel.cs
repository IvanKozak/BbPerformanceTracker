using Microsoft.Identity.Client;
using MvvmCross.ViewModels;
using MvxCore.Helpers;
using MvxCore.Models;
using MvxCore.Repositories;
using Newtonsoft.Json.Linq;

namespace MvxCore.ViewModels;
public class ProfileViewModel : MvxViewModel<AuthenticationResult>
{
    private AuthenticationResult _authResult = default!;
    private string _fullName = "";
    private User _loggedInUser;
    private readonly IUserRepository _userRepo;

    public ProfileViewModel(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }
    public override void Prepare(AuthenticationResult parameter)
    {
        _authResult = parameter;
        JObject user = TokenHelper.ParseIdToken(_authResult.IdToken);
        FullName = user["name"]?.ToString() ?? "Dear User";
    }

    public override async Task Initialize()
    {
        await base.Initialize();
        _loggedInUser = await _userRepo.GetAsync();
        FullName = _loggedInUser.Nickname;
    }


    public User LoggedInUser
    {
        get => _loggedInUser;
        set => SetProperty(ref _loggedInUser, value);
    }


    public string FullName
    {
        get => _fullName;
        set => SetProperty(ref _fullName, value);
    }
}
