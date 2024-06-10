using System.Collections.Specialized;
using MvvmCross.ViewModels;
using MvxCore.Models;

namespace MvxCore.ViewModels;
public class HomeViewModel : MvxViewModel<MvxObservableCollection<ShootingDrill>>
{
    private MvxObservableCollection<ShootingDrill> _drills = new();
    public override void Prepare(MvxObservableCollection<ShootingDrill> parameter)
    {
        Drills = parameter;
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

    private void OnDrillsChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        RaisePropertyChanged(() => MidrangePercentage);
        RaisePropertyChanged(() => PostupPercentage);
        RaisePropertyChanged(() => ThreepointPercentage);
    }

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

}
