USE [LineDB]
GO

/****** Object:  Table [dbo].[Entrepreneurs]    Script Date: 27.12.2014 17:49:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Entrepreneurs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[LocationId] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[DetailsId] [int] NULL,
	[PhotoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Entrepreneurs]  WITH CHECK ADD  CONSTRAINT [FK_Entrepreneurs_ToCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO

ALTER TABLE [dbo].[Entrepreneurs] CHECK CONSTRAINT [FK_Entrepreneurs_ToCategory]
GO

ALTER TABLE [dbo].[Entrepreneurs]  WITH CHECK ADD  CONSTRAINT [FK_Entrepreneurs_ToDetails] FOREIGN KEY([DetailsId])
REFERENCES [dbo].[Details] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Entrepreneurs] CHECK CONSTRAINT [FK_Entrepreneurs_ToDetails]
GO

ALTER TABLE [dbo].[Entrepreneurs]  WITH CHECK ADD  CONSTRAINT [FK_Entrepreneurs_ToGallery] FOREIGN KEY([PhotoId])
REFERENCES [dbo].[Gallery] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Entrepreneurs] CHECK CONSTRAINT [FK_Entrepreneurs_ToGallery]
GO

ALTER TABLE [dbo].[Entrepreneurs]  WITH CHECK ADD  CONSTRAINT [FK_Entrepreneurs_ToMarkers] FOREIGN KEY([LocationId])
REFERENCES [dbo].[Markers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Entrepreneurs] CHECK CONSTRAINT [FK_Entrepreneurs_ToMarkers]
GO

