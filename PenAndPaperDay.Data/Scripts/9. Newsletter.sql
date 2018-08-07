IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'Newsletter'))
BEGIN
	CREATE TABLE [dbo].[Newsletter](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[Email] nvarchar(max) NOT NULL,
		PRIMARY KEY (Id)
	)
END
GO