using APILibrary.Mappers;
using APILibrary.Models;

namespace BbPerformanceTracker.Tests.APILibraryTests.Mappers;
public class TOTMatchDtoMapperTests
{
    private readonly User _user;
    private readonly ThreeOnThreeMatch _match;
    private readonly TOTMatchDto _matchDto;

    public TOTMatchDtoMapperTests()
    {
        _user = new User()
        {
            Id = 2,
            Nickname = "a",
            B2CIdentifier = "b"
        };

        _match = new ThreeOnThreeMatch(
            1,
            _user,
            new DateTime(3),
            new Score(400, 500),
            new ShootingRecord(6, 7),
            new ShootingRecord(8, 9),
            new ShootingRecord(10, 11),
            12,
            13);

        _matchDto = new TOTMatchDto(
            1,
            2,
            new DateTime(3),
            400,
            500,
            6,
            7,
            8,
            9,
            10,
            11,
            12,
            13);
    }

    [Fact]
    public void Adapt_ShouldCorrectlyMapTheObject()
    {
        var result = _matchDto.Adapt(_user);

        result.Should().BeEquivalentTo(_match);
    }

    [Fact]
    public void AdaptToDto_ShouldCorrectlyMapTheObject()
    {
        var result = _match.AdaptToDto();

        result.Should().BeEquivalentTo(_matchDto);
    }
}
