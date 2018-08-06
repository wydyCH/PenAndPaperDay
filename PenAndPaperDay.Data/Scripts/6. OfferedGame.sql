IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'OfferedGame'))
BEGIN
	CREATE TABLE [dbo].[OfferedGame](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[Duration] int NOT NULL,
		[Size] int NOT NULL,
		[LanguageId] int NOT NULL,
		[Description] nvarchar(max) NULL,
		PRIMARY KEY (Id),
		FOREIGN KEY (LanguageId) REFERENCES Language(Id)
	)
END
GO