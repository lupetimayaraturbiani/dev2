-- DDL

-- CRIAR BANCO DE DADOS
CREATE DATABASE Biblioteca_Tarde;

 -- Apontar para o banco que quero usar
USE Biblioteca_Tarde;

 -- CRIAR TABELAS
 CREATE TABLE Autores (
	IdAutor		INT PRIMARY KEY IDENTITY,
	NomeAutor	VARCHAR(200) NOT NULL
);

CREATE TABLE Generos (
	IdGenero	INT PRIMARY KEY IDENTITY,
	Nome		VARCHAR(200) NOT NULL
);

CREATE TABLE Livros (
	IdLivro		INT PRIMARY KEY IDENTITY,
	Titulo		VARCHAR(255),
	IdAutor		INT FOREIGN KEY REFERENCES Autores (IdAutor),
	IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);

 -- ALTERAR: ADICIONAR NOVA COLUNA
 ALTER TABLE Generos
 ADD Descricao VARCHAR(255)

 -- ALTERAR: TIPO DE DADO
 ALTER TABLE  Generos
 ALTER COLUMN Descricao CHAR (100);

 -- ALTERAR EXCLUIR COLUNA 
ALTER TABLE Generos 
DROP COLUMN Descricao;

 -- EXCLUIR
 DROP TABLE Livros;

 -- EXCLUIR BANCO DE DADOS
 DROP DATABASE Biblioteca_Tarde;


 -- DML
 INSERT INTO Autores (NomeAutor)
 VALUES ('Sarah J Maas'), ('Kiera Cass'), ('Tracy Banghart'), (' J. R. R. Tolkien'), (' William P. Young');

  INSERT INTO Generos (Nome)
 VALUES ('Aventura'), ('Romance'), ('Ficção'), ('Suspense'), ('Fantasia');

  INSERT INTO Livros (Titulo, IdAutor, IdGenero)
 VALUES ('Trono de Vidro', 1, 3),
        ('Graça e Fúria', 3, 1),
		('O Senhor Dos Anéis', 4, 5),
		('A Seleção', 2, 2),
		('A Cabana', 5, 4);


UPDATE Generos
SET Nome = 'Aventura'
WHERE IdGenero = '1';

UPDATE Livros
SET IdGenero = '3'
WHERE IdLivro = '2';

DELETE FROM Autores
WHERE IdAutor = 4;

--DQL 
SELECT Nome FROM Generos;
SELECT NomeAutor FROM Autores;
SELECT Titulo FROM Livros;

SELECT Titulo, IdAutor FROM Livros;

SELECT Titulo, IdGenero FROM Livros;

SELECT Titulo, IdAutor, IdGenero FROM Livros;
