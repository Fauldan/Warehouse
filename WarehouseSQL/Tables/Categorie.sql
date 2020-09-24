CREATE TABLE Categorie (
	CategorieId int IDENTITY (1,1) NOT NULL,
	Nom varchar(50) NOT NULL,
	CONSTRAINT PK_Categorie PRIMARY KEY CLUSTERED (CategorieId ASC),
	)
