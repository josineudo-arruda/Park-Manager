# ShrekParkManager

Para rodar o código é necesário criar a tabela e inserir os dados no MySQL, a seguir o código do banco de dados:

```
CREATE DATABASE IF NOT EXISTS estudante;

USE estudante;

CREATE TABLE IF NOT EXISTS Lavatories (
	Id int NOT NULL PRIMARY KEY,
	Localization varchar(25) NOT NULL,
    NumberOfBooths int,
    Mirror varchar(3),
	ToiletPaper varchar(3)
);

CREATE TABLE IF NOT EXISTS Stores (
	Id int NOT NULL PRIMARY KEY,
    Brand varchar(25) NOT NULL,
    Type varchar(25),
    Localization varchar(25) NOT NULL
);

INSERT INTO Lavatories VALUES (1, 'PT - parte inferior', 3, 'sim','não');
INSERT INTO Stores VALUES (1, 'C&A', 'loja','PA - parte inferior');

SELECT * FROM Lavatories;
SELECT * FROM Stores;

```
