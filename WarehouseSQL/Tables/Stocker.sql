CREATE TABLE Stocker (
	StockerId int IDENTITY (1,1) NOT NULL,
	UtilisateurId int NOT NULL,
	ArticleId int NOT NULL,
	Quantite int NOT NULL,
	CONSTRAINT PK_Stocker PRIMARY KEY CLUSTERED (StockerId ASC),
	CONSTRAINT FK_Stocker_Article FOREIGN KEY (ArticleId)
		REFERENCES Article,
	CONSTRAINT FK_Stocker_Utilisateur FOREIGN KEY (UtilisateurId)
		REFERENCES Utilisateur
	)