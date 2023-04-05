CREATE OR ALTER PROC addBooking(
  @id int = 0
, @operId int
, @seatId int
, @seId int
, @code int
, @type int
, @dataZakupu datetime
, @status int = 0
) AS

DECLARE @r varchar(300) = ''
DECLARE @cena decimal(5,2)
--Ustawienie ceny
IF @code != 0
	BEGIN 
		IF (SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_OperID = @operId AND CD_Code = @code AND CD_Stauts = 0) is not null --sprawdzenie czy operator posiada wskazny kod jako aktywny
			BEGIN 
				SET @cena = 0
				UPDATE dbo.codes SET CD_Stauts = 1 WHERE CD_ID = (SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_OperID = @operId AND CD_Code = @code AND CD_Stauts = 0)
			END
		ELSE
			IF(SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_OperID = @operId AND CD_Stauts = 0) is null
				BEGIN 
					SET @r += 'Operator nie posiada ¿adnych aktywnych kodów, '
				END
			IF(SELECT TOP 1 CD_ID FROM dbo.codes WHERE CD_Code = @code AND CD_Stauts = 0) is null
				BEGIN 
					SET @r += 'Nie ma takiego aktywnego kodu'
					RETURN
				END
	END
ELSE 
	BEGIN
		IF @type in (0,1) -- spawdzenie typu biletu
			BEGIN
				SET @cena = CASE WHEN @type = 0 THEN (SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 2) ELSE (SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 3) END
			END
		ELSE 
			BEGIN 
				SET @r += 'Niepoprawny typ, '
				RETURN
			END
		END



IF (SELECT TOP 1 SE_ID FROM dbo.seance WHERE SE_ID = @seId AND SE_DataEmisji - @dataZakupu >= '02:00') is not null -- czy istnieje seans oraz data zakupu > ni¿ 2 godizny przed seansem 
AND (SELECT TOP 1 Oper_ID FROM dbo.operator WHERE Oper_ID = @operId) is not null -- czy istnieje operator
AND (SELECT TOP 1 Seat_ID  FROM dbo.seats  JOIN dbo.seance ON seance.SE_SRID = seats.Seat_SRID WHERE Seat_ID = @seatId AND SE_ID = @seId) is not null -- czy istnieje miejsce oraz czy miejsce jest przypisane do seansu
AND (SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = @seatId AND Book_SeID = @seId) is null -- czy miejsce jest wolne
	BEGIN
		IF @id = 0
			BEGIN
				INSERT INTO dbo.booking (Book_Cena, Book_CodeID, Book_DataZakupu, Book_OperID, Book_SeatID, Book_SeID, Book_Type, Book_Status) VALUES (@cena, @code, @dataZakupu, @operId, @seatId, @seId, @type, @status)
				SELECT 'Poprawnie dodano nowy bilet'
				RETURN
			END
		ELSE
			BEGIN
				UPDATE dbo.booking SET Book_CodeID = @code, Book_DataZakupu = @dataZakupu, Book_OperID = @operId, Book_SeatID = @seatId, Book_SeID = @seId, Book_Type = @type, Book_Status = @status WHERE Book_ID = @id
				SELECT 'Poprawnie dodano nowy bilet'
				RETURN
			END
	END
ELSE
	IF (SELECT TOP 1 SE_ID FROM dbo.seance WHERE SE_ID = @seId) is null
		BEGIN 
			SET @r += 'Seans nie istnieje, '
		END
	IF(SELECT TOP 1 SE_ID FROM dbo.seance WHERE SE_ID = @seId AND SE_DataEmisji - @dataZakupu <= '02:00') is not null
		BEGIN
			SET @r += 'Nie mo¿na kupiæ ju¿ biletu na seans. Rozpoczenie siê za mniej ni¿ 2 godziny, '
		END
	IF(SELECT TOP 1 Oper_ID FROM dbo.operator WHERE Oper_ID = @operId) is  null -- czy istnieje operator
		BEGIN
			SET @r += 'Wybrany opertor nie istnieje, '
		END
	IF(SELECT TOP 1 Seat_ID FROM dbo.seats JOIN dbo.seance ON seance.SE_SRID = seats.Seat_SRID WHERE Seat_ID = @seatId AND SE_ID = @seId) is null
		BEGIN
			SET @r += 'Wybrane miejsce nie zosta³o przypisane do wybranego seansu: ' + (SELECT TOP 1 Seat_ID FROM dbo.seats JOIN dbo.seance ON seance.SE_SRID = seats.Seat_SRID WHERE Seat_ID = @seatId AND SE_ID = @seId) + ', '
		END
	IF(SELECT TOP 1 Book_ID FROM dbo.booking WHERE Book_SeatID = @seatId AND Book_SeID = @seId) is null
		BEGIN
			SET @r += 'Wybrane miejsce jest ju¿ zajête'
		END

SELECT @r
RETURN