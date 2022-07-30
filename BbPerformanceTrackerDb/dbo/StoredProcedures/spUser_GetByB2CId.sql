CREATE PROCEDURE [dbo].[spUser_GetByB2CId]
	@B2CIdentifier nvarchar(50)
AS

    BEGIN
	    SELECT id, nickname, b2c_identifier AS B2CIdentifier FROM [user]
	    WHERE b2c_identifier = @B2CIdentifier
    END