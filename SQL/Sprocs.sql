USE Content

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
	@Description varchar(MAX),
	@Artist varchar(MAX),
	@DateMod datetime
) AS
BEGIN
	UPDATE Content
	SET Title = @Title, [Description] = @Description, Artist = @Artist, DateMod = @DateMod
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
	@FileExtension varchar(MAX),
	@FileName varchar(MAX),
	@FileSize int,
	@DateAdded datetime,
	@DateMod datetime,
	@BlobUrl varchar(MAX)
) AS
BEGIN
	INSERT INTO Content (Title, [Description], Artist, [FileName], FileExtension, FileSize, DateAdded, DateMod, BlobUrl)
	VALUES (@Title, @Description, @Artist, @FileName, @FileExtension, @FileSize, @DateAdded, @DateMod, @BlobUrl)
END
GO