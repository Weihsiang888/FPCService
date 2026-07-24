USE [master]
GO
/****** 物件:  Database [FPC]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE DATABASE [FPC]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'FPC', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FPC.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'FPC_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\FPC_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [FPC] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [FPC].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [FPC] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [FPC] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [FPC] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [FPC] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [FPC] SET ARITHABORT OFF 
GO
ALTER DATABASE [FPC] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [FPC] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [FPC] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [FPC] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [FPC] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [FPC] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [FPC] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [FPC] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [FPC] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [FPC] SET  DISABLE_BROKER 
GO
ALTER DATABASE [FPC] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [FPC] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [FPC] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [FPC] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [FPC] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [FPC] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [FPC] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [FPC] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [FPC] SET  MULTI_USER 
GO
ALTER DATABASE [FPC] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [FPC] SET DB_CHAINING OFF 
GO
ALTER DATABASE [FPC] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [FPC] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [FPC] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [FPC] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [FPC] SET QUERY_STORE = ON
GO
ALTER DATABASE [FPC] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [FPC]
GO
/****** 物件:  Table [dbo].[__EFMigrationsHistory]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Detail_MobileRobot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_MobileRobot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[MobileRobot_UID] [varchar](60) NOT NULL,
	[MobileRobot_Status] [varchar](60) NOT NULL,
	[MobileRobot_Type] [varchar](60) NOT NULL,
	[SwarmCore_ID] [varchar](60) NULL,
	[Point_Code] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Occurrence_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Detail_Packaging]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_Packaging](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Packaging_UID] [varchar](60) NOT NULL,
	[Packaging_Point] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Occurrence_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Detail_PlaceSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_PlaceSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[PlaceSlot_UID] [varchar](60) NOT NULL,
	[Place_UID] [varchar](60) NOT NULL,
	[PlaceSlot_Point] [int] NOT NULL,
	[PlaceSlot_Status] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Occurrence_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Detail_RackSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_RackSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[RackSlot_UID] [varchar](60) NOT NULL,
	[StorageRack_UID] [varchar](60) NOT NULL,
	[RackSlot_Point] [int] NOT NULL,
	[RackSlot_Status] [varchar](60) NOT NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Occurrence_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Detail_YarnMachine]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_YarnMachine](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[YarnMachine_UID] [varchar](60) NOT NULL,
	[YarnMachine_Status] [varchar](60) NOT NULL,
	[WorderOrder] [varchar](60) NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[YarnSpoolCompleted_Count] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Occurrence_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Detail_YarnMachineSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Detail_YarnMachineSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[YarnMachineSlot_UID] [varchar](60) NOT NULL,
	[YarnMachine_UID] [varchar](60) NOT NULL,
	[YarnMachineSlot_Point] [int] NOT NULL,
	[YarnMachineSlot_Status] [varchar](60) NOT NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[Point_Code] [varchar](60) NULL,
	[TaskUID] [varchar](60) NULL,
	[Occurrence_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Log_MobileRobot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_MobileRobot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[MobileRobot_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Message] [varchar](200) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Log_Packaging]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_Packaging](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Packaging_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Message] [varchar](200) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Log_PlaceSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_PlaceSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[PlaceSlot_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Message] [varchar](200) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Log_RackSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_RackSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[RackSlot_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Message] [varchar](200) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Log_YarnMachineSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log_YarnMachineSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[YarnMachineSlot_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Message] [varchar](200) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Machine]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Machine](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IP] [nvarchar](50) NOT NULL,
	[Port] [int] NOT NULL,
	[ConnectionType] [int] NOT NULL,
	[MaxRetryCount] [int] NOT NULL,
	[TagCategoryID] [uniqueidentifier] NULL,
	[Enabled] [bit] NOT NULL,
	[UpdateDelay] [int] NOT NULL,
	[RecordStatusChanged] [bit] NOT NULL,
 CONSTRAINT [PK_Machine] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[MachineStatusLogs]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MachineStatusLogs](
	[Id] [uniqueidentifier] NOT NULL,
	[MachineID] [uniqueidentifier] NOT NULL,
	[Status] [int] NOT NULL,
	[LogTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MachineStatusLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_MobileRobot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_MobileRobot](
	[MobileRobot_UID] [varchar](60) NOT NULL,
	[MobileRobot_Status] [varchar](60) NOT NULL,
	[MobileRobot_Type] [varchar](60) NOT NULL,
	[SwarmCore_ID] [varchar](60) NULL,
	[Place_UID] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[Battery] [int] NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MobileRobot_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_MobileRobot_Point]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_MobileRobot_Point](
	[Point_UID] [varchar](60) NOT NULL,
	[Point_Name] [varchar](60) NOT NULL,
	[Point_Code] [varchar](60) NOT NULL,
	[Point_Number] [int] NOT NULL,
	[Point_Area] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Point_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_Packaging]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Packaging](
	[Packaging_UID] [varchar](60) NOT NULL,
	[Packaging_Point] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Packaging_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_Place]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_Place](
	[Place_UID] [varchar](60) NOT NULL,
	[Place_Name] [varchar](60) NOT NULL,
	[Place_ID] [int] NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[PlaceCompleted_Count] [int] NOT NULL,
	[Process_Time] [datetime] NOT NULL,
 CONSTRAINT [PK__Main_Pla__CE18ECEE11B2ADDB] PRIMARY KEY CLUSTERED 
(
	[Place_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_PlaceSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_PlaceSlot](
	[PlaceSlot_UID] [varchar](60) NOT NULL,
	[Place_UID] [varchar](60) NOT NULL,
	[PlaceSlot_Point] [int] NOT NULL,
	[PlaceSlot_Status] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[PlaceSlot_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_RackSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_RackSlot](
	[RackSlot_UID] [varchar](60) NOT NULL,
	[StorageRack_UID] [varchar](60) NOT NULL,
	[RackSlot_Point] [int] NOT NULL,
	[RackSlot_Status] [varchar](60) NOT NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[RackSlot_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_StorageRack]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_StorageRack](
	[StorageRack_UID] [varchar](60) NOT NULL,
	[StorageRack_Name] [varchar](60) NOT NULL,
	[StorageRack_Point] [int] NOT NULL,
	[YarnSpool_Type] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[StorageCompleted_Count] [int] NOT NULL,
	[Process_Time] [datetime] NOT NULL,
 CONSTRAINT [PK__Main_Sto__67667304DC989EED] PRIMARY KEY CLUSTERED 
(
	[StorageRack_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_YarnMachine]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_YarnMachine](
	[YarnMachine_UID] [varchar](60) NOT NULL,
	[YarnMachine_Status] [varchar](60) NOT NULL,
	[WorderOrder] [varchar](60) NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[YarnSpoolCompleted_Count] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[YarnMachine_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Main_YarnMachineSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Main_YarnMachineSlot](
	[YarnMachineSlot_UID] [varchar](60) NOT NULL,
	[YarnMachine_UID] [varchar](60) NOT NULL,
	[YarnMachineSlot_Point] [int] NOT NULL,
	[YarnMachineSlot_Status] [varchar](60) NOT NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[Point_Code] [varchar](60) NULL,
	[TaskUID] [varchar](60) NULL,
PRIMARY KEY CLUSTERED 
(
	[YarnMachineSlot_UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[ModbusSlaveConfigs]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModbusSlaveConfigs](
	[Id] [uniqueidentifier] NOT NULL,
	[Ip] [nvarchar](max) NOT NULL,
	[Port] [int] NOT NULL,
	[Station] [int] NOT NULL,
 CONSTRAINT [PK_ModbusSlaveConfigs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[ModbusTCPTags]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModbusTCPTags](
	[ID] [uniqueidentifier] NOT NULL,
	[CategoryId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[DataType] [int] NOT NULL,
	[UpdateByTime] [bit] NOT NULL,
	[Station] [tinyint] NOT NULL,
	[InputOrOutput] [bit] NOT NULL,
	[StartIndex] [int] NOT NULL,
	[Offset] [int] NOT NULL,
	[StringReverse] [bit] NOT NULL,
 CONSTRAINT [PK_ModbusTCPTags] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Queue_MobileRobot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queue_MobileRobot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Queue_Status] [int] NOT NULL,
	[MobileRobot_UID] [varchar](60) NOT NULL,
	[Point_Code] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
	[Create_Time] [datetime] NOT NULL,
	[Complete_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Queue_Packaging]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queue_Packaging](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Queue_Status] [int] NOT NULL,
	[Packaging_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
	[Create_Time] [datetime] NOT NULL,
	[Complete_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Queue_PlaceSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queue_PlaceSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Queue_Status] [int] NOT NULL,
	[PlaceSlot_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
	[Create_Time] [datetime] NOT NULL,
	[Complete_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Queue_RackSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queue_RackSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Queue_Status] [int] NOT NULL,
	[RackSlot_UID] [varchar](60) NOT NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
	[Create_Time] [datetime] NOT NULL,
	[Complete_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Queue_YarnMachineSlot]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Queue_YarnMachineSlot](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[Queue_Status] [int] NOT NULL,
	[YarnMachineSlot_UID] [varchar](60) NOT NULL,
	[YarnSpool_Type] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[TaskUID] [varchar](60) NULL,
	[Point_Code] [varchar](60) NULL,
	[Process_Time] [datetime] NOT NULL,
	[Create_Time] [datetime] NOT NULL,
	[Complete_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[Table_YarnSpool]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_YarnSpool](
	[UID] [int] IDENTITY(1,1) NOT NULL,
	[YarnSpool_UID] [varchar](60) NOT NULL,
	[YarnSpool_Status] [varchar](60) NOT NULL,
	[YarnSpool_Type] [varchar](60) NOT NULL,
	[AGV_UID] [varchar](60) NULL,
	[Place_UID] [varchar](60) NULL,
	[PlaceSlot_UID] [varchar](60) NULL,
	[StorageRack_UID] [varchar](60) NULL,
	[RackSlot_UID] [varchar](60) NULL,
	[TaskUID] [varchar](60) NULL,
	[Floor] [int] NOT NULL,
	[Process_Time] [datetime] NOT NULL,
	[Create_Time] [datetime] NOT NULL,
	[Complete_Time] [datetime] NULL,
	[Place_Time] [datetime] NULL,
	[Storage_Time] [datetime] NULL,
	[Packaging_Time] [datetime] NULL,
	[Event_Time] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[TagCategory]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagCategory](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ConnectionType] [int] NOT NULL,
 CONSTRAINT [PK_TagCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[TagWarningBoolConditions]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagWarningBoolConditions](
	[Id] [uniqueidentifier] NOT NULL,
	[TagId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[ComparisonCode] [int] NOT NULL,
	[WarningMessage] [nvarchar](max) NOT NULL,
	[TargetBoolValue] [bit] NOT NULL,
 CONSTRAINT [PK_TagWarningBoolConditions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** 物件:  Table [dbo].[TagWarningUshortConditions]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TagWarningUshortConditions](
	[Id] [uniqueidentifier] NOT NULL,
	[TagId] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[ComparisonCode] [int] NOT NULL,
	[WarningMessage] [nvarchar](max) NOT NULL,
	[TargetUshortValue] [int] NOT NULL,
 CONSTRAINT [PK_TagWarningUshortConditions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** 物件:  Index [IX_Machine_Name]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Machine_Name] ON [dbo].[Machine]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** 物件:  Index [IX_Machine_TagCategoryID]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE NONCLUSTERED INDEX [IX_Machine_TagCategoryID] ON [dbo].[Machine]
(
	[TagCategoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** 物件:  Index [IX_ModbusTCPTags_CategoryId]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE NONCLUSTERED INDEX [IX_ModbusTCPTags_CategoryId] ON [dbo].[ModbusTCPTags]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** 物件:  Index [IX_ModbusTCPTags_Name]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_ModbusTCPTags_Name] ON [dbo].[ModbusTCPTags]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** 物件:  Index [IX_TagCategory_Name]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TagCategory_Name] ON [dbo].[TagCategory]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** 物件:  Index [IX_TagWarningBoolConditions_Name]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TagWarningBoolConditions_Name] ON [dbo].[TagWarningBoolConditions]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** 物件:  Index [IX_TagWarningBoolConditions_TagId]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE NONCLUSTERED INDEX [IX_TagWarningBoolConditions_TagId] ON [dbo].[TagWarningBoolConditions]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** 物件:  Index [IX_TagWarningUshortConditions_Name]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_TagWarningUshortConditions_Name] ON [dbo].[TagWarningUshortConditions]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** 物件:  Index [IX_TagWarningUshortConditions_TagId]    指令碼日期: 2026/7/3 上午 10:07:35 ******/
