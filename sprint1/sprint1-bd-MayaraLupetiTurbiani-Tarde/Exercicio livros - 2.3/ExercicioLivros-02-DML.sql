USE Biblioteca_Tarde;

 -- DML
 INSERT INTO Autores (NomeAutor)
 VALUES ('Sarah J Maas'), ('Kiera Cass'), ('Tracy Banghart'), (' J. R. R. Tolkien'), (' William P. Young');

  INSERT INTO Generos (Nome)
 VALUES ('Aventura'), ('Romance'), ('Fic��o'), ('Suspense'), ('Fantasia');

  INSERT INTO Livros (Titulo, IdAutor, IdGenero)
 VALUES ('Trono de Vidro', 1, 3),
        ('Gra�a e F�ria', 3, 1),
		('O Senhor Dos An�is', 4, 5),
		('A Sele��o', 2, 2),
		('A Cabana', 5, 4);


UPDATE Generos
SET Nome = 'Aventura'
WHERE IdGenero = '1';

UPDATE Livros
SET IdGenero = '3'
WHERE IdLivro = '2';

DELETE FROM Autores
WHERE IdAutor = 4;

