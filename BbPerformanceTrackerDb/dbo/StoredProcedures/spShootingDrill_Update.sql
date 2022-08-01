CREATE PROCEDURE [dbo].[spShootingDrill_Update]
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
        UPDATE shooting_drill
        SET
	    [user_id] = @UserId, accomplished = @Accomplished,
        three_pointer_makes = @ThreePointerMakes, 
        three_pointer_attempts = @ThreePointerAttempts, 
        midrange_makes = @MidrangeMakes, 
        midrange_attempts =@MidrangeAttempts,
        postup_makes = @PostupMakes,
        postup_attempts = @PostupAttempts
        WHERE id = @Id
    END

