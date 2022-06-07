CREATE PROCEDURE [dbo].[spInsertUser]
	@Nickname nvarchar(50),
	@B2CIdentifier nvarchar(50)
AS

begin
   insert into [user] (nickname, b2c_identifier)
   values (@Nickname, @B2CIdentifier)
end