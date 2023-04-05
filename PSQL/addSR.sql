CREATE OR ALTER PROC dbo.addSR (
@id int = 0
, @nr int
, @content varchar(250)
, @status int = 0
) AS

IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = @nr) is null
	IF @id = 0
		BEGIN
			INSERT INTO dbo.screeningRoom (SR_Nr, SR_Content, SR_Status) VALUES (@nr, @content, @status)
			SELECT 'Poporawnie dodano salê: ' + @nr + ': ' + (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = @nr)
			RETURN
		END
	ELSE 
		IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @id) is not null
			BEGIN 
				UPDATE dbo.screeningRoom SET SR_Content = @content, SR_Nr = @nr, SR_Status = @status WHERE SR_ID = @id
				SELECT 'Poprawnie zmodyfikowano salê: ' + @nr + ': ' + @id
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Próba modyzikacji niestniej¹cej sali'
				RETURN
			END
ELSE
	BEGIN 
		SELECT 'Numer sali jest ju¿ dodany: ' + @nr + ': ' + (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = @nr)
		RETURN
	END
