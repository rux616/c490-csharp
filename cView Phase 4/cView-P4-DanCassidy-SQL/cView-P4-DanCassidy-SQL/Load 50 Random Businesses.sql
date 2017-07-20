USE [djcassid]
GO

TRUNCATE TABLE [Business]
TRUNCATE TABLE [BusinessReset]
GO

INSERT INTO [BusinessReset]
SELECT TOP 50 * FROM [BusinessBase] ORDER BY NEWID()
GO

INSERT INTO [Business]
SELECT * FROM [BusinessReset]
GO