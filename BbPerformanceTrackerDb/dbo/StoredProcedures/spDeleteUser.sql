CREATE PROCEDURE [dbo].[spDeleteUser]
	@Id int
AS
	begin
		delete from [user]
		where Id = @Id
	end