CREATE OR ALTER PROC addCategory(
@id int = 0
, @name varchar(50)
) AS

IF (SELECT Cat_ID FROM dbo.category WHERE Cat_Name = @name) is null -- sprawdzenie nazwy
	IF @id = 0  -- warunek utworzenia nowej kartoteki
		BEGIN 
			INSERT INTO dbo.category (Cat_Name) VALUES (@name)
			SELECT 'Poprawnie utworzono kategori�: ' + @name + ': ' + (SELECT Cat_ID FROM dbo.category WHERE Cat_Name = @name)
			RETURN
		END
	ELSE
		IF (SELECT Cat_ID FROM dbo.category WHERE Cat_ID = @id) is not null -- sprawdzenie czy modyfikowana kartoteka istnieje 
			BEGIN 
				UPDATE dbo.category SET Cat_Name = @name WHERE Cat_ID = @id
				SELECT 'Poprawnie zmodyfikowano kategori�: ' + @name + ': ' +  @id
				RETURN
			END
		ELSE
			BEGIN 
			SELECT 'Pr�bowano zmodyfikowa� nieistniej�c� kategori�'
			RETURN
		END
ELSE
	BEGIN 
		SELECT 'Kateogria o takiej nazwie ju� istanieje: ' + @name + ': ' + (SELECT Cat_ID FROM dbo.category WHERE Cat_Name = @name)
		RETURN
	END