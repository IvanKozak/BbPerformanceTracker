namespace APILibrary.Models;
public record ShootingDrillDto(
    int Id,
    int UserId,
    DateTime Accomplished,
    int ThreePointerMakes,
    int ThreePointerAttempts,
    int MidrangeMakes,
    int MidrangeAttempts,
    int PostupMakes,
    int PostupAttempts);
