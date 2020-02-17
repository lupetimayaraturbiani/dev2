CREATE DATABASE Filmes;

USE Filmes;

CREATE TABLE Generos (
IdGenero	INT PRIMARY KEY IDENTITY,
Nome		VARCHAR(225)
);

CREATE TABLE Filmes (
IdFilme		INT PRIMARY KEY IDENTITY,
Titulo		VARCHAR (225),
IdGenero	INT FOREIGN KEY REFERENCES Generos (IdGenero)
);


INSERT INTO Generos (Nome)
VALUES ('Ação'),
	   ('Drama'),
	   ('Comédia');






INSERT INTO Filmes (Titulo, IdGenero)
VALUES ('Rambo', 1),
       ('A vida é bela', 2),
	   ('Meu passado me condena', 3);


SELECT IdGenero, Nome FROM Generos;
