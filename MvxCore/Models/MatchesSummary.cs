namespace MvxCore.Models;
public class MatchesSummary
{
    private readonly IEnumerable<ThreeOnThreeMatch> _matches;

    public MatchesSummary(IEnumerable<ThreeOnThreeMatch> matches)
    {
        _matches = matches;
    }

    public double AveragePoints => _matches.Count() > 0 ? Math.Round(_matches.Average(m => m.OwnPoints), 2) : 0;
    public double AverageAssists => _matches.Count() > 0 ? Math.Round(_matches.Average(m => m.Assists), 2) : 0;
    public double AverageRebounds => _matches.Count() > 0 ? Math.Round(_matches.Average(m => m.Rebounds), 2) : 0;
}
