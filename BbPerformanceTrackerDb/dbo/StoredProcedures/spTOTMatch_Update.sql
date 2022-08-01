CREATE PROCEDURE [dbo].[spTOTMatch_Update]
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
        UPDATE [3x3_match]
        SET
        [user_id] = @UserId, accomplished = @Accomplished,
        own_team_score = @OwnTeamScore, other_team_score = @OtherTeamScore,
        one_point_makes = @OnePointMakes, one_point_attempts = @OnePointAttempts,
        two_point_makes = @TwoPointMakes, two_point_attempts = @TwoPointAttempts,
        free_throw_makes = @FreeThrowMakes, free_throw_attempts = @FreeThrowAttempts,
        rebounds = @Rebounds, assists = @Assists
        WHERE id = @Id
    END