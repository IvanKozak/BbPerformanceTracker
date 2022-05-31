CREATE PROCEDURE [dbo].[spGetUserById]
	@Id int
AS

begin
	SELECT * from [user]
	WHERE @Id = Id
end