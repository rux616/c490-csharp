USE [djcassid]
GO

TRUNCATE TABLE [Business]
GO

INSERT INTO [Business]
SELECT * FROM [BusinessReset]
GO