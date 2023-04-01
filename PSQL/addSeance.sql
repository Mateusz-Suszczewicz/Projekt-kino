CREATE OR ALTER PROC addSeance(
@id int = 0
, @filmID int
, @srID int
, @dataEmisji datetime
, @datakonca datetime
) AS

DECLARE @r varchar(300) = ''

IF (SELECT Film_ID FROM dbo.films WHERE Film_ID = @filmID) is not null --sprawdzenie istnienia filmu
AND (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srID) is not null --sprawdzenie istnienia sali 
AND (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = @srID AND (@datakonca > SE_DataEmisji AND  SE_DataKonca > @dataEmisji)) is null -- sprawdzenie czy w tym czasie nie istnieje inny seans
	IF @id = 0
		BEGIN 
			INSERT INTO dbo.seance (SE_DataEmisji, SE_FilmID, SE_SRID, SE_DataKonca) VALUES (@dataEmisji, @filmID, @srID, @datakonca)
			SELECT 'Poprawnie dodano seans do bazy: ' + @filmID + ': ' + (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = @srID AND (@datakonca < SE_DataEmisji AND  SE_DataKonca < @dataEmisji))
			RETURN
		END
	ELSE
		IF	(SELECT SE_ID FROM dbo.seance WHERE SE_ID = @id) is not null
			BEGIN 
				UPDATE dbo.seance SET SE_FilmID = @filmID, SE_DataEmisji = @dataEmisji, SE_SRID = @srID, SE_DataKonca = @datakonca WHERE SE_ID = @id
				SELECT 'Poprawnie zmodyfikowano seans: ' + @filmID + ': ' + @id
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Próba modyfikacji nieistniej¹cego seansu'
				RETURN
			END
ELSE
	IF (SELECT Film_ID FROM dbo.films WHERE Film_ID = @filmID) is null
		BEGIN 
			SET @r += 'Podany film nie istnieje, '
		END
	IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is null
		BEGIN 
			SET @r += 'Podana sala nie istnieje, '
		END
	IF (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = @srID AND (@datakonca > SE_DataEmisji AND  SE_DataKonca > @dataEmisji)) is not null
		BEGIN 
			SET @r += 'W podanej sali i podanym terminie zosta³ juz dodany seans: ' + @filmID + ': ' + (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = @srID AND (@datakonca < SE_DataEmisji AND  SE_DataKonca < @dataEmisji))
		END

SELECT @r
RETURN