GO
CREATE DATABASE ShipTrackingDB

USE [ShipTrackingDB]
GO
/****** Object:  Table [dbo].[LU_ShipStatus]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LU_ShipStatus](
	[ShipStatusId] [int] IDENTITY(1,1) NOT NULL,
	[ShipStatus] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LU_ShipStatus] PRIMARY KEY CLUSTERED 
(
	[ShipStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LU_ShipType]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LU_ShipType](
	[ShipTypeId] [int] IDENTITY(1,1) NOT NULL,
	[ShipType] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LU_ShipType] PRIMARY KEY CLUSTERED 
(
	[ShipTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ports]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ports](
	[PortId] [bigint] IDENTITY(1,1) NOT NULL,
	[PortName] [nvarchar](50) NOT NULL,
	[Latitude] [nvarchar](50) NOT NULL,
	[Longitude] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Ports] PRIMARY KEY CLUSTERED 
(
	[PortId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ShipRoute]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ShipRoute](
	[RouteId] [bigint] IDENTITY(1,1) NOT NULL,
	[From_PortId] [bigint] NOT NULL,
	[To_PortId] [bigint] NOT NULL,
	[ShipId] [bigint] NOT NULL,
	[Latitude] [nvarchar](50) NOT NULL,
	[Longitude] [nvarchar](50) NOT NULL,
	[CurrentShipSpeed] [float] NOT NULL,
	[Course] [decimal](18, 0) NULL,
	[ShipStatus] [int] NOT NULL,
	[ApproxETA] [datetime] NOT NULL,
	[ApproxETA_Updated] [datetime] NOT NULL,
	[Last_Calculated] [datetime] NOT NULL,
	[Distance] [float] NOT NULL,
	[DistanceToGo] [float] NOT NULL,
	[ArrivalTime] [datetime] NULL,
	[DepartureTime] [datetime] NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_ShipRoute] PRIMARY KEY CLUSTERED 
(
	[RouteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[ShipId] [bigint] IDENTITY(1,1) NOT NULL,
	[ShipName] [nvarchar](50) NOT NULL,
	[ShipSpeed] [float] NOT NULL,
	[BuildYear] [nvarchar](50) NOT NULL,
	[ShipSize] [nvarchar](50) NOT NULL,
	[ShipType] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Ships] PRIMARY KEY CLUSTERED 
(
	[ShipId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GenerateCsharpClass]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

/****** Object:  StoredProcedure [dbo].[GetPortsClosestShipDetailList]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC GetPortsClosestShipDetailList @PortId = '5', @SearchText = 'makarba', @SortExpression = 'CreatedDate', @SortType = 'DESC', @FromIndex = '1', @ToIndex = '10'
CREATE PROCEDURE [dbo].[GetPortsClosestShipDetailList]
	@PortId BIGINT,
	@SearchText VARCHAR(50),
	@FromIndex INT,      
	@ToIndex INT,  
	@SortExpression VARCHAR(100),        
	@SortType VARCHAR(10)  
AS      
BEGIN  
	IF(@SortType is null or LEN(@SortType)=0)  
		SET @SortType='DESC';      
      
	IF(@SortExpression is null or LEN(@SortExpression)=0)      
		SET @SortExpression='CreatedDate';     
  
	;WITH CTEShipRouteList AS      
	(  
		SELECT *, COUNT(t.ShipId) OVER() AS Count      
		FROM       
		(
			Select ROW_NUMBER() OVER (ORDER BY SR.DistanceToGo) AS Row,
				S.ShipName, S.ShipSpeed, S.BuildYear, S.ShipSize,  
				LUSS.ShipStatus AS ShipStatusName, LUST.ShipType AS ShipTypeName,
				PR.PortName, SR.*
			FROM Ships S
			INNER JOIN ShipRoute SR ON S.ShipId = SR.ShipId
			INNER JOIN Ports PR ON PR.PortId = SR.From_PortId OR PR.PortId = SR.To_PortId
			LEFT JOIN LU_ShipStatus LUSS ON LUSS.ShipStatusId = SR.ShipStatus
			LEFT JOIN LU_ShipType LUST ON LUST.ShipTypeId = S.ShipType
			WHERE  
			1 = 1  
			AND (@PortId = 0 OR SR.From_PortId = @PortId)
			AND (ISNULL(@SearchText,'') = '' OR PR.PortName LIKE '%'+@SearchText+'%' OR S.ShipName LIKE '%'+@SearchText+'%')
			AND SR.DistanceToGo > 0 AND SR.ShipStatus != 3
		) AS t      
	 )  
	 SELECT * FROM CTEShipRouteList WHERE Row BETWEEN @FromIndex AND @ToIndex      
END

GO
/****** Object:  StoredProcedure [dbo].[GetShipRouteDetailList]    Script Date: 16-09-2021 22:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--EXEC GetShipRouteDetailList @ShipId = 1, @SearchText = '', @FromIndex = '1', @ToIndex = '10', @SortExpression = 'CreatedDate', @SortType = 'DESC'
CREATE PROCEDURE [dbo].[GetShipRouteDetailList]
	@ShipId BIGINT,
	@SearchText VARCHAR(50),
	@FromIndex INT,      
	@ToIndex INT,  
	@SortExpression VARCHAR(100),        
	@SortType VARCHAR(10)  
AS      
BEGIN  
	IF(@SortType is null or LEN(@SortType)=0)  
		SET @SortType='DESC';      
      
	IF(@SortExpression is null or LEN(@SortExpression)=0)      
		SET @SortExpression='CreatedDate';     
  
	;WITH CTEShipRouteList AS      
	(  
		SELECT *, COUNT(t.ShipId) OVER() AS Count      
		FROM       
		(   
			Select ROW_NUMBER() OVER (ORDER BY   
					CASE WHEN @SortType = 'ASC' THEN CASE WHEN @SortExpression = 'CreatedDate' THEN SR.CreatedDate END END ASC,   

					CASE WHEN @SortType = 'DESC' THEN CASE WHEN @SortExpression = 'CreatedDate' THEN SR.CreatedDate END END DESC
				) AS Row,
				S.ShipName, S.ShipSpeed, S.BuildYear, S.ShipSize, 
				LUSS.ShipStatus AS ShipStatusName, LUST.ShipType AS ShipTypeName,
				SR.*
			FROM Ships S
				INNER JOIN ShipRoute SR ON S.ShipId = SR.ShipId
				LEFT JOIN LU_ShipStatus LUSS ON LUSS.ShipStatusId = SR.ShipStatus
				LEFT JOIN LU_ShipType LUST ON LUST.ShipTypeId = S.ShipType
			WHERE  
			1 = 1  
			AND (@ShipId = 0 OR SR.ShipId = @ShipId)
			AND (ISNULL(@SearchText,'') = '' OR S.ShipName LIKE '%'+@SearchText+'%')
		) AS t      
	 )  
	 SELECT * FROM CTEShipRouteList WHERE Row BETWEEN @FromIndex AND @ToIndex      
END
GO
