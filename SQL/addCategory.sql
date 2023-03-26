CREATE OR ALTER PROC addCategory(
@name varchar(50)
, @r varchar(300)
) AS
IF (SELECT Cat_ID FROM dbo.category WHERE Cat_Name = @name) is null
	BEGIN 
		INSERT INTO dbo.category (Cat_Name) VALUES (@name);
		SELECT @r = 'Poprawnie dodano kategoriê';
		RETURN;
	END;
ELSE
	BEGIN 
		SELECT @r = 'Kateogria o takiej nazwie ju¿ istanieje';
		RETURN;
	END;