CREATE NONCLUSTERED INDEX [IX_TagWarningUshortConditions_TagId] ON [dbo].[TagWarningUshortConditions]
(
	[TagId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Detail_MobileRobot] ADD  DEFAULT (getdate()) FOR [Occurrence_Time]
GO
ALTER TABLE [dbo].[Detail_Packaging] ADD  DEFAULT (getdate()) FOR [Occurrence_Time]
GO
ALTER TABLE [dbo].[Detail_PlaceSlot] ADD  DEFAULT (getdate()) FOR [Occurrence_Time]
GO
ALTER TABLE [dbo].[Detail_RackSlot] ADD  DEFAULT (getdate()) FOR [Occurrence_Time]
GO
ALTER TABLE [dbo].[Detail_YarnMachine] ADD  DEFAULT (getdate()) FOR [Occurrence_Time]
GO
ALTER TABLE [dbo].[Detail_YarnMachineSlot] ADD  DEFAULT (getdate()) FOR [Occurrence_Time]
GO
ALTER TABLE [dbo].[Log_MobileRobot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Log_Packaging] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Log_PlaceSlot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Log_RackSlot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Log_YarnMachineSlot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Main_MobileRobot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Main_Packaging] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Main_Place] ADD  CONSTRAINT [DF__Main_Plac__Place__7E37BEF6]  DEFAULT ((0)) FOR [PlaceCompleted_Count]
GO
ALTER TABLE [dbo].[Main_Place] ADD  CONSTRAINT [DF__Main_Plac__Proce__7F2BE32F]  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Main_StorageRack] ADD  CONSTRAINT [DF__Main_Stor__Stora__0A9D95DB]  DEFAULT ((0)) FOR [StorageCompleted_Count]
GO
ALTER TABLE [dbo].[Main_StorageRack] ADD  CONSTRAINT [DF__Main_Stor__Proce__0B91BA14]  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Main_YarnMachine] ADD  DEFAULT ((0)) FOR [YarnSpoolCompleted_Count]
GO
ALTER TABLE [dbo].[Main_YarnMachine] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Queue_MobileRobot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Queue_MobileRobot] ADD  DEFAULT (getdate()) FOR [Create_Time]
GO
ALTER TABLE [dbo].[Queue_Packaging] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Queue_Packaging] ADD  DEFAULT (getdate()) FOR [Create_Time]
GO
ALTER TABLE [dbo].[Queue_PlaceSlot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Queue_PlaceSlot] ADD  DEFAULT (getdate()) FOR [Create_Time]
GO
ALTER TABLE [dbo].[Queue_RackSlot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Queue_RackSlot] ADD  DEFAULT (getdate()) FOR [Create_Time]
GO
ALTER TABLE [dbo].[Queue_YarnMachineSlot] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Queue_YarnMachineSlot] ADD  DEFAULT (getdate()) FOR [Create_Time]
GO
ALTER TABLE [dbo].[Table_YarnSpool] ADD  DEFAULT (getdate()) FOR [Process_Time]
GO
ALTER TABLE [dbo].[Table_YarnSpool] ADD  DEFAULT (getdate()) FOR [Create_Time]
GO
ALTER TABLE [dbo].[Machine]  WITH CHECK ADD  CONSTRAINT [FK_Machine_TagCategory_TagCategoryID] FOREIGN KEY([TagCategoryID])
REFERENCES [dbo].[TagCategory] ([ID])
GO
ALTER TABLE [dbo].[Machine] CHECK CONSTRAINT [FK_Machine_TagCategory_TagCategoryID]
GO
ALTER TABLE [dbo].[ModbusTCPTags]  WITH CHECK ADD  CONSTRAINT [FK_ModbusTCPTags_TagCategory_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[TagCategory] ([ID])
GO
ALTER TABLE [dbo].[ModbusTCPTags] CHECK CONSTRAINT [FK_ModbusTCPTags_TagCategory_CategoryId]
GO
USE [master]
GO
ALTER DATABASE [FPC] SET  READ_WRITE 
GO
