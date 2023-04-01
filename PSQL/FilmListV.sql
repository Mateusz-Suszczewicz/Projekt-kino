CREATE OR ALTER VIEW FilmListV AS
SELECT 
  Film_Title AS Tytul
, Film_Content AS Opis
, Cat_Name AS Kategoria
, Film_Duration AS Dlugosc
, Film_DataDodania AS Data_Dodania
FROM dbo.films 
LEFT JOIN dbo.category ON  films.Film_CatID = category.Cat_ID