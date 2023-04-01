CREATE OR ALTER PROC dbo.addSeat(
@id int  = 0
, @srid int
, @nr int
, @row int
, @r varchar(300) OUTPUT
) AS

IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is not null 
	AND (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row) is null
	IF @id = 0 
		BEGIN 
			INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES (@srid, @nr, @row)
			SELECT @r = 'Poprawnie dodano miejsce';
			RETURN;
		END;
	ELSE
		IF (SELECT Seat_ID FROM dbo.seats WHERE Seat_ID = @id) is not null
			BEGIN 
				UPDATE dbo.seats SET Seat_Nr = @nr, Seat_Row = @row, Seat_SRID = @srid WHERE Seat_ID = @id
				SELECT @r = 'Poprawnie zmodyfikowano miejsce'
				RETURN
			END
		ELSE
			BEGIN
				SELECT @r = 'Próba modyfikacji nieistniej¹cego miejsca'
				RETURN
			END
ELSE
	IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is null
		BEGIN 
			SELECT @r = 'Nie znaleziono odpowiadaj¹cej sali';
			RETURN;
		END;
	IF (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row) is not null
		BEGIN 
			SELECT @r = 'Miejsce na sali ju¿ istnieje';
			RETURN;
		END;