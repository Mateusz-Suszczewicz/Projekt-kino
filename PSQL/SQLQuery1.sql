CREATE OR ALTER PROC addCategory11(
@id int = 0
, @name varchar(50)

) AS
declare @r varchar(300) = '';
IF (SELECT Cat_ID FROM dbo.category WHERE Cat_Name = @name) is null -- sprawdzenie nazwy
	IF @id = 0  -- warunek utworzenia nowej kartoteki
		BEGIN 
			INSERT INTO dbo.category (Cat_Name) VALUES (@name);
			SELECT 'Poprawnie dodano kategori�';
			RETURN;
		END;
	ELSE
		IF (SELECT Cat_ID FROM dbo.category WHERE Cat_ID = @id) is not null -- sprawdzenie czy modyfikowana kartoteka istnieje 
			BEGIN 
				UPDATE dbo.category SET Cat_Name = @name WHERE Cat_ID = @id;
				SELECT 'Poprawnie dodano kategori�';
				RETURN;
			END;
		ELSE
			BEGIN 
			SELECT 'Pr�bowano zmodyfikowa� nieistniej�c� kategori�';
			RETURN;
		END;
ELSE
	BEGIN 
		SET @r += 'Kateogria o takiej nazwie ju� istanieje ';
		SET @r += 'Kateogria o takiej nazwie ju� istanieje2 ';
		SET @r += 'Kateogria o takiej nazwie ju� istanieje3 ';
		SELECT @r
		RETURN;
	END;