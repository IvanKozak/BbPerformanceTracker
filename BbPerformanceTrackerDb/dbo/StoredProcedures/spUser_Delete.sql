CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id int

AS
	
    BEGIN
        delete from shooting_drill
        where user_id = @Id
		delete from [user]
		where id = @Id
	END