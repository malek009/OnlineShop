CREATE TABLE [dbo].[CartArticles]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [CartId] INT NOT NULL, 
    [ArticleId] INT NOT NULL, 
    [Amount] INT NOT NULL
    constraint [FK_CartArticle_Cart] foreign key (CartId) references [dbo].[Cart](Id),
	constraint [Fk_CartArticle_Article] foreign key (ArticleId) references [dbo].[Article](Id)
)
