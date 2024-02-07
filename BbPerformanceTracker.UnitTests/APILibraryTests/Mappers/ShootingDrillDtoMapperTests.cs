using APILibrary.Mappers;
using APILibrary.Models;

namespace BbPerformanceTracker.Tests.APILibraryTests.Mappers;
public class ShootingDrillDtoMapperTests
{
    private readonly User _user;
    private readonly ShootingDrill _shootingDrill;
    private readonly ShootingDrillDto _shootingDrillDto;


    public ShootingDrillDtoMapperTests()
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

        _shootingDrillDto = new ShootingDrillDto(1, 2, new DateTime(1), 1, 2, 3, 4, 5, 6);

    }

    [Fact]
    public void Adapt_ShouldCorrectlyMapTheObject()
    {
        var result = _shootingDrillDto.Adapt(_user);

        result.Should().BeEquivalentTo(_shootingDrill);
    }

    [Fact]
    public void AdaptToDto_ShouldCorrectlyMapTheObject()
    {
        var result = _shootingDrill.AdaptToDto();

        result.Should().BeEquivalentTo(_shootingDrillDto);
    }
}
