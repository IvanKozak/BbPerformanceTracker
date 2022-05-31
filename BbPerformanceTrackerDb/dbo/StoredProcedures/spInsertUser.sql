CREATE PROCEDURE [dbo].[spInsertUser]
	@Nickname nvarchar(50),
	@B2CIdentifier char(36)
AS

begin
   insert into [user] (nickname, b2c_id)
   values (@Nickname, @B2CIdentifier)
end