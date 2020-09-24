CREATE TABLE Receptionner (
	ReceptionnerId int IDENTITY (1,1) NOT NULL,
	FournisseurNom varchar(50)  NOT NULL,
	FournisseurVille varchar(50)  NOT NULL,
	FournisseurPays varchar(50) NOT NULL,
	UtilisateurId int NOT NULL,
	ArticleId int NOT NULL,
	ArticleNom varchar(50) NOT NULL,
	Quantite int NOT NULL,
	CONSTRAINT PK_Receptionner PRIMARY KEY CLUSTERED (ReceptionnerId ASC),
	CONSTRAINT FK_Receptionner_Article FOREIGN KEY (ArticleId)
		REFERENCES Article,
	CONSTRAINT FK_Receptionner_Utilisateur FOREIGN KEY (UtilisateurId)
		REFERENCES Utilisateur
	)