CREATE TABLE [dbo].[Clientes]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL, 
    [Nome] VARCHAR(50) NULL, 
    [Telefone] VARCHAR(50) NULL, 
    [Email] VARCHAR(50) NULL
)
