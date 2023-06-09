CREATE OR ALTER PROC dbo.addOper( 
@id int = 0
, @login varchar(50)
, @password varchar(50) = null
, @typ int
, @r varchar(300) OUTPUT
) AS

IF (@typ in (1,2)) and @login is not null and @login not like '' and (SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @login) is null 
	IF @id = 0
		BEGIN
			INSERT INTO dbo.operator (Oper_Login, Oper_Password, Oper_Type)VALUES (@login, @password, @typ)
			SELECT @r = 'Poprwanie dodano u�ytkownika';
			RETURN;
		END
	ELSE
		IF (SELECT Oper_ID FROM dbo.operator WHERE Oper_ID = @id) is not null
			BEGIN
				UPDATE dbo.operator SET Oper_Login = @login, Oper_Password = @password, Oper_Type = @typ WHERE Oper_ID = @id
				SELECT @r = 'Poprawnie zmodyfikowano operatora'
				RETURN
			END
		ELSE
			BEGIN
				SELECT @r = 'Pr�ba modyfikacji nieistniej�cego operatora'
				RETURN
			END
ELSE
	IF @typ not in (1,2) 
		BEGIN
			SELECT @r = 'B��dny typ uzytkonika'; 
			RETURN; 
		END;
	IF @login is null OR @login like ''
		BEGIN
			SELECT @r = 'Login nie mo�e by� pusty'; 
			RETURN; 
		END;
	IF (SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @login) is not null 
		BEGIN
			SELECT @r = 'U�ytkownik o podanym loginie istnieje ju� w bazie danych'; 
			RETURN;
		END;

