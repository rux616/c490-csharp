USE [djcassid]
GO

TRUNCATE TABLE [PublicFacility]
GO

INSERT INTO [PublicFacility]
SELECT * FROM [PublicFacilityReset]
GO
