# ShrekParkManager

Para rodar o código é necesário criar a tabela e inserir os dados no MySQL, a seguir o código do banco de dados:

```
SHOW databases;

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

CREATE TABLE IF NOT EXISTS FunFairToys
 (
	Id int NOT NULL PRIMARY KEY,
	Localization varchar(25) NOT NULL,
	NumberOfCarousels int,
	NumberOfBumperCars int,
	NumberOfRollerCoasters int
);

CREATE TABLE IF NOT EXISTS AquaticFunFairToys (
	Id int NOT NULL PRIMARY KEY,
	Localization varchar(25) NOT NULL,
	NumberOfSlides int,
	NumberOfPedalBoats int,
	NumberOfFountains int
);

CREATE TABLE IF NOT EXISTS FastFoodStores (
	Id int NOT NULL PRIMARY KEY,
	Localization varchar(25) NOT NULL,
	NumberOfFood int,
	Veggie varchar(3),
	Potato varchar(3)
);

CREATE TABLE IF NOT EXISTS Nurseries (
	Id int NOT NULL PRIMARY KEY,
	Name varchar(25),
	Leitos int,
	Localization varchar(25) NOT NULL
);

DELETE FROM  FunFairToys WHERE Id=1;
DELETE FROM  AquaticFunFairToys WHERE Id=1;
DELETE FROM  Lavatories WHERE Id=1;
DELETE FROM  Stores WHERE Id=1;
DELETE FROM  FastFoodStores WHERE Id=1;
DELETE FROM  Nurseries WHERE Id=1;

INSERT INTO FastFoodStores VALUES (1, 'PT - parte superior', 3, 'sim','sim');
INSERT INTO Nurseries VALUES (1, 'Shreks Hurt', 2,'PA - parte inferior');
INSERT INTO FunFairToys VALUES (1, 'PD - parte superior', '3', '2', '3');
INSERT INTO AquaticFunFairToys VALUES (1, 'PA - parte inferior', '6','4', '3');
INSERT INTO Lavatories VALUES (1, 'PT - parte inferior', 3, 'sim','não');
INSERT INTO Stores VALUES (1, 'C&A', 'loja','PA - parte inferior');


```
