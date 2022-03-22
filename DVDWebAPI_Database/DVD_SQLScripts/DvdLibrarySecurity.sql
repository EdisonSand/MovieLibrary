USE master

IF EXISTS (SELECT* FROM master.dbo.syslogins WHERE name = 'DVDLibraryApp')
	DROP LOGIN DVDLibraryApp;
GO

CREATE LOGIN DVDLibraryApp WITH PASSWORD = 'Testing123'
GO

USE DvdLibrary

IF EXISTS(SELECT * FROM sys.database_principals WHERE name = 'DvdLibraryApp')
	DROP USER DVDLibraryApp
GO

CREATE USER DvdLibraryApp FOR LOGIN DVDLibraryApp
GO

GRANT EXECUTE ON AddDvd TO DvdLibraryApp
GRANT EXECUTE ON DeleteDvd TO DvdLibraryApp
GRANT EXECUTE ON LoadData TO DvdLibraryApp
GRANT EXECUTE ON UpdateDvd TO DvdLibraryApp
GRANT EXECUTE ON GetDvdById TO DvdLibraryApp
GRANT EXECUTE ON GetDvdByTitle TO DvdLibraryApp
GRANT EXECUTE ON GetDvdByReleaseYear TO DvdLibraryApp
GRANT EXECUTE ON GetDvdByRating TO DvdLibraryApp
GRANT EXECUTE ON GetDvdByDirector TO DvdLibraryApp
GRANT SELECT ON Dvd TO DvdLibraryApp
GRANT INSERT ON Dvd TO DvdLibraryApp
GRANT UPDATE ON Dvd TO DvdLibraryApp
GRANT DELETE ON Dvd TO DvdLibraryApp
GRANT ALTER ON Dvd TO DvdLibraryApp
GO