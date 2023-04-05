CREATE OR ALTER PROC dbo.addSeat(
@id int  = 0
, @srid int
, @nr int
, @row int
) AS

DECLARE @r varchar(300) = ''

IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is not null  --sprawdzenie czy sala istnieje
AND (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row) is null -- speawdzenie czy miejsce istnieje
	IF @id = 0 
		BEGIN 
			INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES (@srid, @nr, @row)
			SELECT 'Poprawnie dodano miejsce: ' + @nr + ' - ' + @row + ': ' + (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row)
			RETURN
		END
	ELSE
		IF (SELECT Seat_ID FROM dbo.seats WHERE Seat_ID = @id) is not null
			BEGIN 
				UPDATE dbo.seats SET Seat_Nr = @nr, Seat_Row = @row, Seat_SRID = @srid WHERE Seat_ID = @id
				SELECT 'Poprawnie zmodyfikowano miejsce: ' + @nr + ' - ' + @row + ': ' + @id
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Próba modyfikacji nieistniej¹cego miejsca'
				RETURN
			END
ELSE
	IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is null
		BEGIN 
			SET @r += 'Nie znaleziono odpowiadaj¹cej sali: ' + @srid + ', '
		END
	IF (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row) is not null
		BEGIN 
			SET @r += 'Miejsce na sali ju¿ istnieje: ' + @nr + ' - ' + @row + ': ' + (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row)
		END

SELECT @r 
RETURN