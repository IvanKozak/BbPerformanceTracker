CREATE PROCEDURE [dbo].[spDeleteUser]
	@Id int
AS
	begin
		delete from [user]
		where id = @Id
	end