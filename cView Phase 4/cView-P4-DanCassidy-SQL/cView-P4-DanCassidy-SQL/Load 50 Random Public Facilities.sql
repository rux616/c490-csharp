USE [djcassid]
GO

TRUNCATE TABLE [PublicFacility]
TRUNCATE TABLE [PublicFacilityReset]
GO

INSERT INTO [PublicFacilityReset]
SELECT TOP 50 * FROM [PublicFacilityBase] ORDER BY NEWID()
GO

INSERT INTO [PublicFacility]
SELECT * FROM [PublicFacilityReset]
GO
