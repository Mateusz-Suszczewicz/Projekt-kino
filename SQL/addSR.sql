CREATE OR ALTER PROC dbo.addSR (
 @Nr int
, @content varchar(250)
, @status int = 0
, @r varchar(300) OUTPUT
) AS

IF (SELECT SR_ID FROM dbo.screeningRoom WHERE SR_Nr = @Nr) is null
	BEGIN
		INSERT INTO dbo.screeningRoom (SR_Nr, SR_Content, SR_Status) VALUES (@Nr, @content, @status)
		SELECT @r =	'Poporawnie dodano salê';
		RETURN
	END
ELSE
	BEGIN 
		SELECT @r = 'Numer sali jest ju¿ dodany'
		RETURN 
	END
