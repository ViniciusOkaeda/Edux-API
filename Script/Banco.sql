/* DDL - Data Definition Language */

-- Criando o banco de dados
CREATE DATABASE Edux;
GO

-- Usando o banco de dados
USE Edux;
GO

-- Criando a tabela de Instituição
CREATE TABLE Instituicao (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255),
	Logradouro VARCHAR(255),
	Numero VARCHAR(255),
	Complemento VARCHAR(255),
	Bairro VARCHAR(255),
	Cidade VARCHAR(255),
	UF VARCHAR(2),
	CEP VARCHAR(15)
);

-- Criando a tabela de Curso
CREATE TABLE Curso (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(255),

	IdInstituicao INT FOREIGN KEY REFERENCES Instituicao (Id)
);

-- Criando a tabela de Turma
CREATE TABLE Turma (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR(255),

	IdCurso INT FOREIGN KEY REFERENCES Curso (Id)
);

-- Criando a tabela de Categoria
CREATE TABLE Categoria (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Tipo VARCHAR(255)
);

-- Criando a tabela de Objetivo
CREATE TABLE Objetivo (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR(255),
	Titulo VARCHAR(100),

	IdCategoria INT FOREIGN KEY REFERENCES Categoria (Id)
);

-- Criando a tabela de Perfil
CREATE TABLE Perfil (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Permissao VARCHAR(15)
);

-- Criando a tabela de Usuario
CREATE TABLE Usuario (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255),
	Email VARCHAR(100),
	Senha VARCHAR(255),
	Imagem VARCHAR(255),
	DataCadastro DateTime DEFAULT GETDATE(),
	DataUltimoAcesso DateTime,
	
	IdPerfil INT FOREIGN KEY REFERENCES Perfil (Id)
);

-- Criando a tabela de Dica
CREATE TABLE Dica (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Texto VARCHAR(255),
	Imagem VARCHAR(255),

	IdUsuario INT FOREIGN KEY REFERENCES Usuario (Id)
);

-- Criando a tabela de Curtida
CREATE TABLE Curtida (
	Id INT PRIMARY KEY IDENTITY NOT NULL,

	IdDica INT FOREIGN KEY REFERENCES Dica (Id),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario (Id)
);

-- Criando a tabela de AlunoTurma
CREATE TABLE AlunoTurma (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Matricula VARCHAR(50),

	IdUsuario INT FOREIGN KEY REFERENCES Usuario (Id),
	IdTurma INT FOREIGN KEY REFERENCES Turma (Id)
);

-- Criando a tabela de AlunoTurma
CREATE TABLE ProfessorTurma (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Matricula VARCHAR(50),

	IdUsuario INT FOREIGN KEY REFERENCES Usuario (Id),
	IdTurma INT FOREIGN KEY REFERENCES Turma (Id)
);

-- Criando a tabela de ObjetivoAluno
CREATE TABLE ObjetivoAluno (
	Id INT PRIMARY KEY IDENTITY NOT NULL,
	Nota DECIMAL(10, 2) DEFAULT NULL,
	DataAlcancado DateTime DEFAULT NULL,

	IdAlunoTurma INT FOREIGN KEY REFERENCES AlunoTurma (Id),
	IdObjetivo INT FOREIGN KEY REFERENCES Objetivo (Id)
);