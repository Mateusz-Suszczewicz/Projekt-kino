CREATE OR ALTER PROC addBooking(
  @id int = 0
, @OperId int
, @SeatId int
, @SeId int
, @CodeId int
, @type int
, @dataZakupu datetime
, @r varchar(300) OUTPUT
) AS

Declare @cena decimal(5,2)

IF @type in (0,1)
	BEGIN
		SET @cena = CASE WHEN @type = 0 THEN (SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 2) ELSE (SELECT Conf_Wartosc FROM dbo.config WHERE Conf_ID = 3) END
	END
ELSE 
	BEGIN 
		SET @r = 'Nie poprawny typ'
		RETURN
	END


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
