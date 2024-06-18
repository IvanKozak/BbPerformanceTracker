using Microsoft.Identity.Client;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using MvxCore.Helpers;
using MvxCore.Models;
using MvxCore.Repositories;
using MvxCore.Services;
using Newtonsoft.Json.Linq;

namespace MvxCore.ViewModels;
public class ProfileViewModel : MvxViewModel<AuthenticationResult>
{
    private AuthenticationResult _authResult = default!;
    private readonly IUserRepository _userRepo;
    private readonly IShootingDrillRepository _drillRepo;
    private readonly IThreeOnThreeMatchRepository _matchRepo;
    private readonly IMvxNavigationService _navigation;
    private readonly IAuthenticationService _auth;
    private string _fullName = "";
    private User? _loggedInUser = default!;
    private MvxObservableCollection<ShootingDrill> _drills = default!;
    private MvxObservableCollection<ThreeOnThreeMatch> _matches = default!;
    private bool _dataLoaded = false;

    public ProfileViewModel(IUserRepository userRepo,
                            IShootingDrillRepository drillRepo,
                            IThreeOnThreeMatchRepository matchRepo,
                            IMvxNavigationService navigation,
                            IAuthenticationService auth)
    {
        _userRepo = userRepo;
        _drillRepo = drillRepo;
        _matchRepo = matchRepo;
        _navigation = navigation;
        _auth = auth;
        NavigateCommand = new MvxAsyncCommand<string>(OnNavigate);
        SignOutCommand = new MvxAsyncCommand(OnSignOut);
    }

    public IMvxCommand<string> NavigateCommand { get; set; }
    public IMvxCommand SignOutCommand { get; set; }

    public bool DataLoaded
    {
        get => _dataLoaded;
        set
        {
            SetProperty(ref _dataLoaded, value);
            RaisePropertyChanged(() => DataNotLoaded);
        }
    }

    public bool DataNotLoaded => !DataLoaded;

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

    public override void Prepare(AuthenticationResult parameter)
    {
        _authResult = parameter;
        JObject user = TokenHelper.ParseIdToken(_authResult.IdToken);
        FullName = user["name"]?.ToString() ?? "Dear User";
    }

    public override async Task Initialize()
    {
        await base.Initialize();

        await LoadData();
        DataLoaded = true;

        await _navigation.Navigate<HomeViewModel, HomeNavigationArgs>(new HomeNavigationArgs
        {
            Drills = _drills,
            Matches = _matches
        });
    }

    private async Task LoadData()
    {
        _loggedInUser = await _userRepo.GetAsync();
        FullName = _loggedInUser.Nickname;

        var drillList = await _drillRepo.GetAsync();
        _drills = new MvxObservableCollection<ShootingDrill>(drillList);
        var matchList = await _matchRepo.GetAsync();
        _matches = new MvxObservableCollection<ThreeOnThreeMatch>(matchList);
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

    private async Task OnSignOut()
    {
        await _auth.ClearTokenCache();
        await _navigation.Close(this);
    }
}
