CREATE DATABASE EstilosMusicais_tarde;

USE EstilosMusicais_tarde;


CREATE TABLE Estilos (
	IdEstilos INT PRIMARY KEY IDENTITY,
	Nome VARCHAR(200) NOT NULL
);

CREATE TABLE Artistas (
	 IdArtistas INT PRIMARY KEY IDENTITY,
	 NomeArtistas VARCHAR(200) NOT NULL,
	 IdEstilosMusicais INT FOREIGN KEY REFERENCES Estilos (IdEstilos)
);

SELECT * FROM Estilos;
SELECT * FROM Artistas;

