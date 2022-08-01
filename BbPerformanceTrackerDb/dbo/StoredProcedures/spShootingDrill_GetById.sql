CREATE PROCEDURE [dbo].[spShootingDrill_GetById]
	@Id int 

AS
    
    BEGIN
	    SELECT  id, [user_id] AS UserId, accomplished, three_pointer_makes AS ThreePointerMakes, three_pointer_attempts AS ThreePointerAttempts, midrange_makes AS MidrangeMakes, midrange_attempts AS MidrangeAttempts, postup_makes AS PostupMakes, postup_attempts AS PostupAttempts
        FROM shooting_drill
        WHERE id = @Id 
    END
