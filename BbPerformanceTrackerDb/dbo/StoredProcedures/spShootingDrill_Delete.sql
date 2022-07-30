CREATE PROCEDURE [dbo].[spShootingDrill_Delete]
	@Id int
AS

    BEGIN
        DELETE FROM shooting_drill
        WHERE id = @Id
    END
