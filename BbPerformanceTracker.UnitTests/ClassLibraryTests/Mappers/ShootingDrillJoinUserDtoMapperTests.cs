using ClassLibrary.Mappers;
using ClassLibrary.Models;

namespace BbPerformanceTracker.Tests.ClassLibraryTests.Mappers;
public class ShootingDrillJoinUserDtoMapperTests
{
    private readonly ShootingDrillJoinUserDto _drillJoinUserDto;
    private readonly User _user;
    private readonly ShootingDrill _shootingDrill;

    public ShootingDrillJoinUserDtoMapperTests()
    {
        _user = new User()
        {
            Id = 2,
            Nickname = "a",
            B2CIdentifier = "b"
        };

        _shootingDrill = new ShootingDrill(
            1,
            _user,
            new DateTime(1),
            new ShootingRecord(1, 2),
            new ShootingRecord(3, 4),
            new ShootingRecord(5, 6));

        _drillJoinUserDto = new ShootingDrillJoinUserDto(1, 2, "a", "b", new DateTime(1), 1, 2, 3, 4, 5, 6);
    }

    [Fact]
    public void Adapt_ShouldCorrectlyMapTheObject()
    {
        var result = _drillJoinUserDto.Adapt();

        result.Should().BeEquivalentTo(_shootingDrill);
    }
}
