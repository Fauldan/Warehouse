	CREATE TABLE Fournisseur (
	FournisseurId int IDENTITY (1,1) NOT NULL,
	Nom varchar(50) NOT NULL,
	NumTva int NOT NULL,
	Email varchar(255),
	NumTel varchar(25) NOT NULL,
	Rue varchar(50) NOT NULL,
	Numero int NOT NULL,
	CodePostal int NOT NULL,
	Ville varchar(50) NOT NULL,
	Pays varchar(50) NOT NULL
	CONSTRAINT PK_Fournisseur PRIMARY KEY CLUSTERED (FournisseurId ASC)
	)