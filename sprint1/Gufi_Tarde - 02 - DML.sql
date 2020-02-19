-- DML 
USE Gufi_Tarde;

SELECT * FROM Usuario;
SELECT * FROM TipoUsuario;
SELECT * FROM TipoEvento;
SELECT * FROM Instituicao;
SELECT * FROM Evento;
SELECT * FROM Presenca;



INSERT INTO TipoUsuario (TituloTipoUsuario)
VALUES ('Administrador'), ('Comum');

INSERT INTO TipoEvento (TituloTipoEvento)
VALUES ('C#'),('React'),('SQL'); 

INSERT INTO Instituicao (CNPJ, Nome, Endereco)
VALUES ('11111111111111', 'Escola SENAI de Informática', 'Alameda Barão de Limeira, 538');

INSERT INTO Instituicao (CNPJ, Nome, Endereco)
VALUES ('22222222222222', 'SESI - Centro Educacional 388', 'Av.Santa Inês, 225');

INSERT INTO Usuario (NomeUsuario, Email, Senha, Genero, DataNascimento, IdTipoUsuario)
VALUES ('Administrador', 'adm@gmail.com', 'adm123', 'Não Informado', '06/02/2020', 1),
       ('Carol', 'carol@gmail.com', 'carol123', 'Feminino', '06/02/2020', 2),
	   ('Saulo', 'saulo@gmail.com', 'saulo123', 'Masculino', '06/02/2020', 2);

INSERT INTO Evento (NomeEvento, DataEvento, Descricao, AcessoLivre, IdInstituicao, IdTipoEvento)
VALUES ('Introducao ao C#', '07/02/2020', 'Conceitos sobre os pilares da programação orientada', 1, 1, 1),
	   ('Ciclo de Vida', '07/02/2020', 'Como utilizar o ciclo de vida com ReactJs', 0, 1, 2),
	   ('Optimização de banco de dados', '07/02/2020', 'Aplicação de indices clusterizados e não clusterizados', 1, 1, 3);

UPDATE Usuario
SET Genero = 'Feminino'
WHERE IdUsuario = 6;


INSERT INTO Presenca (IdUsuario, IdEvento, Situacao)
VALUES (2, 2, 'Agendada'),
       (2, 3, 'Confirmada'),
	   (3, 1, 'Não compareceu');


