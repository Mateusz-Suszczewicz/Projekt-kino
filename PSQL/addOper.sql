CREATE OR ALTER PROC dbo.addOper( 
@id int = 0
, @login varchar(50)
, @password varchar(50) = null
, @typ int
) AS

DECLARE @r varchar(300) = ''

IF (@typ IN (1,2)) --sprawdzenie poprawnosci typu dodawanego pracownika
AND (@login is not null) --sprawdzenie czy login nie jest pusty
AND (@login not like '') --sprawdzenie czy login nie jest pusty 
AND ((SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @login) is null ) --sprawdzenie czy login nie jest ju¿ w bazie danych
	IF @id = 0
		BEGIN
			INSERT INTO dbo.operator (Oper_Login, Oper_Password, Oper_Type) VALUES (@login, @password, @typ)
			SELECT 'Poprwanie dodano u¿ytkownika: ' + @login + ': ' + (SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @login)
			RETURN
		END
	ELSE
		IF (SELECT Oper_ID FROM dbo.operator WHERE Oper_ID = @id) is not null
			BEGIN
				UPDATE dbo.operator SET Oper_Login = @login, Oper_Password = @password, Oper_Type = @typ WHERE Oper_ID = @id
				SELECT 'Poprawnie zmodyfikowano operatora: ' + @login + ': ' + @id 
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Próba modyfikacji nieistniej¹cego operatora'
				RETURN
			END
ELSE
	IF @typ not in (1,2) 
		BEGIN
			SELECT @r += 'B³êdny typ uzytkonika, ' 
		END
	IF @login is null OR @login LIKE ''
		BEGIN
			SELECT @r += 'Login nie mo¿e byæ pusty, ' 
		END
	IF (SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @login) is not null 
		BEGIN
			SELECT @r = 'U¿ytkownik o podanym loginie istnieje ju¿ w bazie danych, ' 
		END

SELECT @r
RETURN

