using Microsoft.Identity.Client;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxCore.Helpers;
using MvxCore.Models;
using MvxCore.Repositories;
using Newtonsoft.Json.Linq;

namespace MvxCore.ViewModels;
public class ProfileViewModel : MvxViewModel<AuthenticationResult>
{
    private AuthenticationResult _authResult = default!;
    private readonly IUserRepository _userRepo;
    private readonly IShootingDrillRepository _drillRepo;
    private readonly IThreeOnThreeMatchRepository _matchRepo;
    private readonly IMvxNavigationService _navigation;
    private string _fullName = "";
    private User? _loggedInUser = default!;
    private MvxObservableCollection<ShootingDrill> _drills = new();
    private MvxObservableCollection<ThreeOnThreeMatch> _matches = new();

    public ProfileViewModel(IUserRepository userRepo,
                            IShootingDrillRepository drillRepo,
                            IThreeOnThreeMatchRepository matchRepo,
                            IMvxNavigationService navigation)
    {
        _userRepo = userRepo;
        _drillRepo = drillRepo;
        _matchRepo = matchRepo;
        _navigation = navigation;

        NavigateCommand = new MvxAsyncCommand<string>(OnNavigate);
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

        var drillList = await _drillRepo.GetAsync();
        _drills = new MvxObservableCollection<ShootingDrill>(drillList);
        var matchList = await _matchRepo.GetAsync();
        _matches = new MvxObservableCollection<ThreeOnThreeMatch>(matchList);
    }

    public IMvxCommand<string> NavigateCommand { get; set; }

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

    private async Task OnNavigate(string? d)
    {
        switch (d)
        {
            case "Home":
                await _navigation.Navigate<HomeViewModel, HomeNavigationArgs>(new HomeNavigationArgs
                {
                    Drills = _drills,
                    Matches = _matches
                });
                break;
            default:
                break;
        }
    }
}
