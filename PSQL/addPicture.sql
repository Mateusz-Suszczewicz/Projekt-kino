CREATE OR ALTER PROCEDURE dbo.addPicture (
@id int = 0
, @filmID int
, @src varchar(250)
) AS

DECLARE @r varchar(300) = ''

IF(SELECT TOP 1 Pic_ID FROM dbo.picture WHERE Pic_Src like @src) is null 
AND (SELECT TOP 1 Film_ID FROM dbo.films WHERE Film_ID = @filmID) is not null
	BEGIN
		IF @id = 0
			BEGIN 
				INSERT INTO dbo.picture (Pic_FilmID, Pic_Src) VALUES (@filmID, @src)
				SELECT 'Poprawnie dodano obrazek'
				RETURN
			END
		ELSE
			BEGIN
				UPDATE dbo.picture SET Pic_FilmID = @filmID, Pic_Src = @src WHERE Pic_ID = @id
				SELECT 'Poprawnie zmodyfikowano obrazek'
				RETURN
			END
	END
ELSE
	IF(SELECT TOP 1 Pic_ID FROM dbo.picture WHERE Pic_Src like @src) is not null 
		BEGIN 
			SET @r += 'Obrazek jest ju¿ dodany'
		END
	IF(SELECT TOP 1 Film_ID FROM dbo.films WHERE Film_ID = @filmID) is null
		BEGIN 
			SET @r += 'Brak filmu w bazie danych'
		END

SELECT @r
RETURN