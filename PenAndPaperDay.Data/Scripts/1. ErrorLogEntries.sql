IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'ErrorLogEntries'))
BEGIN
CREATE TABLE [dbo].[ErrorLogEntries](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[TimeStamp] [datetime] NOT NULL,
		[Message] [nvarchar](max) NULL,
		[LogLevel] [nvarchar](max) NULL,
		[Logger] [nvarchar](max) NULL,
		[UserId] [nvarchar](max) NULL,
		[StackTrace] [text] NOT NULL,
		[Machinename] [nvarchar](max) NULL,
		[AppName] [nvarchar](max) NULL,
		[TransactionId] [varchar](50) NULL,
		PRIMARY KEY (Id)
	)
END
GO