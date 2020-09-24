CREATE TABLE Expedition (
	ExpeditionId int IDENTITY (1,1) NOT NULL,
	UtilisateurId int NOT NULL,
	ArticleId int NOT NULL,
	ClientId int NOT NULL,
	Quantite int NOT NULL,
	CONSTRAINT PK_Expedition PRIMARY KEY CLUSTERED (ExpeditionId ASC),
	CONSTRAINT FK_Expedition_Article FOREIGN KEY (ArticleId)
		REFERENCES Article,
	CONSTRAINT FK_Expedition_Utilisateur FOREIGN KEY (UtilisateurId)
		REFERENCES Utilisateur,
	CONSTRAINT FK_Expedition_Client FOREIGN KEY (ClientId)
		REFERENCES Client
	)