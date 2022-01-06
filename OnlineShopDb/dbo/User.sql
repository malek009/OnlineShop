CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [FirstName] NVARCHAR(150) NOT NULL, 
    [LastName] NVARCHAR(150) NOT NULL, 
    [Address] NVARCHAR(150) NOT NULL,

)
