CREATE TABLE [dbo].[Article]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [Name] NVARCHAR(100) NOT NULL, 
    [Refe] NVARCHAR(150) NOT NULL, 
    [Description] NVARCHAR(50) NOT NULL, 
    [Stock] INT NOT NULL, 
    [Price] FLOAT NOT NULL,
    [image] NVARCHAR(50) NULL, 
    [CategoryId] INT not NULL,

     CONSTRAINT [FK_ARTICLE_ARTICLECATEGORY] FOREIGN KEY (CategoryId) REFERENCES [dbo].[Category](Id)
)
