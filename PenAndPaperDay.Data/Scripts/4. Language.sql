IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Language'))
BEGIN
	CREATE TABLE [dbo].[Language](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[TwoDigitSeoCode] nvarchar(max) NOT NULL,
		[Name] nvarchar(max) NULL,
		PRIMARY KEY (Id)
	)
END
GO