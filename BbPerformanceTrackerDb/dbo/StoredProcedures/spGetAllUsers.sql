CREATE PROCEDURE [dbo].[spGetAllUsers]

AS

begin
	SELECT id, nickname, b2c_identifier AS B2CIdentifier 
    FROM [user]
end
