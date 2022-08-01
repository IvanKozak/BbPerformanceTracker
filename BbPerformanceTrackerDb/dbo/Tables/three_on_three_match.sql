CREATE TABLE [dbo].[3x3_match]
(
	[id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [user_id] INT NOT NULL FOREIGN KEY REFERENCES [user](id) ON DELETE CASCADE, 
    [accomplished] DATETIME NOT NULL, 
    [own_team_score] INT NOT NULL,
    [other_team_score] INT NOT NULL,
    [one_point_makes] INT NOT NULL, 
    [one_point_attempts] INT NOT NULL,
    [two_point_makes] INT NOT NULL, 
    [two_point_attempts] INT NOT NULL, 
    [free_throw_makes] INT NOT NULL, 
    [free_throw_attempts] INT NOT NULL, 
    [rebounds] INT NOT NULL,
    [assists] INT NOT NULL  
)
