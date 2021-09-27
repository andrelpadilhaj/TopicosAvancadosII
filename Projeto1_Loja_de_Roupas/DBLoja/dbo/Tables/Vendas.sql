CREATE TABLE [dbo].[Vendas]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Valor] FLOAT NULL, 
    [Data] DATETIME NULL, 
    [ClienteId] INT NOT NULL,
    CONSTRAINT [PK_Vendas] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Vendas->Clientes] FOREIGN KEY([ClienteId]) REFERENCES [dbo].[Clientes]([Id])
)
