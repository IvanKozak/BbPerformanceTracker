CREATE PROCEDURE [dbo].[spTOTMatch_Delete]
	@Id int
AS
	BEGIN
       DELETE FROM [3x3_match]
       WHERE id = @Id 
    END