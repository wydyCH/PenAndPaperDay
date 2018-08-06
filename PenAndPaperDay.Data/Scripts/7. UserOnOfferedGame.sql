IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'UserOnOfferedGame'))
BEGIN
	CREATE TABLE [dbo].[UserOnOfferedGame](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[UserId] int NOT NULL,
		[OfferedGameId] int NOT NULL,
		[UserType] int NOT NULL,
		PRIMARY KEY (Id),
		FOREIGN KEY ([OfferedGameId]) REFERENCES OfferedGame(Id),
		FOREIGN KEY ([UserId]) REFERENCES [User](Id)
	)
END
GO