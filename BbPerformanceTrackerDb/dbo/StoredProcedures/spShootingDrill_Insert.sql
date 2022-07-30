CREATE PROCEDURE [dbo].[spShootingDrill_Insert]
    @Id int,
    @UserId int,
    @Accomplished datetime,
    @ThreePointerMakes int,
    @ThreePointerAttempts int,
    @MidrangeMakes int,
    @MidrangeAttempts int,
    @PostupMakes int,
    @PostupAttempts int

AS

    BEGIN
	    INSERT INTO [shooting_drill] (user_id, accomplished, three_pointer_makes, three_pointer_attempts, midrange_makes, midrange_attempts, postup_makes, postup_attempts)
        VALUES (@UserId, @Accomplished, @ThreePointerMakes, @ThreePointerAttempts, @MidrangeMakes, @MidrangeAttempts, @PostupMakes, @PostupAttempts)
    END
