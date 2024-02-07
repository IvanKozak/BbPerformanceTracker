using BlazorApp.Helpers;
using ClientLibrary.Models;

namespace BbPerformanceTracker.Tests.BlazorAppTests.Helpers;
public class ThreeOnThreeMatchExtentionsTests
{
    private readonly User _user;

    public ThreeOnThreeMatchExtentionsTests()
    {
        _user = new User()
        {
            Id = 2,
            Nickname = "a",
            B2CIdentifier = "b"
        };
    }

    [Fact]
    public void EffectiveFieldGoalPercentage_ShouldReturnZeroWhenZeroFieldGoalAttempts()
    {
        var match = new ThreeOnThreeMatch(
            1,
            _user,
            new DateTime(3),
            new Score(400, 500),
            new ShootingRecord(0, 0),
            new ShootingRecord(0, 0),
            new ShootingRecord(10, 11),
            12,
            13);

        var result = match.EffectiveFieldGoalPercentage();

        result.Should().Be(0);
    }

    [Theory]
    [InlineData(1, 2, 0, 0, 50)]
    [InlineData(0, 0, 1, 2, 100)]
    [InlineData(1, 2, 1, 2, 75)]
    public void EffectiveFieldGoalPercentage_ShouldReturnCorrectPercentage(int onePointMakes, int onePointAttempts,
                                                                           int twoPointsMakes, int twoPointsAttempts,
                                                                           decimal expected)
    {
        var match = new ThreeOnThreeMatch(
            1,
            _user,
            new DateTime(3),
            new Score(400, 500),
            new ShootingRecord(onePointMakes, onePointAttempts),
            new ShootingRecord(twoPointsMakes, twoPointsAttempts),
            new ShootingRecord(10, 11),
            12,
            13);

        var result = match.EffectiveFieldGoalPercentage();

        result.Should().Be(expected);
    }
}
