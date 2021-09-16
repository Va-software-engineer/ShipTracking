USE [ShipTrackingDB]
GO
SET IDENTITY_INSERT [dbo].[LU_ShipStatus] ON 
GO
INSERT [dbo].[LU_ShipStatus] ([ShipStatusId], [ShipStatus]) VALUES (1, N'Under way using engine')
GO
INSERT [dbo].[LU_ShipStatus] ([ShipStatusId], [ShipStatus]) VALUES (2, N'Not Started')
GO
INSERT [dbo].[LU_ShipStatus] ([ShipStatusId], [ShipStatus]) VALUES (3, N'Docked')
GO
SET IDENTITY_INSERT [dbo].[LU_ShipStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[LU_ShipType] ON 
GO
INSERT [dbo].[LU_ShipType] ([ShipTypeId], [ShipType]) VALUES (1, N'Cargo Ship')
GO
INSERT [dbo].[LU_ShipType] ([ShipTypeId], [ShipType]) VALUES (2, N'Tanker')
GO
INSERT [dbo].[LU_ShipType] ([ShipTypeId], [ShipType]) VALUES (3, N'Passenger Ship')
GO
INSERT [dbo].[LU_ShipType] ([ShipTypeId], [ShipType]) VALUES (4, N'Fishing Ship')
GO
SET IDENTITY_INSERT [dbo].[LU_ShipType] OFF
GO
SET IDENTITY_INSERT [dbo].[Ports] ON 
GO
INSERT [dbo].[Ports] ([PortId], [PortName], [Latitude], [Longitude], [Country], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (3, N'Port 1', N'22.7650', N'69.7048', N'NA', 1, CAST(N'2021-09-14T00:00:00.000' AS DateTime), CAST(N'2021-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Ports] ([PortId], [PortName], [Latitude], [Longitude], [Country], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (4, N'Port 2', N'13.0815', N'80.2921', N'NA', 1, CAST(N'2021-09-14T00:00:00.000' AS DateTime), CAST(N'2021-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Ports] ([PortId], [PortName], [Latitude], [Longitude], [Country], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (5, N'Port 3', N'22.9960', N'72.4997', N'NA', 1, CAST(N'2021-09-14T00:00:00.000' AS DateTime), CAST(N'2021-09-14T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Ports] ([PortId], [PortName], [Latitude], [Longitude], [Country], [IsActive], [CreatedDate], [ModifiedDate]) VALUES (6, N'Port 4', N'23.1378', N'72.5437', N'NA', 1, CAST(N'2021-09-14T00:00:00.000' AS DateTime), CAST(N'2021-09-14T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Ports] OFF
GO
