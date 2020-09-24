CREATE PROCEDURE [dbo].[RegisterUser]
	@Nom nvarchar(50),
	@Prenom nvarchar(50),
	@Email nvarchar(255),
	@Login varchar(25),
	@Password varchar(20)
As 
Begin
	Insert into Utilisateur (Nom, Prenom, Email, Login, Password)
		Values (@Nom, @Prenom, @Email, @Login, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Password + dbo.GetPostSalt()));
End