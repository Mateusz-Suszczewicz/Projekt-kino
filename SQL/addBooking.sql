CREATE OR ALTER PROC addBooking(
  @id int = 0
, @OperId int
, @SeatId int
, @SeId int
, @Code int
, @type int
, @dataZakupu datetime
, @r varchar(300) OUTPUT
) AS

Declare @cena decimal(5,2)
IF @CodeId != 0
	BEGIN 
		IF (SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_OperID = @OperId AND CD_Code = @CodeId AND CD_Stauts = 0) is not null
			BEGIN 
				SET @cena = 0
				UPDATE dbo.codes SET CD_Stauts = 1 WHERE CD_ID = (SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_OperID = @OperId AND CD_Code = @CodeId AND CD_Stauts = 0)
			END
		ELSE
			IF(SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_OperID = @OperId AND CD_Stauts = 0) is null
				BEGIN 
					SET @r = 'Operator nie posiada ¿adnych aktywnych kodów'
					RETURN
				END
			IF(SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_Code = @CodeId AND CD_Stauts = 0) is null
				BEGIN 
					SET @r = 'Nie ma takiego aktywnego kodu'
					RETURN
				END
	END
ELSE 
	BEGIN
		IF @type in (0,1)
			BEGIN
				SET @cena = CASE WHEN @type = 0 THEN (SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 2) ELSE (SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 3) END
			END
		ELSE 
			BEGIN 
				SET @r += ' Nie poprawny typ'
				RETURN
			END
		END



IF (SELECT TOP 1 SE_ID FROM dbo.seance WHERE SE_ID = @SeId AND SE_DataEmisji - @dataZakupu >= '02:00') is not null -- czy istnieje seans oraz data zakupu > ni¿ 2 godizny przed seansem 
AND (SELECT TOP 1 Oper_ID FROM dbo.operator WHERE Oper_ID = @OperId) is not null -- czy istnieje operator
AND (SELECT TOP 1 Seat_ID  FROM dbo.seats  JOIN dbo.seance ON seance.SE_SRID = seats.Seat_SRID WHERE Seat_ID = @SeatId AND SE_ID = @SeId) is not null -- czy istnieje miejsce oraz czy miejsce jest przypisane do seansu
AND (SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = @SeatId AND Book_SeID = @SeId) is null -- czy miejsce jest wolne
	BEGIN
		IF @id = 0
			BEGIN
				INSERT INTO dbo.booking (Book_Cena, Book_CodeID, Book_DataZakupu, Book_OperID, Book_SeatID, Book_SeID, Book_Type) VALUES (@cena, @CodeId, @dataZakupu, @OperId, @SeatId, @SeId, @type)
				SET @r = 'Poprawnie dodano nowy bilet'
				RETURN
			END
		ELSE
			BEGIN
				UPDATE dbo.booking SET Book_CodeID = @CodeId, Book_DataZakupu = @dataZakupu, Book_OperID = @OperId, Book_SeatID = @SeatId, Book_SeID = @SeId, Book_Type = @type
				SET @r = 'Poprawnie dodano nowy bilet'
				RETURN
			END
	END
ELSE
	IF (SELECT top 1 SE_ID FROM dbo.seance WHERE SE_ID = @SeId) is null
		BEGIN 
			SET @r = 'Seans nie istnieje'
			RETURN
		END
	IF(SELECT top 1 SE_ID FROM dbo.seance WHERE SE_ID = @SeId AND SE_DataEmisji - @dataZakupu <= '02:00') is not null
		BEGIN
			SET @r = 'Nie mo¿na kupiæ ju¿ biletu na seans. Rozpoczenie siê za mniej ni¿ 2 godziny'
			RETURN
		END
	IF(SELECT top 1 Oper_ID FROM dbo.operator WHERE Oper_ID = @OperId) is  null -- czy istnieje operator
		BEGIN
			SET @r = 'Wybrany opertor nie istnieje'
			RETURN
		END
	IF(SELECT TOP 1 Seat_ID  FROM dbo.seats  JOIN dbo.seance ON seance.SE_SRID = seats.Seat_SRID WHERE Seat_ID = @SeatId AND SE_ID = @SeId) is null
		BEGIN
			SET @r = 'Wybrane miejsce nie zosta³o przypisane do wybranego seansu'
			RETURN
		END
	IF(SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = @SeatId AND Book_SeID = @SeId) is null
		BEGIN
			SET @r = 'Wybrane miejsce jest ju¿ zajête'
			RETURN
		END