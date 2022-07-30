CREATE PROCEDURE [dbo].[spUser_GetById]
	@Id int

AS

    BEGIN
	    SELECT id, nickname, b2c_identifier AS B2CIdentifier FROM [user]
	    WHERE id = @Id
    END