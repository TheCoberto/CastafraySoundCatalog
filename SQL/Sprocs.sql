USE Content

IF EXISTS (select * from sys.procedures where name = 'ImageSelectAll')
BEGIN
	DROP PROCEDURE ImageSelectAll
END
GO

CREATE OR ALTER PROCEDURE ImageSelectAll AS
BEGIN
	SELECT *
	FROM Images
END
GO

IF EXISTS (select * from sys.procedures where name = 'ImageSelectById')
BEGIN
	DROP PROCEDURE ImageSelectById
END
GO

CREATE OR ALTER PROCEDURE ImageSelectById (
	@ImageId int
) AS
BEGIN
	SELECT *
	FROM Images
	WHERE ImageId = @ImageId
END
GO

IF EXISTS (select * from sys.procedures where name = 'ImageInsert')
BEGIN
	DROP PROCEDURE ImageInsert
END
GO

CREATE OR ALTER PROCEDURE ImageInsert (
	@Title varchar(MAX),
	@Description varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExt varchar(MAX),
	@FileSize int,
	@DateAdded datetime
) AS
BEGIN
	INSERT INTO Images (Title, [Description], FilePath, FileExt, FileSize, DateAdded)
	VALUES (@Title, @Description, @FilePath, @FileExt, @FileSize, @DateAdded)
END
GO

IF EXISTS (select * from sys.procedures where name = 'ImageDeleteById')
BEGIN
	DROP PROCEDURE ImageDeleteById
END
GO

CREATE OR ALTER PROCEDURE ImageDeleteById (
	@ImageId int
) AS
BEGIN
	DELETE 
	FROM Images
	WHERE ImageId = @ImageId
END
GO

IF EXISTS (select * from sys.procedures where name = 'ImageUpdate')
BEGIN
	DROP PROCEDURE ImageUpdate
END
GO

CREATE OR ALTER PROCEDURE ImageUpdate (
	@ImageId int,
	@Description varchar(MAX)
) AS
BEGIN
	UPDATE Images 
	SET [Description] = @Description
	WHERE @ImageId = ImageId
END
GO

IF EXISTS (select * from sys.procedures where name = 'VideoSelectAll')
BEGIN
	DROP PROCEDURE VideoSelectAll
END
GO

CREATE OR ALTER PROCEDURE VideoSelectAll AS
BEGIN
	SELECT *
	FROM Videos
END
GO

IF EXISTS (select * from sys.procedures where name = 'VideoSelectById')
BEGIN
	DROP PROCEDURE VideoSelectById
END
GO

CREATE OR ALTER PROCEDURE VideoSelectById (
	@VideoId int
) AS
BEGIN
	SELECT *
	FROM Videos
	WHERE VideoId = @VideoId
END
GO

IF EXISTS (select * from sys.procedures where name = 'VideoInsert')
BEGIN
	DROP PROCEDURE VideoInsert
END
GO

CREATE OR ALTER PROCEDURE VideoInsert (
	@Title varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExt varchar(MAX),
	@FileSize int,
	@DateAdded datetime
) AS
BEGIN
	INSERT INTO Videos (Title, FilePath, FileExt, FileSize, DateAdded)
	VALUES (@Title, @FilePath, @FileExt, @FileSize, @DateAdded)
END
GO

IF EXISTS (select * from sys.procedures where name = 'SoundDeleteById')
BEGIN
	DROP PROCEDURE SoundDeleteById
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SoundDeleteById] (
	@SoundId int
) AS
BEGIN
	DELETE 
	FROM Sounds
	WHERE SoundId = @SoundId
END
GO

IF EXISTS (select * from sys.procedures where name = 'SoundUpdate')
BEGIN
	DROP PROCEDURE SoundUpdate
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SoundUpdate] (
	@SoundId int,
	@Title varchar(MAX),
	@Artist varchar(MAX)
) AS
BEGIN
	UPDATE Sounds 
	SET Title = @Title, Artist = @Artist
	WHERE @SoundId = SoundId
END
GO

IF EXISTS (select * from sys.procedures where name = 'SoundSelectById')
BEGIN
	DROP PROCEDURE SoundSelectById
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SoundSelectById] (
	@SoundId int
) AS
BEGIN
	SELECT *
	FROM Sounds
	WHERE SoundId = @SoundId
END
GO

IF EXISTS (select * from sys.procedures where name = 'SoundSelectAll')
BEGIN
	DROP PROCEDURE SoundSelectAll
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SoundSelectAll] AS
BEGIN
	SELECT *
	FROM Sounds
END
GO

IF EXISTS (select * from sys.procedures where name = 'SoundInsert')
BEGIN
	DROP PROCEDURE SoundInsert
END
GO

CREATE OR ALTER PROCEDURE [dbo].[SoundInsert] (
	@Title varchar(MAX),
	@Artist varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExtension varchar(MAX),
	@FileName varchar(MAX),
	@FileSize int,
	@DateAdded datetime
) AS
BEGIN
	INSERT INTO Sounds (Title, Artist, FileName, FilePath, FileExtension, FileSize, DateAdded)
	VALUES (@Title, @Artist, @FileName, @FilePath, @FileExtension, @FileSize, @DateAdded)
END
GO

IF EXISTS (select * from sys.procedures where name = 'ContentDeleteById')
BEGIN
	DROP PROCEDURE ContentDeleteById
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentDeleteById] (
	@ContentId int
) AS
BEGIN
	DELETE 
	FROM Content
	WHERE ContentId = @ContentId
END
GO

IF EXISTS (select * from sys.procedures where name = 'ContentUpdate')
BEGIN
	DROP PROCEDURE ContentUpdate
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentUpdate] (
	@ContentId int,
	@Title varchar(MAX),
	@Artist varchar(MAX)
) AS
BEGIN
	UPDATE Content
	SET Title = @Title, Artist = @Artist
	WHERE @ContentId = ContentId
END
GO

IF EXISTS (select * from sys.procedures where name = 'ContentSelectById')
BEGIN
	DROP PROCEDURE ContentSelectById
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentSelectById] (
	@ContentId int
) AS
BEGIN
	SELECT *
	FROM Content
	WHERE ContentId = @ContentId
END
GO

IF EXISTS (select * from sys.procedures where name = 'ContentSelectAll')
BEGIN
	DROP PROCEDURE ContentSelectAll
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentSelectAll] AS
BEGIN
	SELECT *
	FROM Content
END
GO

IF EXISTS (select * from sys.procedures where name = 'ContentInsert')
BEGIN
	DROP PROCEDURE ContentInsert
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentInsert] (
	@Title varchar(MAX),
	@Description varchar(MAX),
	@Artist varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExtension varchar(MAX),
	@FileName varchar(MAX),
	@FileSize int,
	@DateAdded datetime
) AS
BEGIN
	INSERT INTO Content (Title, [Description], Artist, FileName, FilePath, FileExtension, FileSize, DateAdded)
	VALUES (@Title, @Description, @Artist, @FileName, @FilePath, @FileExtension, @FileSize, @DateAdded)
END
GO