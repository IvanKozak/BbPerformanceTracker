CREATE TABLE [dbo].[user]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nickname] NVARCHAR(50) NOT NULL, 
    [b2c_id] CHAR(36) NOT NULL

)
