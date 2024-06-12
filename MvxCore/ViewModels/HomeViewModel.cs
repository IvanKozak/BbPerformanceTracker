using System.Collections.Specialized;
using MvvmCross.ViewModels;
using MvxCore.Models;

namespace MvxCore.ViewModels;
public class HomeViewModel : MvxViewModel<HomeNavigationArgs>
{
    private MvxObservableCollection<ShootingDrill> _drills = new();
    private MvxObservableCollection<ThreeOnThreeMatch> _matches = new();
    private MatchesSummary _matchesSummary = default!;
    private DrillsSummary _drillsSummary = default!;

    public override void Prepare(HomeNavigationArgs args)
    {
        Drills = args.Drills;
        Matches = args.Matches;
        _matchesSummary = new(Matches);
        _drillsSummary = new(Drills);
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
            RaisePropertyChanged(() => DrillsSummary);
        }
    }

    public MvxObservableCollection<ThreeOnThreeMatch> Matches
    {
        get => _matches;
        set
        {
            if (_matches != value)
            {
                if (_matches != null)
                {
                    _matches.CollectionChanged -= OnMatchesChanged;
                }

                _matches = value;

                if (_matches != null)
                {
                    _matches.CollectionChanged += OnMatchesChanged;
                }
            }

            RaisePropertyChanged(() => Matches);
            RaisePropertyChanged(() => MatchesSummary);

        }
    }

    public MatchesSummary MatchesSummary
    {
        get => _matchesSummary;
        set => SetProperty(ref _matchesSummary, value);
    }

    public DrillsSummary DrillsSummary
    {
        get => _drillsSummary;
        set => SetProperty(ref _drillsSummary, value);
    }

    private void OnMatchesChanged(object? sender, NotifyCollectionChangedEventArgs e) => RaisePropertyChanged(() => MatchesSummary);

    private void OnDrillsChanged(object? sender, NotifyCollectionChangedEventArgs e) => RaisePropertyChanged(() => DrillsSummary);
}
