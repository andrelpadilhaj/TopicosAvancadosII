CREATE TABLE [dbo].[Produtos] (
    [Id]         INT          IDENTITY (1, 1) NOT NULL,
    [Descricao]  VARCHAR (50) NULL,
    [Valor]      FLOAT (53)   NULL,
    [DtCadastro] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

