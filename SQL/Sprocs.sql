USE Content

IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'ContentDeleteById')
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

IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'ContentUpdate')
BEGIN
	DROP PROCEDURE ContentUpdate
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentUpdate] (
	@ContentId INT,
	@Title VARCHAR(MAX),
	@Description VARCHAR(MAX),
	@Artist VARCHAR(MAX),
	@DateMod DATETIME
) AS
BEGIN
	UPDATE Content
	SET Title = @Title, [Description] = @Description, Artist = @Artist, DateMod = @DateMod
	WHERE @ContentId = ContentId
END
GO

IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'ContentSelectById')
BEGIN
	DROP PROCEDURE ContentSelectById
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentSelectById] (
	@ContentId INT
) AS
BEGIN
	SELECT *
	FROM Content
	WHERE ContentId = @ContentId
END
GO

IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'ContentSelectAll')
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

IF EXISTS (SELECT * FROM SYS.PROCEDURES WHERE NAME = 'ContentInsert')
BEGIN
	DROP PROCEDURE ContentInsert
END
GO

CREATE OR ALTER PROCEDURE [dbo].[ContentInsert] (
	@Title VARCHAR(MAX),
	@Description VARCHAR(MAX),
	@Artist VARCHAR(MAX),
	@FileExtension VARCHAR(MAX),
	@FileName VARCHAR(MAX),
	@FileSize INT,
	@DateAdded DATETIME,
	@DateMod DATETIME,
	@BlobUrl VARCHAR(MAX)
) AS
BEGIN
	INSERT INTO Content (Title, [Description], Artist, [FileName], FileExtension, FileSize, DateAdded, DateMod, BlobUrl)
	VALUES (@Title, @Description, @Artist, @FileName, @FileExtension, @FileSize, @DateAdded, @DateMod, @BlobUrl)
END
GO