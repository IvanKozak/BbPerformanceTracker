CREATE PROCEDURE [dbo].[spShootingDrill_GetAll]

AS

    BEGIN
	    SELECT  shooting_drill.id as Id, user_id as UserId, [user].nickname as UserNickname, [user].b2c_identifier as UserB2CIdentifier, Accomplished, three_pointer_makes as ThreePointerMakes, three_pointer_attempts as ThreePointerAttempts, midrange_makes as MidrangeMakes, midrange_attempts as MidrangeAttempts, postup_makes as PostupMakes, postup_attempts as PostupAttempts
        FROM shooting_drill INNER JOIN [user] ON shooting_drill.user_id=[user].id
    END
