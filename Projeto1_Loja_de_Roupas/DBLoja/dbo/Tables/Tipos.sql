CREATE TABLE [dbo].[Tipos] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Descricao] NVARCHAR (100) NOT NULL,
	[Valor]		float	NOT NULL,
    CONSTRAINT [PK_Tipos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

