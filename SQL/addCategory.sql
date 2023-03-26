CREATE OR ALTER PROC addCategory(
@id int = 0
, @name varchar(50)
, @r varchar(300)
) AS
IF (SELECT Cat_ID FROM dbo.category WHERE Cat_Name = @name) is null -- sprawdzenie nazwy
	IF @id = 0  -- warunek utworzenia nowej kartoteki
		BEGIN 
			INSERT INTO dbo.category (Cat_Name) VALUES (@name);
			SELECT @r = 'Poprawnie dodano kategoriê';
			RETURN;
		END;
	ELSE
		IF (SELECT Cat_ID FROM dbo.category WHERE Cat_ID = @id) is not null -- sprawdzenie czy modyfikowana kartoteka istnieje 
			BEGIN 
				UPDATE dbo.category SET Cat_Name = @name WHERE Cat_ID = @id;
				SELECT @r = 'Poprawnie dodano kategoriê';
				RETURN;
			END;
		ELSE
			BEGIN 
			SELECT @r = 'Próbowano zmodyfikowaæ nieistniej¹c¹ kategoriê';
			RETURN;
		END;
ELSE
	BEGIN 
		SELECT @r = 'Kateogria o takiej nazwie ju¿ istanieje';
		RETURN;
	END;