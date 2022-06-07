CREATE PROCEDURE [dbo].[spGetAllShootingDrillsByUserId]
    @UserId int
AS

begin
    SELECT  id, user_id as UserId, Accomplished, three_pointer_makes as ThreePointerMakes, three_pointer_attempts as ThreePointerAttempts, midrange_makes as MidrangeMakes, midrange_attempts as MidrangeAttempts, postup_makes as PostupMakes, postup_attempts as PostupAttempts
    FROM shooting_drill
    WHERE user_id = @UserId
end