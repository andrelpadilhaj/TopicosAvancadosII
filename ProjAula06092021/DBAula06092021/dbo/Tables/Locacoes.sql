CREATE TABLE [dbo].[Locacoes]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Descricao] VARCHAR(50) NULL, 
    [Id_Carro] INT NULL, 
    CONSTRAINT [FK_Locacoes_Carros] FOREIGN KEY ([Id_Carro]) REFERENCES [Carros]([Id])
)
