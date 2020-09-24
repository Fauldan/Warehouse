CREATE PROCEDURE [dbo].[CheckUser]
	@Login varchar(25),
	@Password varchar(20)
AS
Begin
	SELECT UtilisateurId, Nom, Prenom, Email, Login, Role
	from Utilisateur
	where Login = @Login and Password = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Password + dbo.GetPostSalt());
End