USE [ServiceDB]
GO
SET IDENTITY_INSERT [dbo].[Services] ON 

INSERT [dbo].[Services] ([Id], [BannerText], [Image], [Title], [Content], [CreateDate]) VALUES (17, N'asdsda', N'9f96bb66-0a02-429b-a747-d164bdedb37f-services-bg.jpg', N'asdds', N'asdsad', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Services] ([Id], [BannerText], [Image], [Title], [Content], [CreateDate]) VALUES (18, N'sss', N'578b26dc-9764-477f-8310-a17db364ae60-team_02.jpg', N'ssss', N'sss', CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Services] OFF
GO
