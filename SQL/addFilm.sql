CREATE OR ALTER PROCEDURE dbo.AddFilm (
  @Title varchar(50)
, @Content varchar(250)
, @DataEmisji datetime 
, @Sala int 
, @Category int 
, @Duration int 
) AS
IF  (
		SELECT Film_ID 
		FROM dbo.films 
		
	) is NULL 
	BEGIN 
		INSERT INTO dbo.films ( Film_SRID
			, Film_Title
			, Film_Content
			, Film_CatID
			, Film_Duration
			) 
		VALUES ( @Sala
			, @Title
			, @Content
			, @Category
			, @Duration
			);
		RETURN 1;
	END;
ELSE
	RETURN 'Nie mo¿na dodaæ filmu; W tym czasie i sali jest ju¿ inny film';
