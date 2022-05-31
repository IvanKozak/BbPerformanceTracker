CREATE PROCEDURE [dbo].[spGetUserById]
	@Id int
AS
	SELECT * from [user]
	WHERE @Id = Id
