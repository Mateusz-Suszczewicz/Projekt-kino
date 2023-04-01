CREATE OR ALTER PROCEDURE dbo.addFilm (
@id int = 0
,  @Title varchar(50)
, @Content varchar(250)
, @DataDodania datetime 
, @Category int 
, @Duration int 
, @src varchar(250)
, @r varchar(300) OUTPUT) AS

IF  
	(SELECT Film_ID FROM dbo.films where Film_Title like @title) is NULL 
	IF @id = 0
		BEGIN 
			INSERT INTO dbo.films (Film_Title
				, Film_Content
				, Film_CatID
				, Film_Duration
				, Film_SrcPicture
				) 
			VALUES ( @Title
				, @Content
				, @Category
				, @Duration
				, @src
				);
			select @r = 'Dodano porpawnie nowy film id' + (SELECT Film_ID FROM dbo.films where Film_Title like @title);
			RETURN;
		END;
	ELSE
		IF(SELECT Film_ID FROM dbo.films where Film_ID = @id) is not null
			BEGIN 
				UPDATE dbo.films SET Film_Title = @Title, Film_Content = @Content, Film_CatID = @Category, Film_Duration = @Duration, Film_SrcPicture = @src, Film_DataDodania = @DataDodania
				SELECT @r = 'Poprawnie zmodyfikowano film'
				RETURN
			END
		ELSE
			BEGIN
				SELECT @r = 'Próba modyfikacji nieistniej¹cego filmu' 
				RETURN
			END
ELSE
	IF (SELECT Film_ID FROM dbo.films where Film_Title like @title) is not NULL 
		BEGIN
			SELECT @r = 'Film o takim tytule istanieje ju¿ w bazie'; 
			RETURN;
		END;