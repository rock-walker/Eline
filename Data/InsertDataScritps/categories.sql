USE [LineDB]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (1, 0, N'CarService
', N'carservice', NULL)
INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (2, 0, N'Beauty', N'beauty', NULL)
INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (3, 1, N'Wires', N'wires', NULL)
INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (4, 1, N'Suspension', N'suspension', NULL)
INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (5, 2, N'Manicure', N'manicure', NULL)
INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (6, 0, N'someCascade', N'll', NULL)
INSERT [dbo].[Categories] ([Id], [Parent], [Title], [Link], [Entrepreneurs_Id]) VALUES (7, 2, N'HairDressing', N'hairdress', NULL)
SET IDENTITY_INSERT [dbo].[Categories] OFF
