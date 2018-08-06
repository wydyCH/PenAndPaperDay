IF (NOT EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'OfferedGameOnTag'))
BEGIN
	CREATE TABLE [dbo].[OfferedGameOnTag](
		[Id] [INT] IDENTITY(1,1) NOT NULL,
		[OfferedGameId] int NOT NULL,
		[TagId] int NOT NULL,
		PRIMARY KEY (Id),
		FOREIGN KEY ([OfferedGameId]) REFERENCES OfferedGame(Id),
		FOREIGN KEY ([TagId]) REFERENCES [Tag](Id)
	)
END
GO