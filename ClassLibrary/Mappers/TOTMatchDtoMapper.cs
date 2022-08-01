using ClassLibrary.Models;

namespace ClassLibrary.Mappers;
public static class TOTMatchDtoMapper
{
    public static ThreeOnThreeMatch Adapt(this TOTMatchDto dto, User user)
    {
        return new ThreeOnThreeMatch(
            dto.Id,
            new User
            {
                Id = user.Id,
                Nickname = user.Nickname,
                B2CIdentifier = user.B2CIdentifier
            },
            dto.Accomplished,
            new Score(dto.OwnTeamScore, dto.OtherTeamScore),
            new ShootingRecord(dto.OnePointMakes, dto.OnePointAttempts),
            new ShootingRecord(dto.TwoPointMakes, dto.TwoPointAttempts),
            new ShootingRecord(dto.FreeThrowMakes, dto.FreeThrowAttempts),
            dto.Rebounds,
            dto.Assists);
    }

    public static TOTMatchDto AdaptToDto(this ThreeOnThreeMatch match)
    {
        return new TOTMatchDto(
            match.Id,
            match.Player.Id,
            match.Accomplished,
            match.GameScore.OwnTeamScore,
            match.GameScore.OtherTeamScore,
            match.OnePointShots.Makes,
            match.OnePointShots.Attempts,
            match.TwoPointShots.Makes,
            match.TwoPointShots.Attempts,
            match.FreeThrows.Makes,
            match.FreeThrows.Attempts,
            match.Rebounds,
            match.Assists);
    }
}
