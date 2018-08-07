IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'UserOnTimeRange'))
BEGIN
	CREATE TABLE [dbo].[UserOnTimeRange](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[UserId] int NOT NULL,
		[TimeRangeId] int NOT NULL,
		PRIMARY KEY (Id),
		FOREIGN KEY ([TimeRangeId]) REFERENCES TimeRange(Id),
		FOREIGN KEY ([UserId]) REFERENCES [User](Id)
	)
END
GO