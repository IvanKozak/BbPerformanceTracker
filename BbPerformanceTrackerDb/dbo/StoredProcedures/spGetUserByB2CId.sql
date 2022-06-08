CREATE PROCEDURE [dbo].[spGetUserByB2CId]
	@B2CIdentifier nvarchar(50)
AS

begin
	SELECT id, nickname, b2c_identifier AS B2CIdentifier FROM [user]
	WHERE b2c_identifier = @B2CIdentifier
end