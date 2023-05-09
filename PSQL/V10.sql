ALTER TABLE dbo.screeningRoom
	ADD SR_MaxNrMiejsca int,
		SR_MaxRowMiejsca int

ALTER TABLE dbo.line_up
	ADD PRIMARY KEY (LU_ID)

ALTER TABLE dbo.lu_film
	ADD PRIMARY KEY (LF_ID)

ALTER TABLE dbo.lu_film
	ADD FOREIGN KEY (LF_FilmID) REFERENCES dbo.films(Film_ID),
		FOREIGN KEY (LF_LUID) REFERENCES dbo.line_up(LU_ID)


