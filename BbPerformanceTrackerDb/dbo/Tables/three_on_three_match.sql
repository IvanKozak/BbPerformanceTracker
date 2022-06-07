CREATE TABLE [dbo].[3x3_match]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] INT NOT NULL FOREIGN KEY REFERENCES [user](Id), 
    [accomplished] DATETIME NOT NULL, 
    [two_point_makes] INT NOT NULL, 
    [two_point_attempts] INT NOT NULL, 
    [one_point_makes] INT NOT NULL, 
    [one_point_attempts] INT NOT NULL, 
    [assists] INT NOT NULL, 
    [rebounds] INT NOT NULL
)
