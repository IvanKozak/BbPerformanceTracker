CREATE PROCEDURE [dbo].[spUpdateUser]
	@Id int,
	@Nickname nvarchar(50),
	@B2CIdentifier char(36)
AS

begin
	update [user]
	set
	b2c_id = @B2CIdentifier, nickname = @Nickname
	where Id = @Id
end