USE SPMEDGROUP_KAUE;
GO

--TipoUsuario

SELECT * FROM tipoUsuario;
GO

--Usuario

SELECT * FROM usuario;
GO

--Especializacao

SELECT * FROM especializacao;
GO

--Clinica

SELECT * FROM clinica;
GO

--Paciente

SELECT * FROM paciente;
GO

--Medico

SELECT * FROM medico;
GO

--Situacao

SELECT * FROM situacao;
GO

--Consulta

SELECT * FROM consulta;
GO

--Prontuario

SELECT U.nome AS Paciente, UMED.nome AS Medico, E.nomeEspec AS Especialização, CONVERT(varchar, C.dataConsul, 103) AS Data, S.descricao AS Situação FROM consulta C
INNER JOIN paciente P
ON C.idPaciente = P.idPaciente
INNER JOIN medico M
ON C.idMedico = M.idMedico
INNER JOIN usuario U
ON P.idUsuario = U.idUsuario
INNER JOIN usuario UMED
ON M.idUsuario = UMED.idUsuario
INNER JOIN especializacao E
ON M.idEspecializacao = E.idEspecializacao
INNER JOIN situacao S
ON C.idSituacao = S.idSituacao;
GO

--Contagem de Usuarios

SELECT COUNT(idUsuario) [Numero De Usuarios] FROM usuario;
GO

--Funções

CREATE FUNCTION MED_ESPC(@nomeEspec VARCHAR(100))
RETURNS TABLE
AS
RETURN
(
 SELECT @nomeEspec AS Especialização, COUNT(idEspecializacao) [Numero De Médicos] FROM especializacao
 WHERE nomeEspec LIKE '%'+ @nomeEspec +'%'
)
GO

SELECT * FROM MED_ESPC('Psiquiatria');
GO

CREATE PROCEDURE IDADE
@nome VARCHAR(100)
AS
BEGIN
 SELECT U.nome, DATEDIFF(YEAR, P.dataNasc, GETDATE()) AS Idade  FROM paciente P
 INNER JOIN usuario U
 ON P.idUsuario = U.idUsuario
 WHERE U.nome = @nome
END
GO

exec IDADE 'Mariana'

