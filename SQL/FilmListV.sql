Create OR ALTER View FilmListV as
SELECT 
  Film_Title as Tytu�
, Film_Content as Opis
, Cat_Name as Kategoria
, Film_Duration as D�ugo��
, Film_DataDodania as Data_Dodania
FROM dbo.films 
left join dbo.category on  films.Film_CatID = category.Cat_ID