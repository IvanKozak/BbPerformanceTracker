using ClassLibrary.Models;

namespace ClassLibrary.Mappers;
public static class ShootingDrillJoinUserDtoMapper
{
    public static ShootingDrill Adapt(this ShootingDrillJoinUserDto drillJoinUserDto)
    {
        return new ShootingDrill(
            drillJoinUserDto.Id,
            new User
            {
                Id = drillJoinUserDto.UserId,
                Nickname = drillJoinUserDto.UserNickname,
                B2CIdentifier = drillJoinUserDto.UserB2CIdentifier
            },
            drillJoinUserDto.Accomplished,
            new ShootingRecord(drillJoinUserDto.ThreePointerMakes, drillJoinUserDto.ThreePointerAttempts),
            new ShootingRecord(drillJoinUserDto.MidrangeMakes, drillJoinUserDto.MidrangeAttempts),
            new ShootingRecord(drillJoinUserDto.PostupMakes, drillJoinUserDto.PostupAttempts)
            );
    }
}
