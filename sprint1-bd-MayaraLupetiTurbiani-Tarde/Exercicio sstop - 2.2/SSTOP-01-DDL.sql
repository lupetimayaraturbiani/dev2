--DDL

CREATE DATABASE EstilosMusicais_tarde;

USE EstilosMusicais_tarde;


CREATE TABLE Estilos (
	IdEstilos INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL
);

CREATE TABLE Artistas (
	 IdArtistas INT PRIMARY KEY IDENTITY,
	 NomeArtistas VARCHAR(200),
	 IdEstilosMusicais INT FOREIGN KEY REFERENCES Estilos (IdEstilos)
);


ALTER TABLE  Estilos
ALTER COLUMN Nome VARCHAR (200);

