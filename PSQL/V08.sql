ALTER TABLE dbo.films
	ALTER COLUMN Film_Content VARCHAR(2000)

CREATE TABLE dbo.line_up(
	LU_ID int not null IDENTITY(1,1),
	LU_Name varchar(100), 
	LU_Surname varchar(100),
	LU_Country varchar(100),


)

CREATE TABLE dbo.lu_film(
	LF_ID int not null IDENTITY(1,1),
	LF_FilmID int not null,
	LF_LUID int not null,
	LF_Status int DEFAULT 0 --1-> re¿yser 0 -> actor
)