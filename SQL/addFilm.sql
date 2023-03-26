CREATE OR ALTER PROCEDURE dbo.AddFilm (
  @Title varchar(50)
, @Content varchar(250)
, @DataEmisji datetime 
, @Category int 
, @Duration int 
, @src varchar(250)
, @r varchar(300) OUTPUT) AS

IF  
	(SELECT Film_ID FROM dbo.films where Film_Title like @title) is NULL 
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
	IF (SELECT Film_ID FROM dbo.films where Film_Title like @title) is not NULL 
		BEGIN
			SELECT @r = 'Film o takim tytule istanieje ju¿ w bazie'; 
			RETURN;
		END;