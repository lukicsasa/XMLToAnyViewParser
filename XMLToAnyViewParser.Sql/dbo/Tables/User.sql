CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, 
    [Username] NVARCHAR(50) NOT NULL, 
    [Password] NVARCHAR(200) NOT NULL, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Email] NVARCHAR(50) NULL, 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [Role]([Id])
)
