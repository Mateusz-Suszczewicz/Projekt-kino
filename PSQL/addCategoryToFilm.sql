CREATE OR ALTER PROC addCategoryToFilm(
@catID int,
@filmID int
) AS
DECLARE @r varchar(300) = ''

IF (SELECT TOP 1 Cat_ID FROM dbo.category WHERE Cat_ID = @catID) is not null -- sprawdzenie istnienia kategorii
AND (SELECT TOP 1 Film_ID FROM dbo.films WHERE Film_ID = @filmID) is not null -- sprawdzenie istnienia filmu
AND (SELECT TOP 1 CF_ID FROM dbo.cat_film WHERE CF_CatID = @catID AND CF_FilmID = @filmID) is null
	BEGIN 
		INSERT INTO dbo.cat_film (CF_CatID, CF_FilmID) VALUES (@catID, @filmID)
		SELECT 'Poprawnie dodano kategoriê do filmu'
	END
ELSE
	IF(SELECT TOP 1 Cat_ID FROM dbo.category WHERE Cat_ID = @catID) is null
	BEGIN 
		SET @r += 'Kategoria nie istnieje, '
	END
	IF(SELECT TOP 1 Film_ID FROM dbo.films WHERE Film_ID = @filmID) is null
	BEGIN 
		SET @r += 'Film nie istnieje, '
	END
	IF(SELECT TOP 1 CF_ID FROM dbo.cat_film WHERE CF_CatID = @catID AND CF_FilmID = @filmID) is not null
	BEGIN 
		SET @r += 'Powi¹zanie istnieje'
	END

SELECT @r
RETURN