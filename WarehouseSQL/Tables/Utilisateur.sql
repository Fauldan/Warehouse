CREATE TABLE Utilisateur (
	UtilisateurId int IDENTITY (1,1) NOT NULL,
	Nom varchar(50) NOT NULL,
	Prenom varchar(50) NOT NULL,
	Email varchar(255) NOT NULL,
	Login varchar(25) UNIQUE NOT NULL,
	Password binary(64) NOT NULL,
	Role varchar (50) NOT NULL DEFAULT 'USER',
	CONSTRAINT PK_Utilisateur PRIMARY KEY CLUSTERED (UtilisateurId ASC)
	)