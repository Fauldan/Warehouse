/*
Script de déploiement pour LaboWarehouse

Ce code a été généré par un outil.
La modification de ce fichier peut provoquer un comportement incorrect et sera perdue si
le code est régénéré.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "LaboWarehouse"
:setvar DefaultFilePrefix "LaboWarehouse"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
/*
Détectez le mode SQLCMD et désactivez l'exécution du script si le mode SQLCMD n'est pas pris en charge.
Pour réactiver le script une fois le mode SQLCMD activé, exécutez ce qui suit :
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'Le mode SQLCMD doit être activé de manière à pouvoir exécuter ce script.';
        SET NOEXEC ON;
    END


GO
USE [master];


GO

IF (DB_ID(N'$(DatabaseName)') IS NOT NULL) 
BEGIN
    ALTER DATABASE [$(DatabaseName)]
    SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE [$(DatabaseName)];
END

GO
PRINT N'Création de $(DatabaseName)...'
GO
CREATE DATABASE [$(DatabaseName)]
    ON 
    PRIMARY(NAME = [$(DatabaseName)], FILENAME = N'$(DefaultDataPath)$(DefaultFilePrefix)_Primary.mdf')
    LOG ON (NAME = [$(DatabaseName)_log], FILENAME = N'$(DefaultLogPath)$(DefaultFilePrefix)_Primary.ldf') COLLATE SQL_Latin1_General_CP1_CI_AS
GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CLOSE OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                NUMERIC_ROUNDABORT OFF,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                CURSOR_CLOSE_ON_COMMIT OFF,
                AUTO_CREATE_STATISTICS ON,
                AUTO_SHRINK OFF,
                AUTO_UPDATE_STATISTICS ON,
                RECURSIVE_TRIGGERS OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ALLOW_SNAPSHOT_ISOLATION OFF;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET READ_COMMITTED_SNAPSHOT OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_UPDATE_STATISTICS_ASYNC OFF,
                PAGE_VERIFY NONE,
                DATE_CORRELATION_OPTIMIZATION OFF,
                DISABLE_BROKER,
                PARAMETERIZATION SIMPLE,
                SUPPLEMENTAL_LOGGING OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET TRUSTWORTHY OFF,
        DB_CHAINING OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
IF IS_SRVROLEMEMBER(N'sysadmin') = 1
    BEGIN
        IF EXISTS (SELECT 1
                   FROM   [master].[dbo].[sysdatabases]
                   WHERE  [name] = N'$(DatabaseName)')
            BEGIN
                EXECUTE sp_executesql N'ALTER DATABASE [$(DatabaseName)]
    SET HONOR_BROKER_PRIORITY OFF 
    WITH ROLLBACK IMMEDIATE';
            END
    END
ELSE
    BEGIN
        PRINT N'Impossible de modifier les paramètres de base de données. Vous devez être administrateur système pour appliquer ces paramètres.';
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET FILESTREAM(NON_TRANSACTED_ACCESS = OFF),
                CONTAINMENT = NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET AUTO_CREATE_STATISTICS ON(INCREMENTAL = OFF),
                MEMORY_OPTIMIZED_ELEVATE_TO_SNAPSHOT = OFF,
                DELAYED_DURABILITY = DISABLED 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE (QUERY_CAPTURE_MODE = ALL, DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_PLANS_PER_QUERY = 200, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 367), MAX_STORAGE_SIZE_MB = 100) 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET QUERY_STORE = OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
        ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
        ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET TEMPORAL_HISTORY_RETENTION ON 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF fulltextserviceproperty(N'IsFulltextInstalled') = 1
    EXECUTE sp_fulltext_database 'enable';


GO
PRINT N'Création de [dbo].[Adresse]...';


GO
CREATE TABLE [dbo].[Adresse] (
    [AdresseId]     INT          IDENTITY (1, 1) NOT NULL,
    [Rue]           VARCHAR (50) NOT NULL,
    [Numero]        INT          NOT NULL,
    [CodePostal]    INT          NOT NULL,
    [Ville]         VARCHAR (50) NOT NULL,
    [Pays]          VARCHAR (50) NOT NULL,
    [ClientId]      INT          NULL,
    [FournisseurId] INT          NULL,
    CONSTRAINT [PK_Adresse] PRIMARY KEY CLUSTERED ([AdresseId] ASC)
);


GO
PRINT N'Création de [dbo].[Article]...';


GO
CREATE TABLE [dbo].[Article] (
    [ArticleId]     INT          IDENTITY (1, 1) NOT NULL,
    [Nom]           VARCHAR (50) NOT NULL,
    [Quantite]      INT          NOT NULL,
    [PrixAchat]     REAL         NOT NULL,
    [PrixVente]     REAL         NOT NULL,
    [FournisseurId] INT          NOT NULL,
    CONSTRAINT [PK_Article] PRIMARY KEY CLUSTERED ([ArticleId] ASC)
);


GO
PRINT N'Création de [dbo].[Categorie]...';


GO
CREATE TABLE [dbo].[Categorie] (
    [CategorieId] INT          IDENTITY (1, 1) NOT NULL,
    [Nom]         VARCHAR (50) NOT NULL,
    [ArticleId]   INT          NOT NULL,
    CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED ([CategorieId] ASC)
);


GO
PRINT N'Création de [dbo].[Client]...';


GO
CREATE TABLE [dbo].[Client] (
    [ClientId]   INT           IDENTITY (1, 1) NOT NULL,
    [Nom]        VARCHAR (50)  NOT NULL,
    [Prenom]     VARCHAR (50)  NOT NULL,
    [NomSociete] VARCHAR (50)  NULL,
    [NumTva]     INT           NULL,
    [Email]      VARCHAR (255) NULL,
    [NumTel]     INT           NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([ClientId] ASC)
);


GO
PRINT N'Création de [dbo].[Expedier]...';


GO
CREATE TABLE [dbo].[Expedier] (
    [ExpedierId]    INT IDENTITY (1, 1) NOT NULL,
    [UtilisateurId] INT NOT NULL,
    [ArticleId]     INT NOT NULL,
    [ClientId]      INT NOT NULL,
    [Quantite]      INT NOT NULL,
    CONSTRAINT [PK_Expedier] PRIMARY KEY CLUSTERED ([ExpedierId] ASC)
);


GO
PRINT N'Création de [dbo].[Fournisseur]...';


GO
CREATE TABLE [dbo].[Fournisseur] (
    [FournisseurId] INT           IDENTITY (1, 1) NOT NULL,
    [Nom]           VARCHAR (50)  NOT NULL,
    [NumTva]        INT           NOT NULL,
    [Email]         VARCHAR (255) NULL,
    [NumTel]        INT           NULL,
    CONSTRAINT [PK_Fournisseur] PRIMARY KEY CLUSTERED ([FournisseurId] ASC)
);


GO
PRINT N'Création de [dbo].[Receptionner]...';


GO
CREATE TABLE [dbo].[Receptionner] (
    [ReceptionnerId] INT IDENTITY (1, 1) NOT NULL,
    [UtilisateurId]  INT NOT NULL,
    [ArticleId]      INT NOT NULL,
    [Quantite]       INT NOT NULL,
    CONSTRAINT [PK_Receptionner] PRIMARY KEY CLUSTERED ([ReceptionnerId] ASC)
);


GO
PRINT N'Création de [dbo].[Stocker]...';


GO
CREATE TABLE [dbo].[Stocker] (
    [StockerId]     INT IDENTITY (1, 1) NOT NULL,
    [UtilisateurId] INT NOT NULL,
    [ArticleId]     INT NOT NULL,
    [Quantite]      INT NOT NULL,
    CONSTRAINT [PK_Stocker] PRIMARY KEY CLUSTERED ([StockerId] ASC)
);


GO
PRINT N'Création de [dbo].[Utilisateur]...';


GO
CREATE TABLE [dbo].[Utilisateur] (
    [UtilisateurId] INT           IDENTITY (1, 1) NOT NULL,
    [Nom]           VARCHAR (50)  NOT NULL,
    [Prenom]        VARCHAR (50)  NOT NULL,
    [Email]         VARCHAR (255) NOT NULL,
    [Login]         VARCHAR (25)  NOT NULL,
    [Password]      BINARY (64)   NOT NULL,
    [Role]          VARCHAR (1)   NOT NULL,
    CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED ([UtilisateurId] ASC),
    UNIQUE NONCLUSTERED ([Login] ASC)
);


GO
PRINT N'Création de contrainte sans nom sur [dbo].[Utilisateur]...';


GO
ALTER TABLE [dbo].[Utilisateur]
    ADD DEFAULT 'USER' FOR [Role];


GO
PRINT N'Création de [dbo].[FK_Client_Adresse]...';


GO
ALTER TABLE [dbo].[Adresse]
    ADD CONSTRAINT [FK_Client_Adresse] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([ClientId]);


GO
PRINT N'Création de [dbo].[FK_Fournisseur_Adresse]...';


GO
ALTER TABLE [dbo].[Adresse]
    ADD CONSTRAINT [FK_Fournisseur_Adresse] FOREIGN KEY ([FournisseurId]) REFERENCES [dbo].[Fournisseur] ([FournisseurId]);


GO
PRINT N'Création de [dbo].[FK_Fournisseur_Article]...';


GO
ALTER TABLE [dbo].[Article]
    ADD CONSTRAINT [FK_Fournisseur_Article] FOREIGN KEY ([FournisseurId]) REFERENCES [dbo].[Fournisseur] ([FournisseurId]);


GO
PRINT N'Création de [dbo].[FK_Article_Categorie]...';


GO
ALTER TABLE [dbo].[Categorie]
    ADD CONSTRAINT [FK_Article_Categorie] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]);


GO
PRINT N'Création de [dbo].[FK_Expedier_Article]...';


GO
ALTER TABLE [dbo].[Expedier]
    ADD CONSTRAINT [FK_Expedier_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]);


GO
PRINT N'Création de [dbo].[FK_Expedier_Utilisateur]...';


GO
ALTER TABLE [dbo].[Expedier]
    ADD CONSTRAINT [FK_Expedier_Utilisateur] FOREIGN KEY ([UtilisateurId]) REFERENCES [dbo].[Utilisateur] ([UtilisateurId]);


GO
PRINT N'Création de [dbo].[FK_Expedier_Client]...';


GO
ALTER TABLE [dbo].[Expedier]
    ADD CONSTRAINT [FK_Expedier_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([ClientId]);


GO
PRINT N'Création de [dbo].[FK_Receptionner_Article]...';


GO
ALTER TABLE [dbo].[Receptionner]
    ADD CONSTRAINT [FK_Receptionner_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]);


GO
PRINT N'Création de [dbo].[FK_Receptionner_Utilisateur]...';


GO
ALTER TABLE [dbo].[Receptionner]
    ADD CONSTRAINT [FK_Receptionner_Utilisateur] FOREIGN KEY ([UtilisateurId]) REFERENCES [dbo].[Utilisateur] ([UtilisateurId]);


GO
PRINT N'Création de [dbo].[FK_Stocker_Article]...';


GO
ALTER TABLE [dbo].[Stocker]
    ADD CONSTRAINT [FK_Stocker_Article] FOREIGN KEY ([ArticleId]) REFERENCES [dbo].[Article] ([ArticleId]);


GO
PRINT N'Création de [dbo].[FK_Stocker_Utilisateur]...';


GO
ALTER TABLE [dbo].[Stocker]
    ADD CONSTRAINT [FK_Stocker_Utilisateur] FOREIGN KEY ([UtilisateurId]) REFERENCES [dbo].[Utilisateur] ([UtilisateurId]);


GO
PRINT N'Création de [dbo].[GetPostSalt]...';


GO
CREATE FUNCTION [dbo].[GetPostSalt]
(
)
RETURNS NCHAR(2048)
AS
BEGIN
	RETURN N'?h8TN_*yGGq6nQj^xm3GMb3?8d#SCXb-d5qsXEeF*M6*=QTSRQmksnuXH9ECCRK3qYLyj2awhdBMEJU!MDcb7vxBPh=Qj&?6EtnEL8^&2up&BzQ77b@C-QTBzetutSevreGR2Y_pzwxT_NkwWL8SJU7H7xe%v-c#A93phWwfHaT*78HMx&&T*B6LJK&UmAr93VsCAW=nJqxY2wd_N!=JB48M&4cNg7-g%Q4&ZSJ-fvZ#9yy48q@Zfefa_UUnR5^8%&M-RNcjsap4X+gMC#LgsEdEbG5!ZFUJ#sew?zVLmkjq3aW#J&RtqmwfNGsb!ksB7$-Y_q!w%_XcHr_quzpt^Dg9e*PzDT2wUBfu76sSKm_Jm6S8gtFNkTs2qex$CDe!xJbecYn&qkGv%723FYEGqCmq+aPwNpsj7=FFqu?-%h9ms+WqX^9vw*+e%zpEmPfZ=KraNJArtmuBVZCe3d+58CEz8dEdDGjQgnLX+4$F*_^63mY6ePm^?hs+*V$2dLUQ%^nGrRKM^qM!gu-_$FuMgb=jG&Yak4rw8zkD5^sveHBT!7TmzHMfSuzb^syy4D_UZbrntaKWsCh2A4bX&yj*h*S#T*9V53%upp?x77pXBs^9hegbwLw6Dv$H*umxQLu+J=_2_?7MCX-8MGquVd8TSzpk#?YrR^QG&e=VNAA8AX@?#Xq&97f-b?EqHeeR-NBTUcn2JG5S8qf3Qj=jbeRdHs@ej$L+5&?A7FNLv5NDQR9zS_J!mcLA#7$y6JQc=uajmUjkxkL_3_LUcvn=%a!XfB4vAypMsFEyJqWSVvNqAA2Ep$r_*cN@t7kTWs=7sK=taDGbUdW&pwAcftscX&WPethvH9c5Mp^cS5q#Fe-8*=wBZ3kdx#QpK@kmE57+bLwc-zvjN%JwLjtLxDt$Wc@f^xBDBZ=bJShsB&*+?Cp!24c&kNp7CvCVy4X$UJ4ssMyz=zJRGF6#ycT?A@+7LKzK65uA33qGnuUvERZ=GqgZKkaH^KhbKt&UkkR7z=68frcLGcqt+k=_=c&AcM=Ke+tsUD$_aG@TUxbwd*hAJJFz+YJ^kgJ7Ln9MznG4RJAsY*-KM%mbZV9ka8JVCf?#Avw#KzyG*FyA+a8Xj4#wrCy87qLJ_$vAZBWb53H2?G&B_AvpHqXVNV*&68VR&SZSEQ&Y3?sbp6HYqy4Cb7g?wxG#Vsbz_w-Gc%4#nKExWGRpJGWkchr^R%2q2y2YBg6FNCasV^BeVKKpQG&zKZuT_cFw3&2WMghSTc#Bc$66zd5^QEVnhqnfhMx-bN7jUdaUCK!+*$?-9CBzjwe@+eet%!6H^Q?eu34X@AG3!wY-W63mLBmBrGd!u5NWY8yqrA7d_V+2vx9tm_#*KNsQmNKK*u%!=%qAAXQk9Z#q#m%u6QP7-hkGzA4W@V+%G-4U=cFxHFsjqQ*G%w_DK2hPdJKvXEv+TD8@K@-AYb2H6a?r6Y^$*yyD=?qE5hjZ&t2XQFjY^!zp29V2qMWEDr8NBec9$HN-wcYuEdmLp%Z+#V2Rzt8nXytE?pXpW#nBXq&sZf3Z+GADr?3#c6Fw4LDp%M^58Hjc?spsMLCK%ju+5KDpPbvQKnWZV+nE5Sxz*B3t&69Fpt+L76Z!6svJb6AQ_yFEyumbbJK@v4h2@DwrnzU%z6*2cf=uxAmLj?pSQjsn?TYV*%n2E626q?3ZLJT=s59dS_Np=d3vSpvv*drH_?Ts9EWdSYKSs2HP@*?Kt2bDFSY+&#_7ZtgEZJJ@x=QGBnuHg94m-wG+eXHyCEd6M*A$u6!__=5nB8L=@q?4AqD#4neeQRrqKR#Kv2q8TB*LcvJ+eqeEzubSJYxbsMareQgX7q75AjcZB!Etz44uJKH62w-?f$7zw2K?#_RCZAsXnXbTA=wsKsZN9KSa@G$n7gXg$!#V^SpFjT5Z_Nr!?bLL5$$E?cM=9_GF?%Lp-ma!=D%c-2_a5DuZbjrXAq&#nfa?G4@?YeD*SH@ZtmeJ7QfSXf=ZtxpDU-UtR7CHs2C5v9gS%p6d4qfQGcx5pVDa&=UA7TGHuzNx';
END
GO
PRINT N'Création de [dbo].[GetPreSalt]...';


GO
CREATE FUNCTION [dbo].[GetPreSalt]
(
)
RETURNS NCHAR(2048)
AS
BEGIN
	RETURN N'huuMbB!wus^k?9t?STR&wC6K?h8^r?S&H%s-SycX6e9ZKLNY-DdBc*V=zAfNvbE4L%p^@zJKyuW*SbL^uJLXK2TYW_+--9kj_d#E?Pk4L6!D+d=-Td7*?@8Ns+26vPkZ!DC%kQu7=dZRzwqn_jX4nG^Xx^g?kT6jyCr9NTV$k435zmU&LcyvuP-7cnBLmquKH^XT^T##bt^VH3QSKmf=eSSG33LjKmfTGSJrWCXLUe!nYjS6GCZUE@*BET?V!zem+zT*kQ6GPWR4vqs8f!ry8q=LN_G_rq=P=V6s9$8J6WKdW^M$-vabCrJQPXCy6X632S6s=spJN5-tdtAPpA7e*T^Su%+EqwD#^JVG=Us^?L9p@8@7TbN4mbL%-Py#qfRmF2Lwe3Kx%C!-bNjGysM8N+UEkC%p7Gs3xVP^JtzCVsu2%9P9L%6REcKs@N8@C3^Nsv4T#C_N$5T!Ne#JteXR%btqcG@R9ekE@jD+nXGU82DN&V5qmyc%D^wX5KS5t5J8WL2c?5V$Zd4zyJyn*KAp!QB@e8a_@SqAdS^z_EW^gUp4Zd=**e9G3CvcA8Ps3g$M*pSY+tmKCCa6bc6_SFk=aQ9wR!*4ZGYC&yunJ*XhNVfU5d%bFZ6Pb&nNSbQRd8vnqL952KjXUjT%rfLQ^-H4a*REgABtV6kEY_^um74RsUk+t7=G@p9#Vaa4jwgDD?HT9eVXQc4naK-tY2=H3z&HvLeV-C?-e4HbL6pVXk+brUw7C=zYv7uSHkYXrnUff6yGz+u8=haxnJbFKEgfNFgHXV*p4$!kgMtFmCSZhX%QDa%Fw7V?JtLJd87LD$6RckKBc?kvNLpfjwwvcx4@Nty=@xc*CnePs&mUL8_=?fM@!kgPU^mznScASra$HP2D5rYD!aNYJfjFn!nF#W4n%vUUfd%5DrhPxe3A$Kc&TZu!2qKejYUydVsaWca+YuatdwJJXzqa^RygE&4!7qSJKQZyCUeRte_QTtzuq=E!=?BzTmFHcX_7+gc@jWB&LuJJ&d9LtQ2Z4YGs*YDcUNPTqeGD%_&GGW4ns_&WYsEC#V_^hcj3xf@$TTQKz#cxVD5r!EqDWGYJYERH$NFtcXpdGYg5FCBsEB-@n_ZsS%YqstQ3JQ@zp#xDXhNwEYXwCQ+d%=UD@#S#p9vHPB#=y$AF%@9=4Bn^re-X!w^n23Vy2RFNFe+5MS$6F=GT=VLR?6_ta*Fc2UawLs+_%_*Z2sWqCK#8@?!ae9Gz#@N6cY=Xmz5@_8@B@JtxzWGF?Ln%?NfadWREguDa^%EdXXBhUPJg%*Ls%HKfbSew$*BCVq=Eu4Z@j+HQBcEpx6ZrA8R?355tM3!-s!+^76c*uVmYaGm?g3FtJ4K%v9PS@dmVVPT#gKzfvCm5aQN@@ecgvsN*U$#j+*L#@H$sUC_T@DscGPVtMy+zt?-9rQs9zk6N?!BXgkHqgGV+WZKJNKEm%uh!bF*W-Y3*=7L7wSHN?&##h2Nd7RuAhK#JY$tLLdCa=_N^nNsCu9Pme2LQmddmsEuU9vsM2bLn5J2V#!BJau?*?5n93jJBQn58A&2EnqAREgCWN@7q=zaB?L4CLc4MKquz7GV5RQh^DJQyfHUKf*JCK9KGWYwZ$Nh84_QuJGjam4tVX4K?@59j+k+nHmUyzD8mP!hx!@Qa78&Jt-betKGZq9&k#55K+axjH^6J4&p==@*y97$2Z?wX7HPn3S%@ynPJ@WJZXFJFa&s5T%h!F#8?cun5D9g!AXc%d_Rp8MQJxhQqd%MmweCLz&f7xWR&CRW=BUa7m%*wHu9^DccT*SqpBJWQQU3!W*&hKc-Ygub+d?ZXrN4DYnTk6%fNF9zQLnZu$q3M2dKX@mK5c&@*g5%!3n3E@f8!=9FhTb7U%YxkxznfxKVSCMjZ!!S!5weT+cJ8$BRHb^W&KYuB7BfVsA%xQ?8avVQKKVLhS95A=s-7SAzM5VSf2&zJ69gwEwch8H!_vcbSeQwEQ%#9$w#5fNVJ%ZVx3vqy2vXHPg%SUs6#HaV6_a-VQQ-#C^j6x6vj-vS4reLdcW!H';
END
GO
PRINT N'Création de [dbo].[CheckUser]...';


GO
CREATE PROCEDURE [dbo].[CheckUser]
	@Login varchar(25),
	@Password varchar(20)
AS
Begin
	SELECT UtilisateurId, Nom, Prenom, Email, Login, Role
	from Utilisateur
	where Login = @Login and Password = HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Password + dbo.GetPostSalt());
End
GO
PRINT N'Création de [dbo].[RegisterUser]...';


GO
CREATE PROCEDURE [dbo].[RegisterUser]
	@Nom nvarchar(50),
	@Prenom nvarchar(50),
	@Email nvarchar(255),
	@Login varchar(25),
	@Password varchar(20)
AS
Begin
	Insert into Utilisateur (Nom, Prenom, Email, Login, Password)
	Values (@Nom, @Prenom, @Email, @Login, HASHBYTES('SHA2_512', dbo.GetPreSalt() + @Password + dbo.GetPostSalt()));
End
GO
DECLARE @VarDecimalSupported AS BIT;

SELECT @VarDecimalSupported = 0;

IF ((ServerProperty(N'EngineEdition') = 3)
    AND (((@@microsoftversion / power(2, 24) = 9)
          AND (@@microsoftversion & 0xffff >= 3024))
         OR ((@@microsoftversion / power(2, 24) = 10)
             AND (@@microsoftversion & 0xffff >= 1600))))
    SELECT @VarDecimalSupported = 1;

IF (@VarDecimalSupported > 0)
    BEGIN
        EXECUTE sp_db_vardecimal_storage_format N'$(DatabaseName)', 'ON';
    END


GO
PRINT N'Mise à jour terminée.';


GO
