CREATE TABLE [dbo].[shooting_drill]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [person_id] INT FOREIGN KEY REFERENCES [user](id) NOT NULL, 
    [date] DATETIME NOT NULL, 
    [3pt_attempts] INT NOT NULL, 
    [3pt_makes] INT NULL, 
    [midrange_attempts] INT NOT NULL, 
    [midrange_makes] INT NULL, 
    [postup_attempts] INT NOT NULL, 
    [postup_makes] INT NULL
)
