namespace APILibrary.Models;
public record class TOTMatchDto(
    int Id,
    int UserId,
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
