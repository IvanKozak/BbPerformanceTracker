CREATE TABLE [dbo].[3x3_match]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [person_id] INT NOT NULL FOREIGN KEY REFERENCES person(Id), 
    [date] DATETIME NOT NULL, 
    [2pt_attempts] INT NOT NULL, 
    [2pt_makes] INT NULL, 
    [1pt_attempts] INT NOT NULL, 
    [1pt_makes] INT NULL, 
    [assists] INT NULL, 
    [rebounds] INT NULL
)
