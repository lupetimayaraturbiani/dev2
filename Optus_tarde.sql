 --DDL Linguagem de defini�ao de dados

 --Criar o banco de dados
CREATE DATABASE Optus_tarde;

USE Optus_tarde;

CREATE TABLE Artistas (
	IdArtistas		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);

CREATE TABLE Estilos (
	IdEstilos		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);

CREATE TABLE Albuns (
	IdAlbuns		INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL,
	DataLancamento	DATE,
	IdArtista		INT FOREIGN KEY REFERENCES Artistas (IdArtistas),
	IdEstilo		INT FOREIGN KEY REFERENCES Estilos (IdEstilos)
);


CREATE TABLE TipoUsuario (
	IdTipoUsuario	INT PRIMARY KEY IDENTITY,
	Nome			VARCHAR(200) NOT NULL
);


CREATE TABLE Usuario (
	IdUsuario INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL,
	Telefone INT,
	Endere�o VARCHAR(250),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);



--DML LINGUAGEM DE MANIPULA�AO DE DADOS
SELECT * FROM Artistas;
SELECT * FROM Estilos;
SELECT * FROM Albuns;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;

-- COMANDO DE INSERIR DADOS
INSERT INTO Estilos (Nome)
VALUES ('Samba'), ('Pagode'), ('MPB'), ('Rock');

INSERT INTO Estilos (Nome)
VALUES ('Indie');

INSERT INTO Artistas (Nome)
VALUES ('Zeca Pagodinho'), ('Tiaguinho'), ('Caetano Veloso'), ('Legi�o Urbana'); 

INSERT INTO Artistas (Nome)
VALUES ('Imagine Dragons');

INSERT INTO Albuns (Nome, DataLancamento, IdArtista, IdEstilo)
VALUES ('Eu Cansei', '25/01/2020', 2, 2),
       ('Voltei Brasil', '30/03/2020', 1, 2),
	   ('� Agora', '12/10/2020', 3, 3),
	   ('Tempo Perdido', '07/08/2020', 4, 4);

INSERT INTO Albuns (Nome, DataLancamento, IdArtista, IdEstilo)
VALUES ('Evolve', '22/10/2017', 5, 5);


INSERT INTO TipoUsuario (Nome)
VALUES ('Comum'), ('Administrador');

INSERT INTO TipoUsuario (Nome)
VALUES ('Plebeu'), ('Realeza'), ('Esc�ria');

INSERT INTO Usuario (Nome, Telefone, Endere�o,  IdTipoUsuario)
VALUES ('Jos� Bezerra', '11 22334455', 'Rua Rio Branco de Cardoso 23', 1),
       ('Carla Santos', '11 12345678', 'Av Guaraj� 111', 4),
	   ('Judson Henrrique', '11 09876543', 'Rua dos Palmares 98', 3),
	   ('Laura Silveira', '11 54327658', 'Rua Jo�o Carlos Pereira 543', 2),
	   ('Silvio Valverde', '11 24567388', 'Av Whashington Luiz 721', 5);


-- DELETE: APAGAR DADOS
DELETE FROM Albuns
WHERE IdAlbuns = 4;


-- UPDATE: ALTERA DADOS
UPDATE Artistas
SET Nome = 'Pericles'
WHERE IdArtistas = 2;

UPDATE TipoUsuario
SET Nome = 'N�o Sei'
WHERE IdTipoUsuario = 5;

-- NAO TENHO ATRIBUTO VIZUALIZA�OES: VOU ALTERAR A DATA DE LAN�AMENTO
UPDATE Albuns
SET DataLancamento = '06/07/2020'
WHERE IdAlbuns = 4;


-- LIMPAR TODOS OS DADOS DA TABELA
TRUNCATE TABLE Albuns;
