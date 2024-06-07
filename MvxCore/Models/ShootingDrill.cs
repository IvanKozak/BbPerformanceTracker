namespace MvxCore.Models;

public record class ShootingDrill(
    int Id,
    User User,
    DateTime Accomplished,
    ShootingRecord ThreePointers,
    ShootingRecord MidrangeShots,
    ShootingRecord PostUps);

