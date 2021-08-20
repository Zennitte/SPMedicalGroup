USE SPMEDGROUP_KAUE;
GO

--TipoUsuario

INSERT INTO tipoUsuario(nomeTipo)
VALUES ('CM'), ('ADM'), ('MED');
GO

--Usuario

  --Comum

INSERT INTO usuario(idTipoUsuario, nome, email,senha)
VALUES (1, 'Lígia', 'ligia@gmail.com', '1234'), (1, 'Alexandre', 'alexandre@gmail.com', '1234'), 
       (1, 'Fernando', 'fernando@gmail.com', '1234'), (1, 'Henrique', 'henrique@gmail.com', '1234'),
	   (1, 'João', 'joao@hotmail.com', '1234'), (1, 'Bruno', 'bruno@gmail.com', '1234'),
	   (1, 'Mariana', 'mariana@outlook.com', '1234');
GO

  --Medico

INSERT INTO usuario(idTipoUsuario, nome, email,senha)
VALUES (3, 'Ricardo Lemos', 'ricardo.lemos@spmedicalgroup.com.br', '123456'),
       (3, 'Roberto Possarle', 'roberto.possarle@spmedicalgroup.com.br', '123456'),
	   (3, 'Helena Strada', 'helena.souza@spmedicalgroup.com.br', '123456');
GO

--Especializacao

INSERT INTO especializacao(nomeEspec)
VALUES ('Acupuntura'), ('Anestesiologia'), ('Angiologia'), ('Cardiologia'), ('Cirurgia Cardiovascular'),
       ('Cirurgia da Mão'), ('Cirurgia do Aparelho Digestivo'), ('Cirurgia Geral'), ('Cirurgia Pediátrica'),
	   ('Cirurgia Plástica'), ('Cirurgia Torácica'), ('Cirurgia Vascular'), ('Dermatologia'),
	   ('Radioterapia'), ('Urologia'), ('Pediatria'), ('Psiquiatria');
GO

--Clinica

INSERT INTO clinica(nomeFantasia, cnpj, razaoSocial, endereco)
VALUES ('Clinica Possarle', '86.400.902/0001-30', 'SP Medical Group', 'Av. Barão Limeira, 532, São Paulo, SP');
GO

--Paciente

INSERT INTO paciente(idUsuario, dataNasc, telefone, rg, cpf, endereco)
VALUES (1, '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
(2, '23/07/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
(3, '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
(4, '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
(5, '27/08/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
(6, '21/03/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
(7, '05/03/2018', NULL, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

--Medico

INSERT INTO medico(idUsuario, idEspecializacao, idClinica, crm)
VALUES (8, 2, 1, '54356-SP'), (9, 17, 1, '53452-SP'), (10, 16, 1, '65463-SP');
GO

--Situacao

INSERT INTO situacao(descricao)
VALUES ('Agendada'), ('Cancelada'), ('Realizada');
GO

--Consulta

INSERT INTO consulta(idPaciente, idMedico, idSituacao, descricao, dataConsul)
VALUES (7, 3, 3, NULL, '20/01/2020 15:00:00'), (2, 2, 2, NULL, '06/01/2020 10:00:00'),
       (3, 2 ,3, NULL, '07/02/2020 11:00:00'), (2, 2, 3, NULL, '06/02/2018 10:00:00'),
	   (4, 1, 2, NULL, '07/02/2019 11:00:45'), (7, 3, 1, NULL, '08/03/2020 15:00:00'),
	   (4, 1, 1, NULL, '09/03/2020 11:00:45');
GO