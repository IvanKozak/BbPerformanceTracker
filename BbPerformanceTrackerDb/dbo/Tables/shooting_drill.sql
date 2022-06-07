CREATE TABLE [dbo].[shooting_drill]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] INT FOREIGN KEY REFERENCES [user](id) NOT NULL, 
    [accomplished] DATETIME NOT NULL, 
    [three_pointer_makes] INT NOT NULL, 
    [three_pointer_attempts] INT NOT NULL, 
    [midrange_makes] INT NOT NULL, 
    [midrange_attempts] INT NOT NULL, 
    [postup_makes] INT NOT NULL,
    [postup_attempts] INT NOT NULL 
)
