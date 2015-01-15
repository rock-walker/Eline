USE [LineDB]
GO

/****** Object:  Table [dbo].[Movables]    Script Date: 27.12.2014 18:20:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First] [nvarchar](255) NULL,
	[Last] [nvarchar](255) NULL,
	[Middle] [nvarchar](255) NULL,
	[DetailsId] [int] NULL,
	[GalleryId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[Movables]  WITH CHECK ADD  CONSTRAINT [FK_Movables_ToDetails] FOREIGN KEY([DetailsId])
REFERENCES [dbo].[Details] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Movables] CHECK CONSTRAINT [FK_Movables_ToDetails]
GO

ALTER TABLE [dbo].[Movables]  WITH CHECK ADD  CONSTRAINT [FK_Movables_ToGallery] FOREIGN KEY([GalleryId])
REFERENCES [dbo].[Gallery] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Movables] CHECK CONSTRAINT [FK_Movables_ToGallery]
GO

