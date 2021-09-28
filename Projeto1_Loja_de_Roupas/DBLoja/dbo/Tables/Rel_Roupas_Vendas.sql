CREATE TABLE [dbo].[Rel_Roupas_Vendas] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [RoupaId]   INT NOT NULL,
    [VendaId]   INT NOT NULL,
    [Quantidade] INT NOT NULL,
    CONSTRAINT [PK_Rel_Roupas_Vendas] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Rel_Roupas_Vendas->Vendas] FOREIGN KEY ([VendaId]) REFERENCES [dbo].[Vendas] ([Id]),
    CONSTRAINT [FK_Rel_Roupas_Vendas->Roupas] FOREIGN KEY ([RoupaId]) REFERENCES [dbo].[Roupas] ([Id])
);

