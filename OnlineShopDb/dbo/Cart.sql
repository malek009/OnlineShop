CREATE TABLE [dbo].[Cart]
(
	[Id] INT NOT NULL PRIMARY KEY identity(1,1), 
    [DateCreation] DATETIME2 NOT NULL, 
    [DatePaied] DATETIME2 NULL, 
    [Price] FLOAT NOT NULL, 
    [IsPaied] BIT NOT NULL, 
    [UserId] INT NOT NULL,

    CONSTRAINT [FK_Cart_User] FOREIGN KEY (UserId) REFERENCES [dbo].[User](Id)
)
