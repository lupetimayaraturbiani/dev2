 --DDL Linguagem de definiçao de dados

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
	Endereço VARCHAR(250),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);



--DML LINGUAGEM DE MANIPULAÇAO DE DADOS

-- COMANDO DE INSERIR DADOS
INSERT INTO Estilos (Nome)
VALUES ('Samba'), ('Pagode'), ('MPB'), ('Rock');

INSERT INTO Estilos (Nome)
VALUES ('Indie');

INSERT INTO Estilos (Nome)
VALUES ('Pop');

INSERT INTO Artistas (Nome)
VALUES ('Zeca Pagodinho'), ('Tiaguinho'), ('Caetano Veloso'), ('Legião Urbana'); 

INSERT INTO Artistas (Nome)
VALUES ('Imagine Dragons');

INSERT INTO Artistas (Nome)
VALUES ('Halsey');

INSERT INTO Albuns (Nome, DataLancamento, IdArtista, IdEstilo)
VALUES ('Eu Cansei', '25/01/2020', 2, 2),
       ('Voltei Brasil', '30/03/2020', 1, 2),
	   ('É Agora', '12/10/2020', 3, 3),
	   ('Tempo Perdido', '07/08/2020', 4, 4);

INSERT INTO Albuns (Nome, DataLancamento, IdArtista, IdEstilo)
VALUES ('Evolve', '22/10/2017', 5, 5);

INSERT INTO Albuns (Nome, DataLancamento, IdArtista, IdEstilo)
VALUES ('Maniac', '25/01/2020', 6, 6);

INSERT INTO Albuns (Nome, DataLancamento, IdArtista, IdEstilo)
VALUES ('Night Visios', '02/03/2019', 5, 5);


INSERT INTO TipoUsuario (Nome)
VALUES ('Comum'), ('Administrador');

INSERT INTO TipoUsuario (Nome)
VALUES ('Plebeu'), ('Realeza'), ('Escória');

INSERT INTO Usuario (Nome, Telefone, Endereço,  IdTipoUsuario)
VALUES ('José Bezerra', '11 22334455', 'Rua Rio Branco de Cardoso 23', 1),
       ('Carla Santos', '11 12345678', 'Av Guarajá 111', 4),
	   ('Judson Henrrique', '11 09876543', 'Rua dos Palmares 98', 3),
	   ('Laura Silveira', '11 54327658', 'Rua João Carlos Pereira 543', 2),
	   ('Silvio Valverde', '11 24567388', 'Av Whashington Luiz 721', 5);


-- DELETE: APAGAR DADOS
DELETE FROM Albuns
WHERE IdAlbuns = 4;


-- UPDATE: ALTERA DADOS
UPDATE Artistas
SET Nome = 'Pericles'
WHERE IdArtistas = 2;

UPDATE TipoUsuario
SET Nome = 'Não Sei'
WHERE IdTipoUsuario = 5;

-- NAO TENHO ATRIBUTO VIZUALIZAÇOES: VOU ALTERAR A DATA DE LANÇAMENTO
UPDATE Albuns
SET DataLancamento = '06/07/2020'
WHERE IdAlbuns = 4;

-- LIMPAR TODOS OS DADOS DA TABELA
TRUNCATE TABLE Albuns;

-- DQL LINGUAGEM DE CONSULTA DE DADOS 
SELECT * FROM Artistas;
SELECT * FROM Estilos;
SELECT * FROM TipoUsuario;
SELECT * FROM Usuario;

SELECT Nome FROM Artistas;

SELECT Nome, DataLancamento FROM Albuns;

--Operadores < > =
SELECT * FROM Albuns WHERE IdAlbuns = 1;

SELECT * FROM Albuns WHERE IdAlbuns > 1;

-- OR OU

SELECT Nome, DataLancamento FROM Albuns 
WHERE (DataLancamento IS NULL); 

-- LIKE Comparacao de texto 

SELECT IdAlbuns, Nome FROM  Albuns
WHERE Nome LIKE 'É%' -- começo da frase

SELECT IdAlbuns, Nome FROM  Albuns
WHERE Nome LIKE '%Brasil' -- fim da fase

SELECT IdAlbuns, Nome FROM  Albuns
WHERE Nome LIKE '%Cansei%' -- meio da frase

-- ORDENAÇAO

SELECT Nome FROM Albuns
ORDER BY Nome;

SELECT IdAlbuns FROM Albuns
ORDER BY IdAlbuns;

--Ordenacao invertida (maior pro menor)

SELECT IdAlbuns, Nome FROM Albuns
ORDER BY IdAlbuns DESC;

SELECT IdAlbuns, Nome, DataLancamento FROM Albuns
ORDER BY DataLancamento ASC;

--COUNT

SELECT COUNT(IdAlbuns) FROM Albuns;

-- SELECIONAR ALBUNS DO MESMO ARTISTA
SELECT * FROM Albuns WHERE IdArtista = 5;

-- USANDO INNER JOIN (JUNCAO DE UMA OU MAIS TABELAS)
SELECT Artistas.Nome, Albuns.Nome FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtista
WHERE Albuns.IdArtista = 2;

-- SELECIONAR ALBUNS COM A MESMA DATA DE LANCAMENTO
SELECT * FROM Albuns WHERE DataLancamento = '25/01/2020';

-- COM INNER JOIN 
SELECT * FROM Artistas 
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtista
WHERE DataLancamento = '25/01/2020';


SELECT * FROM Albuns WHERE IdEstilo = 2;


-- SELECIONAR ALBUNS E ARTISTAS E ORDENAR POR DATA DE LANCAMENTO(MAIS ANTIGO AO MAIS RECENTE)
SELECT Nome, IdArtista, DataLancamento FROM Albuns
ORDER BY DataLancamento DESC;

-- COM JOIN
SELECT Artistas.Nome as NomeArtista, Albuns.Nome as NomeAlbum, DataLancamento
FROM Artistas 
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtista
ORDER BY DataLancamento DESC;

-- DESAFIO REALIZAR EXERCICIO COM INNER JOIN COM PELO MENOS 3 TABELAS
SELECT Artistas.Nome, Estilos.Nome
FROM Artistas
INNER JOIN Albuns ON Artistas.IdArtistas = Albuns.IdArtista
INNER JOIN Estilos ON Estilos.IdEstilos = Albuns.IdEstilo
WHERE Albuns.IdEstilo = 2; 

