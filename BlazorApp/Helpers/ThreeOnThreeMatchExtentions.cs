using ClientLibrary.Models;

namespace BlazorApp.Helpers;

public static class ThreeOnThreeMatchExtentions
{
    public static decimal EffectiveFieldGoalPercentage(this ThreeOnThreeMatch match)
    {
        return (match.OwnPoints - match.FreeThrows.Makes) * 100 / (match.OnePointShots.Attempts + match.TwoPointShots.Attempts);
    }
}
