CREATE TABLE Article (
	ArticleId int IDENTITY (1,1) NOT NULL,
	Nom varchar(50) NOT NULL,
	Quantite int NOT NULL,
	PrixAchat real NOT NULL,
	PrixVente real NOT NULL,
	FournisseurId int NOT NULL,
	CategorieId int NOT NULL,
	CONSTRAINT PK_Article PRIMARY KEY CLUSTERED (ArticleId ASC),
	CONSTRAINT FK_Fournisseur_Article FOREIGN KEY (FournisseurId)
		REFERENCES Fournisseur,	
	CONSTRAINT FK_Categorie_Article FOREIGN KEY (CategorieId)
		REFERENCES Categorie
	)