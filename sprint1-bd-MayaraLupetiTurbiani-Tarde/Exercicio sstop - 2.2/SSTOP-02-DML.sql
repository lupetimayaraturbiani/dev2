USE EstilosMusicais_tarde;

--DML

INSERT INTO Estilos (Nome)
VALUES ('Rock Roll'), ('Metal'), ('MPB'), ('Pop'), ('Reggae'), ('HipHop'), ('Kpop'), ('Indie');

INSERT INTO Artistas (NomeArtistas, IdEstiloMusical)
VALUES ('Legião Urbana', 1), 
	   ('Mettalica', 2), 
	   ('14Bis', 3), 
	   ('Taylor Swift', 4), 
	   ('Bob Marley', 5), 
	   ('The Black Eyed Peas',6), 
	   ('Seventeen', 7), 
	   ('The Neighbourhood', 8), 
	   ('Selena Gomez', 4), 
	   ('Scorpions', 1);

INSERT INTO Artistas (IdEstiloMusical)
VALUES (1), (2), (3), (4), (5), (6), (7), (8), (4), (1);

TRUNCATE TABLE Artistas;


--DQL

SELECT * FROM Estilos;
SELECT * FROM Artistas;
SELECT Artistas.NomeArtistas, Estilos.Nome
FROM Artistas
INNER JOIN Estilos ON Estilos.IdEstilos = Artistas.IdEstiloMusical;
