CREATE TABLE [dbo].[Roupas] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Cor] VARCHAR (20) NOT NULL,
	[Quantidade]	INT	NOT NULL,
    [TipoId]    INT           NOT NULL,
    CONSTRAINT [PK_Roupas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Roupas->Tipos] FOREIGN KEY ([TipoId]) REFERENCES [dbo].[Tipos] ([Id])
);

