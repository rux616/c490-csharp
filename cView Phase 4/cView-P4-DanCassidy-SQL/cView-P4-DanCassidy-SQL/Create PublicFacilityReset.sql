USE [djcassid]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[PublicFacilityReset](
	[Name] [varchar](100) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Zip] [varchar](50) NOT NULL,
	[Latitude] [decimal](18, 15) NOT NULL,
	[Longitude] [decimal](18, 15) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
 CONSTRAINT [PK_PublicFacilityReset_Name] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[PublicFacilityReset] ADD  CONSTRAINT [DF_PublicFacilityReset_Latitude]  DEFAULT ((0)) FOR [Latitude]
GO

ALTER TABLE [dbo].[PublicFacilityReset] ADD  CONSTRAINT [DF_PublicFacilityReset_Longitude]  DEFAULT ((0)) FOR [Longitude]
GO
