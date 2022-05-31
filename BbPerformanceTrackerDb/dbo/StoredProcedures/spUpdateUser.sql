CREATE PROCEDURE [dbo].[spUpdateUser]
	@Id int,
	@Nickname nvarchar(50),
	@B2CIdentifier nvarchar(50)
AS

begin
	update [user]
	set
	B2CIdentifier = @B2CIdentifier, nickname = @Nickname
	where Id = @Id
end