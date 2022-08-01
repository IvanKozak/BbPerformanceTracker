CREATE PROCEDURE [dbo].[spUser_Insert]
	@Nickname nvarchar(50),
	@B2CIdentifier nvarchar(50)

AS

    BEGIN
       INSERT INTO [user] (nickname, b2c_identifier)
       VALUES (@Nickname, @B2CIdentifier)
    END