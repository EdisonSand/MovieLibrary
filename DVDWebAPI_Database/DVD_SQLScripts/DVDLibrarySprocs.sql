USE DvdLibrary

IF EXISTS(
	SELECT * FROM INFORMATION_SCHEMA.ROUTINES
	WHERE ROUTINE_NAME = 'usp_DBResetData'
)
BEGIN
	DROP PROCEDURE usp_DBResetData
END
GO

CREATE PROCEDURE usp_DBResetData
AS
BEGIN
	DELETE FROM Dvd;
	DBCC CHECKIDENT('dvd', RESEED, 1)

	SET IDENTITY_INSERT Dvd ON
	INSERT INTO Dvd(DvdId, DvdTitle, Director, Rating, ReleaseYear, Notes) VALUES
		(1, 'Rambo: First Blood', 'Ted Kotcheff','R', 1982, 'The exotic locales and boat travel scenes captured in the film are really mesmerizing'),
		(2, 'Planes, Trains & Automobiles', NULL, 'R' , 1987, 'It is perfectly cast and soundly constructed, and all else flows naturally.'),
		(3, 'Ghostbusters','Ivan Reitman','PG',1984, 'They are funny, but they are not afraid to reveal that they are also quick-witted and intelligent'),
		(4, 'The Great Outdoors','Howard Deutch','PG',1988, 'This is a great movie for the family and as classic as they get.')
	SET IDENTITY_INSERT Dvd OFF
END 
GO

-- Loads Database
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'LoadData')
BEGIN
   DROP PROCEDURE LoadData
END
GO
CREATE PROCEDURE LoadData
AS
	SELECT * 
	FROM Dvd
GO
-- Get By Id

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdById')
BEGIN
   DROP PROCEDURE GetDvdById
END
GO
CREATE PROCEDURE GetDvdById (
	@id int
)
AS
	SELECT * 
	FROM Dvd
	WHERE DvdId = @id;
GO
-- Get By Director

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdByDirector')
BEGIN
   DROP PROCEDURE GetDvdByDirector
END
GO
CREATE PROCEDURE GetDvdByDirector (
	@director nvarchar(60)
)
AS
	SELECT * 
	FROM Dvd
	WHERE Director = @director;
GO



-- Add DVD
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'AddDvd')
BEGIN
   DROP PROCEDURE AddDvd
END
GO
CREATE PROCEDURE AddDvd(
	@id int,
	@title nvarchar(60),
	@director nvarchar(60),
	@rating varchar(5), 
	@releaseYear int,
	@notes nvarchar(150)
	)
AS
	SET IDENTITY_INSERT Dvd ON
	INSERT INTO Dvd(DvdId, DvdTitle, Director, Rating, ReleaseYear, Notes) VALUES
	(@id, @title, @director,@rating, @releaseYear, @notes)
	SET IDENTITY_INSERT Dvd OFF
GO


--Updates dvd
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'UpdateDvd')
BEGIN
   DROP PROCEDURE UpdateDvd
END
GO
CREATE PROCEDURE UpdateDvd(
	@id int,
	@title nvarchar(60),
	@director nvarchar(60),
	@rating varchar(5), 
	@releaseYear int,
	@notes nvarchar(150)
	)
AS
	UPDATE Dvd
	SET 
		Dvd.DvdTitle = @title,
		Dvd.Director = @director,
		Dvd.Rating = @rating,
		Dvd.ReleaseYear = @releaseYear,
		Dvd.notes =@notes
	WHERE DvdId = @id;
GO



--Delete
IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'DeleteDvd')
BEGIN
   DROP PROCEDURE DeleteDvd
END
GO
CREATE PROCEDURE DeleteDvd(
	@id int
)
AS
	DELETE 
	FROM Dvd
	WHERE
		DvdId = @id;

GO
-- Get By Title

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdByTitle')
BEGIN
   DROP PROCEDURE GetDvdByTitle
END
GO
CREATE PROCEDURE GetDvdByTitle (
	@title nvarchar(60)
)
AS
	SELECT * 
	FROM Dvd
	WHERE DvdTitle = @title;
GO


-- Get By Rating

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdByRating')
BEGIN
   DROP PROCEDURE GetDvdByRating
END
GO
CREATE PROCEDURE GetDvdByRating (
	@rating varchar(5)
)
AS
	SELECT * 
	FROM Dvd
	WHERE Rating = @rating;
GO

-- Get By ReleaseYear

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdByReleaseYear')
BEGIN
   DROP PROCEDURE GetDvdByReleaseYear
END
GO
CREATE PROCEDURE GetDvdByReleaseYear (
	@releaseYear int
)
AS
	SELECT * 
	FROM Dvd
	WHERE ReleaseYear = @releaseYear;
GO

IF EXISTS(
   SELECT *
   FROM INFORMATION_SCHEMA.ROUTINES
   WHERE ROUTINE_NAME = 'GetDvdByDirector')
BEGIN
   DROP PROCEDURE GetDvdByDirector
END
GO
CREATE PROCEDURE GetDvdByDirector (
	@director nvarchar(60)
)
AS
	SELECT * 
	FROM Dvd
	WHERE Director = @director;
GO


EXEC GetDvdByTitle 'Ghostbusters'