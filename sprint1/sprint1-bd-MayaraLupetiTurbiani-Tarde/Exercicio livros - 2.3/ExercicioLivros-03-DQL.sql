USE Biblioteca_Tarde;

--DQL 
SELECT Nome FROM Generos;
SELECT NomeAutor FROM Autores;
SELECT Titulo FROM Livros;

SELECT Titulo, IdAutor FROM Livros;

SELECT Titulo, IdGenero FROM Livros;

SELECT Titulo, IdAutor, IdGenero FROM Livros;