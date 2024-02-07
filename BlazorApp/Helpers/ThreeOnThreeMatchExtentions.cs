using ClientLibrary.Models;

namespace BlazorApp.Helpers;

public static class ThreeOnThreeMatchExtentions
{
    public static decimal EffectiveFieldGoalPercentage(this ThreeOnThreeMatch match)
    {
        var fieldAttempts = match.OnePointShots.Attempts + match.TwoPointShots.Attempts;
        if (fieldAttempts == 0)
        {
            return 0;
        }
        return (match.OwnPoints - match.FreeThrows.Makes) * 100 / fieldAttempts;
    }
}
