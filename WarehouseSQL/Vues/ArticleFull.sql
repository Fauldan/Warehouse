CREATE PROCEDURE [dbo].[ArticleFull]
As
Begin
	Select ArticleId, Article.Nom, Quantite, PrixAchat, PrixVente, Article.CategorieId, Article.FournisseurId, Categorie.Nom as CategorieNom, Fournisseur.Nom as FournisseurNom  FROM Article 
		INNER JOIN Categorie on Article.CategorieId = Categorie.CategorieId 
		INNER JOIN Fournisseur on Article.FournisseurId = Fournisseur.FournisseurId
End