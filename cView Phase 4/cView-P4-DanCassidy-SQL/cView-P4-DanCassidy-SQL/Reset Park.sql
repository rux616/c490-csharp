USE [djcassid]
GO

TRUNCATE TABLE [Park]
GO

INSERT INTO [Park]
SELECT * FROM [ParkReset]
GO
