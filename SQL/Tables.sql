USE Content

IF EXISTS (SELECT * FROM SYS.TABLES WHERE NAME = 'Content')
BEGIN
	DROP TABLE Content
END

CREATE TABLE Content (
	ContentId INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(MAX),
	[Description] VARCHAR(MAX) NULL,
    Artist VARCHAR(MAX) NULL,
	FileSize INT NULL,
    FileName VARCHAR(MAX),
    FileExtension VARCHAR(MAX),
	DateAdded DATETIME NULL,
	DateMod DATETIME NULL,
	BlobUrl varchar(MAX)
);