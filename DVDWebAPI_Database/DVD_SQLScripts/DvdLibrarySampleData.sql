USE DvdLibrary;
GO

SET IDENTITY_INSERT Dvd ON
INSERT INTO Dvd(DvdId, DvdTitle, Director, Rating, ReleaseYear, Notes) VALUES
	(1, 'Rambo: First Blood', 'Ted Kotcheff','R', 1982, 'The exotic locales and boat travel scenes captured in the film are really mesmerizing'),
	(2, 'Planes, Trains & Automobiles', NULL, 'R' , 1987, 'It is perfectly cast and soundly constructed, and all else flows naturally.'),
	(3, 'Ghostbusters','Ivan Reitman','PG',1984, 'They are funny, but they are not afraid to reveal that they are also quick-witted and intelligent'),
	(4, 'The Great Outdoors','Howard Deutch','PG',1988, 'This is a great movie for the family and as classic as they get.')
SET IDENTITY_INSERT Dvd OFF

SELECT * 
FROM Dvd
