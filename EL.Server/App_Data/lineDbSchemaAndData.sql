USE [master]
GO
/****** Object:  Database [LineDB]    Script Date: 14.04.2014 2:23:18 ******/
CREATE DATABASE [LineDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LineDB', FILENAME = N'D:\Projects\ELine\EL.Server\App_Data\LineDB.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'LineDB_log', FILENAME = N'D:\Projects\ELine\EL.Server\App_Data\LineDB.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [LineDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LineDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LineDB] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [LineDB] SET ANSI_NULLS ON 
GO
ALTER DATABASE [LineDB] SET ANSI_PADDING ON 
GO
ALTER DATABASE [LineDB] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [LineDB] SET ARITHABORT ON 
GO
ALTER DATABASE [LineDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [LineDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LineDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LineDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LineDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LineDB] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [LineDB] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [LineDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LineDB] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [LineDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LineDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LineDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LineDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LineDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LineDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LineDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LineDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LineDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LineDB] SET RECOVERY FULL 
GO
ALTER DATABASE [LineDB] SET  MULTI_USER 
GO
ALTER DATABASE [LineDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LineDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LineDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LineDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [LineDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 14.04.2014 2:23:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Link] [nvarchar](255) NULL,
	[Parent] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 14.04.2014 2:23:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Mobile] [nvarchar](max) NULL,
	[Municipal] [nvarchar](max) NULL,
	[Email] [nvarchar](60) NULL,
	[Chat] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Details]    Script Date: 14.04.2014 2:23:18 ******/
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
/****** Object:  Table [dbo].[Entrepreneurs]    Script Date: 14.04.2014 2:23:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entrepreneurs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](255) NULL,
	[LocationId] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[DescriptionId] [int] NULL,
	[PhotoId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Gallery]    Script Date: 14.04.2014 2:23:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Thumb] [nvarchar](max) NULL,
	[Results] [nvarchar](max) NULL,
	[Certificates] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Markers]    Script Date: 14.04.2014 2:23:18 ******/
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
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (1, N'CarService', N'carservice', 0)
INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (2, N'Beauty', N'beauty', 0)
INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (3, N'Wires', N'wires', 1)
INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (4, N'Suspension', N'suspension', 1)
INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (5, N'Manicure', N'manicure', 2)
INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (6, N'someCascadeTest', N'll', 0)
INSERT [dbo].[Category] ([Id], [Title], [Link], [Parent]) VALUES (7, N'HairDressing', N'hairdress', 2)
SET IDENTITY_INSERT [dbo].[Category] OFF
SET IDENTITY_INSERT [dbo].[Contacts] ON 

INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (1, N'+375295464646;+375447212208', N'0172256987', N'parik@gmail.com', N'skype: parik.by')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Details] ON 

INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (1, 1, N'Over 10 years at BY market')
SET IDENTITY_INSERT [dbo].[Details] OFF
SET IDENTITY_INSERT [dbo].[Entrepreneurs] ON 

INSERT [dbo].[Entrepreneurs] ([Id], [Name], [LocationId], [CategoryId], [DescriptionId], [PhotoId]) VALUES (2, N'Парикмахерская №1В', 7, 7, 1, 1)
SET IDENTITY_INSERT [dbo].[Entrepreneurs] OFF
SET IDENTITY_INSERT [dbo].[Gallery] ON 

INSERT [dbo].[Gallery] ([Id], [Thumb], [Results], [Certificates]) VALUES (1, N'file:\\somePath\th', N'file:\\somePath\res', N'file:\\somePath\certs')
SET IDENTITY_INSERT [dbo].[Gallery] OFF
SET IDENTITY_INSERT [dbo].[Markers] ON 

INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (1, 54.5566969, 27.55555552, 6, N'Minsk', NULL, NULL, NULL)
INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (2, 53.8, 27.6, 6, N'Minsk', NULL, NULL, NULL)
INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (3, 52.44, 28.656, 1, N'Minsk', NULL, NULL, NULL)
INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (4, 54.8, 27.3, 2, N'Minsk', NULL, NULL, NULL)
INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (5, 54.9, 26.9, 3, N'Minsk', NULL, NULL, NULL)
INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (6, 53.9, 27, 4, N'Minsk', NULL, NULL, NULL)
INSERT [dbo].[Markers] ([Id], [Lat], [Lng], [CategoryId], [City], [Street], [HouseNumber], [Appartment]) VALUES (7, 53.907173, 27.480556, 7, N'Minsk', N'Belskogo', N'2', NULL)
SET IDENTITY_INSERT [dbo].[Markers] OFF
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((0.0)) FOR [Lat]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((0.0)) FOR [Lng]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((1)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ('Minsk') FOR [City]
GO
ALTER TABLE [dbo].[Details]  WITH CHECK ADD  CONSTRAINT [FK_Details_ToContacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Details] CHECK CONSTRAINT [FK_Details_ToContacts]
GO
ALTER TABLE [dbo].[Entrepreneurs]  WITH CHECK ADD  CONSTRAINT [FK_Entrepreneurs_ToCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
GO
ALTER TABLE [dbo].[Entrepreneurs] CHECK CONSTRAINT [FK_Entrepreneurs_ToCategory]
GO
ALTER TABLE [dbo].[Entrepreneurs]  WITH CHECK ADD  CONSTRAINT [FK_Entrepreneurs_ToDetails] FOREIGN KEY([DescriptionId])
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
ALTER TABLE [dbo].[Markers]  WITH CHECK ADD  CONSTRAINT [FK_Markers_ToCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Markers] CHECK CONSTRAINT [FK_Markers_ToCategory]
GO
USE [master]
GO
ALTER DATABASE [LineDB] SET  READ_WRITE 
GO
