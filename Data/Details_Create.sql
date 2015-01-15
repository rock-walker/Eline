USE [LineDB]
GO

/****** Object:  Table [dbo].[Details]    Script Date: 27.12.2014 18:19:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ContactId] [int] NULL,
	[Experience] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Details]  WITH CHECK ADD  CONSTRAINT [FK_Details_ToContacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO

ALTER TABLE [dbo].[Details] CHECK CONSTRAINT [FK_Details_ToContacts]
GO

