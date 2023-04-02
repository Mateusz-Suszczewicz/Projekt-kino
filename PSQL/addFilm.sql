CREATE OR ALTER PROCEDURE dbo.addFilm (
@id int = 0
, @title varchar(50)
, @content varchar(250)
, @dataDodania datetime 
, @duration int 
, @film_Language varchar(20)
, @film_Production varchar(300)
, @film_Translation varchar(50)
) AS

IF(SELECT Film_ID FROM dbo.films WHERE Film_Title LIKE @title) is null -- sprawdzenie czy film o takim tytule ju¿ istnieje
	IF @id = 0
		BEGIN 
			INSERT INTO dbo.films (Film_Title, Film_Content, Film_Duration, Film_Language, Film_Production, Film_Translation) VALUES (@title, @content, @duration, @film_Language, @film_Production, @film_Translation)
			SELECT 'Dodano porpawnie nowy film: ' + @title + ': ' + (SELECT Film_ID FROM dbo.films where Film_Title like @title)
			RETURN
		END
	ELSE
		IF(SELECT Film_ID FROM dbo.films WHERE Film_ID = @id) is not null
			BEGIN 
				UPDATE dbo.films SET Film_Title = @title, Film_Content = @content, Film_Duration = @duration,  Film_DataDodania = @dataDodania, Film_Language = @film_Language, Film_Production = @film_Production, Film_Translation = @film_Translation WHERE Film_ID = @id
				SELECT 'Poprawnie zmodyfikowano film' + @title + ': ' + @id
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Próba modyfikacji nieistniej¹cego filmu' 
				RETURN
			END
ELSE
	IF (SELECT Film_ID FROM dbo.films WHERE Film_Title LIKE @title) is not NULL 
		BEGIN
			SELECT 'Film o takim tytule istanieje ju¿ w bazie: ' + @title + ': ' + @id
			RETURN
		END