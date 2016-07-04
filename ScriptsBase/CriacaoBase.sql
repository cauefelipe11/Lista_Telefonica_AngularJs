CREATE DATABASE ListaTelefonicaAngular
GO
USE ListaTelefonicaAngular
GO

CREATE TABLE Operadoras(
	codigo    INT NOT NULL,
	nome      VARCHAR(80),
	categoria VARCHAR(30),
	preco     FLOAT

)
GO

CREATE TABLE Contatos(
	id          INT NOT NULL,
	nome        VARCHAR(200),
	data        DATETIME,
	telefone    VARCHAR(15),
	codigoOperadora INT
)
GO

ALTER TABLE Operadoras ADD CONSTRAINT PK_Operadoras PRIMARY KEY (codigo)
GO

ALTER TABLE Contatos ADD CONSTRAINT PK_Contatos PRIMARY KEY (id)
GO

ALTER TABLE Contatos ADD CONSTRAINT FK_Contatos_Operadoras FOREIGN KEY (codigoOperadora) REFERENCES Operadoras(codigo)
GO