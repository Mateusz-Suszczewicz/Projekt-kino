CREATE OR ALTER PROC dbo.addSeat(
@srid int
, @nr int
, @row int
, @r varchar(300) OUTPUT
) AS

IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @srid) is not null 
	AND (SELECT Seat_ID FROM dbo.seats WHERE Seat_Nr = @nr AND Seat_Row = @row) is null
	BEGIN 
		INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES (@srid, @nr, @row)
		SELECT @r = 'Poprawnie dodano miejsce';
		RETURN;
	END;
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