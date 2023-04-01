CREATE OR ALTER PROC addSeance(
@id int = 0
, @filmID int
, @srID int
, @dataEmisji datetime
, @datakonca datetime
, @r varchar(300) OUTPUT
) AS

IF (SELECT Film_ID FROM dbo.films WHERE Film_ID = @filmID) is not null and (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srID) is not null 
and (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = 3 and (@datakonca > SE_DataEmisji and  SE_DataKonca > @dataEmisji)) is null
	IF @id = 0
		BEGIN 
			INSERT INTO dbo.seance (SE_DataEmisji, SE_FilmID, SE_SRID, SE_DataKonca) VALUES (@dataEmisji, @filmID, @srID, @datakonca)
			SELECT @r = 'Poprawnie dodano seans do bazy'
			RETURN
		END
	ELSE
		IF	(SELECT SE_ID FROM dbo.seance WHERE SE_ID = @id) is not null
			BEGIN 
				UPDATE dbo.seance SET SE_FilmID = @filmID, SE_DataEmisji = @dataEmisji, SE_SRID = @srID, SE_DataKonca = @datakonca WHERE SE_ID = @id
				SELECT @r = 'Poprawnie zmodyfikowano seans'
				RETURN
			END
		ELSE
			BEGIN
				SELECT @r = 'Próba modyfikacji nieostniej¹cego seansu'
				RETURN
			END
ELSE
	IF (SELECT Film_ID FROM dbo.films WHERE Film_ID = @filmID) is null
		BEGIN 
			SELECT @r = 'Podany film nie istnieje'
			RETURN
		END
	IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is null
		BEGIN 
			SELECT @r = 'Podana sala nie istnieje'
			RETURN
		END
	IF (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_SRID = 3 and (@datakonca > SE_DataEmisji and  SE_DataKonca > @dataEmisji)) is not null
		BEGIN 
			SELECT @r = 'W podanej sali i podanym terminie zosta³ juz dodany seans'
			RETURN
		END