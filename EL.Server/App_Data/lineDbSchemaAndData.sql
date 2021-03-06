USE [master]
GO
/****** Object:  Database [LineDB]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[CategoriesToMovables]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[Category]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[Contacts]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[Details]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[Entrepreneurs]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[Gallery]    Script Date: 15.05.2014 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gallery](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Avatar] [nvarchar](max) NULL,
	[FolderId] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Markers]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[Movables]    Script Date: 15.05.2014 23:34:26 ******/
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
/****** Object:  Table [dbo].[UserProfile]    Script Date: 15.05.2014 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](256) NULL,
	[LastName] [nvarchar](256) NULL,
	[RegistrationDate] [datetimeoffset](7) NULL,
	[Email] [nvarchar](256) NULL,
	[UserName] [nvarchar](256) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 15.05.2014 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 15.05.2014 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 15.05.2014 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 15.05.2014 23:34:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
 CONSTRAINT [PK_webpages_UsersInRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CategoriesToMovables] ON 

INSERT [dbo].[CategoriesToMovables] ([Id], [CategoryId], [MovableId]) VALUES (1, 7, 5)
INSERT [dbo].[CategoriesToMovables] ([Id], [CategoryId], [MovableId]) VALUES (3, 5, 6)
INSERT [dbo].[CategoriesToMovables] ([Id], [CategoryId], [MovableId]) VALUES (5, 7, 7)
INSERT [dbo].[CategoriesToMovables] ([Id], [CategoryId], [MovableId]) VALUES (6, 7, 8)
INSERT [dbo].[CategoriesToMovables] ([Id], [CategoryId], [MovableId]) VALUES (7, 7, 9)
INSERT [dbo].[CategoriesToMovables] ([Id], [CategoryId], [MovableId]) VALUES (8, 4, 10)
SET IDENTITY_INSERT [dbo].[CategoriesToMovables] OFF
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

INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (1, N'+375295464646;+375447212208', N'0172256987', N'parik@gmail.com', N'skype:parik.by')
INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (2, N'+375298585555;+375296452595', N'0172245689', N'mast@gmail.com', N'icq:milena')
INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (3, N'+375336358703', N'0172526589', N'mi@lk.by', N'skype:bur.by')
INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (4, N'+375297728088', N'0173490049', N'mmmi@kj.yb', N'skype:mm')
INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (5, N'+375336658895', N'0175556699', N'mh@lk.by', NULL)
INSERT [dbo].[Contacts] ([Id], [Mobile], [Municipal], [Email], [Chat]) VALUES (6, N'+375889966666', NULL, N'yu@lk.vy', N'wil:bur')
SET IDENTITY_INSERT [dbo].[Contacts] OFF
SET IDENTITY_INSERT [dbo].[Details] ON 

INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (1, 1, N'Over 10 years at BY market')
INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (3, 2, N'1 year of working')
INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (4, 3, N'5 years of working in the same structure')
INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (5, 4, N'mixed several jobs')
INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (6, 5, N'many many years ago')
INSERT [dbo].[Details] ([Id], [ContactId], [Experience]) VALUES (7, 6, N'just started movable business')
SET IDENTITY_INSERT [dbo].[Details] OFF
SET IDENTITY_INSERT [dbo].[Entrepreneurs] ON 

INSERT [dbo].[Entrepreneurs] ([Id], [Name], [LocationId], [CategoryId], [DetailsId], [PhotoId]) VALUES (2, N'Парикмахерская №1В', 7, 7, 1, 1)
SET IDENTITY_INSERT [dbo].[Entrepreneurs] OFF
SET IDENTITY_INSERT [dbo].[Gallery] ON 

INSERT [dbo].[Gallery] ([Id], [Avatar], [FolderId]) VALUES (1, N'img3-small.jpg', N'f1410d69-9f11-45c0-8499-6285de7f4da8')
INSERT [dbo].[Gallery] ([Id], [Avatar], [FolderId]) VALUES (2, N'img4-small.jpg', N'63f3d788-daad-4b5b-b188-b4d35db8afbb')
INSERT [dbo].[Gallery] ([Id], [Avatar], [FolderId]) VALUES (3, N'img1-small.jpg', N'b99d0887-32cb-410e-abb6-fb215daf9562')
INSERT [dbo].[Gallery] ([Id], [Avatar], [FolderId]) VALUES (4, N'img5-small.jpg', N'558ec6ce-8abd-43e7-812d-72c3f3cb4933')
INSERT [dbo].[Gallery] ([Id], [Avatar], [FolderId]) VALUES (5, N'xx.png', N'905107eb-51a9-4640-8eb7-4e6106396bea')
INSERT [dbo].[Gallery] ([Id], [Avatar], [FolderId]) VALUES (6, N'n1.png', N'a6281f58-d142-4074-8fba-3ebd072d785b')
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
SET IDENTITY_INSERT [dbo].[Movables] ON 

INSERT [dbo].[Movables] ([Id], [First], [Last], [Middle], [DetailsId], [GalleryId]) VALUES (5, N'Milena', N'Smith', NULL, 3, 3)
INSERT [dbo].[Movables] ([Id], [First], [Last], [Middle], [DetailsId], [GalleryId]) VALUES (6, N'Monica', N'Wolf', N'Smith', 1, 1)
INSERT [dbo].[Movables] ([Id], [First], [Last], [Middle], [DetailsId], [GalleryId]) VALUES (7, N'Laila', N'Monsiger', NULL, 4, 2)
INSERT [dbo].[Movables] ([Id], [First], [Last], [Middle], [DetailsId], [GalleryId]) VALUES (8, N'Batu', N'Sita', N'Lond', 5, 4)
INSERT [dbo].[Movables] ([Id], [First], [Last], [Middle], [DetailsId], [GalleryId]) VALUES (9, N'Lisa', N'Klobus', NULL, 6, 5)
INSERT [dbo].[Movables] ([Id], [First], [Last], [Middle], [DetailsId], [GalleryId]) VALUES (10, N'Klerk', N'Simon', NULL, 7, 6)
SET IDENTITY_INSERT [dbo].[Movables] OFF
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (1, N'andr', N'meln', NULL, N'm@lk.by', N'and')
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (2, NULL, NULL, CAST(0x074135E463A883380BB400 AS DateTimeOffset), N'klop', NULL)
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (3, NULL, NULL, CAST(0x075CB16CE8A883380BB400 AS DateTimeOffset), N'a1@lk.by', N'sim')
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (4, NULL, NULL, CAST(0x07973B55DCAC85380BB400 AS DateTimeOffset), N'm2@a1.by', N'mand')
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (5, NULL, NULL, CAST(0x072637200AB185380BB400 AS DateTimeOffset), N'm2@a2.by', N'as')
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (6, NULL, NULL, CAST(0x070A3476D1B185380BB400 AS DateTimeOffset), N'm3@a1.by', N'sad')
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (7, NULL, NULL, CAST(0x0799CF0637B385380BB400 AS DateTimeOffset), N'd@a1.by', N'd')
INSERT [dbo].[UserProfile] ([UserId], [FirstName], [LastName], [RegistrationDate], [Email], [UserName]) VALUES (9, NULL, NULL, CAST(0x072B27BD6AB485380BB400 AS DateTimeOffset), N'd3@a3.by', N'd3')
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (2, CAST(0x0000A328014B28D1 AS DateTime), NULL, 1, NULL, 0, N'AI3/teODR8ifE2X/YEEcvKAMQBFwVeSf8b7GRYcme8cerunCp95l/QK+Bab0d8zwsA==', CAST(0x0000A328014B28D1 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3, CAST(0x0000A328014C177B AS DateTime), NULL, 1, NULL, 0, N'ACbDSsa/NWKhl1kYMzALEKOXCaqO5w15F/1nW7EPjGgZe131QPU2OUu7XJSre8Q9RA==', CAST(0x0000A328014C177B AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (4, CAST(0x0000A32A0153DCF9 AS DateTime), NULL, 1, NULL, 0, N'AMmShP1dkUNMk2JinJREQ3Du6Z35Ke+2jMtyOh83M5P3mdvJaQA0n0VC7k33DgolfA==', CAST(0x0000A32A0153DCF9 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (5, CAST(0x0000A32A015C14A9 AS DateTime), NULL, 1, NULL, 0, N'AF5ATX6r7xj8dGEl3es6XJIKb4W8Ra8GY17o1TGX4Z6M1UzeTJLIetJ5FgTG5m8aNQ==', CAST(0x0000A32A015C14A9 AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (6, CAST(0x0000A32A015D9AEB AS DateTime), NULL, 1, NULL, 0, N'AARw4DGtCQBUl9pdgM7Ni0gC5xLQ6pYlmeRmzDmXhM/wib+MmShPefY0mdVM+OAUkQ==', CAST(0x0000A32A015D9AEB AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (7, CAST(0x0000A32A016059EB AS DateTime), NULL, 1, NULL, 0, N'AB5oUMSPkwJqa5oJ/ljNaSvPX+H7/VTnUsp/gcHHqEkTZ29ECoHsxcyK55Sxp8vXSA==', CAST(0x0000A32A016059EB AS DateTime), N'', NULL, NULL)
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (9, CAST(0x0000A32A0162B6E4 AS DateTime), NULL, 1, NULL, 0, N'APS90YR3Zf6oCyxi6U4Wk/ak/GmNX471yRfQ65J5pjSETPaUrka4tGmKpfj6GgNCKQ==', CAST(0x0000A32A0162B6E4 AS DateTime), N'', NULL, NULL)
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (4, N'Client')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Editor')
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'Entrepreneur')
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
SET IDENTITY_INSERT [dbo].[webpages_UsersInRoles] ON 

INSERT [dbo].[webpages_UsersInRoles] ([Id], [UserId], [RoleId]) VALUES (1, 9, 1)
SET IDENTITY_INSERT [dbo].[webpages_UsersInRoles] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__tmp_ms_x__A9D105340C97C677]    Script Date: 15.05.2014 23:34:26 ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__tmp_ms_x__C9F284567C3F93C6]    Script Date: 15.05.2014 23:34:26 ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B61607AD7C356]    Script Date: 15.05.2014 23:34:26 ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((0.0)) FOR [Lat]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((0.0)) FOR [Lng]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ((1)) FOR [CategoryId]
GO
ALTER TABLE [dbo].[Markers] ADD  DEFAULT ('Minsk') FOR [City]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
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
ALTER TABLE [dbo].[Details]  WITH CHECK ADD  CONSTRAINT [FK_Details_ToContacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[Details] CHECK CONSTRAINT [FK_Details_ToContacts]
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
ALTER TABLE [dbo].[Markers]  WITH CHECK ADD  CONSTRAINT [FK_Markers_ToCategory] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Markers] CHECK CONSTRAINT [FK_Markers_ToCategory]
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
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
USE [master]
GO
ALTER DATABASE [LineDB] SET  READ_WRITE 
GO
