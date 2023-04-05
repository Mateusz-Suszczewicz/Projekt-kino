ALTER TABLE dbo.booking
	ADD Book_Status int 

ALTER TABLE dbo.films
	ADD Film_Language varchar(20),
		Film_Translation varchar(50),
		Film_Production varchar(300)

DECLARE @CONSTRAINT_NAME NVARCHAR(1000)
SELECT @CONSTRAINT_NAME=CONSTRAINT_NAME FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS WHERE  CONSTRAINT_TYPE='FOREIGN KEY' AND TABLE_NAME = 'films' AND TABLE_SCHEMA ='dbo'
DECLARE @sql NVARCHAR(1000) = 'ALTER TABLE dbo.films  DROP CONSTRAINT ' + @CONSTRAINT_NAME;
EXEC (@sql)

ALTER TABLE dbo.films
	DROP COLUMN Film_SrcPicture, Film_CatID

CREATE TABLE dbo.picture(
	Pic_ID int not null IDENTITY(1,1),
	Pic_FilmID int not null,
	Pic_Src varchar(300) not null

	PRIMARY KEY (Pic_ID),
	FOREIGN KEY (Pic_FilmID) REFERENCES dbo.films(Film_ID)
)

CREATE TABLE dbo.cat_film(
	CF_ID int not null IDENTITY(1,1),
	CF_CatID int not null,
	CF_FilmID int not null

	PRIMARY KEY (CF_ID)
	FOREIGN KEY (CF_CatID) REFERENCES dbo.category(Cat_ID),
	FOREIGN KEY (CF_FilmID) REFERENCES dbo.films(FIlm_ID)
)

SELECT CONSTRAINT_NAME
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
WHERE TABLE_NAME like 'films' and CONSTRAINT_NAME like '%Cat%';