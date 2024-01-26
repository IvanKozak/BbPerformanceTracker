CREATE PROCEDURE [dbo].[spTOTMatch_GetAllByB2CId]
	@B2CIdentifier nvarchar(50)
AS
	
    BEGIN
	    SELECT mtch.id AS Id, player.id AS UserId, player.nickname AS UserNickname, 
            player.b2c_identifier AS UserB2CIdentifier, accomplished, 
            own_team_score AS OwnTeamScore, other_team_score AS OtherTeamScore,
            one_point_makes AS OnePointMakes, one_point_attempts AS OnePointAttempts,
            two_point_makes AS TwoPointMakes, two_point_attempts AS TwoPointAttempts,
            free_throw_makes AS FreeThrowMakes, free_throw_attempts AS FreeThrowAttempts,
            rebounds, assists
        FROM [3x3_match] as mtch INNER JOIN [user] as player ON mtch.[user_id]=player.id
        WHERE player.b2c_identifier = @B2CIdentifier
    END
