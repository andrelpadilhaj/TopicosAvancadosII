CREATE TABLE [dbo].[Carros]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Nome] VARCHAR(50) NULL, 
    [Cor] VARCHAR(20) NULL, 
    [Ano] INT NULL, 
    [Modelo] INT NULL, 
    [Placa] VARCHAR(7) NULL
)
