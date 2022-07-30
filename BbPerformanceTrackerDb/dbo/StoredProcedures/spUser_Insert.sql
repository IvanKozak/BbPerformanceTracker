CREATE PROCEDURE [dbo].[spUser_Insert]
	@Nickname nvarchar(50),
	@B2CIdentifier nvarchar(50)

AS

    BEGIN
       insert into [user] (nickname, b2c_identifier)
       values (@Nickname, @B2CIdentifier)
    END