CREATE OR ALTER PROCEDURE dbo.addFilm (
@id int = 0
, @title varchar(50)
, @content varchar(250)
, @dataDodania datetime 
, @catID int 
, @duration int 
, @src varchar(250)
) AS

IF(SELECT Film_ID FROM dbo.films WHERE Film_Title LIKE @title) is null -- sprawdzenie czy film o takim tytule ju� istnieje
	IF @id = 0
		BEGIN 
			INSERT INTO dbo.films (Film_Title, Film_Content, Film_CatID, Film_Duration, Film_SrcPicture) VALUES (@title, @content, @catID, @duration, @src)
			SELECT 'Dodano porpawnie nowy film: ' + @title + ': ' + (SELECT Film_ID FROM dbo.films where Film_Title like @title)
			RETURN
		END
	ELSE
		IF(SELECT Film_ID FROM dbo.films WHERE Film_ID = @id) is not null
			BEGIN 
				UPDATE dbo.films SET Film_Title = @title, Film_Content = @content, Film_CatID = @catID, Film_Duration = @duration, Film_SrcPicture = @src, Film_DataDodania = @dataDodania WHERE Film_ID = @id
				SELECT 'Poprawnie zmodyfikowano film' + @title + ': ' + @id
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Pr�ba modyfikacji nieistniej�cego filmu' 
				RETURN
			END
ELSE
	IF (SELECT Film_ID FROM dbo.films WHERE Film_Title LIKE @title) is not NULL 
		BEGIN
			SELECT 'Film o takim tytule istanieje ju� w bazie: ' + @title + ': ' + @id
			RETURN
		END