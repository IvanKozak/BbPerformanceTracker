CREATE PROCEDURE [dbo].[spShootingDrill_GetAll]

AS

    BEGIN
	    SELECT  shooting_drill.id AS Id, user_id AS UserId,
                [user].nickname AS UserNickname, [user].b2c_identifier AS UserB2CIdentifier,
                accomplished, three_pointer_makes AS ThreePointerMakes, three_pointer_attempts AS ThreePointerAttempts,
                midrange_makes AS MidrangeMakes, midrange_attempts AS MidrangeAttempts,
                postup_makes AS PostupMakes, postup_attempts AS PostupAttempts
        FROM shooting_drill INNER JOIN [user] ON shooting_drill.user_id=[user].id
    END
