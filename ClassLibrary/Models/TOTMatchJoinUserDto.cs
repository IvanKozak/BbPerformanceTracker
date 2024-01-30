namespace APILibrary.Models;
public record class TOTMatchJoinUserDto(
    int Id,
    int UserId,
    string UserNickname,
    string UserB2CIdentifier,
    DateTime Accomplished,
    int OwnTeamScore,
    int OtherTeamScore,
    int OnePointMakes,
    int OnePointAttempts,
    int TwoPointMakes,
    int TwoPointAttempts,
    int FreeThrowMakes,
    int FreeThrowAttempts,
    int Rebounds,
    int Assists);
