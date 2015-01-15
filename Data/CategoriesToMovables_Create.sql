USE [LineDB]
GO

/****** Object:  Table [dbo].[CategoriesToMovables]    Script Date: 27.12.2014 17:41:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CategoriesToMovables](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[MovableId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CategoriesToMovables]  WITH CHECK ADD  CONSTRAINT [FK_ToCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CategoriesToMovables] CHECK CONSTRAINT [FK_ToCategory]
GO

ALTER TABLE [dbo].[CategoriesToMovables]  WITH CHECK ADD  CONSTRAINT [FK_ToMovables] FOREIGN KEY([MovableId])
REFERENCES [dbo].[Movables] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[CategoriesToMovables] CHECK CONSTRAINT [FK_ToMovables]
GO

