CREATE PROCEDURE [dbo].[spGetAllUsers]

AS

begin
	SELECT id, nickname, B2CIdentifier 
    FROM [user]
end
