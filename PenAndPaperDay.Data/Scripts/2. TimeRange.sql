IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'TimeRange'))
BEGIN
	CREATE TABLE [dbo].[TimeRange](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[From] DateTime NOT NULL,
		[Till] DateTime NOT NULL,
		PRIMARY KEY (Id)
	)
END
GO