CREATE DATABASE Pessoas_Tarde;

USE Pessoas_Tarde;

CREATE TABLE Pessoas(
	IdPessoa	INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR(250)
);

CREATE TABLE Emails(
	IdEmail		INT PRIMARY KEY IDENTITY,
	Descricao	VARCHAR(210),
	IdPessoa	INT FOREIGN KEY REFERENCES Pessoas (IdPessoa)
);

CREATE TABLE CNH(
	IdCNH		INT PRIMARY KEY IDENTITY,
	Descricao	VARCHAR(200),
	IdPessoa    INT FOREIGN KEY REFERENCES Pessoas (IdPessoa)
);

CREATE TABLE Telefones(
	IdTelefone  INT PRIMARY KEY IDENTITY,
	Descricao	VArCHAR(100),
	IdPessoas	INT FOREIGN KEY REFERENCES Pessoas (IdPessoa)
);

INSERT INTO Pessoas (Nome)
VALUES ('Sabrina Silva Campos'), 
	   ('Paulo Rodrigues Santos'), 
	   ('Gabriel Nogueira'), 
	   ('Haila Batista'), 
	   ('Yasmin Marcondes');

INSERT INTO Emails(Descricao, IdPessoa)
VALUES ('gabs123@gmail.com', 3), 
	   ('hailinhadejesus@gmail.com', 4), 
	   ('sabrina.s.c@gmail.com', 1), 
	   ('yazminimarc@gmail.com', 5), 
	   ('paulousrod@gmail.com', 2);

INSERT INTO CNH(Descricao, IdPessoa)
VALUES (124567890, 2), 
	   (543288776, 5), 
	   (878789004, 1), 
	   (433336674, 4), 
	   (612398733, 3);

INSERT INTO Telefones(Descricao, IdPessoas)
VALUES (33445567, 1), 
	   (22448765, 3), 
	   (76554487, 5), 
	   (20983451, 2), 
	   (54543289, 4);




SELECT * FROM Pessoas;
SELECT * FROM Emails;
SELECT * FROM CNH;
SELECT * FROM Telefones;