using ClientLibrary.Models;

namespace BbPerformanceTracker.Tests.ClientLibraryTests.Models;
public class ShootingRecordTests
{
    [Fact]
    public void ShootingRecord_IfMakesMoreThanAttempts_ShouldThrow()
    {
        Assert.Throws<MakesMoreThanAttemptsException>(() => new ShootingRecord(10, 5));
    }

    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 2, 0.5)]
    [InlineData(3, 3, 1)]
    public void Accuracy_ShouldReturnCorrectAccuracy(int makes, int attempts, double expected)
    {
        var record = new ShootingRecord(makes, attempts);

        var result = record.Accuracy;

        result.Should().Be(expected);
    }
}
