USE [LineDB]
GO

/****** Object:  Table [dbo].[Markers]    Script Date: 27.12.2014 17:50:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Markers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Lat] [float] NOT NULL,
	[Lng] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[City] [nvarchar](50) NOT NULL,
	[Street] [nvarchar](100) NULL,
	[HouseNumber] [nvarchar](10) NULL,
	[Appartment] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((0.0)) FOR [Lat]
GO

ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((0.0)) FOR [Lng]
GO

ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((1)) FOR [CategoryId]
GO

ALTER TABLE [dbo].[Markers] ADD  DEFAULT ('Minsk') FOR [City]
GO

ALTER TABLE [dbo].[Markers]  WITH CHECK ADD  CONSTRAINT [FK_Markers_ToCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Markers] CHECK CONSTRAINT [FK_Markers_ToCategory]
GO

