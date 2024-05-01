USE Content

CREATE TABLE Images (
	ImageId int IDENTITY (1,1) PRIMARY KEY,
	Title varchar(MAX) NOT NULL,
	Artist varchar(MAX) NULL,
	[Description] varchar(MAX) NULL,
	FileSize int NULL,
	FileName VARCHAR(MAX),
	FilePath nvarchar(MAX) NULL,
	FileExt varchar(MAX) NOT NULL
)

CREATE TABLE Videos (
	VideoId int IDENTITY (1,1) PRIMARY KEY,
	Title varchar(MAX) NOT NULL,
	Artist varchar(MAX) NULL,
	[Description] varchar(MAX) NULL,
	FileSize int NULL,
	FileName VARCHAR(MAX),
	FilePath nvarchar(MAX) NOT NULL,
	FileExt varchar(MAX) NOT NULL
)

CREATE TABLE Sounds (
    SoundId INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(MAX),
	[Description] VARCHAR(MAX),
    Artist VARCHAR(MAX),
	FileSize int NULL,
    FileName VARCHAR(MAX),
    FilePath VARCHAR(MAX),
    FileExtension VARCHAR(MAX)
);

CREATE TABLE Content (
	ContentId INT PRIMARY KEY IDENTITY(1,1),
	Title VARCHAR(MAX),
	[Description] VARCHAR(MAX),
    Artist VARCHAR(MAX),
	FileSize int NULL,
    FileName VARCHAR(MAX),
    FilePath VARCHAR(MAX),
    FileExtension VARCHAR(MAX)
);