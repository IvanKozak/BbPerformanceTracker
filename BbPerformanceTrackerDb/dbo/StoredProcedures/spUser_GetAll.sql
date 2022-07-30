CREATE PROCEDURE [dbo].[spUser_GetAllUser]

AS

    BEGIN
	    SELECT id, nickname, b2c_identifier AS B2CIdentifier 
        FROM [user]
    END
