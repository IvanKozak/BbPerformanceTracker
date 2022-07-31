namespace ClassLibrary.Models;

public record class ThreeOnThreeMatch
{
    public ThreeOnThreeMatch(int id,
    User player, DateTime accomplished,
    Score gameScore,
    ShootingRecord onePointShots,
    ShootingRecord twoPointShots,
    ShootingRecord freeThrows,
    int rebounds,
    int assists)
    {
        OwnPoints = onePointShots.Makes + (twoPointShots.Makes * 2) + freeThrows.Makes;
        var teammatesScored = gameScore.OwnTeamScore - OwnPoints;
        if (assists > teammatesScored)
        {
            throw new InvalidAssistsException();
        }
        if (OwnPoints > gameScore.OwnTeamScore)
        {
            throw new ScoredMoreThanWholeTeamException();
        }

        Id = id;
        Player = player;
        Accomplished = accomplished;
        GameScore = gameScore;
        IsWin = gameScore.OwnTeamScore > gameScore.OwnTeamScore;
        OnePointShots = onePointShots;
        TwoPointShots = twoPointShots;
        FreeThrows = freeThrows;
        Rebounds = rebounds;
        Assists = assists;

    }

    public int Id { get; init; }
    public User Player { get; init; }
    public DateTime Accomplished { get; init; }
    public Score GameScore { get; init; }
    public bool IsWin { get; }
    public ShootingRecord OnePointShots { get; init; }
    public ShootingRecord TwoPointShots { get; init; }
    public ShootingRecord FreeThrows { get; init; }
    public int Rebounds { get; init; }
    public int Assists { get; init; }
    public int OwnPoints { get; }
}

public class InvalidAssistsException : Exception
{
    public InvalidAssistsException()
        : base($"Can't make more assists than your teammates scored points.")
    {

    }
}

public class ScoredMoreThanWholeTeamException : Exception
{
    public ScoredMoreThanWholeTeamException()
        : base($"Can't score more points than whole team.")
    {

    }
}
