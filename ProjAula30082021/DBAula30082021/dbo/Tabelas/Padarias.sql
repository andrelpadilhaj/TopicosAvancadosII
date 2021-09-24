CREATE TABLE [dbo].[Padarias]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Nome] VARCHAR(50) NULL, 
    [CNPJ] VARCHAR(18) NOT NULL, 
    [QtdFuncionarios] INT NULL, 
    [Endereco] VARCHAR(50) NULL, 
    [Telefone] VARCHAR(16) NULL
)
