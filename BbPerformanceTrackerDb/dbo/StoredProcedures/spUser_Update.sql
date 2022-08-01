CREATE PROCEDURE [dbo].[spUser_Update]
	@Id int,
	@Nickname nvarchar(50),
	@B2CIdentifier nvarchar(50)

AS

    BEGIN
	    UPDATE [user]
	    SET
	    b2c_identifier = @B2CIdentifier, nickname = @Nickname
	    WHERE id = @Id
    END