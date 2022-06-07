CREATE TABLE [dbo].[user]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [nickname] NVARCHAR(50) NOT NULL, 
    [b2c_identifier] NVARCHAR(50) NOT NULL

)
