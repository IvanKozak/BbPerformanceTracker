using ClassLibrary.Models;

namespace ClassLibrary.Mappers;
public static class ShootingDrillMapper
{
    public static ShootingDrill Adapt(this ShootingDrillDto shootingDrillDto, User user)
    {
        return new ShootingDrill(
            shootingDrillDto.Id,
            user,
            shootingDrillDto.Accomplished,
            new ShootingRecord(shootingDrillDto.ThreePointerMakes, shootingDrillDto.ThreePointerAttempts),
            new ShootingRecord(shootingDrillDto.MidrangeMakes, shootingDrillDto.MidrangeAttempts),
            new ShootingRecord(shootingDrillDto.PostupMakes, shootingDrillDto.PostupAttempts)
            );
    }

    public static ShootingDrillDto AdaptToDto(this ShootingDrill shootingDrill)
    {
        return new ShootingDrillDto(
            shootingDrill.Id,
            shootingDrill.User.Id,
            shootingDrill.Accomplished,
            shootingDrill.ThreePointers.Makes,
            shootingDrill.ThreePointers.Attempts,
            shootingDrill.MidrangeShots.Makes,
            shootingDrill.MidrangeShots.Attempts,
            shootingDrill.PostUps.Makes,
            shootingDrill.PostUps.Attempts);
    }
}
