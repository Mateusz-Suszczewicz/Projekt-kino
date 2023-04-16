CREATE OR ALTER   PROC [dbo].[addOper]( 
@OpId int = 0
, @OpLogin varchar(50)
, @OpPassword varchar(50) = null
, @OpTyp int
) AS

DECLARE @r varchar(300) = ''

IF (@OpTyp IN (1,2)) --sprawdzenie poprawnosci typu dodawanego pracownika
AND (@OpLogin is not null) --sprawdzenie czy login nie jest pusty
AND (@OpLogin not like '') --sprawdzenie czy login nie jest pusty 

	IF @OpId = 0 AND ((SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @OpLogin) is null ) --sprawdzenie czy login nie jest ju� w bazie danych
		BEGIN
			INSERT INTO dbo.operator (Oper_Login, Oper_Password, Oper_Type) VALUES (@OpLogin, @OpPassword, @OpTyp)
			SELECT 'Poprawnie dodano uzytkownika: ' + @OpLogin + ': ' + CAST((SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @OpLogin) as varchar(20))
			RETURN
		END
	ELSE
		IF (SELECT Oper_ID FROM dbo.operator WHERE Oper_ID = @OpId) is not null
			BEGIN
				UPDATE dbo.operator SET Oper_Login = @OpLogin, Oper_Password = @OpPassword, Oper_Type = @OpTyp WHERE Oper_ID = @OpId
				SELECT 'Poprawnie zmodyfikowano operatora: ' + @OpLogin + ': ' + @OpId 
				RETURN
			END
		ELSE
			BEGIN
				SELECT 'Pr�ba modyfikacji nieistniej�cego operatora'
				RETURN
			END
ELSE
	IF @OpTyp not in (1,2) 
		BEGIN
			SET @r += 'B��dny typ uzytkonika, ' 
		END
	IF @OpLogin is null OR @OpLogin LIKE ''
		BEGIN
			SET @r += 'Login nie mo�e by� pusty, ' 
		END
	IF (SELECT Oper_ID FROM dbo.operator WHERE Oper_Login = @OpLogin) is not null 
		BEGIN
			SET @r = 'U�ytkownik o podanym loginie istnieje ju� w bazie danych, ' 
		END

SELECT @r
RETURN

