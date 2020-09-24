CREATE PROCEDURE [dbo].[ArticleFull_By_Id]
	@ArticleId int
As
Begin
	Select ArticleId, Article.Nom, Quantite, PrixAchat, PrixVente, Article.CategorieId, Article.FournisseurId, Categorie.Nom as CategorieNom, Fournisseur.Nom as FournisseurNom  FROM Article 
		INNER JOIN Categorie on Article.CategorieId = Categorie.CategorieId 
		INNER JOIN Fournisseur on Article.FournisseurId = Fournisseur.FournisseurId
	Where ArticleId = @ArticleId
End