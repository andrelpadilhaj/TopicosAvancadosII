CREATE TABLE [dbo].[Clientes]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Nome] VARCHAR(50) NOT NULL, 
    [Telefone] VARCHAR(16) NOT NULL, 
    [Nascimento] DATE NOT NULL, 
    [CPF] VARCHAR(14) NOT NULL, 
    [Endereco] VARCHAR(100) NOT NULL,
    CONSTRAINT [PK_Clientes] PRIMARY KEY([Id]),
    CONSTRAINT [UN_Clientes_Telefone] UNIQUE([Telefone]),
    CONSTRAINT [UN_Clientes_CPF] UNIQUE([CPF])
)
