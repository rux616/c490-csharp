USE [djcassid]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Business](
	[Name] [varchar](100) NOT NULL,
	[Type] [varchar](50) NOT NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
	[Zip] [varchar](50) NOT NULL,
	[Latitude] [decimal](18, 15) NOT NULL,
	[Longitude] [decimal](18, 15) NOT NULL,
	[Phone] [varchar](50) NOT NULL,
	[LicenseNumber] [varchar](50) NOT NULL,
	[LicenseIssueDate] [date] NOT NULL,
	[LicenseExpirDate] [date] NOT NULL,
	[LicenseStatus] [varchar](50) NOT NULL,
	[CouncilDistrict] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Business_LicenseNumber] PRIMARY KEY CLUSTERED 
(
	[LicenseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_Latitude]  DEFAULT ((0)) FOR [Latitude]
GO

ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_Longitude]  DEFAULT ((0)) FOR [Longitude]
GO

ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_LicenseIssueDate]  DEFAULT ('0001-01-01') FOR [LicenseIssueDate]
GO

ALTER TABLE [dbo].[Business] ADD  CONSTRAINT [DF_Business_LicenseExpirDate]  DEFAULT ('0001-01-01') FOR [LicenseExpirDate]
GO
