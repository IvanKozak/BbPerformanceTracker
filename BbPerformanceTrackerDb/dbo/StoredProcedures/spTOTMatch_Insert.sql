CREATE PROCEDURE [dbo].[spTOTMatch_Insert]
	@Id int,
    @UserId int,
    @Accomplished DateTime,
    @OwnTeamScore int,
    @OtherTeamScore int,
    @OnePointMakes int,
    @OnePointAttempts int,
    @TwoPointMakes int,
    @TwoPointAttempts int,
    @FreeThrowMakes int,
    @FreeThrowAttempts int,
    @Rebounds int,
    @Assists int

AS
    BEGIN
	    INSERT INTO [3x3_match] 
            ([user_id], accomplished,
            own_team_score, other_team_score,
            one_point_makes, one_point_attempts,
            two_point_makes, two_point_attempts,
            free_throw_makes, free_throw_attempts,
            rebounds, assists)
        VALUES 
            (@UserId, @Accomplished,
            @OwnTeamScore, @OtherTeamScore,
            @OnePointMakes, @OnePointAttempts,
            @TwoPointMakes, @TwoPointAttempts,
            @FreeThrowMakes, @FreeThrowAttempts,
            @Rebounds, @Assists)
    END