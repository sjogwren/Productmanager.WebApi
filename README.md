# Getting Started

Please run the following script on your sql server to recreate the database:

1.	Go to sql server and connect using windows authentication
2.	Open a new query window and paste script on window
3.	Execute script by pressing F5 or execute button
4.	Wait for command to complete
5.	Database will now be created


```CREATE DATABASE dbFruitSA
GO

USE dbFruitSA
GO

select * from 


CREATE TABLE [dbo].[ExternalUser](
	[ExternalUserID] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](max) NOT NULL,
	[FirstName] [varchar](500) NULL,
	[LastName] [varchar](500) NULL,
	[PasswordHash] [varchar](max) NULL,
	[SecurityStamp] [varchar](max) NULL,
	[PhoneNumber] [varchar](50) NULL,
	[PhoneNumberConfirmed] [bit] NULL,
	[Email] [varchar](500) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NULL,
	[AccessFailedCount] [int] NULL,
	[Id] [varchar](500) NULL,
	[NormalizedUserName] [varchar](255) NULL,
	[NormalizedEmail] [varchar](255) NULL,
	[ConcurrencyStamp] [varchar](255) NULL,
	[TwoFactorEnabled] [bit] NULL,
	[LockoutEnd] [datetimeoffset] NULL,
	[CreatedBy] [varchar](500) UNIQUE,
	[CreatedOn] [datetime] NULL,
	)
GO

CREATE TABLE Category
(
	CategoryId INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Name	VARCHAR(255) UNIQUE,
	CategoryCode		VARCHAR(255),
	IsActive	BIT,
	CreatedOn DATETIME,
	CreatedBy VARCHAR(500) FOREIGN KEY REFERENCES ExternalUser(CreatedBy),
	DeletedOn DATETIME,
	DeletedBy INT
)
GO


CREATE TABLE Product
(
	ProductId	INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	ProductCode	VARCHAR(255) NOT NULL,
	Name VARCHAR(255) NOT NULL,
	Description VARCHAR(255),
	CategoryName VARCHAR(255) FOREIGN KEY REFERENCES Category(Name),
	Price DECIMAL(18,2) NOT NULL,
	Image VARCHAR(255),
	CreatedOn DATETIME,
	CreatedBy VARCHAR(500) FOREIGN KEY REFERENCES ExternalUser(CreatedBy),
	DeletedOn DATETIME,
	DeletedBy INT
)
GO



CREATE TABLE [dbo].[File](
	[FileId] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[ProductId] [int] FOREIGN KEY REFERENCES Product(ProductId),
	[FileName] [varchar](255) NOT NULL,
	[FileData] [varbinary](max) NOT NULL,
	[FileContentType] [varchar](255) NOT NULL,
	[FileLength] [int] NOT NULL,
	[CreatedOn] [datetime] NOT NULL,
	[CreatedBy] [varchar](500) FOREIGN KEY REFERENCES ExternalUser(CreatedBy),
	[DeletedOn] [datetime] NULL,
	[DeletedByUserID] [int] NULL
)
GO



CREATE TYPE ProductTypeTVP AS TABLE
(
	ProductCode	VARCHAR(255),
	Name VARCHAR(255),
	Description VARCHAR(255),
	CategoryName VARCHAR(255),
	Price DECIMAL(18,2),
	Image VARCHAR(255),
	CreatedOn Datetime,
	CreatedBy VARCHAR(255),
	DeletedOn Datetime,
	DeletedBy VARCHAR(255)

)
GO

CREATE PROCEDURE TVP_products_Insert
(
	@Products ProductTypeTVP READONLY
)
AS 
BEGIN
	


		INSERT INTO Product(ProductCode, NAME, Description, CategoryName, Price, Image, CreatedOn,
									CreatedBy, DeletedOn, DeletedBy)
		SELECT
				ProductCode, Name, Description, CategoryName, Price, Image, CreatedOn,
									CreatedBy, DeletedOn, DeletedBy
		FROM @Products


END
GO