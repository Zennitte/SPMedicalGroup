CREATE DATABASE SPMEDGROUP_KAUE;
GO

USE SPMEDGROUP_KAUE;
GO

--TipoUsuario

CREATE TABLE tipoUsuario(
 idTipoUsuario TINYINT PRIMARY KEY IDENTITY,
 nomeTipo VARCHAR(100) NOT NULL UNIQUE
);
GO

--Usuario

CREATE TABLE usuario(
 idUsuario INT PRIMARY KEY IDENTITY, 
 idTipoUsuario TINYINT FOREIGN KEY REFERENCES tipoUsuario(idTipoUsuario),
 nome VARCHAR(100) NOT NULL,
 email VARCHAR(256) NOT NULL UNIQUE,
 senha VARCHAR(20) NOT NULL
);
GO

--Especialização

CREATE TABLE especializacao(
 idEspecializacao TINYINT PRIMARY KEY IDENTITY,
 nomeEspec VARCHAR(100) NOT NULL UNIQUE
);
GO

--Clinica

CREATE TABLE clinica(
 idClinica SMALLINT PRIMARY KEY IDENTITY,
 nomeFantasia VARCHAR(200) NOT NULL,
 cnpj VARCHAR(20) NOT NULL UNIQUE,
 razaoSocial VARCHAR(200) NOT NULL UNIQUE,
 endereco VARCHAR(200) NOT NULL UNIQUE
);
GO

--Paciente

CREATE TABLE paciente(
 idPaciente INT PRIMARY KEY IDENTITY,
 idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
 dataNasc DATE NOT NULL,
 telefone VARCHAR(20),
 rg VARCHAR(15) NOT NULL UNIQUE,
 cpf VARCHAR(15) NOT NULL UNIQUE,
 endereco VARCHAR(200) NOT NULL
);
GO

--Situacao

CREATE TABLE situacao(
 idSituacao TINYINT PRIMARY KEY IDENTITY,
 descricao VARCHAR(100) NOT NULL
);
GO

--Medico

CREATE TABLE medico(
 idMedico INT PRIMARY KEY IDENTITY,
 idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
 idEspecializacao TINYINT FOREIGN KEY REFERENCES especializacao(idEspecializacao),
 idClinica SMALLINT FOREIGN KEY REFERENCES clinica(idClinica),
 crm VARCHAR(20) NOT NULL UNIQUE
);
GO

--Consulta

CREATE TABLE consulta(
 idConsulta INT PRIMARY KEY IDENTITY,
 idPaciente INT FOREIGN KEY REFERENCES paciente(idPaciente),
 idMedico INT FOREIGN KEY REFERENCES medico(idMedico),
 idSituacao TINYINT FOREIGN KEY REFERENCES situacao(idSituacao) DEFAULT(1),
 descricao VARCHAR(250),
 dataConsul DATETIME NOT NULL
);
GO

--Imagem Usuario

CREATE TABLE imagemUsuario(
 id INT PRIMARY KEY IDENTITY(1,1),
 idUsuario INT FOREIGN KEY REFERENCES usuario(idUsuario),
 binario VARBINARY(MAX) NOT NULL,
 mimeType VARCHAR(30) NOT NULL,
 nomeArquivo VARCHAR(250) NOT NULL,
 data_inclusao DATETIME DEFAULT GETDATE() NULL
);
GO