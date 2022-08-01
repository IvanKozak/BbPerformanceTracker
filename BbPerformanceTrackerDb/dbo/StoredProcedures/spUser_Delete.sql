CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int

AS
	
    BEGIN
        DELETE FROM shooting_drill
        WHERE [user_id] = @Id
		DELETE FROM [user]
		WHERE id = @Id
	END