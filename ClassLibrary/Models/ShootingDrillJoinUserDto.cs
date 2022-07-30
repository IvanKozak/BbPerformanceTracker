namespace ClassLibrary.Models;

public record ShootingDrillJoinUserDto(
    int Id,
    int UserId,
    string UserNickname,
    string UserB2CIdentifier,
    DateTime Accomplished,
    int ThreePointerMakes,
    int ThreePointerAttempts,
    int MidrangeMakes,
    int MidrangeAttempts,
    int PostupMakes,
    int PostupAttempts);
