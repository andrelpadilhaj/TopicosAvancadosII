CREATE TABLE [dbo].[Funcionarios] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (50)  NOT NULL,
    [Telefone] VARCHAR (16)  NOT NULL,
    [Endereco] VARCHAR (100) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

