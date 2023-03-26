INSERT INTO dbo.operator (Oper_Login, Oper_Type) VALUES ('ADMIN', 0);
INSERT INTO dbo.screeningRoom (SR_Nr, SR_Content) VALUES (3,'Opis trzeciej sali');
INSERT INTO dbo.category (Cat_Name) VALUES ('Przygodowy');
INSERT INTO dbo.films (Film_Title, Film_Content, Film_CatID, Film_Duration) VALUES ( 'tytu³ filmu', 'Opis pierwszego filmu',1, 40);
INSERT INTO dbo.seance(SE_SRID, SE_FilmID, SE_DataEmisji) VALUES (1, 2, GETDATE())
INSERT INTO dbo.seats (Seat_SRID, Seat_Nr, Seat_Row) VALUES (1, 6, 2);
INSERT INTO dbo.codes (CD_OperID, CD_Code) VALUES (1, 'aa33');
INSERT INTO dbo.booking (Book_OperID, Book_SeatID, Book_SeID, Book_CodeID, Book_Type, Book_Cena) VALUES (1, 4, 3, 1, 2, 25);

create database test1
INSERT INTO dbo.Config (Conf_Wartosc, Conf_Opis) VALUES ('0.1', 'wersja')

DECLARE @r VARCHAR(300)
exec dbo.addOper @login = 'test3', @password = 'test', @typ = 9, @r = @r output
 
  SELECT @r
SELECT * FROM dbo.operator

delete dbo.operator where Oper_ID = 5