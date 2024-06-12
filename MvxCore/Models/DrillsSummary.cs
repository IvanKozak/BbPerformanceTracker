namespace MvxCore.Models;
public class DrillsSummary
{
    private readonly IEnumerable<ShootingDrill> _drills;

    public DrillsSummary(IEnumerable<ShootingDrill> drills)
    {
        _drills = drills;
    }

    public double MidrangePercentage => _drills.Count() > 0 ? Math.Round(100 * _drills.Average(d => d.MidrangeShots.Accuracy), 1) : 0;
    public double PostupPercentage => _drills.Count() > 0 ? Math.Round(100 * _drills.Average(d => d.PostUps.Accuracy), 1) : 0;
    public double ThreepointPercentage => _drills.Count() > 0 ? Math.Round(100 * _drills.Average(d => d.ThreePointers.Accuracy), 1) : 0;
}
