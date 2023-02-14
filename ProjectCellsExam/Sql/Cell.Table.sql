CREATE TABLE [dbo].[Cell]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] VARCHAR(50) NOT NULL, 
    [IdOperation] INT NOT NULL, 
    [IdStatus] INT NOT NULL, 
    [CodOperation] INT NOT NULL
)