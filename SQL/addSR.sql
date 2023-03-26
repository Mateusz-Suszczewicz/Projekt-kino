CREATE OR ALTER PROC dbo.addSR (
@id int = 0
, @Nr int
, @content varchar(250)
, @status int = 0
, @r varchar(300) OUTPUT
) AS

IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = @Nr) is null
	IF @id = 0
		BEGIN
			INSERT INTO dbo.screeningRoom (SR_Nr, SR_Content, SR_Status) VALUES (@Nr, @content, @status)
			SELECT @r =	'Poporawnie dodano salê';
			RETURN;
		END;
	ELSE 
		IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_ID = @id) is not null
			BEGIN 
				UPDATE dbo.screeningRoom SET SR_Content = @content, SR_Nr = @Nr, SR_Status = @status WHERE SR_ID = @id
				SELECT @r = 'Poprawnie zmodyfikowano salê'
				RETURN
			END;
		ELSE
			BEGIN
				SELECT @r = 'Próba modyzikacji niestniej¹cej sali'
				RETURN
			END
ELSE
	BEGIN 
		SELECT @r = 'Numer sali jest ju¿ dodany'
		RETURN;
	END;
