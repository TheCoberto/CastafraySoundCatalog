CREATE PROCEDURE ImageSelectAll AS
BEGIN
	SELECT *
	FROM Images
END
GO

CREATE PROCEDURE ImageSelectById (
	@ImageId int
) AS
BEGIN
	SELECT *
	FROM Images
	WHERE ImageId = @ImageId
END
GO

CREATE PROCEDURE ImageInsert (
	@Title varchar(MAX),
	@Description varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExt varchar(MAX)
) AS
BEGIN
	INSERT INTO Images (Title, [Description], FilePath, FileExt)
	VALUES (@Title, @Description, @FilePath, @FileExt)
END
GO

CREATE PROCEDURE ImageDeleteById (
	@ImageId int
) AS
BEGIN
	DELETE 
	FROM Images
	WHERE ImageId = @ImageId
END
GO

CREATE PROCEDURE ImageUpdate (
	@ImageId int,
	@Description varchar(MAX)
) AS
BEGIN
	UPDATE Images 
	SET [Description] = @Description
	WHERE @ImageId = ImageId
END

GO

CREATE PROCEDURE VideoSelectAll AS
BEGIN
	SELECT *
	FROM Videos
END
GO

CREATE PROCEDURE VideoSelectById (
	@VideoId int
) AS
BEGIN
	SELECT *
	FROM Videos
	WHERE VideoId = @VideoId
END
GO

CREATE PROCEDURE VideoInsert (
	@Title varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExt varchar(MAX)
) AS
BEGIN
	INSERT INTO Videos (Title, FilePath, FileExt)
	VALUES (@Title, @FilePath, @FileExt)
END
GO

CREATE PROCEDURE [dbo].[SoundDeleteById] (
	@SoundId int
) AS
BEGIN
	DELETE 
	FROM Sounds
	WHERE SoundId = @SoundId
END
GO

CREATE PROCEDURE [dbo].[SoundUpdate] (
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

CREATE PROCEDURE [dbo].[SoundSelectById] (
	@SoundId int
) AS
BEGIN
	SELECT *
	FROM Sounds
	WHERE SoundId = @SoundId
END
GO

CREATE PROCEDURE [dbo].[SoundSelectAll] AS
BEGIN
	SELECT *
	FROM Sounds
END
GO

CREATE PROCEDURE [dbo].[SoundInsert] (
	@Title varchar(MAX),
	@Artist varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExtension varchar(MAX),
	@FileName varchar(MAX)
) AS
BEGIN
	INSERT INTO Sounds (Title, Artist, FileName, FilePath, FileExtension)
	VALUES (@Title, @Artist, @FileName, @FilePath, @FileExtension)
END
GO

CREATE PROCEDURE [dbo].[ContentDeleteById] (
	@ContentId int
) AS
BEGIN
	DELETE 
	FROM Content
	WHERE ContentId = @ContentId
END
GO

CREATE PROCEDURE [dbo].[ContentUpdate] (
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

CREATE PROCEDURE [dbo].[ContentSelectById] (
	@ContentId int
) AS
BEGIN
	SELECT *
	FROM Content
	WHERE ContentId = @ContentId
END
GO

CREATE PROCEDURE [dbo].[ContentSelectAll] AS
BEGIN
	SELECT *
	FROM Content
END
GO

CREATE PROCEDURE [dbo].[ContentInsert] (
	@Title varchar(MAX),
	@Description varchar(MAX),
	@Artist varchar(MAX),
	@FilePath nvarchar(MAX),
	@FileExtension varchar(MAX),
	@FileName varchar(MAX)
) AS
BEGIN
	INSERT INTO Content (Title, [Description], Artist, FileName, FilePath, FileExtension)
	VALUES (@Title, @Description, @Artist, @FileName, @FilePath, @FileExtension)
END
GO