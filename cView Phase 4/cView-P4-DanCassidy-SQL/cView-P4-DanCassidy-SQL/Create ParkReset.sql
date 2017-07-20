USE [djcassid]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ParkReset](
	[Name] [varchar](100) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Zip] [varchar](50) NOT NULL,
	[Latitude] [decimal](18, 15) NOT NULL,
	[Longitude] [decimal](18, 15) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[FeatureBaseball] [tinyint] NOT NULL,
	[FeatureBasketball] [decimal](4, 1) NOT NULL,
	[FeatureGolf] [decimal](4, 1) NOT NULL,
	[FeatureLargeMPField] [tinyint] NOT NULL,
	[FeatureTennis] [tinyint] NOT NULL,
	[FeatureVolleyball] [tinyint] NOT NULL,
 CONSTRAINT [PK_ParkReset_Name] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_Latitude]  DEFAULT ((0)) FOR [Latitude]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_Longitude]  DEFAULT ((0)) FOR [Longitude]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_FeatureBaseball]  DEFAULT ((0)) FOR [FeatureBaseball]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_FeatureBasketball]  DEFAULT ((0)) FOR [FeatureBasketball]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_FeatureGolf]  DEFAULT ((0)) FOR [FeatureGolf]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_FeatureLargeMPField]  DEFAULT ((0)) FOR [FeatureLargeMPField]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_FeatureTennis]  DEFAULT ((0)) FOR [FeatureTennis]
GO

ALTER TABLE [dbo].[ParkReset] ADD  CONSTRAINT [DF_ParkReset_FeatureVolleyball]  DEFAULT ((0)) FOR [FeatureVolleyball]
GO
