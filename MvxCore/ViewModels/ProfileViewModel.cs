using System.Collections.Specialized;
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
    private readonly IShootingDrillRepository _drillRepo;
    private readonly IUserRepository _userRepo;
    private string _fullName = "";
    private User _loggedInUser;
    private MvxObservableCollection<ShootingDrill> _drills = new();

    public ProfileViewModel(IUserRepository userRepo, IShootingDrillRepository drillRepo)
    {
        _userRepo = userRepo;
        _drillRepo = drillRepo;
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
        Drills = new MvxObservableCollection<ShootingDrill>(drillList);
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

    public MvxObservableCollection<ShootingDrill> Drills
    {
        get => _drills;
        set
        {
            if (_drills != value)
            {
                if (_drills != null)
                {
                    _drills.CollectionChanged -= OnDrillsChanged;
                }

                _drills = value;

                if (_drills != null)
                {
                    _drills.CollectionChanged += OnDrillsChanged;
                }
            }

            RaisePropertyChanged(() => Drills);
            RaisePropertyChanged(() => MidrangePercentage);
            RaisePropertyChanged(() => ThreepointPercentage);
            RaisePropertyChanged(() => PostupPercentage);
        }
    }

    private double _midrangePercentage;

    public double MidrangePercentage
    {
        get => _drills.Count > 0 ? Math.Round(100 * _drills.Average(d => d.MidrangeShots.Accuracy), 1) : 0;
    }
    public double PostupPercentage
    {
        get => _drills.Count > 0 ? Math.Round(100 * _drills.Average(d => d.PostUps.Accuracy), 1) : 0;
    }
    public double ThreepointPercentage
    {
        get => _drills.Count > 0 ? Math.Round(100 * _drills.Average(d => d.ThreePointers.Accuracy), 1) : 0;
    }

    private void OnDrillsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        RaisePropertyChanged(() => MidrangePercentage);
        RaisePropertyChanged(() => PostupPercentage);
        RaisePropertyChanged(() => ThreepointPercentage);
    }

    private void AddDrill()
    {

    }

}
