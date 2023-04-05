CREATE TABLE dbo.operator(
	Oper_ID int not null IDENTITY(1,1),
	Oper_Login varchar(50) not null,
	Oper_Password varchar(50),
	Oper_Type int not null,

	PRIMARY KEY(Oper_ID)
)

CREATE TABLE dbo.codes(
	CD_ID int not null IDENTITY(1,1),
	CD_OperID int not null,
	CD_Code varchar(50) not null,
	CD_Stauts int DEFAULT 0,

	PRIMARY KEY (CD_ID),
	FOREIGN KEY (CD_OperID) REFERENCES dbo.operator(Oper_ID)
)

CREATE TABLE dbo.screeningRoom(
	SR_ID int not null IDENTITY(1,1),
	SR_Nr int not null,
	SR_Status int DEFAULT 0,
	SR_Content varchar(250)

	PRIMARY KEY (SR_ID)
) 

CREATE TABLE dbo.seats(
	Seat_ID int not null IDENTITY(1,1),
	Seat_SRID int not null,
	Seat_Nr int not null,
	Seat_Row int not null,

	PRIMARY KEY (Seat_ID),
	FOREIGN KEY (Seat_SRID) REFERENCES dbo.screeningRoom (SR_ID)
)

CREATE TABLE dbo.category(
	Cat_ID int not null IDENTITY(1,1),
	Cat_Name varchar(50)

	PRIMARY KEY (Cat_ID)
)

CREATE TABLE dbo.films(
	Film_ID int not null IDENTITY(1,1),
	Film_CatID int,
	Film_Title varchar(50) not null,
	Film_Content varchar(250),
	Film_Duration int not null,
	Film_DataDodania datetime DEFAULT GETDATE(),
	Film_SrcPicture varchar(250)

	PRIMARY KEY(Film_ID),
	FOREIGN KEY (Film_CatID) REFERENCES  dbo.category (Cat_ID)
)

CREATE TABLE dbo.seance(
	SE_ID int not null IDENTITY(1,1),
	SE_FilmID int not null,
	SE_SRID int not null,
	SE_DataEmisji datetime not null,
	SE_DataKonca datetime not null

	PRIMARY KEY (SE_ID),
	FOREIGN KEY (SE_SRID) REFERENCES  dbo.screeningRoom (SR_ID),
	FOREIGN KEY (SE_FilmID) REFERENCES  dbo.films(Film_ID),
)


CREATE TABLE dbo.booking(
	Book_ID int not null IDENTITY(1,1),
	Book_OperID int not null,
	Book_SeatID int not null,
	Book_SeID int not null,
	Book_CodeID int,
	Book_Type int not null,
	Book_DataZakupu datetime DEFAULT GETDATE(),
	Book_Cena decimal(5,2) not null,
	

	PRIMARY KEY (Book_ID),
	FOREIGN KEY (Book_OperID) REFERENCES dbo.operator(Oper_ID),
	FOREIGN KEY (Book_SeatID) REFERENCES dbo.seats(Seat_ID),
	FOREIGN KEY (Book_SeID) REFERENCES dbo.seance(SE_ID),
	FOREIGN KEY (Book_CodeID) REFERENCES dbo.codes(CD_ID),
)

CREATE TABLE dbo.config(
	Conf_ID int not null IDENTITY(1,1), 
	Conf_Wartosc varchar(50),
	Conf_Opis varchar (250)

	PRIMARY KEY (Conf_ID)
)

INSERT INTO dbo.operator (Oper_Login, Oper_Password, Oper_Type) VALUES ('Admin', '', 0)
INSERT INTO dbo.config (Conf_Wartosc, Conf_Opis) VALUES ('0.3', 'wersja')
INSERT INTO dbo.config (Conf_Wartosc, Conf_Opis) VALUES ('25', 'Cena biletu normalnego')
INSERT INTO dbo.config (Conf_Wartosc, Conf_Opis) VALUES ('20', 'Cena biletu ulgowego')