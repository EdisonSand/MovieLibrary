USE Master;
GO

if exists (select * from sys.databases where name = N'DvdLibrary')
begin
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'DvdLibrary';
	ALTER DATABASE DvdLibrary SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE DvdLibrary;
end

CREATE DATABASE DvdLibrary;
GO

USE DvdLibrary;
GO


CREATE TABLE Dvd(
	DvdId int identity(1,1) primary key,
	DvdTitle nvarchar(60) not null,
	Director nvarchar(60) null,
	Rating varchar(5) null,
	ReleaseYear int not null,
	Notes nvarchar(150) null,
);