CREATE PROCEDURE [dbo].[spGetUserById]
	@Id int
AS

begin
	SELECT id, nickname, b2c_identifier AS B2CIdentifier FROM [user]
	WHERE id = @Id
end