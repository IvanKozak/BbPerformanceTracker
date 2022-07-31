using ClassLibrary.Models;

namespace ClassLibrary.Mappers;
public static class TOTMatchJoinUserDtoMapper
{
    public static ThreeOnThreeMatch Adapt(this TOTMatchJoinUserDto dto)
    {
        return new ThreeOnThreeMatch(
            dto.Id,
            new User
            {
                Id = dto.UserId,
                Nickname = dto.UserNickname,
                B2CIdentifier = dto.UserB2CIdentifier
            },
            dto.Accomplished,
            new Score(dto.OwnTeamScore, dto.OtherTeamScore),
            new ShootingRecord(dto.OnePointMakes, dto.OnePointAttempts),
            new ShootingRecord(dto.TwoPointMakes, dto.TwoPointAttempts),
            new ShootingRecord(dto.FreeThrowMakes, dto.FreeThrowAttempts),
            dto.Rebounds,
            dto.Assists);
    }

    public static TOTMatchJoinUserDto AdaptToDto(this ThreeOnThreeMatch match)
    {
        return new TOTMatchJoinUserDto(
            match.Id,
            match.Player.Id,
            match.Player.Nickname,
            match.Player.B2CIdentifier,
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
