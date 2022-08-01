CREATE PROCEDURE [dbo].[spTOTMatch_GetAllByUserId]
	@UserId int

AS

    BEGIN
        SELECT id, [user_id] AS UserId, accomplished, own_team_score AS OwnTeamScore, other_team_score AS OtherTeamScore, one_point_makes AS OnePointMakes, one_point_attempts AS OnePointAttempts, two_point_makes AS TwoPointMakes, two_point_attempts AS TwoPointAttempts, free_throw_makes AS FreeThrowMakes, free_throw_attempts AS FreeThrowAttempts, rebounds, assists
        FROM [3x3_match]
        WHERE [user_id] = @UserId
    END
