IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'User'))
BEGIN
	CREATE TABLE [dbo].[User](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[Code] nvarchar(max) NOT NULL,
		[Email] nvarchar(max) NOT NULL,
		[Games] nvarchar(max) NULL,
		PRIMARY KEY (Id)
	)
END
GO