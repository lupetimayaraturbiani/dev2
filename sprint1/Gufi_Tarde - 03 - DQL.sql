USE Gufi_Tarde;



-- DQL
SELECT Usuario.NomeUsuario, Usuario.Email, Usuario.DataNascimento, Usuario.Genero, TipoUsuario.TituloTipoUsuario
FROM Usuario
INNER JOIN TipoUsuario ON Usuario.IdTipoUsuario = TipoUsuario.IdTipoUsuario;

SELECT Instituicao.CNPJ, Instituicao.Endereco, Instituicao.Nome FROM Instituicao;

SELECT TipoEvento.TituloTipoEvento FROM TipoEvento;

SELECT Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Evento.AcessoLivre, 
TipoEvento.TituloTipoEvento,Instituicao.Nome, Instituicao.Endereco
FROM Evento
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
WHERE Evento.AcessoLivre = 1;

SELECT Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Evento.AcessoLivre, 
TipoEvento.TituloTipoEvento, Instituicao.Nome, Instituicao.Endereco, Usuario.NomeUsuario
,Usuario.NomeUsuario, Usuario.Email, Usuario.DataNascimento, Usuario.Genero, 
TipoUsuario.TituloTipoUsuario, Presenca.Situacao
FROM Presenca
INNER JOIN Evento ON Evento.IdEvento = Presenca.IdEvento
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
INNER JOIN Usuario ON Usuario.IdUsuario = Presenca.IdUsuario
INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario
WHERE Usuario.IdUsuario = 2;

SELECT * FROM Presenca;


SELECT Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, 
Instituicao.Nome AS NomeInstituicao,
CASE 
	WHEN AcessoLivre = '1' THEN 'Público'
	WHEN AcessoLivre = '0' THEN 'Privado'
END AS TipoAcesso
FROM Evento
INNER JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
INNER JOIN Presenca ON Presenca.IdPresenca = Presenca.IdEvento
WHERE Presenca.Situacao = 'Confirmada';

SELECT Evento.NomeEvento, Evento.DataEvento, Evento.Descricao, Evento.AcessoLivre, 
TipoEvento.TituloTipoEvento, Instituicao.Nome, Instituicao.Endereco, Usuario.NomeUsuario
,Usuario.NomeUsuario, Usuario.Email, Usuario.DataNascimento, Usuario.Genero, 
TipoUsuario.TituloTipoUsuario, Presenca.Situacao
FROM Presenca
INNER JOIN Evento ON Evento.IdEvento = Presenca.IdEvento
INNER JOIN TipoEvento ON TipoEvento.IdTipoEvento = Evento.IdTipoEvento
INNER JOIN Instituicao ON Instituicao.IdInstituicao = Evento.IdInstituicao
INNER JOIN Usuario ON Usuario.IdUsuario = Presenca.IdUsuario
INNER JOIN TipoUsuario ON TipoUsuario.IdTipoUsuario = Usuario.IdTipoUsuario
WHERE Usuario.IdUsuario = 2
AND Presenca.Situacao = 'Confirmada';

