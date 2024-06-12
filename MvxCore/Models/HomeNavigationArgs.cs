using MvvmCross.ViewModels;

namespace MvxCore.Models;
public class HomeNavigationArgs
{
    public MvxObservableCollection<ShootingDrill> Drills { get; set; } = new();
    public MvxObservableCollection<ThreeOnThreeMatch> Matches { get; set; } = new();
}
