USE EstilosMusicais_tarde;

--DQL

SELECT * FROM Estilos;
SELECT * FROM Artistas;
SELECT Artistas.NomeArtistas, Estilos.Nome
FROM Artistas
INNER JOIN Estilos ON Estilos.IdEstilos = Artistas.IdEstiloMusical;