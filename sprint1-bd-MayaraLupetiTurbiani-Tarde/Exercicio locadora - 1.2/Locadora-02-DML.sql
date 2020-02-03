USE Locadora_Tarde;

--DML


INSERT INTO Empresa (Nome)
VALUES ('Unidas'), ('Localiza');

INSERT INTO Marca (Nome)
VALUES ('Ford'), ('GM'), ('Fiat');

INSERT INTO Cliente (Nome, CPF)
VALUES ('Fernando', 1231231233),
       ('Helena', 4564564565);

INSERT INTO Modelo (Nome, IdMarca)
VALUES ('Fiesta', 1),
       ('Onix', 2),
	   ('Argo', 3);

INSERT INTO Veiculo (Placa, IdModelo, IdEmpresa)
VALUES ('HEL1805', 1, 1),
       ('FER1010', 2, 1),
	   ('POR1978', 3, 2),
	   ('LEM9876', 1, 2);

INSERT INTO Aluguel (DataInicio, DataFim, IdCliente, IdVeiculo)
VALUES ('19/01/2019', '20/01/2019', 1, 1),
       ('20/01/2019', '21/01/2019', 1, 2),
	   ('21/01/2019', '21/01/2019', 2, 3),
	   ('22/01/2019', '22/01/2019', 2, 2);
		