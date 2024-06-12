namespace MvxCore.Models;
public class MatchesSummary
{
    private readonly IEnumerable<ThreeOnThreeMatch> _matches;

    public MatchesSummary(IEnumerable<ThreeOnThreeMatch> matches)
    {
        _matches = matches;
    }

    public double AveragePoints => Math.Round(_matches.Average(m => m.OwnPoints), 2);
    public double AverageAssists => Math.Round(_matches.Average(m => m.Assists), 2);
    public double AverageRebounds => Math.Round(_matches.Average(m => m.Rebounds), 2);
}
