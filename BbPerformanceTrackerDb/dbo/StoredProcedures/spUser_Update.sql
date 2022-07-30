CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@Nickname nvarchar(50),
	@B2CIdentifier nvarchar(50)

AS

    BEGIN
	    update [user]
	    set
	    b2c_identifier = @B2CIdentifier, nickname = @Nickname
	    where id = @Id
    END