USE [master]
GO
/****** Object:  Database [myCarYard_mycaryard]    Script Date: 2/15/2018 6:06:33 PM ******/
CREATE DATABASE [myCarYard_mycaryard]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'myCarYard_mycaryard', FILENAME = N'E:\MSSQL.MSSQLSERVER\DATA\myCarYard_mycaryard.mdf' , SIZE = 7168KB , MAXSIZE = 204800KB , FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'myCarYard_mycaryard_log', FILENAME = N'D:\MSSQL.MSSQLSERVER\DATA\myCarYard_mycaryard_log.ldf' , SIZE = 3072KB , MAXSIZE = 102400KB , FILEGROWTH = 1024KB )
GO
ALTER DATABASE [myCarYard_mycaryard] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [myCarYard_mycaryard].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [myCarYard_mycaryard] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET ARITHABORT OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [myCarYard_mycaryard] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [myCarYard_mycaryard] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET  ENABLE_BROKER 
GO
ALTER DATABASE [myCarYard_mycaryard] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [myCarYard_mycaryard] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [myCarYard_mycaryard] SET  MULTI_USER 
GO
ALTER DATABASE [myCarYard_mycaryard] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [myCarYard_mycaryard] SET DB_CHAINING OFF 
GO
ALTER DATABASE [myCarYard_mycaryard] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [myCarYard_mycaryard] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [myCarYard_mycaryard] SET DELAYED_DURABILITY = DISABLED 
GO
USE [myCarYard_mycaryard]
GO
/****** Object:  User [mycaryard]    Script Date: 2/15/2018 6:06:35 PM ******/
CREATE USER [mycaryard] FOR LOGIN [mycaryard] WITH DEFAULT_SCHEMA=[mycaryard]
GO
/****** Object:  DatabaseRole [gd_execprocs]    Script Date: 2/15/2018 6:06:36 PM ******/
CREATE ROLE [gd_execprocs]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [mycaryard]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [mycaryard]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [mycaryard]
GO
ALTER ROLE [db_datareader] ADD MEMBER [mycaryard]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [mycaryard]
GO
/****** Object:  Schema [mycaryard]    Script Date: 2/15/2018 6:06:37 PM ******/
CREATE SCHEMA [mycaryard]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BadgeTypeMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BadgeTypeMaster](
	[bad_id] [int] IDENTITY(1,1) NOT NULL,
	[make_id] [int] NULL,
	[model_id] [int] NULL,
	[badge_type] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Body_ColorMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Body_ColorMaster](
	[body_color_id] [int] IDENTITY(1,1) NOT NULL,
	[body_color_name] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Body_TypeMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Body_TypeMaster](
	[Body_type_id] [int] IDENTITY(1,1) NOT NULL,
	[Body_Type] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CarWatchList]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CarWatchList](
	[WatchListID] [int] IDENTITY(1,1) NOT NULL,
	[cid] [int] NULL,
	[uid] [int] NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatMessageDetail]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatMessageDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[Message] [nvarchar](max) NULL,
	[EmailID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatPrivateMessageDetails]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatPrivateMessageDetails](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MasterEmailID] [nvarchar](50) NOT NULL,
	[ChatToEmailID] [nvarchar](50) NOT NULL,
	[Message] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatPrivateMessageMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatPrivateMessageMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](100) NULL,
	[EmailID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatUserDetail]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatUserDetail](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ConnectionId] [nvarchar](100) NULL,
	[UserName] [nvarchar](100) NULL,
	[EmailID] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChatUsers]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChatUsers](
	[UserName] [nvarchar](50) NOT NULL,
	[UserID] [nvarchar](max) NULL,
	[ConnectionID] [nvarchar](max) NULL,
 CONSTRAINT [PK_ChatUsers] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CityMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CityMaster](
	[city_id] [int] IDENTITY(1,1) NOT NULL,
	[count_id] [int] NULL,
	[state_id] [int] NULL,
	[city] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ConditionMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ConditionMaster](
	[cond_id] [int] IDENTITY(1,1) NOT NULL,
	[condition] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cylinder_Master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cylinder_Master](
	[cylinder_id] [int] IDENTITY(1,1) NOT NULL,
	[cylinder_name] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DrivetrainMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DrivetrainMaster](
	[driv_id] [int] IDENTITY(1,1) NOT NULL,
	[drive] [nchar](10) NULL,
	[status] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EngineMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngineMaster](
	[eng_id] [int] IDENTITY(1,1) NOT NULL,
	[engine] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EngineSizeMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EngineSizeMaster](
	[ensize_id] [int] IDENTITY(1,1) NOT NULL,
	[make_id] [int] NULL,
	[model_id] [int] NULL,
	[bad_id] [int] NULL,
	[ser_id] [int] NULL,
	[ensize_name] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventGoingMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventGoingMaster](
	[sno] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[email] [nvarchar](max) NULL,
	[eid] [int] NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EventWatchList]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EventWatchList](
	[watchlistid] [int] IDENTITY(1,1) NOT NULL,
	[eid] [int] NULL,
	[uid] [int] NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Fuel_Master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fuel_Master](
	[fuel_id] [int] IDENTITY(1,1) NOT NULL,
	[fuel_name] [nvarchar](50) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Interior_ColorMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interior_ColorMaster](
	[Inter_color_id] [int] IDENTITY(1,1) NOT NULL,
	[Inter_color_name] [nvarchar](250) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Interior_MaterialMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interior_MaterialMaster](
	[Inter_Mat_Id] [int] IDENTITY(1,1) NOT NULL,
	[Inter_Mat_Name] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ListedAs_Master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ListedAs_Master](
	[listed_id] [int] IDENTITY(1,1) NOT NULL,
	[listed_name] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MakeTypeMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MakeTypeMaster](
	[make_id] [int] IDENTITY(1,1) NOT NULL,
	[make_type] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ModelMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ModelMaster](
	[model_id] [int] IDENTITY(1,1) NOT NULL,
	[make_id] [int] NULL,
	[model] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NewRegionMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NewRegionMaster](
	[regionid] [int] IDENTITY(1,1) NOT NULL,
	[coun_id] [int] NULL,
	[state_id] [int] NULL,
	[city_id] [int] NULL,
	[reas_id] [int] NULL,
	[regionname] [nvarchar](max) NULL,
	[status] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OdoMeterMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OdoMeterMaster](
	[odo_id] [int] IDENTITY(1,1) NOT NULL,
	[odometer] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReasonMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReasonMaster](
	[reas_id] [int] IDENTITY(1,1) NOT NULL,
	[count_id] [int] NULL,
	[state_id] [int] NULL,
	[city_id] [int] NULL,
	[reason] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SeriesTypeMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SeriesTypeMaster](
	[ser_id] [int] IDENTITY(1,1) NOT NULL,
	[make_id] [int] NULL,
	[model_id] [int] NULL,
	[bad_id] [int] NULL,
	[series_type] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SpeedTypeMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SpeedTypeMaster](
	[speedtypeid] [int] IDENTITY(1,1) NOT NULL,
	[speedtypename] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_car_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_car_master](
	[cid] [float] NULL,
	[make_type] [nvarchar](255) NULL,
	[model_type] [nvarchar](255) NULL,
	[badge_type] [nvarchar](255) NULL,
	[series_type] [nvarchar](255) NULL,
	[year] [float] NULL,
	[odometer] [float] NULL,
	[metrics_type] [nvarchar](255) NULL,
	[tran_type] [nvarchar](255) NULL,
	[speed_type] [nvarchar](255) NULL,
	[body_type] [nvarchar](255) NULL,
	[esize_type] [float] NULL,
	[cylinder_type] [nvarchar](255) NULL,
	[drive_type] [nvarchar](255) NULL,
	[condition_type] [nvarchar](255) NULL,
	[brief_comm] [nvarchar](255) NULL,
	[description] [nvarchar](255) NULL,
	[fuel_type] [nvarchar](255) NULL,
	[extirior_color] [nvarchar](255) NULL,
	[paint_type] [nvarchar](255) NULL,
	[intirior_color] [nvarchar](255) NULL,
	[status] [float] NULL,
	[uid] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_car_master1]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_car_master1](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[make_type] [nvarchar](max) NULL,
	[model_type] [nvarchar](max) NULL,
	[badge_type] [nvarchar](max) NULL,
	[series_type] [nvarchar](max) NULL,
	[year] [int] NULL,
	[odometer] [int] NULL,
	[metrics_type] [nvarchar](max) NULL,
	[tran_type] [nvarchar](max) NULL,
	[speed_type] [nvarchar](max) NULL,
	[body_type] [nvarchar](max) NULL,
	[esize_type] [nvarchar](max) NULL,
	[cylinder_type] [nvarchar](max) NULL,
	[drive_type] [nvarchar](max) NULL,
	[condition_type] [nvarchar](50) NULL,
	[breif_comm] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[fuel_type] [nvarchar](max) NULL,
	[exterior_color] [nvarchar](max) NULL,
	[paint_type] [nvarchar](max) NULL,
	[intirior_color] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_carmaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_carmaster](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[make] [nvarchar](50) NULL,
	[price] [float] NULL,
	[descr] [nvarchar](max) NULL,
	[body_type] [nvarchar](max) NULL,
	[year] [nvarchar](50) NULL,
	[transmition] [nvarchar](max) NULL,
	[model] [nvarchar](50) NULL,
	[engine] [nvarchar](max) NULL,
	[status] [int] NULL,
	[img] [nvarchar](max) NULL,
	[img1] [nvarchar](max) NULL,
	[img2] [nvarchar](max) NULL,
	[badge] [int] NULL,
	[series] [int] NULL,
	[currency] [int] NULL,
	[list] [nvarchar](max) NULL,
	[condition] [int] NULL,
	[bcolor] [nvarchar](max) NULL,
	[icolor] [nvarchar](max) NULL,
	[material] [nvarchar](max) NULL,
	[drive] [int] NULL,
	[cylinder] [int] NULL,
	[meter] [nvarchar](max) NULL,
	[matrics] [int] NULL,
	[created_date] [datetime] NULL,
	[gstatus] [nvarchar](50) NULL,
	[fuel] [nvarchar](50) NULL,
	[speedtype] [nvarchar](50) NULL,
	[star] [int] NULL,
	[img3] [nvarchar](max) NULL,
	[img4] [nvarchar](max) NULL,
	[img5] [nvarchar](max) NULL,
	[listid] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_country_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_country_master](
	[count_id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_currency_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_currency_master](
	[cur_id] [int] IDENTITY(1,1) NOT NULL,
	[count_id] [int] NULL,
	[currency] [nvarchar](50) NULL,
	[status] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_event_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_event_master](
	[e_id] [int] IDENTITY(1,1) NOT NULL,
	[cust_id] [int] NULL,
	[cost_event] [nvarchar](50) NULL,
	[currency] [int] NULL,
	[price] [int] NULL,
	[title] [nvarchar](max) NULL,
	[category] [int] NULL,
	[time_form] [int] NULL,
	[time_to] [int] NULL,
	[location] [nvarchar](max) NULL,
	[comment] [nvarchar](max) NULL,
	[description] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_eventcat_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_eventcat_master](
	[ecat_id] [int] IDENTITY(1,1) NOT NULL,
	[category] [nvarchar](max) NULL,
	[status] [nchar](10) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_eventmaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_eventmaster](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NULL,
	[title] [nvarchar](max) NULL,
	[subject] [nvarchar](max) NULL,
	[edate] [datetime] NULL,
	[etime] [nvarchar](max) NULL,
	[address] [nvarchar](max) NULL,
	[cno] [nvarchar](50) NULL,
	[country] [int] NULL,
	[state] [int] NULL,
	[city] [int] NULL,
	[descr] [nvarchar](max) NULL,
	[status] [int] NULL,
	[img] [nvarchar](max) NULL,
	[img1] [nvarchar](max) NULL,
	[img2] [nvarchar](max) NULL,
	[late] [nvarchar](max) NULL,
	[long] [nvarchar](max) NULL,
	[reason] [int] NULL,
	[suburb] [nvarchar](max) NULL,
	[code] [nvarchar](50) NULL,
	[unit] [nvarchar](max) NULL,
	[street] [nvarchar](max) NULL,
	[sname] [nvarchar](max) NULL,
	[cat] [int] NULL,
	[created_date] [datetime] NULL,
	[price] [int] NULL,
	[ispaid] [int] NULL,
	[shownumber] [int] NULL,
	[listid] [nvarchar](50) NULL,
	[sponsorship] [nvarchar](50) NULL,
	[sponsorname] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_login]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[email] [nvarchar](50) NULL,
	[pass] [nvarchar](50) NULL,
	[type] [nvarchar](50) NULL,
	[status] [int] NULL,
	[gender] [nvarchar](50) NULL,
	[cno] [nvarchar](10) NULL,
	[country] [int] NULL,
	[state] [int] NULL,
	[city] [int] NULL,
	[other] [nvarchar](max) NULL,
	[other1] [nvarchar](max) NULL,
	[other2] [nvarchar](max) NULL,
	[fname] [nvarchar](max) NULL,
	[lname] [nvarchar](max) NULL,
	[regions] [int] NULL,
	[suburb] [nvarchar](max) NULL,
	[zip] [nvarchar](max) NULL,
	[street] [nvarchar](max) NULL,
	[streetname] [nvarchar](max) NULL,
	[late] [nvarchar](max) NULL,
	[long] [nvarchar](max) NULL,
	[reg_date] [datetime] NULL,
	[valid_date] [datetime] NULL,
	[plan_id] [int] NULL,
	[Cust_id] [nvarchar](max) NULL,
	[orgname] [nvarchar](max) NULL,
	[showphone] [int] NULL,
	[buslogo] [nvarchar](max) NULL,
	[parentstore] [nvarchar](50) NULL,
	[facebookId] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_plan_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_plan_master](
	[plan_id] [int] IDENTITY(1,1) NOT NULL,
	[plan_name] [nvarchar](max) NULL,
	[duration] [int] NULL,
	[amnt] [int] NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_state_master]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_state_master](
	[state_id] [int] IDENTITY(1,1) NOT NULL,
	[count_id] [int] NULL,
	[state_name] [nvarchar](max) NULL,
	[status] [int] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Tmp_ForgotUserPassword]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Tmp_ForgotUserPassword](
	[Userid] [int] NULL,
	[uniqueId] [nvarchar](50) NULL,
	[createDate] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TransmisionMaster]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransmisionMaster](
	[trans_id] [int] IDENTITY(1,1) NOT NULL,
	[transmision] [nvarchar](20) NULL,
	[speedtype] [nvarchar](20) NULL,
	[status] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserNotification]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserNotification](
	[NID] [int] IDENTITY(1,1) NOT NULL,
	[edate] [datetime] NULL,
	[fromuid] [int] NULL,
	[touid] [int] NULL,
	[msg] [nvarchar](max) NULL,
	[status] [nvarchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  UserDefinedFunction [dbo].[SplitInts]    Script Date: 2/15/2018 6:06:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[SplitInts]
(
   @List      VARCHAR(MAX),
   @Delimiter VARCHAR(255)
)
RETURNS TABLE
AS
  RETURN ( SELECT Item = CONVERT(INT, Item) FROM
      ( SELECT Item = x.i.value('(./text())[1]', 'varchar(max)')
        FROM ( SELECT [XML] = CONVERT(XML, '<i>'
        + REPLACE(@List, @Delimiter, '</i><i>') + '</i>').query('.')
          ) AS a CROSS APPLY [XML].nodes('i') AS x(i) ) AS y
      WHERE Item IS NOT NULL
  );


GO
INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'49a6d030-b7bd-4df2-a596-7f059546fad4', N'kamal@gmail.com', 0, N'ACm7/ion9wd1XlFniDQrTU5MNW/jFsE17c5Uos+q53c7LmewwEFoiAL9HVnCKKuFzg==', N'199b40d5-d858-417c-a095-e5abe2c6416a', NULL, 0, 0, NULL, 1, 0, N'kamal@gmail.com')
SET IDENTITY_INSERT [dbo].[BadgeTypeMaster] ON 

INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1, 2, 2, N'Impreza', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (2, 1, 1, N'E87', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1002, 1002, 1002, N'S 1.3', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1003, 1002, 1003, N'Sigma 1.2', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1004, 1002, 1003, N'Delta 1.2', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1005, 1002, 1004, N'LDi', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1006, 1002, 1004, N'VDi', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1007, 1002, 1002, N'Zeta 1.4 AT', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1008, 1, 1005, N'E30', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1009, 2, 1006, N'Z1', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1010, 1003, 1007, N'8X', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1011, 2, 1008, N'S', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1012, 1004, 1009, N'R33', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1013, 2, 1008, N'G3', 1)
INSERT [dbo].[BadgeTypeMaster] ([bad_id], [make_id], [model_id], [badge_type], [status]) VALUES (1014, 2, 1008, N'G4', 1)
SET IDENTITY_INSERT [dbo].[BadgeTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[Body_ColorMaster] ON 

INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (1, N'Dark Gray Metallic [Gray]', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (2, N'Crystal White Pearl [White]', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (3, N'Venetian Red Pearl [Red]', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (4, N'Alpine White', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (5, N'Jet Black', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (6, N'Mineral White', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (7, N'Black Sapphire', N'1')
INSERT [dbo].[Body_ColorMaster] ([body_color_id], [body_color_name], [status]) VALUES (8, N'Blue', N'1')
SET IDENTITY_INSERT [dbo].[Body_ColorMaster] OFF
SET IDENTITY_INSERT [dbo].[Body_TypeMaster] ON 

INSERT [dbo].[Body_TypeMaster] ([Body_type_id], [Body_Type], [status]) VALUES (1, N'Coupe', N'1')
INSERT [dbo].[Body_TypeMaster] ([Body_type_id], [Body_Type], [status]) VALUES (2, N'Sedan', N'1')
INSERT [dbo].[Body_TypeMaster] ([Body_type_id], [Body_Type], [status]) VALUES (3, N'Compact and Touring', N'1')
SET IDENTITY_INSERT [dbo].[Body_TypeMaster] OFF
SET IDENTITY_INSERT [dbo].[CarWatchList] ON 

INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (1, 1, 2, N'0')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (2, 1, 1005, N'1')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (3, 3, 2, N'1')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (4, 6, 1013, N'1')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (5, 8, 1013, N'0')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (7, 26, 2033, N'1')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (8, 11, 1014, N'0')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (9, 29, 1014, N'0')
INSERT [dbo].[CarWatchList] ([WatchListID], [cid], [uid], [status]) VALUES (6, 7, 1013, N'0')
SET IDENTITY_INSERT [dbo].[CarWatchList] OFF
SET IDENTITY_INSERT [dbo].[CityMaster] ON 

INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1, 6, 5, N'LA', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (2, 6, 5, N'San Francisco', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (3, 4, 8, N'Pune', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (4, 4, 7, N'Indore', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (5, 4, 9, N'Delhi', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (6, 2, 10, N'Aberdeen', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (7, 2, 13, N'Bradford', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (8, 2, 12, N'Bath', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (9, 2, 11, N'Bangor', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (10, 1, 18, N'Perth', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (11, 1, 17, N'Hobart', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (12, 1, 16, N'Sunshine Coast', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (13, 1, 15, N'Geelong', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1003, 1005, 1002, N'Manama 1', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1004, 4, 7, N'Dewas', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1005, 4, 7, N'Bhopal', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1006, 4, 7, N'Ujjain', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1007, 4, 7, N'Betul', 1)
INSERT [dbo].[CityMaster] ([city_id], [count_id], [state_id], [city], [status]) VALUES (1008, 1008, 1003, N'Brisbane', 1)
SET IDENTITY_INSERT [dbo].[CityMaster] OFF
SET IDENTITY_INSERT [dbo].[ConditionMaster] ON 

INSERT [dbo].[ConditionMaster] ([cond_id], [condition], [status]) VALUES (1, N'Good', 1)
INSERT [dbo].[ConditionMaster] ([cond_id], [condition], [status]) VALUES (2, N'Very Good', 1)
INSERT [dbo].[ConditionMaster] ([cond_id], [condition], [status]) VALUES (3, N'Top Class', 1)
INSERT [dbo].[ConditionMaster] ([cond_id], [condition], [status]) VALUES (4, N'OKAY', 1)
INSERT [dbo].[ConditionMaster] ([cond_id], [condition], [status]) VALUES (5, N'Used', 1)
SET IDENTITY_INSERT [dbo].[ConditionMaster] OFF
SET IDENTITY_INSERT [dbo].[Cylinder_Master] ON 

INSERT [dbo].[Cylinder_Master] ([cylinder_id], [cylinder_name], [status]) VALUES (4, N'4 Cylinder liquid-cooled', N'1')
INSERT [dbo].[Cylinder_Master] ([cylinder_id], [cylinder_name], [status]) VALUES (5, N'2.9 L 5-cylinder', N'1')
INSERT [dbo].[Cylinder_Master] ([cylinder_id], [cylinder_name], [status]) VALUES (6, N'4cyl', N'1')
SET IDENTITY_INSERT [dbo].[Cylinder_Master] OFF
SET IDENTITY_INSERT [dbo].[DrivetrainMaster] ON 

INSERT [dbo].[DrivetrainMaster] ([driv_id], [drive], [status]) VALUES (1, N'FWD       ', 1)
INSERT [dbo].[DrivetrainMaster] ([driv_id], [drive], [status]) VALUES (2, N'AWD       ', 1)
SET IDENTITY_INSERT [dbo].[DrivetrainMaster] OFF
SET IDENTITY_INSERT [dbo].[EngineSizeMaster] ON 

INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1, 2, 2, 1, 2, N'20 ltr', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (2, 1, 1, 2, 1, N'30 ltr', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1002, 1002, 1002, 1002, 1002, N'1373cc', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1003, 1002, 1002, 1007, 1003, N'1373cc', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1004, 1002, 1003, 1003, 1004, N'1197cc', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1005, 1002, 1003, 1004, 1005, N'1197cc', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1006, 1002, 1004, 1005, 1006, N'1248cc', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1007, 1002, 1004, 1006, 1007, N'1248cc ', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1008, 1003, 1007, 1010, 1010, N'4cyl', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1009, 2, 1008, 1011, 1011, N'2.0', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1010, 2, 1008, 1011, 1011, N'2.5', 1)
INSERT [dbo].[EngineSizeMaster] ([ensize_id], [make_id], [model_id], [bad_id], [ser_id], [ensize_name], [status]) VALUES (1011, 2, 1008, 1014, 1019, N'2.0', 1)
SET IDENTITY_INSERT [dbo].[EngineSizeMaster] OFF
SET IDENTITY_INSERT [dbo].[EventGoingMaster] ON 

INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (1, 1013, N'madelslim@gmail.com', 3, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (2, 1013, N'madelslim@gmail.com', 36, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (3, 1013, N'madelslim@gmail.com', 38, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (4, 2, N'adamwilsonmw@gmail.com', 3, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (5, 1008, N'laurabrownmw@gmail.com', 41, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (6, 1014, N'madelslim@hotmail.com', 1049, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (7, 1014, N'madelslim@hotmail.com', 3, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (26, 1014, N'madelslim@hotmail.com', 36, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (11, 2037, N'saumitra@mobiwebtech.com', 1048, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (27, 1014, N'madelslim@hotmail.com', 38, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (25, 2, N'adamwilsonmw@gmail.com', 1042, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (61, 2034, N'admin@mobiwebtech.com', 1047, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (83, 2034, N'admin@mobiwebtech.com', 36, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (88, 2034, N'admin@mobiwebtech.com', 1061, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (90, 2034, N'admin@mobiwebtech.com', 1060, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (91, 2034, N'admin@mobiwebtech.com', 1050, 1)
INSERT [dbo].[EventGoingMaster] ([sno], [uid], [email], [eid], [status]) VALUES (92, 2033, N'shailendra@mobiwebtech.com', 1060, 1)
SET IDENTITY_INSERT [dbo].[EventGoingMaster] OFF
SET IDENTITY_INSERT [dbo].[EventWatchList] ON 

INSERT [dbo].[EventWatchList] ([watchlistid], [eid], [uid], [status]) VALUES (1, 1, 2, N'0')
INSERT [dbo].[EventWatchList] ([watchlistid], [eid], [uid], [status]) VALUES (2, 3, 2, N'0')
INSERT [dbo].[EventWatchList] ([watchlistid], [eid], [uid], [status]) VALUES (3, 38, 1013, N'1')
INSERT [dbo].[EventWatchList] ([watchlistid], [eid], [uid], [status]) VALUES (4, 41, 1008, N'0')
INSERT [dbo].[EventWatchList] ([watchlistid], [eid], [uid], [status]) VALUES (5, 36, 2, N'1')
INSERT [dbo].[EventWatchList] ([watchlistid], [eid], [uid], [status]) VALUES (6, 1047, 2036, N'1')
SET IDENTITY_INSERT [dbo].[EventWatchList] OFF
SET IDENTITY_INSERT [dbo].[Fuel_Master] ON 

INSERT [dbo].[Fuel_Master] ([fuel_id], [fuel_name], [status]) VALUES (1, N'Gas', N'1')
INSERT [dbo].[Fuel_Master] ([fuel_id], [fuel_name], [status]) VALUES (2, N'Premium fuel', N'1')
INSERT [dbo].[Fuel_Master] ([fuel_id], [fuel_name], [status]) VALUES (3, N'Lower-octane fuel', N'1')
INSERT [dbo].[Fuel_Master] ([fuel_id], [fuel_name], [status]) VALUES (4, N'Premium unleaded gasoline (93 octane)', N'1')
SET IDENTITY_INSERT [dbo].[Fuel_Master] OFF
SET IDENTITY_INSERT [dbo].[Interior_ColorMaster] ON 

INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (1, N'Black w/Extended Merino Leather Upholstery [Black]', N'1')
INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (5, N'Sakhir Orange Metallic [Orange]', N'1')
INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (6, N'Yas Marina Blue Metallic [Blue]', N'1')
INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (7, N'Crystal White. Pearl', N'1')
INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (8, N'Ice Silver. Metallic', N'1')
INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (1002, N'Black w/Extended Merino Leather Upholstery [Black]	Black w/Extended Merino Leather Upholstery [Black]	Black w/Extended Merino Leather Upholstery [Black]	Black w/Extended Merino Leather Upholstery [Black]	Black w/Extended Merino Leather Upholstery BS', N'1')
INSERT [dbo].[Interior_ColorMaster] ([Inter_color_id], [Inter_color_name], [status]) VALUES (1003, N'Grey / Blue', N'1')
SET IDENTITY_INSERT [dbo].[Interior_ColorMaster] OFF
SET IDENTITY_INSERT [dbo].[Interior_MaterialMaster] ON 

INSERT [dbo].[Interior_MaterialMaster] ([Inter_Mat_Id], [Inter_Mat_Name], [status]) VALUES (1, N'GERMAN VINYL', N'1')
INSERT [dbo].[Interior_MaterialMaster] ([Inter_Mat_Id], [Inter_Mat_Name], [status]) VALUES (2, N'LEATHER', N'1')
INSERT [dbo].[Interior_MaterialMaster] ([Inter_Mat_Id], [Inter_Mat_Name], [status]) VALUES (3, N'BRITISH VINYL', N'1')
INSERT [dbo].[Interior_MaterialMaster] ([Inter_Mat_Id], [Inter_Mat_Name], [status]) VALUES (4, N'Leather', N'1')
SET IDENTITY_INSERT [dbo].[Interior_MaterialMaster] OFF
SET IDENTITY_INSERT [dbo].[ListedAs_Master] ON 

INSERT [dbo].[ListedAs_Master] ([listed_id], [listed_name], [status]) VALUES (1, N'Garazed', N'1')
INSERT [dbo].[ListedAs_Master] ([listed_id], [listed_name], [status]) VALUES (2, N'For Sale', N'1')
SET IDENTITY_INSERT [dbo].[ListedAs_Master] OFF
SET IDENTITY_INSERT [dbo].[MakeTypeMaster] ON 

INSERT [dbo].[MakeTypeMaster] ([make_id], [make_type], [status]) VALUES (1, N'BMW', 1)
INSERT [dbo].[MakeTypeMaster] ([make_id], [make_type], [status]) VALUES (2, N'Subaru', 1)
INSERT [dbo].[MakeTypeMaster] ([make_id], [make_type], [status]) VALUES (1002, N'Maruti', 1)
INSERT [dbo].[MakeTypeMaster] ([make_id], [make_type], [status]) VALUES (1003, N'Audi', 1)
INSERT [dbo].[MakeTypeMaster] ([make_id], [make_type], [status]) VALUES (1004, N'Nissan', 1)
SET IDENTITY_INSERT [dbo].[MakeTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[ModelMaster] ON 

INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1, 1, N'120i', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (2, 2, N'Brumby', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1002, 1002, N'Ciaz', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1003, 1002, N'Baleno', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1004, 1002, N'Brezza', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1005, 1, N'320i', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1006, 2, N'BRZ', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1007, 1003, N'A1', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1008, 2, N'Impreza', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1009, 1004, N'Skyline', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1010, 1004, N'Silvia', 1)
INSERT [dbo].[ModelMaster] ([model_id], [make_id], [model], [status]) VALUES (1011, 1005, N'DB7', 1)
SET IDENTITY_INSERT [dbo].[ModelMaster] OFF
SET IDENTITY_INSERT [dbo].[OdoMeterMaster] ON 

INSERT [dbo].[OdoMeterMaster] ([odo_id], [odometer], [status]) VALUES (1, N'BHP', 1)
INSERT [dbo].[OdoMeterMaster] ([odo_id], [odometer], [status]) VALUES (2, N'Fuel Injected', 1)
SET IDENTITY_INSERT [dbo].[OdoMeterMaster] OFF
SET IDENTITY_INSERT [dbo].[ReasonMaster] ON 

INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1, 6, 5, 1, N'Santa Monica', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (2, 6, 5, 1, N'Venice Beach.', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1006, 1005, 1002, 1003, N'Arad', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (4, 4, 8, 3, N'Shaniwar wada', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (5, 4, 7, 4, N'New Palasia', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1007, 4, 7, 1004, N'Lal Gate', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1003, 4, 9, 5, N'Delhi6', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1004, 4, 9, 5, N'Delhi6', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1008, 4, 7, 1005, N'HabibiGanj', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1009, 4, 7, 1007, N'Balaji Puram', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1010, 4, 7, 1006, N'Nanakheda', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (6, 2, 13, 7, N'Barkerend', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (7, 2, 12, 8, N'St Catherines Valley', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (8, 2, 11, 9, N'Hampden', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (9, 1, 18, 10, N'Highgate', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (10, 1, 17, 11, N'Battery Point.', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (11, 1, 17, 11, N'Dynnyrne', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (12, 1, 16, 12, N'Alexandra Headland.', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (13, 1, 16, 12, N'Caloundra', 1)
INSERT [dbo].[ReasonMaster] ([reas_id], [count_id], [state_id], [city_id], [reason], [status]) VALUES (1011, 1008, 1003, 1008, N'Sunnybank', 1)
SET IDENTITY_INSERT [dbo].[ReasonMaster] OFF
SET IDENTITY_INSERT [dbo].[SeriesTypeMaster] ON 

INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1, 1, 1, 2, N'Sport Line', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (2, 2, 2, 1, N'Special', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1002, 1002, 1002, 1002, N'CS', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1003, 1002, 1002, 1007, N'Zet', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1004, 1002, 1003, 1003, N'Sig', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1005, 1002, 1003, 1004, N'Del', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1006, 1002, 1004, 1005, N'LD', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1007, 1002, 1004, 1006, N'VD', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1008, 1, 1005, 1008, N'E30 Sport', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1009, 2, 1006, 1009, N'Sports Pack', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1010, 1003, 1007, 1010, N'Ambition', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1011, 2, 1008, 1011, N'WRX STI', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1012, 1004, 1009, 1012, N'GTS-t', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1013, 2, 1008, 1011, N'GX', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1014, 2, 1008, 1011, N'R', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1015, 2, 1008, 1011, N'RS', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1016, 2, 1008, 1011, N'GX', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1017, 2, 1008, 1013, N'GX', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1018, 2, 1008, 1014, N'GX', 1)
INSERT [dbo].[SeriesTypeMaster] ([ser_id], [make_id], [model_id], [bad_id], [series_type], [status]) VALUES (1019, 2, 1008, 1014, N'STI', 1)
SET IDENTITY_INSERT [dbo].[SeriesTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[SpeedTypeMaster] ON 

INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (1, N'3AT Gear Ratios', N'1')
INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (2, N'3EAT', N'1')
INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (3, N'ACT-4 or VTD', N'1')
INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (4, N'Six-speed', N'1')
INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (5, N'Six-Speed manual', N'1')
INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (6, N'Eight-Speed Automatic', N'1')
INSERT [dbo].[SpeedTypeMaster] ([speedtypeid], [speedtypename], [status]) VALUES (7, N'6sp', N'1')
SET IDENTITY_INSERT [dbo].[SpeedTypeMaster] OFF
SET IDENTITY_INSERT [dbo].[tbl_carmaster] ON 

INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (1, 2, N'1', 3250, N'The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW''s in-house motorsport division, BMW M. M3 models have been derived from the E30, E36, E46, E90/E92/E93, and F30 3-series.

The initial model was a coupe body style. At times the M3 has also been available in saloon and convertible body styles. Due to the 4 Series coupe and convertible models no longer being part of the 3 Series range from 2015, [1][2] the F82/F83 coupe and convertible models are now called the M4. The M3 name remains in use solely for the saloon version.

Upgrades over the "standard" 3 Series automobiles include more powerful and responsive engines, improved handling/suspension/braking systems, aerodynamic body enhancements, lightweight components, and interior/exterior accents with the tri-colour "M" (Motorsport) emblem.', N'1', N'2010', N'2', N'1', N'2', 1, N'1_0_car2252017235016.png', N'1_1_car2252017235016.png', N'1_2_car1852017081214.png', 2, 1, 2, N'0', 2, N'1', N'7', N'1', 1, 5, N'220', 1, CAST(N'2017-05-23 14:03:31.990' AS DateTime), N'1', N'1', N'6', 0, N'1_3_car1852017081214.png', N'1_4_car1852017081214.png', N'1_5_car1852017081214.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (2, 2, N'1', 520, N'Etiam ultricies nisi vel augue. Curabitur ullamcorper ultricies nisi. Nam eget dui. Etiam rhoncus. Maecenas tempus, tellus eget condimentum rhoncus, sem quam semper libero, sit amet adipiscing sem neque sed ipsum. Nam quam nunc, blandit vel, luctus pulvinar, hendrerit id, lorem. Maecenas nec odio et ante tincidunt tempus. Donec vitae sapien ut libero venenatis faucibus. Nullam quis ante. Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc.

Etiam sit amet orci eget eros faucibus tincidunt. Duis leo. Sed fringilla mauris sit amet nibh. Donec sodales sagittis magna. Sed consequat, leo eget bibendum sodales, augue velit cursus nunc.', N'1', N'1966', N'2', N'1', N'2', 1, N'2_0_car2052017025956.png', N'2_1_car2052017025956.png', N'2_2_car2052017025956.png', 2, 1, 2, N'0', 4, N'1', N'6', N'1', 1, 4, N'138', 1, CAST(N'2017-05-23 14:04:16.910' AS DateTime), N'1', N'1', N'3', 0, N'2_3_car2052017025956.png', N'2_4_car2052017025956.png', N'2_5_car2052017025956.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (5, 1006, N'2', 5100000, N'Google Car', N'1', N'2016', N'1', N'2', N'1', 1, N'5_0_car2352017023432.png', N'5_1_car2352017023432.png', N'5_2_car2352017023432.png', 1, 2, 1, N'0', 3, N'1', N'8', N'1', 1, 5, N'2', 1, CAST(N'2017-09-18 12:12:02.113' AS DateTime), N'1', N'2', N'6', 0, N'5_3_car2352017023432.png', N'5_4_car2352017023432.png', N'5_5_car2352017023432.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (10, 2, N'1', 5640, N'Testing ', N'1', N'1950', N'2', N'1', N'2', 0, N'10_0_car792017070601.png', N'10_1_car792017070601.png', N'10_2_car792017070601.png', 2, 1, 1, N'0', 2, N'3', N'5', N'2', 1, 4, N'45', 1, CAST(N'2017-10-09 07:53:02.173' AS DateTime), N'1', N'2', N'5', 0, N'10_3_car792017070601.png', N'10_4_car792017070601.png', N'10_5_car792017070601.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (11, 1014, N'2', 89898, N'This is my car

Need to test', N'1', N'1965', N'1', N'2', N'1', 1, N'11_0_car1192017011020.png', N'11_1_car1192017011020.png', N'11_2_car1192017011020.png', 1, 2, 1002, N'0', 1, N'1', N'5', N'2', 1, 4, N'87712', 1, CAST(N'2017-10-04 06:26:51.813' AS DateTime), N'1', N'2', N'6', 0, N'11_3_car1192017011020.png', N'11_4_car1192017011020.png', N'11_5_car3102017224013.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (12, 2015, N'1', 500000, N'Spire User Add Car for sale 1', N'1', N'2010', N'1', N'1', N'2', 1, N'12_0_car1492017024859.png', N'12_1_car1492017024859.png', N'12_2_car1492017024859.png', 2, 1, 2, N'0', 1, N'1', N'1', N'1', 1, 4, N'7', 1, CAST(N'2017-08-16 10:08:49.977' AS DateTime), N'1', N'1', N'6', 0, N'12_3_car1492017024859.png', N'12_4_car1492017024859.png', N'12_5_car1492017024859.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (3, 2, N'1', 720, N'The European languages are members of the same family. Their separate existence is a myth. For science, music, sport, etc, Europe uses the same vocabulary. The languages only differ in their grammar, their pronunciation and their most common words. Everyone realizes why a new common language would be desirable: one could refuse to pay expensive translators. To achieve this, it would be necessary to have uniform grammar, pronunciation and more common words. If several languages coalesce, the grammar of the resulting language is more simple and regular than that of the individual languages. The new common language will be more simple and regular than the existing European languages. It will be as simple as Occidental; in fact, it will be Occidental. To an English person, it will seem like simplified English, as a skeptical Cambridge friend of mine told me what Occidental is.The European languages are members of the same family. Their separate existence is a myth. For science, music, sport, etc, Europe uses the same vocabulary. The languages only differ in their grammar, their pronunciation and their most common words. Everyone realizes why a new common language would be desirable: one could refuse to pay expensive translators.', N'3', N'1964', N'1', N'1', N'2', 1, N'3_0_car2052017031630.png', N'3_1_car2052017031630.png', N'3_2_car2052017031630.png', 2, 1, 1, N'0', 2, N'5', N'7', N'2', 1, 5, N'138', 1, CAST(N'2017-09-18 12:13:00.623' AS DateTime), N'1', N'3', N'4', 0, N'3_3_car2052017031630.png', N'3_4_car2052017031630.png', N'3_5_car2052017031630.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (13, 2015, N'2', 75000, N'Spire User Ad car sale 2', N'2', N'2011', N'2', N'2', N'1', 0, N'13_0_car1492017025210.png', N'13_1_car1492017025210.png', N'13_2_car1492017025210.png', 1, 2, 2, N'0', 2, N'2', N'5', N'2', 1, 5, N'10', 1, CAST(N'2017-09-14 09:52:06.257' AS DateTime), N'1', N'2', N'5', 0, N'13_3_car1492017025210.png', N'13_4_car1492017025210.png', N'13_5_car1492017025210.png', NULL)
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (14, 2015, N'1', 100000, N'Spire user ad car sale 3', N'3', N'2012', N'2', N'1', N'2', 1, N'14_0_car1492017025514.png', N'14_1_car1492017025514.png', N'14_2_car1492017025514.png', 2, 1, 2, N'0', 3, N'3', N'6', N'3', 1, 4, N'8', 1, CAST(N'2017-05-15 10:08:49.977' AS DateTime), N'1', N'3', N'4', 0, N'14_3_car1492017025514.png', N'14_4_car1492017025514.png', N'14_5_car1492017025514.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (15, 2015, N'2', 1000000, N'Spire user ad car sale 4', N'3', N'2014', N'1', N'2', N'1', 0, N'15_0_car1492017025750.png', N'15_1_car1492017025750.png', N'15_2_car1492017025750.png', 1, 2, 2, N'0', 4, N'4', N'7', N'1', 1, 5, N'3', 1, CAST(N'2017-09-14 09:57:45.187' AS DateTime), N'1', N'3', N'3', 0, N'15_3_car1492017025750.png', N'15_4_car1492017025750.png', N'15_5_car1492017025750.png', NULL)
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (16, 2015, N'1', 70000, N'testsetsetsetsett', N'1', N'2015', N'2', N'1', N'2', 0, N'16_0_car1592017145900.png', N'16_1_car1592017145900.png', N'16_2_car1592017145900.png', 2, 1, 2, N'0', 1, N'7', N'8', N'2', 1, 5, N'4', 1, CAST(N'2017-09-15 09:28:45.433' AS DateTime), N'1', N'2', N'5', 0, N'16_3_car1592017145900.png', N'16_4_car1592017145900.png', N'16_5_car1592017145900.png', NULL)
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (9, 1008, N'1', 3600, N'The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphs grab quick-jived waltz. Brick quiz whangs jumpy veldt fox. Bright vixens jump; dozy fowl quack. Quick wafting zephyrs vex bold Jim. Quick zephyrs blow, vexing daft Jim. Sex-charged fop blew my junk TV quiz. How quickly daft jumping zebras vex. Two driven jocks help fax my big quiz. Quick, Baz, get my woven flax jodhpurs! "Now fax quiz Jack!" my brave ghost pled. Five quacking zephyrs jolt my wax bed. Flummoxed by job, kvetching W. zaps Iraq. Cozy sphinx waves quart jug of bad milk.
A very bad quack might jinx zippy fowls. Few quips galvanized the mock jury box. Quick brown dogs jump over the lazy fox. The jay, pig, fox, zebra, and my wolves quack! Blowzy red vixens fight for a quick jump. Joaquin Phoenix was gazed by MTV for luck. A wizard’s job is to vex chumps quickly in fog. Watch "Jeopardy!", Alex Trebek''s fun TV quiz game. Woven silk pyjamas exchanged for blue quartz. Brawny gods just', N'1', N'1950', N'1', N'1', N'2', 1, N'9_0_car1372017045843.png', N'9_1_car1372017045843.png', N'9_2_car1372017045843.png', 2, 1, 2, N'0', 1, N'1', N'1', N'1', 1, 4, N'138', 1, CAST(N'2017-07-13 11:59:55.717' AS DateTime), N'1', N'2', N'6', 0, N'9_3_car1372017045843.png', N'9_4_car1372017045843.png', N'9_5_car1372017045843.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (17, 1011, N'1', 6666666, N'tetwetertertert', N'2', N'2017', N'3', N'1', N'2', 0, N'17_0_car1592017162027.png', N'17_1_car1592017162027.png', N'17_2_car1592017162027.png', 2, 1, 1, N'0', 2, N'4', N'7', N'3', 1, 5, N'2', 1, CAST(N'2017-09-15 10:50:24.703' AS DateTime), N'1', N'2', N'2', 0, N'17_3_car1592017162027.png', N'17_4_car1592017162027.png', N'17_5_car1592017162027.png', NULL)
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (18, 2016, N'1', 5000000, N'Tetetwetwetwet', N'1', N'2017', N'1', N'1', N'2', 1, N'18_0_car1592017162225.png', N'18_1_car1592017162225.png', N'18_2_car1592017162225.png', 2, 1, 1, N'0', 2, N'2', N'6', N'2', 1, 4, N'4', 1, CAST(N'2017-11-07 14:45:37.203' AS DateTime), N'1', N'1', N'4', 0, N'18_3_car1592017162225.png', N'18_4_car1592017162225.png', N'18_5_car1592017162225.png', NULL)
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (21, 2036, N'1002', 350000, N'Ciaz Car', N'1', N'2016', N'1', N'1002', N'1002', 1, N'21_0_car1892017010831.png', N'21_1_car1892017010831.png', N'21_2_car1892017010831.png', 1002, 1002, 2, N'0', 1, N'1', N'6', N'1', 1, 5, N'2', 1, CAST(N'2017-09-18 09:03:20.433' AS DateTime), N'1', N'2', N'6', 0, N'21_3_car1892017010831.png', N'21_4_car1892017010831.png', N'21_5_car1892017010831.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (24, 2034, N'1002', 300000, N'Baleno Delta 1.2', N'1', N'2017', N'1', N'1003', N'1005', 0, N'24_0_car1892017073549.png', N'24_1_car1892017073549.png', N'24_2_car1892017073549.png', 1004, 1005, 2, N'0', 2, N'1', N'7', N'2', 1, 4, N'2', 1, CAST(N'2018-01-19 10:46:04.433' AS DateTime), N'0', N'2', N'5', 0, N'24_3_car1892017073549.png', N'24_4_car1892017073549.png', N'24_5_car1892017073549.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (25, 2032, N'1002', 400000, N'Ciaz Zeta 1.4 AT', N'3', N'2016', N'1', N'1002', N'1003', 1, N'25_0_car1892017080029.png', N'25_1_car1892017080029.png', N'25_2_car1892017080029.png', 1007, 1003, 1, N'0', 3, N'5', N'6', N'2', 1, 4, N'2', 1, CAST(N'2017-09-18 15:02:37.280' AS DateTime), N'1', N'4', N'4', 0, N'25_3_car1892017080029.png', N'25_4_car1892017080029.png', N'25_5_car1892017080029.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (26, 2033, N'1002', 300000, N'Brezza', N'3', N'2016', N'2', N'1004', N'1007', 1, N'26_0_car2092017050532.png', N'26_1_car2092017050532.png', N'26_2_car2092017050532.png', 1006, 1007, 2, N'0', 2, N'5', N'5', N'2', 1, 4, N'2', 1, CAST(N'2017-10-09 13:56:39.950' AS DateTime), N'1', N'2', N'4', 0, N'26_3_car2092017050532.png', N'26_4_car2092017050532.png', N'26_5_car2092017050532.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (27, 2037, N'1003', 500000, N'Audi Embition', N'1', N'2010', N'1', N'1007', N'1008', 1, N'27_0_car2892017070555.png', N'27_1_car2892017070555.png', N'27_2_car2892017070555.png', 1010, 1010, 2, N'0', 1, N'3', N'1', N'1', 1, 4, N'2', 1, CAST(N'2017-10-09 13:57:31.210' AS DateTime), N'1', N'1', N'6', 0, N'27_3_car2892017070555.png', N'27_4_car2892017070555.png', N'27_5_car2892017070555.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (28, 1014, N'1', 123, N'21321321312


12312321312


123123123', N'1', N'1966', N'1', N'1', N'2', 1, N'28_0_car3102017232447.png', N'28_1_car3102017232447.png', N'28_2_car3102017232447.png', 2, 1, 1002, N'0', 1, N'5', N'8', N'2', 1, 5, N'123123', 1, CAST(N'2017-10-04 06:26:35.423' AS DateTime), N'1', N'1', N'2', 0, N'28_3_car3102017232447.png', N'28_4_car3102017232447.png', N'28_5_car3102017232447.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (33, 2034, N'2', 5600, N'Good Condition', N'1', N'2012', N'2', N'1006', N'', 0, N'33_0_car12122017022356.png', N'33_1_car12122017022356.png', N'33_2_car12122017022356.png', 1009, 1009, 2, N'0', 2, N'3', N'1', N'2', 1, 5, N'20', 1, CAST(N'2018-01-19 07:37:47.337' AS DateTime), N'0', N'1', N'5', 0, N'33_3_car12122017022356.png', N'33_4_car12122017022356.png', N'33_5_car12122017022356.png', NULL)
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (29, 1014, N'2', 123, N'This is a test lets check this out

Enter

', N'1', N'2005', N'2', N'1008', N'1009', 1, N'29_0_car5102017172225.png', N'29_1_car5102017172225.png', N'29_2_car5102017172225.png', 1011, 1011, 1002, N'0', 1, N'5', N'8', N'2', 1, 5, N'67000', 1, CAST(N'2017-10-06 00:25:12.470' AS DateTime), N'1', N'2', N'4', 0, N'29_3_car5102017172225.png', N'29_4_car5102017172225.png', N'29_5_car5102017172225.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (30, 2034, N'1002', 50000, N'Test', N'2', N'2017', N'2', N'1002', N'1002', 0, N'30_0_car7112017191015.png', N'30_1_car7112017191015.png', N'30_2_car7112017191015.png', 1002, 1002, 2, N'0', 2, N'3', N'6', N'2', 1, 5, N'2', 1, CAST(N'2017-12-08 08:09:52.393' AS DateTime), N'1', N'2', N'5', 0, N'30_3_car7112017191015.png', N'30_4_car7112017191015.png', N'30_5_car7112017191015.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (22, 2033, N'1002', 250000, N'Baleno', N'2', N'2016', N'1', N'1003', N'1004', 1, N'22_0_car1892017020014.png', N'22_1_car1892017020014.png', N'22_2_car1892017020014.png', 1003, 1004, 2, N'0', 2, N'3', N'7', N'2', 1, 5, N'2', 1, CAST(N'2017-11-07 06:35:29.160' AS DateTime), N'1', N'2', N'5', 0, N'22_3_car1892017020014.png', N'22_4_car1892017020014.png', N'22_5_car1892017020014.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (23, 2035, N'1002', 300000, N'Brezza', N'2', N'2016', N'1', N'1004', N'1006', 1, N'23_0_car1892017043906.png', N'23_1_car1892017043906.png', N'23_2_car1892017043906.png', 1005, 1006, 2, N'0', 3, N'2', N'7', N'3', 1, 5, N'2', 1, CAST(N'2017-11-07 06:35:20.537' AS DateTime), N'1', N'4', N'6', 0, N'23_3_car1892017043906.png', N'23_4_car1892017043906.png', N'23_5_car1892017043906.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (31, 1013, N'2', 15000, N'This is my daily drive and my pride and joy. Up for sale for genuine buyers. Please contact Joe weekdays 8 to 6pm and weekends anytime

Car comes with RW and warranty

Prices to sell
', N'1', N'2005', N'2', N'1008', N'1011', 1, N'31_0_car8122017024816.png', N'31_1_car8122017024816.png', N'31_2_car8122017024816.png', 1014, 1019, 1003, N'0', 5, N'8', N'1003', N'4', 2, 6, N'130000', 2, CAST(N'2017-12-08 09:49:47.807' AS DateTime), N'1', N'1', N'7', 0, N'31_3_car8122017024816.png', N'31_4_car8122017024816.png', N'31_5_car8122017024816.png', N'')
INSERT [dbo].[tbl_carmaster] ([cid], [uid], [make], [price], [descr], [body_type], [year], [transmition], [model], [engine], [status], [img], [img1], [img2], [badge], [series], [currency], [list], [condition], [bcolor], [icolor], [material], [drive], [cylinder], [meter], [matrics], [created_date], [gstatus], [fuel], [speedtype], [star], [img3], [img4], [img5], [listid]) VALUES (32, 2034, N'1', 25000, N'Good Condition', N'1', N'2010', N'1', N'1', N'2', 0, N'32_0_car12122017143255.png', N'32_1_car12122017143255.png', N'32_2_car12122017143255.png', 2, 1, 2, N'0', 1, N'3', N'1', N'1', 1, 4, N'20', 1, CAST(N'2017-12-12 09:02:49.467' AS DateTime), N'1', N'2', N'6', 0, N'32_3_car12122017143255.png', N'32_4_car12122017143255.png', N'32_5_car12122017143255.png', NULL)
SET IDENTITY_INSERT [dbo].[tbl_carmaster] OFF
SET IDENTITY_INSERT [dbo].[tbl_country_master] ON 

INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1002, N'China', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1003, N'Russia', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (3, N'United Kingdom', 0)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (4, N'India', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (5, N'UAE', 0)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (6, N'United States Of America', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1004, N'Japan', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1005, N'Bahrain', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1006, N'Brazil', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1007, N'Ukraine', 1)
INSERT [dbo].[tbl_country_master] ([count_id], [country_name], [status]) VALUES (1008, N'Australia', 1)
SET IDENTITY_INSERT [dbo].[tbl_country_master] OFF
SET IDENTITY_INSERT [dbo].[tbl_currency_master] ON 

INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1, 6, N'USD', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (2, 4, N'INR', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (3, 2, N'GBP', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (4, 1, N'AUD', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1002, 1005, N'BHD', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1003, 1008, N'AUD', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1004, 1006, N'BRL', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1005, 1002, N'CNY', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1006, 1004, N'JPY', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1007, 1003, N'RUB', 1)
INSERT [dbo].[tbl_currency_master] ([cur_id], [count_id], [currency], [status]) VALUES (1008, 1007, N'UAH', 1)
SET IDENTITY_INSERT [dbo].[tbl_currency_master] OFF
SET IDENTITY_INSERT [dbo].[tbl_eventcat_master] ON 

INSERT [dbo].[tbl_eventcat_master] ([ecat_id], [category], [status]) VALUES (1, N'Classic Cars', N'1         ')
INSERT [dbo].[tbl_eventcat_master] ([ecat_id], [category], [status]) VALUES (2, N'Car show', N'1         ')
SET IDENTITY_INSERT [dbo].[tbl_eventcat_master] OFF
SET IDENTITY_INSERT [dbo].[tbl_eventmaster] ON 

INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (41, 1008, N'Eents hall', N'One morning, when Gregor Samsa woke from troubled dreams, he found himself transformed in his bed into a horrible vermin. He lay on his armour-like back, and if he lifted his head a little he could see his brown belly, slightly domed and divided by arches into stiff sections. The bedding was hardly able to cover it and seemed ready to slide off any moment. His many legs, pitifully thin compared with the size of the rest of him, waved about helplessly as he looked. "What''s happened to me?" he thought. It wasn''t a dream. His room, a proper human room although a little too small, lay peacefully between its four familiar walls.

A collection of textile samples lay spread out on the table - Samsa was a travelling salesman - and above it there hung a picture that he had recently cut out of an illustrated magazine and housed in a nice, gilded frame. It showed a lady fitted out with a fur hat and fur boa who sat upright, raising a heavy fur muff that covered the whole of her lower arm towards the viewer. Gregor then turned to look out the window at the dull weather.', CAST(N'2018-07-21 00:00:00.000' AS DateTime), N'11:00 AM', NULL, N'9425632145', 4, 7, 4, N'', 1, N'41_0_event1372017030442.png', N'41_1_event1372017030442.png', N'41_2_event1372017030442.png', N'22.72359686533105', N'75.8841270476114', 5, NULL, N'452001', N'Magnat Tower', N'Race cource road', N'Race cource', 2, CAST(N'2017-07-13 03:04:02.567' AS DateTime), 120, 1, 1, N'EV11', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (42, 2, N'wasim', N'sdsdsdsdsdsd', CAST(N'2017-07-27 00:00:00.000' AS DateTime), N'18:30 PM', NULL, N'7777777777', 4, 7, 4, N'', 0, N'42_0_event2572017015949.png', N'42_1_event2572017015949.png', N'42_2_event2572017015949.png', N'22.728245160515794', N'75.8817207813263', 5, NULL, N'452001', N'mobi', N'palasia', N'palasia street', 2, CAST(N'2017-07-25 01:59:30.167' AS DateTime), 0, 0, 1, NULL, N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (3, 2, N'Death Race Cars', N'Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur?

Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur? At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et.', CAST(N'2018-05-26 00:00:00.000' AS DateTime), N'10:00 AM', NULL, N'9425632145', 4, 9, 5, N'', 1, N'3_0_event1952017014500.png', N'3_1_event1952017014500.png', N'3_2_event1952017014500.png', N'22.912715709555552', N'78.78089904785156', 1003, NULL, N'02244', N'The Eden Ground', N'NP Road', N'RC Bheem ', 1, CAST(N'2017-05-19 01:44:57.413' AS DateTime), 0, 1, 1, N'1', N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1042, 2036, N'Nexa Event 1', N'Nexa Event1', CAST(N'2018-12-25 00:00:00.000' AS DateTime), N'12:00 PM', NULL, N'9874563210', 4, 7, 1005, N'', 1, N'1042_0_event1992017031216.png', N'1042_1_event1992017031216.png', N'1042_2_event1992017031216.png', N'23.210427207064953', N'77.4422836303711', 1008, NULL, N'789654', N'1', N'123', N'Habib', 2, CAST(N'2017-09-19 03:12:11.690' AS DateTime), 0, 0, 1, N'123', N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1043, 2040, N'2017 Betul Auto Show: Hyundai Sonata ', N'Hyndui AutoShow', CAST(N'2017-10-01 00:00:00.000' AS DateTime), N'12:00 PM', NULL, N'9874563210', 4, 7, 1007, N'', 0, N'1043_0_event2192017131354.png', N'1043_1_event2192017131354.png', N'1043_2_event2192017131354.png', N'22.004174972902007', N'77.8985595703125', 1009, NULL, N'456321', N'123', N'AB Road', N'Business Park', 2, CAST(N'2017-09-21 00:44:05.663' AS DateTime), 0, 0, 1, NULL, N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1070, 1014, N'Test Car', N'Test car ', CAST(N'2018-02-20 00:00:00.000' AS DateTime), N'23:55 PM', N'452001', N'9874125630', 4, 7, 4, N'', 1, N'1070_0_event822018163633.png', N'1070_1_event822018163633.png', N'1070_2_event822018163633.png', N'23.019076187293035', N'75.794677734375', 5, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2018-02-08 04:06:36.533' AS DateTime), 0, 0, 1, NULL, N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1048, 2023, N'Mercedes-Benz Car show', N'Mercedes-Benz Car show', CAST(N'2017-09-30 00:00:00.000' AS DateTime), N'14:30 PM', NULL, N'7897897895', 6, 5, 1, N'', 1, N'1048_0_event2292017151604.png', N'1048_1_event2292017151604.png', N'1048_2_event2292017151604.png', N'34.00485820541724', N'-118.45870971679688', 1, NULL, N'456987', N'123', N'Santa Monica', N'Santa Monica', 2, CAST(N'2017-09-22 02:46:17.267' AS DateTime), 0, 0, 1, N'123', N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (36, 2, N'Car Owners Meet ', N'The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphs grab quick-jived waltz. Brick quiz whangs jumpy veldt fox.', CAST(N'2017-09-01 00:00:00.000' AS DateTime), N'05:00 AM', NULL, N'5566441122', 4, 9, 5, N'', 1, N'36_0_event2052017075945.png', N'36_1_event2052017075945.png', N'36_2_event2052017075945.png', N'22.72821547335959', N'75.82892417907715', 1004, NULL, N'022', N'Race course  ', N'New Palasia', N'Palasia Thana', 1, CAST(N'2017-05-20 07:59:33.893' AS DateTime), 220, 1, 1, N'1', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (37, 1006, N'Bugati', N'Test', CAST(N'2017-05-23 00:00:00.000' AS DateTime), N'22:00 PM', NULL, N'9874563210', 6, 5, 1, N'', 1, N'37_0_event2352017033836.png', N'37_1_event2352017033836.png', N'37_2_event2352017033836.png', N'34.05265942137599', N'-118.14697265625', 1, NULL, N'789654', N'1', N'1', N'Test', 1, CAST(N'2017-05-23 03:38:33.687' AS DateTime), 0, 0, 1, N'333', N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (38, 1014, N'Bahrain Motor Show', N'mpetition is, in general, a contest or rivalry between two or more entities, organisms, animals, individuals, economic groups or social groups, etc., for territory, a niche, for scarce resources, goods, for mates, for prestige, recognition, for awards, for group or social status, or for leadership and profit. It arises whenever at least two parties strive for a goal which cannot be shared, where one''s gain is the other''s loss (a zero-sum game).

tERST

tEST

tEST

tET

tEEST', CAST(N'2017-11-15 00:00:00.000' AS DateTime), N'23:45 PM', N'hEEEE', N'0404696666', 4, 9, 5, N'', 1, N'38_0_event162017040005.png', N'38_1_event162017040005.png', N'381504104_10153744992878077_1743850742054188756_n.jpg', N'25.124596087055135', N'71.37070387601852', 1003, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2017-06-01 03:59:45.170' AS DateTime), 0, 0, 1, N'E1', N'1', N'')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (39, 1013, N'BBB', N'The quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphThe quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphThe quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphThe quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymphThe quick, brown fox jumps over a lazy dog. DJs flock by when MTV ax quiz prog. Junk MTV quiz graced by fox whelps. Bawds jog, flick quartz, vex nymphs. Waltz, bad nymph, for quick jigs vex! Fox nymph', CAST(N'2017-06-04 00:00:00.000' AS DateTime), N'22:36 PM', NULL, N'122f', 4, 9, 5, N'', 1, N'39_0_event462017045055.png', N'39_1_event462017045055.png', N'39_2_event462017045055.png', N'13.730953664436945', N'76.42265662550926', 1003, NULL, N'4109', N'21', N'1212', N'1212', 1, CAST(N'2017-06-04 04:50:40.900' AS DateTime), 0, 0, 1, N'ok', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1047, 2036, N'Google Car Show', N'Google car show', CAST(N'2017-12-01 00:00:00.000' AS DateTime), N'10:55 AM', NULL, N'9874563210', 4, 7, 1005, N'', 1, N'1047_0_event2192017151347.png', N'1047_1_event2192017151347.png', N'1047_2_event2192017151347.png', N'23.175713800385203', N'77.31285095214844', 1008, NULL, N'456456', N'1', N'Hamidiya', N'Hamidiya', 2, CAST(N'2017-09-21 02:43:58.563' AS DateTime), 0, 0, 1, N'234', N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1050, 2036, N'Test Title', N'Test Overview', CAST(N'2017-11-30 00:00:00.000' AS DateTime), N'04:00 AM', NULL, N'9874563210', 4, 7, 4, N'', 1, N'1050_0_event17102017104627.png', N'1050_1_event17102017104627.png', N'1050_2_event17102017104627.png', N'23.28171917560002', N'80.09033203125', 5, NULL, N'123456', N'1', N'1', N'2', 2, CAST(N'2017-10-16 22:16:14.920' AS DateTime), 0, 0, 1, N'12', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1051, 2033, N'Brezza Event', N'Brezza Event ', CAST(N'2017-10-31 00:00:00.000' AS DateTime), N'10:00 AM', N'Lal Gate 4520001', N'98745632100', 4, 7, 1004, N'', 0, N'1051_0_event17102017105459.png', N'1051_1_event17102017105459.png', N'1051_2_event17102017105459.png', N'22.146707780012626', N'78.81591796875', 1007, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2017-10-16 22:24:58.510' AS DateTime), 0, 0, 1, NULL, N'on', N'SK')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1055, 2034, N'mercedes benz1', N'mercedes-benz1 Overview', CAST(N'2017-10-25 00:00:00.000' AS DateTime), N'23:55 PM', NULL, N'9876945644', 4, 7, 1005, N'', 2, N'1055_0_event23102017030057.png', N'1055_1_event23102017030057.png', N'1055_2_event23102017030057.png', N'23.251440517055993', N'77.42889404296875', 1008, NULL, N'', N'', N'', N'', 2, CAST(N'2017-10-23 03:00:50.783' AS DateTime), 1111, 1, 1, N'123', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1044, 2040, N'2017 Maruti Auto Show: Baleno', N'Baleno', CAST(N'2017-10-02 00:00:00.000' AS DateTime), N'12:00 PM', NULL, N'9632587410', 4, 7, 1007, N'', 0, N'1044_0_event2192017133831.png', N'1044_1_event2192017133831.png', N'1044_2_event2192017133831.png', N'21.963424936844223', N'77.9754638671875', 1009, NULL, N'456321', N'123', N'Betul', N'Betul', 2, CAST(N'2017-09-21 01:08:43.447' AS DateTime), 0, 0, 1, NULL, N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1052, 2033, N'Audi Event', N'Audi Event Overview', CAST(N'2017-11-01 00:00:00.000' AS DateTime), N'09:00 AM', N'Hi Tech City 456321', N'974563210', 4, 8, 3, N'', 0, N'1052_0_event17102017105940.png', N'1052_1_event17102017105940.png', N'1052_2_event17102017105940.png', N'', N'', 4, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2017-10-16 22:29:38.603' AS DateTime), 0, 0, 0, NULL, N'1', N'')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1053, 2037, N'Renault', N'Renault Overview', CAST(N'2017-10-18 00:00:00.000' AS DateTime), N'14:10 PM', N'Near Station 452220', N'9632587408', 4, 7, 1005, N'', 0, N'1053_0_event17102017144037.png', N'1053_1_event17102017144037.png', N'1053_2_event17102017144037.png', N'22.978623970384913', N'77.4371337890625', 1008, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2017-10-17 02:10:36.207' AS DateTime), 0, 0, 0, NULL, N'0', N'')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1068, 2034, N'Hundai Event', N'yrys', CAST(N'2017-11-22 00:00:00.000' AS DateTime), N'08:00 AM', N'test', N'234234234', 4, 7, 1006, N'', 0, N'1068_0_event7112017171019.png', N'1068_1_event7112017171019.png', N'1068_2_event7112017171019.png', N'20.66105614283098', N'78.73970031738281', 1010, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2017-11-07 04:40:20.567' AS DateTime), 121, 1, 1, NULL, N'1', N'GV Admin')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1059, 2034, N'Audi Black', N'Audi Black', CAST(N'2017-11-03 00:00:00.000' AS DateTime), N'10:00 AM', NULL, N'1231231231', 4, 7, 4, N'', 1, N'1059_0_event3112017124312.png', N'1059_1_event3112017124312.png', N'1059_2_event3112017124312.png', N'23.28171917560002', N'76.97021484375', 5, NULL, N'123456', N'', N'1', N'1', 2, CAST(N'2017-11-03 00:13:18.140' AS DateTime), 123, 1, 1, N'1', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1069, 2034, N'Baleno Golder', N'Event Baleno Golder', CAST(N'2017-11-22 00:00:00.000' AS DateTime), N'09:00 AM', N'test 123', N'7894561232', 4, 7, 4, N'', 0, N'1069_0_event7112017044839.png', N'1069_1_event7112017044839.png', N'1069_2_event7112017044839.png', N'20.652061110924272', N'78.80287170410156', 5, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2017-11-07 04:48:34.453' AS DateTime), 0, 0, 1, NULL, N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1045, 2040, N'2017 Ciaz Auto Show: Hyundai Sonata ', N'Test', CAST(N'2017-10-03 00:00:00.000' AS DateTime), N'12:00 PM', NULL, N'9874563210', 4, 7, 1007, N'', 0, N'1045_0_event2192017134406.png', N'1045_1_event2192017134406.png', N'1045_2_event2192017134406.png', N'21.937950226141936', N'77.90130615234375', 1009, NULL, N'456321', N'123', N'Test', N'Test ', 2, CAST(N'2017-09-21 01:14:18.400' AS DateTime), 0, 0, 1, NULL, N'0', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1067, 2034, N'Baleno Event', N'tetst', CAST(N'2017-11-15 00:00:00.000' AS DateTime), N'09:25 AM', N'test', N'234234234234', 4, 7, 4, N'', 0, N'1067_0_event7112017170727.png', N'1067_1_event7112017170727.png', N'1067_2_event7112017170727.png', N'20.605792542957076', N'78.70674133300781', 5, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2017-11-07 04:37:22.547' AS DateTime), 0, 0, 1, NULL, N'1', N'GV Admin')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1054, 2037, N'Ethos Concept', N'Ethos Event Overview', CAST(N'2017-10-18 00:00:00.000' AS DateTime), N'09:00 AM', N'YN Road 456321', N'9874563210', 4, 9, 5, N'', 0, N'1054_0_event17102017144355.png', N'1054_1_event17102017144355.png', N'1054_2_event17102017144355.png', N'28.5941685062326', N'77.200927734375', 1003, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2017-10-17 02:13:54.533' AS DateTime), 0, 0, 1, NULL, N'0', N'Samitra ')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1058, 2034, N'Audi Red', N'Test ', CAST(N'2017-11-03 00:00:00.000' AS DateTime), N'09:00 AM', NULL, N'123123123', 4, 7, 4, N'', 1, N'1058_0_event3112017123851.png', N'1058_1_event3112017123851.png', N'1058_2_event3112017123851.png', N'23.241346102386135', N'77.01416015625', 5, NULL, N'123123', N'ab', N'ab', N'ab', 2, CAST(N'2017-11-03 00:08:48.420' AS DateTime), 123, 1, 1, N'11', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1063, 1014, N'Holden Meet up', N'This is a meet up organised by the MCY team on the north side of bribsnae. Please make it. Test

Test

TEst', CAST(N'2017-11-15 00:00:00.000' AS DateTime), N'08:25 AM', N'135 Troughton road, Sunnybank 4999', N'36699666', 1005, 1002, 1003, N'', 1, N'1063_0_event6112017025104.png', N'1063_1_event6112017025104.png', N'1063_2_event6112017025104.png', N'26.246063741970204', N'50.64609527529683', 1006, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2017-11-06 02:50:14.477' AS DateTime), 15, 1, 1, NULL, N'1', N'MCY Event')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1060, 2034, N'Hundai Sonata', N'Test Hundai Sonata', CAST(N'2017-11-10 00:00:00.000' AS DateTime), N'10:00 AM', NULL, N'9874563210', 4, 7, 4, N'', 1, N'1060_0_event3112017124938.png', N'1060_1_event3112017124938.png', N'1060_2_event3112017124938.png', N'23.28171917560002', N'77.23388671875', 5, NULL, N'123123', N'123', N'ab', N'ab', 2, CAST(N'2017-11-03 00:19:43.883' AS DateTime), 5000, 1, 1, N'123', N'1', NULL)
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1066, 1014, N'Super Car', N'Super var overview', CAST(N'2017-11-20 00:00:00.000' AS DateTime), N'04:00 AM', N'Arad 123', N'98745655545', 1005, 1002, 1003, N'', 0, N'1066_0_event6112017074429.png', N'1066_1_event6112017074429.png', N'1066_2_event6112017074429.png', N'25.72073513441211', N'50.47119140625', 1006, NULL, NULL, NULL, NULL, NULL, 1, CAST(N'2017-11-06 07:44:26.257' AS DateTime), 1099, 1, 1, NULL, N'1', N'Moe')
INSERT [dbo].[tbl_eventmaster] ([eid], [uid], [title], [subject], [edate], [etime], [address], [cno], [country], [state], [city], [descr], [status], [img], [img1], [img2], [late], [long], [reason], [suburb], [code], [unit], [street], [sname], [cat], [created_date], [price], [ispaid], [shownumber], [listid], [sponsorship], [sponsorname]) VALUES (1064, 2034, N'Lamborghini Italian Police Car', N'Lamborghini Italian Police Car Event Overview Lamborghini Italian Police Car', CAST(N'2017-11-30 00:00:00.000' AS DateTime), N'08:00 AM', N'Palasia indore 452001', N'9874563210', 4, 7, 4, N'', 0, N'1064_0_event6112017061753.png', N'1064_1_event6112017061753.png', N'1064_2_event6112017061753.png', N'22.727344647244575', N'75.88353931903839', 5, NULL, NULL, NULL, NULL, NULL, 2, CAST(N'2017-11-06 06:17:48.537' AS DateTime), 5001, 1, 1, NULL, N'1', N'GV Admin')
SET IDENTITY_INSERT [dbo].[tbl_eventmaster] OFF
SET IDENTITY_INSERT [dbo].[tbl_login] ON 

INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1, N'Mohamed', N'admin@mycaryard.com', N'admin123@', N'Super', 1, N'M', N'9993866111', 0, 0, 0, N'', N'', N'', N'Mohamed', N'Janahi', 0, N'0', N'', N'', N'', N'', N'', CAST(N'2016-12-08 00:00:00.000' AS DateTime), CAST(N'1900-01-01 00:00:00.000' AS DateTime), 0, NULL, N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2, N'Adam Wilson', N'adamwilsonmw@gmail.com', N'123456', N'Free', 1, N'M', N'9425632145', 6, 5, 1, N'', N'', N'', N'Adam ', N'Wilson', 1, NULL, N'452001', N'Race Cource road', N'Holkar road', NULL, NULL, CAST(N'2017-05-13 00:00:00.000' AS DateTime), CAST(N'2017-05-13 00:00:00.000' AS DateTime), 0, N'', NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1003, N'DotNetUser', N'DotNetUser@hp.com', N'123456', N'Free', 1, N'M', N'2547127', 4, 9, 5, NULL, NULL, NULL, NULL, NULL, 1003, NULL, N'5263456', N'asdfasdf', N'asdfasdf', N'', N'', CAST(N'2017-05-16 00:00:00.000' AS DateTime), CAST(N'2017-05-16 00:00:00.000' AS DateTime), 0, N'1010', N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1004, N'test', N'test@t.tvv', N'123456', N'Free', 1, N'M', N'645654654', 4, 9, 5, NULL, NULL, NULL, NULL, NULL, 1003, NULL, N'123456', N'kjknk', N'nknknk', N'', N'', CAST(N'2017-05-16 00:00:00.000' AS DateTime), CAST(N'2017-05-16 00:00:00.000' AS DateTime), 0, N'111', N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1005, N'Donnet2', N'Dotnet2@gmail.com', N'1', N'Paid', 2, N'M', N'9632587410', 4, 7, 4, N'', N'', N'', N'Donnet2', N'Dotnet2', 5, NULL, N'452001', N'Indore', N'indore', N'22.692467465132328', N'75.8675479888916', CAST(N'2017-05-17 00:00:00.000' AS DateTime), CAST(N'2017-06-17 00:00:00.000' AS DateTime), 1, N'100', N'Dotnet2', 0, N'1005Lucas_George-Stephenson.jpg', NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1009, N'Ani', N'ani@mailinator.com', N'123456', N'Paid', 2, N'M', N'9425632145', 4, 7, 4, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'452010', N'NA', N'NA', N'22.72235708178894', N'75.89424133300781', CAST(N'2017-05-19 00:00:00.000' AS DateTime), CAST(N'2017-06-19 00:00:00.000' AS DateTime), 1, N'PU-01', N'Car Experts', NULL, N'1009adam wilson.jpeg', NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1010, N'Ravikant Premium', N'ravip@mailinator.com', N'123456', N'Paid', 2, N'M', N'9988776655', 4, 7, 4, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'452000', N'NA', N'NA', N'22.697654078334974', N'75.443115234375', CAST(N'2017-05-20 00:00:00.000' AS DateTime), CAST(N'2017-06-20 00:00:00.000' AS DateTime), 1, N'RVP-02', N'Used Car Sales', NULL, N'1010brad-pitt-fight-club-hair1.jpg', NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1011, N'Ravikant Normal', N'ravin@mailinator.com', N'123456', N'Free', 1, N'M', N'8877665544', 6, 5, 1, NULL, NULL, NULL, NULL, NULL, 1, NULL, N'473001', N'NA', N'NA', N'', N'', CAST(N'2017-05-20 00:00:00.000' AS DateTime), CAST(N'2017-05-20 00:00:00.000' AS DateTime), 0, N'TVN-02', N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1014, N'Moe 6969', N'madelslim@hotmail.com', N'Password123', N'Free', 1, N'M', N'6699696', 4, 9, 5, N'', N'', N'', N'Moe', N'J', 1003, NULL, N'13123123', N'12313', N'123', NULL, NULL, CAST(N'2017-06-01 00:00:00.000' AS DateTime), CAST(N'2017-06-01 00:00:00.000' AS DateTime), 0, NULL, NULL, 1, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1013, N'MYCARYARD', N'madelslim@gmail.com', N'Password123', N'Paid', 1, N'M', N'0404696666', 1008, 1003, 1008, N'', N'', N'', N'Moe', N'Janahi', 1011, NULL, N'4109', N'174', N'Station Road', N'-27.559598927886046', N'153.04804801940918', CAST(N'2017-06-01 00:00:00.000' AS DateTime), CAST(N'2017-06-01 00:00:00.000' AS DateTime), 0, NULL, N'MYCARYARD', 0, N'1013_8122017022415.png', NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1015, N'RavikantSonare', N'ravikant.s@mobiwebtech.com', N'1', N'Free', 0, NULL, NULL, 4, 9, 5, NULL, NULL, NULL, NULL, NULL, 1003, NULL, N'252200', NULL, NULL, NULL, NULL, CAST(N'2017-08-01 01:59:20.613' AS DateTime), CAST(N'2017-08-01 01:59:20.613' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2015, N'BasicUser1', N'spire@yopmail.com', N'123456', N'Free', 1, N'', N'', 4, 7, 4, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'452001', N'', N'', N'', N'', CAST(N'2017-09-14 00:00:00.000' AS DateTime), CAST(N'2017-09-14 00:00:00.000' AS DateTime), 0, NULL, N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2016, N'PremiumUser1', N'mycaryard@yopmail.com', N'123456', N'Paid', 2, N'M', N'9874563210', 6, 5, 1, N'', N'', N'', N'Premium', N'User1', 1, NULL, N'789654', N'', N'', N'34.16181816123038', N'-116.8505859375', CAST(N'2017-09-14 03:16:10.280' AS DateTime), CAST(N'2017-09-14 03:16:10.280' AS DateTime), 0, NULL, N'PremiumUser1', 0, N'2016angrycar.JPG', NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2017, N'mycaryard2', N'mycaryard2@yopmail.com', N'123456', N'Paid', 2, NULL, N'9632587410', 1005, 1002, 1003, NULL, NULL, NULL, NULL, NULL, 1006, NULL, N'456987', NULL, NULL, NULL, NULL, CAST(N'2017-09-14 23:56:23.320' AS DateTime), CAST(N'2017-09-14 23:56:23.320' AS DateTime), 0, NULL, N'mycaryard2', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1006, N'Dotnet3', N'Dotnet3@gmail.com', N'123456', N'Paid', 1, N'M', N'9874563210', 6, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'456321', N'Uit', N'uit', N'34.13454168193737', N'-118.311767578125', CAST(N'2017-05-17 00:00:00.000' AS DateTime), CAST(N'2017-06-17 00:00:00.000' AS DateTime), 1, N'101', N'Dotnet3', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1007, N'Dotnet4', N'Dotnet4@gmail.com', N'123456', N'Paid', 2, N'M', N'9632587410', 4, 8, 3, NULL, NULL, NULL, NULL, NULL, 4, NULL, N'4520414', N'pune', N'pune', N'18.51802788851641', N'73.85902404785156', CAST(N'2017-05-17 00:00:00.000' AS DateTime), CAST(N'2017-06-17 00:00:00.000' AS DateTime), 1, N'102', N'Dotnet4', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (1008, N'Laura Brown', N'laurabrownmw@gmail.com', N'123456', N'Free', 1, N'F', N'9988776655', 6, 5, 1, N'', N'', N'', N'Laura', N'Brown', 1, NULL, N'01122', N'', N'', NULL, NULL, CAST(N'2017-05-19 00:33:50.090' AS DateTime), CAST(N'2017-05-19 00:33:50.090' AS DateTime), 0, NULL, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2018, N'Maruti Nexa 1', N'mycaryard3@yopmail.com', N'123456', N'Paid', 1, N'M', N'9632587410', 4, 9, 5, N'', N'', N'', N'Maruti Nexa 1', N'Maruti Nexa 1', 1003, NULL, N'789654', N'123', N'Khan Market', N'28.6001972984909', N'77.22684860229492', CAST(N'2017-09-15 00:00:00.000' AS DateTime), CAST(N'2017-09-15 00:00:00.000' AS DateTime), 0, NULL, N'Maruti Nexa 1', 0, NULL, N'0', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2019, N'mycaryard4', N'mycaryard4@yopmail.com', N'123456', N'Free', 1, N'', N'', 6, 5, 1, NULL, NULL, NULL, NULL, NULL, 2, NULL, N'4564756', N'', N'', N'', N'', CAST(N'2017-09-15 00:00:00.000' AS DateTime), CAST(N'2017-09-15 00:00:00.000' AS DateTime), 0, NULL, N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2020, N'mycaryard5', N'mycaryard5@yopmail.com', N'123456', N'Free', 0, NULL, NULL, 4, 9, 5, NULL, NULL, NULL, NULL, NULL, 1003, NULL, N'789456', NULL, NULL, NULL, NULL, CAST(N'2017-09-15 06:39:49.960' AS DateTime), CAST(N'2017-09-15 06:39:49.960' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2021, N'New Store1', N'NewStore1@gmail.com', N'123456', N'Paid', 2, N'M', N'987456321', 4, 9, 5, N'', N'', N'', N'New Store1', N'New Store1', 1003, NULL, N'456789', N'123', N'New Delhi', N'28.659261153016082', N'77.23320007324219', CAST(N'2017-09-16 00:58:29.340' AS DateTime), CAST(N'2017-09-16 00:58:29.340' AS DateTime), 0, NULL, N'New Store1', 0, N'2021logo.jpg', N'2018', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2024, N'Robert', N'Robert@yopmail.com', N'123456', N'Paid', 2, N'M', N'1234567890', 6, 5, 1, N'', N'', N'', N'Robert', N'Toyata', 1, NULL, N'123123', N'123', N'Henderson', N'35.88905007936091', N'-114.9554443359375', CAST(N'2017-09-16 07:08:01.800' AS DateTime), CAST(N'2017-09-16 07:08:01.800' AS DateTime), 0, NULL, N'Robert Toyota Dealer', 0, N'2024secondary_logo.png', N'2033', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2035, N'RS Car Dealer', N'ravikant.s@mobiweb.com', N'123456', N'Paid', 1, N'M', N'9637412580', 4, 7, 1007, N'', N'', N'', N'Ravikant', N'Sonare', 1009, NULL, N'785412', N'123', N'Link Road', N'21.90355212979805', N'77.89515852928162', CAST(N'2017-09-17 00:00:00.000' AS DateTime), CAST(N'2017-09-17 00:00:00.000' AS DateTime), 0, NULL, N'RS Car Dealer', 0, N'2035_12122017042459.png', N'2023', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2040, N'Ravikant', N'ravikant@yopmail.com', N'123456', N'Free', 1, N'', N'', 4, 7, 1007, NULL, NULL, NULL, NULL, NULL, 1009, NULL, N'785412', N'', N'', N'', N'', CAST(N'2017-09-21 00:00:00.000' AS DateTime), CAST(N'2017-09-21 00:00:00.000' AS DateTime), 0, NULL, N'', NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2023, N'John', N'John@yopmail.com', N'123456', N'Paid', 1, N'M', N'9874563210', 6, 5, 1, N'', N'', N'', N'John', N'Wills', 1, NULL, N'123654', N'123', N'Covina', N'34.08906131584994', N'-117.89222717285156', CAST(N'2017-09-16 00:00:00.000' AS DateTime), CAST(N'2017-09-16 00:00:00.000' AS DateTime), 0, NULL, N'John Car Dealer', 0, NULL, N'0', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2036, N'Maruti Nexa1', N'johnson@mobiwebtech.com', N'123456', N'Paid', 1, N'M', N'9874236510', 4, 7, 1005, N'', N'', N'', N'Jimmy ', N'Johnson', 1008, NULL, N'963252', N'123', N'Main Rd 2', N'23.22241701635157', N'77.43741273880005', CAST(N'2017-09-18 00:00:00.000' AS DateTime), CAST(N'2017-12-18 00:00:00.000' AS DateTime), 0, NULL, N'Maruti Nexa1', 0, N'2036logo3.png', N'2033', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2038, N'Kuldeep', N'kuldeep@mobiwebtech.com', N'kuldeep123', N'Paid', 1, N'M', N'9827041964', 4, 7, 4, N'', N'', N'', N'Kuldeep', N'Patel', 5, NULL, N'452001', N'palasia', N'Robert''s street', N'22.654571520098997', N'75.926513671875', CAST(N'2017-09-20 22:27:31.103' AS DateTime), CAST(N'2017-09-20 22:27:31.103' AS DateTime), 0, NULL, N'Patel Motors', 1, N'2038logo.jpg', N'0', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2022, N'Generic Car Dealer', N'Generic@gmail.com', N'123456', N'Paid', 1, N'M', N'9876543210', 4, 8, 3, N'', N'', N'', N'Generic', N' Car Dealer', 4, NULL, N'223232', N'456', N'Lavale', N'18.51347017266187', N'73.72444152832031', CAST(N'2017-09-16 00:00:00.000' AS DateTime), CAST(N'2017-09-16 00:00:00.000' AS DateTime), 0, NULL, N'Generic Car Dealer', 0, N'202299gen_car.jpg', N'2018', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2034, N'Gaurav Verma', N'admin@mobiwebtech.com', N'123456', N'Paid', 1, N'M', N'9632587410', 4, 7, 1004, N'', N'', N'', N'Gaurav ', N'Verma', 1007, NULL, N'987456', N'123', N'A B Road', N'22.966928493717297', N'76.05787754058838', CAST(N'2017-09-17 00:00:00.000' AS DateTime), CAST(N'2018-09-17 00:00:00.000' AS DateTime), 0, NULL, N'Mobile Car Detailers', 0, N'2034_2392017035544.png', N'2033', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2039, N'Patel Mortos II', N'sorav@mobiwebtech.com', N'sorav123', N'Paid', 1, N'M', N'9827041964', 4, 8, 3, N'', N'', N'', N'Kuldeep', N'Patel', 4, NULL, N'452001', N'Shaniwarwada', N'Shaniwar Peth', N'18.55676356786887', N'73.89421463012695', CAST(N'2017-09-20 22:37:04.400' AS DateTime), CAST(N'2017-09-20 22:37:04.400' AS DateTime), 0, NULL, N'Patel Motos II', 1, NULL, N'2038', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2041, N'Kevin', N'kevinwill@yopmail.com', N'123456', N'Paid', 2, N'M', N'9632587410', 6, 5, 1, N'', N'', N'', N'Kevin', N'wills', 2, NULL, N'987456', N'W 5th St', N'Grand Central market', N'34.05031266902129', N'-118.2492184638977', CAST(N'2017-09-23 03:37:58.493' AS DateTime), CAST(N'2017-09-23 03:37:58.493' AS DateTime), 0, NULL, N'Carsale.com', 0, N'2041_2392017160901.png', N'2023', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2032, N'Henry M. Gillispie', N'henrymgillispie@yopmail.com', N'123456', N'Paid', 1, N'M', N'9876543210', 6, 5, 1, N'', N'', N'', N'Henry ', N'M. Gillispie', 1, NULL, N'456567', N'123', N'Oliver Street Dallas', N'33.77914733128647', N'-117.147216796875', CAST(N'2017-09-17 00:00:00.000' AS DateTime), CAST(N'2017-09-17 00:00:00.000' AS DateTime), 0, NULL, N'Henry Dealer', 0, N'203299gen_car.jpg', N'2023', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2033, N'Shailendra Kumrawat', N'shailendra@mobiwebtech.com', N'123456', N'Paid', 1, N'M', N'9863521470', 4, 7, 4, N'', N'', N'', N'Shailendra ', N'Kumrawat', 5, NULL, N'452001', N'123', N'Magnet Tower', N'22.714123242600653', N'75.8609390258789', CAST(N'2017-09-17 00:00:00.000' AS DateTime), CAST(N'2017-09-17 00:00:00.000' AS DateTime), 0, NULL, N'SK Car Dealer', 0, N'2033_2392017035045.png', N'0', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2037, N'Saumitra Tomar', N'saumitra@mobiwebtech.com', N'123456', N'Paid', 1, N'M', N'9865324710', 4, 7, 1006, N'', N'', N'', N'Saumitra ', N'Tomar', 1010, NULL, N'897456', N'123', N'Sanwer Rd', N'23.14825227274326', N'75.81270217895508', CAST(N'2017-09-18 00:00:00.000' AS DateTime), CAST(N'2017-11-18 00:00:00.000' AS DateTime), 0, NULL, N'Saumitra Auto Dealer', 0, N'2037logo4.jpg', N'2033', NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2042, N'Tester Ani', N'aniqa.mobiweb@gmail.com', N'123456', N'Free', 0, NULL, NULL, 1005, 1002, 1003, NULL, NULL, NULL, NULL, NULL, 1006, NULL, N'452001', NULL, NULL, NULL, NULL, CAST(N'2017-12-18 05:51:09.300' AS DateTime), CAST(N'2017-12-18 05:51:09.300' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL, N'381583558934365')
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2044, N'GoldenTabs', N'support@goldentabs.com', N'nirOu', N'Free', 0, NULL, NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, 0, NULL, N'14206', NULL, NULL, NULL, NULL, CAST(N'2018-01-07 12:04:22.133' AS DateTime), CAST(N'2018-01-07 12:04:22.133' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[tbl_login] ([id], [name], [email], [pass], [type], [status], [gender], [cno], [country], [state], [city], [other], [other1], [other2], [fname], [lname], [regions], [suburb], [zip], [street], [streetname], [late], [long], [reg_date], [valid_date], [plan_id], [Cust_id], [orgname], [showphone], [buslogo], [parentstore], [facebookId]) VALUES (2045, N'Mobi Web', N'mobiweb.ani@gmail.com', N'its_ani123', N'Free', 0, NULL, NULL, 4, 7, 4, NULL, NULL, NULL, NULL, NULL, 5, NULL, N'456123', NULL, NULL, NULL, NULL, CAST(N'2018-02-05 03:18:24.203' AS DateTime), CAST(N'2018-02-05 03:18:24.203' AS DateTime), 0, NULL, NULL, NULL, NULL, NULL, N'427745850978820')
SET IDENTITY_INSERT [dbo].[tbl_login] OFF
SET IDENTITY_INSERT [dbo].[tbl_plan_master] ON 

INSERT [dbo].[tbl_plan_master] ([plan_id], [plan_name], [duration], [amnt], [status]) VALUES (1, N'Monthly', 1, 300, 1)
SET IDENTITY_INSERT [dbo].[tbl_plan_master] OFF
SET IDENTITY_INSERT [dbo].[tbl_state_master] ON 

INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (1, 6, N'Abu Dhabi', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (2, 6, N'Dubai', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (3, 6, N'Sharjah', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (4, 6, N'Alaska', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (5, 6, N'California', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (6, 6, N'Hawaii', 0)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (7, 4, N'Madhya Pradesh (MP)', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (8, 4, N'Maharashtra', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (9, 4, N'New Delhi', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (19, 5, N'Abu Dhabi', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (1002, 1005, N'Manama', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (10, 2, N'	Scotland', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (11, 2, N'	Wales', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (12, 2, N'South West, England', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (13, 2, N'Yorkshire and the Humber, England', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (14, 1, N'New South Wales', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (15, 1, N'	Victoria', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (16, 1, N'Queensland', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (17, 1, N'	Tasmania', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (18, 1, N'Western Australia', 1)
INSERT [dbo].[tbl_state_master] ([state_id], [count_id], [state_name], [status]) VALUES (1003, 1008, N'QLD', 1)
SET IDENTITY_INSERT [dbo].[tbl_state_master] OFF
INSERT [dbo].[tbl_Tmp_ForgotUserPassword] ([Userid], [uniqueId], [createDate]) VALUES (1015, N'B20254AB-D265-43B7-A893-218912CC3806', CAST(N'2017-08-02 01:12:50.763' AS DateTime))
INSERT [dbo].[tbl_Tmp_ForgotUserPassword] ([Userid], [uniqueId], [createDate]) VALUES (1014, N'3985EA4F-C46F-44C9-B7C1-4DA2A9CF6501', CAST(N'2017-10-03 23:12:01.470' AS DateTime))
INSERT [dbo].[tbl_Tmp_ForgotUserPassword] ([Userid], [uniqueId], [createDate]) VALUES (1015, N'CC478735-1781-46CA-ABA1-77D462B57495', CAST(N'2017-08-02 01:13:53.503' AS DateTime))
INSERT [dbo].[tbl_Tmp_ForgotUserPassword] ([Userid], [uniqueId], [createDate]) VALUES (1014, N'2298CFE0-A223-47B0-983C-8C7F14A60C70', CAST(N'2017-10-12 04:19:02.843' AS DateTime))
INSERT [dbo].[tbl_Tmp_ForgotUserPassword] ([Userid], [uniqueId], [createDate]) VALUES (2033, N'B8644E5A-4006-4C8B-AEAE-2D0C6B096EC5', CAST(N'2017-12-08 02:02:39.930' AS DateTime))
SET IDENTITY_INSERT [dbo].[TransmisionMaster] ON 

INSERT [dbo].[TransmisionMaster] ([trans_id], [transmision], [speedtype], [status]) VALUES (1, N'Automatic ', N'1sp', 1)
INSERT [dbo].[TransmisionMaster] ([trans_id], [transmision], [speedtype], [status]) VALUES (2, N'Manual', NULL, 1)
SET IDENTITY_INSERT [dbo].[TransmisionMaster] OFF
SET IDENTITY_INSERT [dbo].[UserNotification] ON 

INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1, CAST(N'2017-05-13 00:41:34.053' AS DateTime), 2, 2, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2, CAST(N'2017-05-13 08:24:15.983' AS DateTime), 2, 2, N'Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (3, CAST(N'2017-05-13 08:28:27.960' AS DateTime), 1, 2, N'Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (4, CAST(N'2017-05-13 09:37:45.823' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedanis Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1002, CAST(N'2017-05-16 12:26:01.757' AS DateTime), 1002, 1002, N'Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1003, CAST(N'2017-05-16 07:06:15.547' AS DateTime), 1003, 1003, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1004, CAST(N'2017-05-16 14:10:26.150' AS DateTime), 1003, 1003, N'Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1005, CAST(N'2017-05-16 07:31:43.797' AS DateTime), 1004, 1004, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1006, CAST(N'2017-05-16 14:42:31.337' AS DateTime), 1004, 1004, N'Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1012, CAST(N'2017-05-18 14:21:20.013' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedanis Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1013, CAST(N'2017-05-18 15:12:10.787' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedanis being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1014, CAST(N'2017-05-18 15:13:51.890' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedanis Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1016, CAST(N'2017-05-19 14:08:16.470' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedan is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1017, CAST(N'2017-05-19 14:09:05.857' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1018, CAST(N'2017-05-20 05:37:58.347' AS DateTime), 1005, 1005, N'Your Event Google Car is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1019, CAST(N'2017-05-20 13:50:25.790' AS DateTime), 2, 2, N'Your Event BMW is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1020, CAST(N'2017-05-20 14:42:42.027' AS DateTime), 2, 2, N'Your Event Death Race Cars is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1022, CAST(N'2017-05-20 15:19:44.373' AS DateTime), 2, 2, N'Your Event Car Owners Meet  is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1023, CAST(N'2017-05-20 15:27:10.143' AS DateTime), 2, 2, N'Your Car 1963 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1025, CAST(N'2017-05-23 06:50:13.220' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedan is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1026, CAST(N'2017-05-23 06:51:30.737' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1027, CAST(N'2017-05-23 09:57:27.067' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedan is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1029, CAST(N'2017-05-23 14:02:42.207' AS DateTime), 1, 1006, N'Your Car 2016 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1030, CAST(N'2017-05-23 14:02:52.673' AS DateTime), 1006, 1006, N'Your Car 2016 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1031, CAST(N'2017-05-23 14:03:31.993' AS DateTime), 1, 2, N'Your Car 2010 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1032, CAST(N'2017-05-23 14:04:04.057' AS DateTime), 1, 2, N'Your Car 1966 BMW BMW M3 Sedan is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1033, CAST(N'2017-05-23 14:04:16.913' AS DateTime), 2, 2, N'Your Car 1966 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1036, CAST(N'2017-06-01 03:37:18.993' AS DateTime), 1012, 1012, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1037, CAST(N'2017-06-01 03:39:02.227' AS DateTime), 1013, 1013, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1038, CAST(N'2017-06-01 03:49:15.490' AS DateTime), 1014, 1014, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1039, CAST(N'2017-06-01 10:50:01.610' AS DateTime), 1, 1013, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1040, CAST(N'2017-06-01 10:50:53.257' AS DateTime), 1, 1014, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1041, CAST(N'2017-06-01 10:51:17.127' AS DateTime), 1, 1014, N' Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1042, CAST(N'2017-06-01 10:52:17.260' AS DateTime), 1, 1014, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1043, CAST(N'2017-06-01 10:52:34.870' AS DateTime), 1, 1014, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1046, CAST(N'2017-06-01 13:38:20.953' AS DateTime), 1, 1013, N'Your Car 2000 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1047, CAST(N'2017-06-01 13:57:56.217' AS DateTime), 1, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1048, CAST(N'2017-06-01 14:30:14.917' AS DateTime), 1, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1052, CAST(N'2017-06-04 12:31:42.500' AS DateTime), 1013, 1013, N'Your Event BBB is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1054, CAST(N'2017-06-11 08:57:41.553' AS DateTime), 1013, 1013, N'Your Event BBB is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1055, CAST(N'2017-06-11 08:57:58.777' AS DateTime), 1013, 1013, N'Your Event BBB is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1056, CAST(N'2017-06-13 10:03:01.020' AS DateTime), 1, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1057, CAST(N'2017-06-13 10:03:43.190' AS DateTime), 1, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1058, CAST(N'2017-07-13 07:19:20.983' AS DateTime), 1, 1008, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1061, CAST(N'2017-07-13 10:18:46.530' AS DateTime), 1008, 1008, N'Your Event Eents hall is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1062, CAST(N'2017-07-13 10:36:43.630' AS DateTime), 1008, 1008, N'Your Event Eents hall is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1063, CAST(N'2017-07-13 11:37:13.510' AS DateTime), 1008, 1008, N'Your Event Eents hall is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1064, CAST(N'2017-07-13 11:59:55.720' AS DateTime), 1, 1008, N'Your Car 1950 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1065, CAST(N'2017-08-01 01:59:20.613' AS DateTime), 1015, 1015, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2065, CAST(N'2017-08-30 16:04:01.450' AS DateTime), 1013, 1013, N'Your Event BBB is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2073, CAST(N'2017-09-14 10:17:29.260' AS DateTime), 1, 2016, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2074, CAST(N'2017-09-14 10:38:04.457' AS DateTime), 1, 2015, N'Your Car 2012 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1007, CAST(N'2017-05-17 13:35:49.947' AS DateTime), 1, 1007, N'Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1008, CAST(N'2017-05-17 13:35:53.910' AS DateTime), 1, 1006, N'Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1009, CAST(N'2017-05-17 13:35:57.890' AS DateTime), 1, 1005, N'Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1010, CAST(N'2017-05-17 13:39:30.000' AS DateTime), 1005, 1005, N'Your Event Jaguaris Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1011, CAST(N'2017-05-17 13:39:35.053' AS DateTime), 1005, 1005, N'Your Event Google Caris Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1021, CAST(N'2017-05-20 15:18:53.833' AS DateTime), 2, 2, N'Your Event Car Owners Meet  is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1024, CAST(N'2017-05-20 15:50:31.627' AS DateTime), 1, 2, N'Your Car 1966 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1028, CAST(N'2017-05-23 10:41:09.210' AS DateTime), 1006, 1006, N'Your Event Bugati is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1034, CAST(N'2017-05-23 14:05:10.393' AS DateTime), 1, 2, N'Your Car 1964 BMW BMW M3 Sedan is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1035, CAST(N'2017-05-23 14:05:20.050' AS DateTime), 2, 2, N'Your Car 1964 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1044, CAST(N'2017-06-01 11:03:45.047' AS DateTime), 1014, 1014, N'Your Event Bahrain Motor Show is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1045, CAST(N'2017-06-01 11:03:58.150' AS DateTime), 1014, 1014, N'Your Event Bahrain Motor Show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1049, CAST(N'2017-06-01 14:31:17.710' AS DateTime), 1, 1013, N'Your Car 1950 Subaru 2017 BRZ Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1050, CAST(N'2017-06-01 14:31:28.323' AS DateTime), 1013, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1051, CAST(N'2017-06-01 14:31:33.460' AS DateTime), 1013, 1013, N'Your Car 1950 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1053, CAST(N'2017-06-04 12:37:42.943' AS DateTime), 1013, 1013, N'Your Event BBB is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1059, CAST(N'2017-07-13 10:09:52.693' AS DateTime), 1008, 1008, N'Your Event Eents hall is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (1060, CAST(N'2017-07-13 10:17:29.557' AS DateTime), 1, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2066, CAST(N'2017-08-31 05:29:52.127' AS DateTime), 1, 2, N'Your Car 1964 BMW BMW M3 Sedan is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2067, CAST(N'2017-08-31 05:30:43.850' AS DateTime), 1, 2, N'Your Car 1964 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2068, CAST(N'2017-08-31 06:05:22.667' AS DateTime), 2, 2, N'Your Event Car Owners Meet  is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2076, CAST(N'2017-09-15 06:28:15.533' AS DateTime), 2018, 2018, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2077, CAST(N'2017-09-15 06:31:45.967' AS DateTime), 2019, 2019, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2078, CAST(N'2017-09-15 06:39:49.960' AS DateTime), 2020, 2020, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2080, CAST(N'2017-09-16 03:23:29.830' AS DateTime), NULL, NULL, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2081, CAST(N'2017-09-16 04:01:07.873' AS DateTime), 2022, 2022, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2084, CAST(N'2017-09-17 23:23:36.087' AS DateTime), 2032, 2032, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2086, CAST(N'2017-09-17 23:46:49.830' AS DateTime), 2034, 2034, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2088, CAST(N'2017-09-18 00:00:32.763' AS DateTime), 2036, 2036, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2089, CAST(N'2017-09-18 00:03:52.937' AS DateTime), 2037, 2037, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2090, CAST(N'2017-09-18 09:03:20.437' AS DateTime), 1, 2036, N'Your Car 2016 Maruti Ciaz S 1.3 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2103, CAST(N'2017-09-18 14:43:56.847' AS DateTime), 1, 2034, N'Your Car 2017 Maruti Baleno Delta 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2105, CAST(N'2017-09-19 06:05:27.887' AS DateTime), 1, 1013, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2106, CAST(N'2017-09-19 06:05:34.547' AS DateTime), 1, 2016, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2107, CAST(N'2017-09-19 06:05:38.577' AS DateTime), 1, 2018, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2108, CAST(N'2017-09-19 06:05:45.123' AS DateTime), 1, 2022, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2109, CAST(N'2017-09-19 06:06:09.333' AS DateTime), 1, 2022, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2110, CAST(N'2017-09-19 06:06:16.627' AS DateTime), 1, 2018, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2111, CAST(N'2017-09-19 06:06:28.140' AS DateTime), 1, 1005, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2112, CAST(N'2017-09-19 06:06:32.730' AS DateTime), 1, 1006, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2113, CAST(N'2017-09-19 06:06:36.043' AS DateTime), 1, 1007, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2114, CAST(N'2017-09-19 06:06:39.583' AS DateTime), 1, 1009, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2115, CAST(N'2017-09-19 06:06:43.553' AS DateTime), 1, 1010, N' Your Profile is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2116, CAST(N'2017-09-19 10:13:58.157' AS DateTime), 2036, 2036, N'Your Event Nexa Event 1 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2120, CAST(N'2017-09-20 22:37:04.400' AS DateTime), 2039, 2039, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2121, CAST(N'2017-09-21 05:37:35.683' AS DateTime), 1, 2039, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2123, CAST(N'2017-09-22 09:48:46.040' AS DateTime), 2023, 2023, N'Your Event Mercedes-Benz Car show is Approved By Super Admin', N'1')
GO
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2124, CAST(N'2017-09-22 10:02:43.823' AS DateTime), 2036, 2036, N'Your Event Google Car Show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2127, CAST(N'2017-09-25 07:22:34.683' AS DateTime), 2036, 2036, N'Your Event Nexa Event 1 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2131, CAST(N'2017-10-04 05:40:40.650' AS DateTime), 1, 1014, N'Your Car 1965 Subaru Brumby Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2133, CAST(N'2017-10-04 06:26:35.430' AS DateTime), 1, 1014, N'Your Car 1966 BMW 120i E87 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2134, CAST(N'2017-10-04 06:26:51.817' AS DateTime), 1014, 1014, N'Your Car 1965 Subaru Brumby Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2136, CAST(N'2017-10-06 00:25:12.470' AS DateTime), 1, 1014, N'Your Car 2005 Subaru Impreza S is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2139, CAST(N'2017-10-06 06:42:34.183' AS DateTime), 1014, 1014, N'Your Event Subbie show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2069, CAST(N'2017-09-11 08:11:26.790' AS DateTime), 1, 1014, N'Your Car 1965 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2072, CAST(N'2017-09-14 03:16:10.283' AS DateTime), 2016, 2016, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2075, CAST(N'2017-09-14 23:56:23.320' AS DateTime), 2017, 2017, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2082, CAST(N'2017-09-16 07:02:49.713' AS DateTime), 2023, 2023, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2083, CAST(N'2017-09-16 07:08:01.800' AS DateTime), 2024, 2024, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2085, CAST(N'2017-09-17 23:32:33.090' AS DateTime), 2033, 2033, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2091, CAST(N'2017-09-18 09:17:34.160' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2093, CAST(N'2017-09-18 11:58:36.880' AS DateTime), 1006, 1006, N'Your Car 2016 Subaru 2017 BRZ Impreza is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2094, CAST(N'2017-09-18 12:01:24.723' AS DateTime), 1013, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2095, CAST(N'2017-09-18 12:01:29.723' AS DateTime), 1013, 1013, N'Your Car 1950 Subaru 2017 BRZ Impreza is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2104, CAST(N'2017-09-18 15:02:37.283' AS DateTime), 1, 2032, N'Your Car 2016 Maruti Ciaz Zeta 1.4 AT is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2117, CAST(N'2017-09-20 12:07:22.373' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2122, CAST(N'2017-09-21 00:21:57.840' AS DateTime), 2040, 2040, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2135, CAST(N'2017-10-04 07:19:00.110' AS DateTime), 1, 1013, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2140, CAST(N'2017-10-08 02:20:38.673' AS DateTime), 1014, 1014, N'Your Event Subbie show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2141, CAST(N'2017-10-09 07:53:02.177' AS DateTime), 1, 2, N'Your Car 1950 BMW 120i E87 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2144, CAST(N'2017-10-09 08:01:42.250' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2146, CAST(N'2017-10-09 08:05:08.417' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2148, CAST(N'2017-10-09 08:06:05.840' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2152, CAST(N'2017-10-09 09:40:08.447' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2154, CAST(N'2017-10-09 09:43:59.397' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2159, CAST(N'2017-10-09 13:56:39.957' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2161, CAST(N'2017-10-09 13:57:31.213' AS DateTime), 1, 2037, N'Your Car 2010 Audi A1 8X is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2164, CAST(N'2017-10-24 06:38:53.723' AS DateTime), 2034, 2034, N'Your Event Audi Red is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2165, CAST(N'2017-10-24 06:40:08.057' AS DateTime), 2034, 2034, N'Your Event Audi Red is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2166, CAST(N'2017-10-24 06:41:48.123' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2167, CAST(N'2017-10-24 06:56:33.847' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2168, CAST(N'2017-10-24 06:57:23.960' AS DateTime), 2034, 2034, N'Your Event Audi Red is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2170, CAST(N'2017-10-24 07:17:45.897' AS DateTime), 2034, 2034, N'Your Event Audi Red is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2172, CAST(N'2017-10-29 23:39:47.280' AS DateTime), 1014, 1014, N'Your Event Subbie show is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2173, CAST(N'2017-11-03 10:55:04.720' AS DateTime), 2034, 2034, N'Your Event Lexus Event is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2181, CAST(N'2017-11-06 07:34:59.517' AS DateTime), 2036, 2036, N'Your Event Google Car Show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2182, CAST(N'2017-11-06 07:35:19.337' AS DateTime), 2036, 2036, N'Your Event Nexa Event 1 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2183, CAST(N'2017-11-06 09:57:34.583' AS DateTime), 1013, 1013, N'Your Car 2001 Subaru Brumby Impreza is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2184, CAST(N'2017-11-06 09:57:41.180' AS DateTime), 1013, 1013, N'Your Car 2001 Subaru Brumby Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2185, CAST(N'2017-11-06 09:58:20.923' AS DateTime), 1, 1013, N'Your Car 2001 Subaru Brumby Impreza is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2186, CAST(N'2017-11-06 11:14:18.867' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2187, CAST(N'2017-11-06 11:14:41.470' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2191, CAST(N'2017-11-07 13:43:09.340' AS DateTime), 1, 2034, N'Your Car 2017 Maruti Ciaz S 1.3 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2192, CAST(N'2017-11-07 14:37:33.523' AS DateTime), 1, 1013, N'Your Car 2017 Subaru Brumby Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2193, CAST(N'2017-11-07 14:37:50.607' AS DateTime), 1013, 1013, N'Your Car 2016 BMW 120i E87 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2070, CAST(N'2017-09-14 02:34:40.110' AS DateTime), 2015, 2015, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2071, CAST(N'2017-09-14 10:08:49.980' AS DateTime), 1, 2015, N'Your Car 2010 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2087, CAST(N'2017-09-17 23:52:50.797' AS DateTime), 2035, 2035, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2092, CAST(N'2017-09-18 11:40:00.130' AS DateTime), 1, 2035, N'Your Car 2016 Maruti Brezza LDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2096, CAST(N'2017-09-18 12:04:52.593' AS DateTime), 1, 2, N'Your Car 1964 BMW BMW M3 Sedan is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2097, CAST(N'2017-09-18 12:05:35.370' AS DateTime), 1014, 1014, N'Your Car 1965 Subaru 2017 BRZ Impreza is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2098, CAST(N'2017-09-18 12:11:50.977' AS DateTime), 1013, 1013, N'Your Car 2001 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2099, CAST(N'2017-09-18 12:12:02.117' AS DateTime), 1006, 1006, N'Your Car 2016 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2100, CAST(N'2017-09-18 12:13:00.627' AS DateTime), 2, 2, N'Your Car 1964 BMW BMW M3 Sedan is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2101, CAST(N'2017-09-18 12:13:50.073' AS DateTime), 1013, 1013, N'Your Car 1950 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2102, CAST(N'2017-09-18 12:15:00.160' AS DateTime), 1014, 1014, N'Your Car 1965 Subaru 2017 BRZ Impreza is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2128, CAST(N'2017-09-28 14:07:16.303' AS DateTime), 1, 2037, N'Your Car 2010 Audi A1 8X is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2174, CAST(N'2017-11-03 13:33:10.480' AS DateTime), 1014, 1014, N'Your Event Bahrain Motor Show is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2194, CAST(N'2017-11-07 14:45:37.207' AS DateTime), 2016, 2016, N'Your Car 2017 BMW 120i E87 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2079, CAST(N'2017-09-16 00:58:29.340' AS DateTime), 2021, 2021, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2132, CAST(N'2017-10-04 05:42:23.337' AS DateTime), 1, 1014, N'Your Car 1965 Subaru Brumby Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2138, CAST(N'2017-10-06 06:35:56.893' AS DateTime), 1014, 1014, N'Your Event Subbie show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2147, CAST(N'2017-10-09 08:05:41.230' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2163, CAST(N'2017-10-12 11:17:32.333' AS DateTime), 1, 1013, N'Your Car 2016 BMW 120i E87 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2177, CAST(N'2017-11-06 07:00:59.483' AS DateTime), 2034, 2034, N'Your Event Audi Black is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2178, CAST(N'2017-11-06 07:02:25.543' AS DateTime), 2036, 2036, N'Your Event Test Title is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2179, CAST(N'2017-11-06 07:04:05.420' AS DateTime), 2036, 2036, N'Your Event Test Title is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2180, CAST(N'2017-11-06 07:04:16.157' AS DateTime), 2036, 2036, N'Your Event Test Title is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2118, CAST(N'2017-09-20 22:27:31.103' AS DateTime), 2038, 2038, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2119, CAST(N'2017-09-21 05:29:37.847' AS DateTime), 1, 2038, N' Your Profile is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2126, CAST(N'2017-09-25 07:22:21.000' AS DateTime), 2036, 2036, N'Your Event Nexa Event 1 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2142, CAST(N'2017-10-09 07:56:20.903' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2145, CAST(N'2017-10-09 08:04:43.537' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2149, CAST(N'2017-10-09 08:43:33.203' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2155, CAST(N'2017-10-09 10:42:30.780' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2156, CAST(N'2017-10-09 10:43:15.080' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2158, CAST(N'2017-10-09 13:51:50.203' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2160, CAST(N'2017-10-09 13:57:04.253' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2125, CAST(N'2017-09-23 03:37:58.493' AS DateTime), 2041, 2041, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2137, CAST(N'2017-10-06 06:35:30.133' AS DateTime), 1014, 1014, N'Your Event Subbie show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2143, CAST(N'2017-10-09 07:59:11.737' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Baleno Sigma 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2157, CAST(N'2017-10-09 11:34:50.747' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2162, CAST(N'2017-10-09 13:58:02.237' AS DateTime), 1, 2035, N'Your Car 2016 Maruti Brezza LDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2190, CAST(N'2017-11-06 14:41:34.567' AS DateTime), 1014, 1014, N'Your Event Bahrain Motor Show is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2129, CAST(N'2017-10-04 05:40:02.303' AS DateTime), 1, 1014, N'Your Car 1965 Subaru Brumby Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2130, CAST(N'2017-10-04 05:40:15.327' AS DateTime), 1, 1014, N'Your Car 1965 Subaru Brumby Impreza is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2150, CAST(N'2017-10-09 09:27:31.947' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2175, CAST(N'2017-11-04 13:19:03.303' AS DateTime), 2034, 2034, N'Your Event Audi Red is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2176, CAST(N'2017-11-04 13:20:37.597' AS DateTime), 2034, 2034, N'Your Event Hundai Sonata is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2151, CAST(N'2017-10-09 09:30:35.697' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2153, CAST(N'2017-10-09 09:43:41.733' AS DateTime), 1, 2033, N'Your Car 2016 Maruti Brezza VDi is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2169, CAST(N'2017-10-24 06:57:58.743' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2171, CAST(N'2017-10-24 07:34:49.943' AS DateTime), 2034, 2034, N'Your Event Audi Red is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2188, CAST(N'2017-11-06 12:45:38.663' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2189, CAST(N'2017-11-06 12:46:32.927' AS DateTime), 2034, 2034, N'Your Event mercedes benz1 is DisApproved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2195, CAST(N'2017-12-08 08:09:52.393' AS DateTime), 1, 2034, N'Your Car 2017 Maruti Ciaz S 1.3 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2197, CAST(N'2017-12-08 09:49:40.083' AS DateTime), 1, 1013, N'Your Car 2005 Subaru Impreza G4 is being reviewed by the MYCARYARD team.', N'1')
GO
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2198, CAST(N'2017-12-08 09:49:47.807' AS DateTime), 1013, 1013, N'Your Car 2005 Subaru Impreza G4 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2199, CAST(N'2017-12-18 05:51:09.300' AS DateTime), 2042, 2042, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2203, CAST(N'2018-01-19 08:03:49.327' AS DateTime), 2034, 2034, N'Your Car 2017 Maruti Baleno Delta 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2204, CAST(N'2018-01-19 08:43:00.243' AS DateTime), 2034, 2034, N'Your Car 2017 Maruti Baleno Delta 1.2 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2208, CAST(N'2018-02-08 13:11:37.297' AS DateTime), 1014, 1014, N'Your Event Test Car is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2209, CAST(N'2018-02-08 13:11:54.530' AS DateTime), 1014, 1014, N'Your Event Holden Meet up is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2196, CAST(N'2017-12-08 08:10:20.410' AS DateTime), 1, 2034, N'Your Car 2017 Maruti Baleno Delta 1.2 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2201, CAST(N'2018-01-19 07:37:08.637' AS DateTime), 2034, 2034, N'Your Car 2012 Subaru BRZ Z1 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2202, CAST(N'2018-01-19 07:37:47.337' AS DateTime), 2034, 2034, N'Your Car 2012 Subaru BRZ Z1 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2205, CAST(N'2018-01-19 10:04:46.597' AS DateTime), 2034, 2034, N'Your Car 2017 Maruti Baleno Delta 1.2 is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2206, CAST(N'2018-01-19 10:46:04.433' AS DateTime), 2034, 2034, N'Your Car 2017 Maruti Baleno Delta 1.2 is being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2207, CAST(N'2018-02-05 03:18:24.203' AS DateTime), 2045, 2045, N'Your details are being reviewed by the MYCARYARD team.', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2210, CAST(N'2018-02-08 14:28:32.763' AS DateTime), 1014, 1014, N'Your Event Bahrain Motor Show is Approved By Super Admin', N'1')
INSERT [dbo].[UserNotification] ([NID], [edate], [fromuid], [touid], [msg], [status]) VALUES (2200, CAST(N'2018-01-07 12:04:22.133' AS DateTime), 2044, 2044, N'Your details are being reviewed by the MYCARYARD team.', N'1')
SET IDENTITY_INSERT [dbo].[UserNotification] OFF
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
/****** Object:  StoredProcedure [dbo].[AddBadgeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddBadgeType]
	-- Add the parameters for the stored procedure here
	@make_id	int,
	@model_id	int,
	@badge	nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into BadgeTypeMaster(make_id,model_id,badge_type,status) values(@make_id,@model_id,@badge,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddCar]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCar]
	-- Add the parameters for the stored procedure here
	@uid int,
	@make int,
	@model int,
	@badge int,
	@series int,	
	@price nvarchar(200),
	@currency int,
	@list nvarchar(200),
	@condition int,
@descr nvarchar(max),
@body_type int,
@bcolor int,
@icolor int,
@year int,
@material int,
@transmition int,
@drive int ,
@cylinder int,
@meter nvarchar(max),
@engine nvarchar(200),
@matrics int,
--@img nvarchar(max),
--@img1 nvarchar (max),
--@img2 nvarchar (max),
@speedtype nvarchar(200),
@fuel nvarchar(200),
-- output values 
@carid int output


AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--	insert into tbl_carmaster(uid,make,price,subject,date,time,descr,body_type,color,year,fuel,transmition,gear,brand,model,engine,km,status,img,img1,img2) values(@uid,@make,@price,@subject,@date,@time,@descr,@body_type,@color,@year,@fuel,@transmition,@gear,@brand,@model,@engine,@km,0,@img,@img1,@img2)
    DECLARE @Utype nvarchar(50)
	select @Utype= type from tbl_login where id= @uid
	if(@Utype='free')
		begin
		   DECLARE @Carcount int 
		   SELECT @Carcount=COUNT(dbo.tbl_carmaster.cid) FROM dbo.tbl_carmaster WHERE tbl_carmaster.uid = @uid
		   IF(@Carcount>=3)
		     Begin
			    set @carid = -1
			 End
           Else
		     Begin
			   insert into tbl_carmaster(uid,make,price,descr,body_type,bcolor,year,transmition,model,engine,status,badge,series,currency,list,condition,icolor,material,drive,cylinder,meter,matrics,speedtype,fuel,gstatus,created_date,star) values(@uid,@make,@price,@descr,@body_type,@bcolor,@year,@transmition,@model,@engine,0,@badge,@series,@currency,@list,@condition,@icolor,@material,@drive,@cylinder,@meter,@matrics,@speedtype,@fuel,@list,GETUTCDATE(),'0')
				if @@ROWCOUNT > 0
				begin
				set @carid = @@IDENTITY
				end
			 End
		end
	else
	  Begin
		insert into tbl_carmaster(uid,make,price,descr,body_type,bcolor,year,transmition,model,engine,status,badge,series,currency,list,condition,icolor,material,drive,cylinder,meter,matrics,speedtype,fuel,gstatus,created_date,star) values(@uid,@make,@price,@descr,@body_type,@bcolor,@year,@transmition,@model,@engine,0,@badge,@series,@currency,@list,@condition,@icolor,@material,@drive,@cylinder,@meter,@matrics,@speedtype,@fuel,@list,GETUTCDATE(),'0')
		if @@ROWCOUNT > 0
		begin
		set @carid = @@IDENTITY
		end
      End
END



GO
/****** Object:  StoredProcedure [dbo].[AddCity]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCity]
	-- Add the parameters for the stored procedure here
@count_id	int,
@state_id	int,
@city nvarchar(max),
@status	int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select 1 from CityMaster where  city= RTRIM(LTRIM(@city)) and state_id=@state_id)
	begin
	
		Select 'Exists'
	end
	else
	begin

    -- Insert statements for procedure here
	insert into CityMaster(count_id,state_id,city,status) values(@count_id,@state_id,@city,@status)
	Select 'Success'
   end
END



GO
/****** Object:  StoredProcedure [dbo].[AddCondition]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCondition]
	-- Add the parameters for the stored procedure here
	@condition nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into ConditionMaster(condition,status) values(@condition,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[Addcustomer]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Addcustomer]
	-- Add the parameters for the stored procedure here
@cust_id nvarchar(max),
	@plan_id int=null,
	@regdate nvarchar(50)=null,
	@validdate nvarchar(50)=null,
	@name nvarchar(50)=null,
	@cno nvarchar(50)=null,
	@email nvarchar(50)=null,
	@gender nvarchar(20)=null,
	@country int=null,
	@state int=null,
	@city int=null,
	@region int=null,
	@zipcode nvarchar(50)=null,
	--@suburb nvarchar(200)=null,
	@streetname nvarchar(200)=null,
	@street nvarchar(200)=null,
	@pass nvarchar(50)=null,
	@lat nvarchar(200)=null,
	@longi nvarchar(200)=null,
	@apprstatus nvarchar(50)=null,
	--Return values 
	@errorCode int output,
	@errorMessage nvarchar(100) output,
	@customerid nvarchar(200)=null,
	@bname nvarchar(200)=null,
	@ctype nvarchar(200)=null,
	@custid nvarchar(100) output

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    if exists (select * from tbl_login where Cust_id=@customerid)
	begin
		set @errorCode = 4004
		set @errorMessage = 'Customer Code Already Exist'

		return
	end

	INSERT INTO [dbo].[tbl_login]
           ([name]
           ,[email]
           ,[pass]
           ,[type]
           ,[status]
           ,[gender]
           ,[cno]
           ,[country]
           ,[state]
           ,[city]
          
          
           ,[regions]
           --,[suburb]
           ,[zip]
           ,[street]
           ,[streetname]
           ,[late]
           ,[long]
           ,[reg_date]
           ,[valid_date]
           ,[plan_id]
           ,[Cust_id]
           ,[orgname])
     VALUES
           (
		   @name
           ,@email
           ,@pass
           ,@ctype
           ,@apprstatus
           ,@gender
           ,@cno
           ,@country
           ,@state
           ,@city
          
         
           ,@region
           --,@suburb
           ,@zipcode
           ,@street
           ,@streetname
           ,@lat
           ,@longi
           ,@regdate
           ,@validdate
           ,@plan_id
           ,@customerid
           ,@bname)


		   if @@ROWCOUNT > 0
		   begin 
				set @custid = @@IDENTITY
		   end

		   SET @errorCode = 0
		   SET @errorMessage = 'Success'
	
END TRY
BEGIN CATCH
	SET @errorCode  = 202
	SET @errorMessage = ERROR_MESSAGE()
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[AddCylinder]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddCylinder]
	-- Add the parameters for the stored procedure here
@cylinder nvarchar(200),
@status nvarchar(50)

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into cylinder_master (cylinder_name,status) values(@cylinder,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddDriveTrain]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddDriveTrain] 
	-- Add the parameters for the stored procedure here
	@drive nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into DrivetrainMaster(drive,status) values(@drive,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddEngine]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddEngine]
	-- Add the parameters for the stored procedure here
@engine nvarchar(max),
@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into EngineMaster(engine,status) values(@engine,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddEngineSize]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddEngineSize]
	-- Add the parameters for the stored procedure here
	@make_id int,
	@model_id int,
	@bad_id int,
	@series int,
	@engsize nvarchar(50),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO EngineSizeMaster(make_id,model_id,bad_id,ser_id,ensize_name,status) values(@make_id,@model_id,@bad_id,@series,@engsize,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddEvent] 
	-- Add the parameters for the stored procedure here
@uid int=0,
@title nvarchar(max)=null,
@subject nvarchar(max)=null,
@edate nvarchar(200)=null,
@etime nvarchar(200)=null,
@address nvarchar(200)=null,
@cno nvarchar(200)=null,
@country int =0,
@state int=0,
@city int=0,
@reason int=0,
--@suburb int,
@code nvarchar(200)=null,
@unit nvarchar(max)=null,
@street nvarchar(max)=null,
@sname nvarchar(max)=null,
@descr nvarchar(max)=null,
@late nvarchar (max)=null,
@long nvarchar (max)=null,
@cat int=0,
@ispaid int=0,
@price int=0,
@eid int output,
@showphone nvarchar(200)=null,
@sponsorship nvarchar(200)=null,
@sponsorname nvarchar(200)=null

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	--

    -- Insert statements for procedure here

	DECLARE @Utype nvarchar(50)
	select @Utype= type from tbl_login where id= @uid
	if(@Utype='free')
		begin
		   DECLARE @Eventcount int 
		   SELECT @Eventcount=COUNT(dbo.tbl_eventmaster.eid) FROM dbo.tbl_eventmaster WHERE tbl_eventmaster.uid = @uid
		   IF(@Eventcount>=3)
		     Begin
			    set @eid = -1
			 End
           Else
		     Begin
			   Insert into tbl_eventmaster(uid,title,subject,edate,etime,address,cno,country,state,city,descr,status,late,long,reason,code,unit,street,sname,cat,created_date,ispaid,price,shownumber,sponsorship,sponsorname) values(@uid,@title,@subject,@edate,@etime,@address,@cno,@country,@state,@city,@descr,0,@late,@long,@reason,@code,@unit,@street,@sname,@cat,GETDATE(),@ispaid,@price,@showphone,@sponsorship,@sponsorname)
				if @@ROWCOUNT > 0
				begin
				set @eid = @@IDENTITY
				end
			 End
		end
	else
	  Begin
			Insert into tbl_eventmaster(uid,title,subject,edate,etime,address,cno,country,state,city,descr,status,late,long,reason,code,unit,street,sname,cat,created_date,ispaid,price,shownumber,sponsorship,sponsorname) values(@uid,@title,@subject,@edate,@etime,@address,@cno,@country,@state,@city,@descr,0,@late,@long,@reason,@code,@unit,@street,@sname,@cat,GETDATE(),@ispaid,@price,@showphone,
			@sponsorship,@sponsorname)
			if @@ROWCOUNT> 0
			begin
			SET @eid = @@IDENTITY
	        end
	  End
END



GO
/****** Object:  StoredProcedure [dbo].[AddMakeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddMakeType] 
	-- Add the parameters for the stored procedure here
	@make nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
insert into MakeTypeMaster(make_type,status) values(@make,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddModel]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddModel]
	-- Add the parameters for the stored procedure here
	@make_id int,
	@model nvarchar(max),
	@status int	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into ModelMaster(make_id,model,status) values(@make_id,@model,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddOdometer]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddOdometer] 
	-- Add the parameters for the stored procedure here
	@meter nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into OdoMeterMaster(odometer,status) values(@meter,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddReason]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddReason]
	-- Add the parameters for the stored procedure here
	@count_id int,
	@state_id int,
	@city_id	int,
	@reason	nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into ReasonMaster(count_id,state_id,city_id,reason,status) values(@count_id,@state_id,@city_id,@reason,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddRegion]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddRegion]
	-- Add the parameters for the stored procedure here
	@count_id int,
	@state_id int,
	@city_id int,
	@suburb int,
	@region nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO NewRegionMaster(coun_id,state_id,city_id,reas_id,regionname,status) values(@count_id,@state_id,@city_id,@suburb,@region,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddRegions]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[AddRegions]
	-- Add the parameters for the stored procedure here
	@count_id int,
	@state_id int,
	@city_id int,
	@region nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select 1 from ReasonMaster where  reason= RTRIM(LTRIM(@region)) and city_id=@city_id)
	begin
	
		Select 'Exists'
	end
	else
	begin
    -- Insert statements for procedure here
	INSERT INTO ReasonMaster(count_id,state_id,city_id,reason,status) values(@count_id,@state_id,@city_id,@region,@status)
	Select 'Success'
END
END



GO
/****** Object:  StoredProcedure [dbo].[AddSeriesType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSeriesType] 
	-- Add the parameters for the stored procedure here
	@make_id int,
	@model_id int,
	@bad_id int,
	@series nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into SeriesTypeMaster(make_id,model_id,bad_id,series_type,status) values(@make_id,@model_id,@bad_id,@series,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddSpeedType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddSpeedType]
	-- Add the parameters for the stored procedure here
	@speedtype nvarchar(200),
	@status nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into speedtypemaster(speedtypename,status) values(@speedtype,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AddStore]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddStore]
	-- Add the parameters for the stored procedure here
@id int,
@dname nvarchar(100) = null,
@email nvarchar(100)=null,
@pass nvarchar(100)=null,
@city nvarchar(max) = null,
@state nvarchar(max) = null,
@country nvarchar(max) = null,
@zip nvarchar(max) = null,
@gender nvarchar(max) = null,
@cno nvarchar(max) = null,
@regions nvarchar(max) = null,
@street nvarchar(max) = null,
@streetname nvarchar(max) = null,
@fname nvarchar(max) = null,
@lname nvarchar(max) = null,
@other nvarchar(max) = null,
@other1 nvarchar(max) = null,
@other2 nvarchar(max)= null,
@late nvarchar(max) = null,
@long nvarchar(max) = null,
@showphone nvarchar(max) = null,
@bname nvarchar(max) = NULL,
@Event nvarchar(50)=Null,

--return values
@errorCode int output,
@errorMessage nvarchar (200) output,
@storeid int output

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	
			-- Insert statements for procedure here

			Insert Into tbl_login([name],email,pass,type,status,reg_date,plan_id,valid_date,[gender],
			[cno],[country],[state],[city],[other],[other1],[other2],[fname],[lname],[regions],[zip],
			[street],[streetname],[late],[long],showphone,orgname,parentstore)
			Values(@dname,@email,@pass,'Paid','2',GETDATE(),'0',GETDATE(),@gender,@cno,@country,@state,
			@city,@other,@other1,@other2,@fname,@lname,@regions,@zip,@street,@streetname,@late,@long,
			@showphone,@bname,@id)
		

    IF @@ROWCOUNT > 0 
	BEGIN
		SET @storeid = @@IDENTITY
		INSERT INTO UserNotification 
		(
			edate,
			fromuid,
			touid,
			msg,
			status
		)
		VALUES
		(
		GETDATE(),
		@storeid,
		@storeid,
		'Your details are being reviewed by the MYCARYARD team.',
		'1'
		)
	END
	SET @errorCode = 0
	SET @errorMessage = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[AddTransmision]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddTransmision]
	-- Add the parameters for the stored procedure here
	@transmision nvarchar(max),
	
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into TransmisionMaster(transmision,status) values(@transmision,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[AdvanceSearchCar]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdvanceSearchCar] 
	-- Add the parameters for the stored procedure here
	@make nvarchar(max) = NULL,
	@model nvarchar(max) = NULL,
	@series nvarchar(max) = NULL,
	@badge nvarchar(max) = NULL,
	@condition nvarchar(max) = NULL,
	@transmission nvarchar(max) = NULL,
	@fyear nvarchar(max) = NULL,
	@tyear nvarchar(MAX) = NULL,
	@country nvarchar(max) = NULL,
	@state nvarchar(max) = NULL,
	@minprice nvarchar(max) = NULL,
	@maxprice nvarchar(max)= NULL,
	@keyword nvarchar(max) = NULL

AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @SQLQ NVARCHAR(MAX)

	SET @SQLQ = 'SELECT q.reason as regionname,p.city as cityname,b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as currencyname,j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as bodytypename,k.zip,k.cno,k.orgname,isnull(k.showphone,0) as showphone from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p,ReasonMaster q where q.reas_id = k.regions and p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and g.ser_id=a.series and f.bad_id=a.badge and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.gstatus=0'
    
	IF @make != 'null'
	BEGIN
    SET @SQLQ = @SQLQ + 'and a.make in ('+@make+')' 
	END
	if @model != 'null'
	begin
	  SET @SQLQ = @SQLQ + 'and a.model in ('+@model+')' 
	end
	
	if @series != 'null'
	begin
		SET @SQLQ = @SQLQ + 'and a.badge in ('+@series+')' 
	end

	if @badge != 'null'
	begin
		SET @SQLQ = @SQLQ + 'and a.series in ('+@badge+')' 
	end

	if @condition != 'null'
	begin
		SET @SQLQ = @SQLQ + 'and a.condition in ('+@condition+')' 
	end
	if @transmission != 'null'
	begin
	   SET @SQLQ = @SQLQ + 'and a.transmition in ('+@transmission+')' 
	end
 --   if @fyear != '0'  OR @tyear !='0'
	--begin
	--	SET @SQLQ = @SQLQ + 'and a.year between '+@fyear+' and '+@tyear+'' ----Change 27/4/2017 by Shailendra
	--end
	 if @fyear != '0'  OR @tyear !='0'
	begin
		SET @SQLQ = @SQLQ + 'and a.year between '+@fyear+' and '+@tyear+'' 
	end

	if @country != '0'
	begin
		SET @SQLQ = @SQLQ + 'and b.count_id ='+@country 
	end

	if @state != '0'
	begin
		SET @SQLQ = @SQLQ + 'and k.state ='+@state 
	end

	if @minprice != '0'
	begin
		SET @SQLQ = @SQLQ + 'and a.price between '+@minprice+' and '+@maxprice+'' 
	end

	if @minprice = '0' and @maxprice!='0'
	begin
		SET @SQLQ = @SQLQ + 'and a.price between '+@minprice+' and '+@maxprice+'' 
	end

	if @keyword != 'null'
	begin
		--SET @SQLQ = @SQLQ + 'and d.make_type like ''%' + @keyword + '%'' or e.model like ''%' + @keyword + '%'' or f.badge_type like ''%' + @keyword + '%'' or g.series_type like ''%' + @keyword + '%'
		SET @SQLQ = @SQLQ + ' and a.descr like '+ Concat('''%',@keyword,'%''')

	end
	--print @SQLQ
	EXEC sp_executesql @SQLQ





GO
/****** Object:  StoredProcedure [dbo].[AdvanceSearchCarMap]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdvanceSearchCarMap] 
	-- Add the parameters for the stored procedure here
	@make nvarchar(max) = NULL,
	@model nvarchar(max) = NULL,
	@series nvarchar(max) = NULL,
	@badge nvarchar(max) = NULL,
	@condition nvarchar(max) = NULL,
	@transmission nvarchar(max) = NULL,
	@fyear nvarchar(max) = NULL,
	@tyear nvarchar(MAX) = NULL,
	@country nvarchar(max) = NULL,
	@state nvarchar(max) = NULL,
	@minprice nvarchar(max) = NULL,
	@maxprice nvarchar(max)= NULL,
	@keyword nvarchar(max) = NULL

AS

	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @SQLQ NVARCHAR(MAX)

	SET @SQLQ = 'SELECT k.*,b.country_name,c.state_name,q.reason as regionname,p.city as cityname from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p,ReasonMaster q where q.reas_id = k.regions and p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and g.ser_id=a.series and f.bad_id=a.badge and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id  and a.status = 1 and a.gstatus=0'
    
	IF @make != 'null'
	BEGIN
    SET @SQLQ = @SQLQ + 'and a.make in ('+@make+')' 
	END
	if @model != 'null'
	begin
	  SET @SQLQ = @SQLQ + 'and a.model in ('+@model+')' 
	end
	
	if @series != 'null'
	begin
		SET @SQLQ = @SQLQ + 'and a.badge in ('+@series+')' 
	end

	if @badge != 'null'
	begin
		SET @SQLQ = @SQLQ + 'and a.series in ('+@badge+')' 
	end

	if @condition != 'null'
	begin
		SET @SQLQ = @SQLQ + 'and a.condition in ('+@condition+')' 
	end
	if @transmission != 'null'
	begin
	   SET @SQLQ = @SQLQ + 'and a.transmition in ('+@transmission+')' 
	end
    if @fyear != '0' 
	begin
		SET @SQLQ = @SQLQ + 'and a.year between '+@fyear+' and '+@tyear+'' 
	end
	if @country != '0'
	begin
		SET @SQLQ = @SQLQ + 'and b.count_id ='+@country 
	end

	if @state != '0'
	begin
		SET @SQLQ = @SQLQ + 'and k.state ='+@state 
	end

	if @minprice != '0'
	begin
		SET @SQLQ = @SQLQ + 'and a.price between '+@minprice+' and '+@maxprice+'' 
	end

	if @minprice = '0' and @maxprice!='0'
	begin
		SET @SQLQ = @SQLQ + 'and a.price between '+@minprice+' and '+@maxprice+'' 
	end

	if @keyword != 'null'
	begin
		SET @SQLQ = @SQLQ + ' and a.descr like '+ Concat('''%',@keyword,'%''')

	end

	EXEC sp_executesql @SQLQ





GO
/****** Object:  StoredProcedure [dbo].[AdvanceSearchEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdvanceSearchEvent] 
	-- Add the parameters for the stored procedure here
@cat nvarchar(max) = NULL,
@eventdue nvarchar(max) = NULL,
@country nvarchar(max) = NULL,
@state nvarchar(max) = NULL,
@keyword nvarchar(max) = NULL,
@spons nvarchar(max) = NULL,
@loginid nvarchar(max)=null

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @SQLQ NVARCHAR(MAX)

	--SET @SQLQ = 'SELECT  e.city as cityname,f.reason as regionname,b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as going from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d,citymaster e,ReasonMaster f where e.city_id=a.city and f.reas_id=a.reason and b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1'
	--if @cat != 'null'
	--begin
	--	SET @SQLQ = @SQLQ + ' and a.cat in ('+@cat+')'
	--end

	--if @spons != 'null'
	--begin
	--	SET @SQLQ = @SQLQ + ' and a.sponsorship in ('+@spons+')'
	--end

	--if @eventdue != '0'
	--begin
	--	if @eventdue = '1'
	--	begin
	--		SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,2,GETDATE())) as date)'
	--	end
	--	if @eventdue = '7'
	--	begin
	--		SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,7,GETDATE())) as date)'
	--	end
	--	if @eventdue = '14'
	--	begin
	--		SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,14,GETDATE())) as date)'
	--	end
	--	if @eventdue = '30'
	--	begin
	--		SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,30,GETDATE())) as date)'
	--	end
	--end
    
	--if @country != '0'
	--begin
	--	SET @SQLQ = @SQLQ + ' and a.country='+@country
	--end

	--if @state != '0'
	--begin
	--	SET @SQLQ = @SQLQ + ' and a.state='+@state
	--end

	--if @keyword != 'null'
	--begin

	--SET @SQLQ = @SQLQ + ' and a.title like ''%' + @keyword + '%'''
	--end


    SET @SQLQ='SELECT  dbo.CityMaster.city AS cityname, dbo.ReasonMaster.reason AS regionname, dbo.tbl_country_master.country_name, dbo.tbl_state_master.state_name, dbo.tbl_eventmaster.*, dbo.tbl_login.name,(select count(*) from dbo.eventgoingmaster where dbo.eventgoingmaster.eid=dbo.tbl_eventmaster.eid) as going'

	if @loginid !='Null'
	Begin
		SET @SQLQ=@SQLQ +',(select count(*) from dbo.eventgoingmaster where dbo.eventgoingmaster.eid=dbo.tbl_eventmaster.eid and dbo.eventgoingmaster.uid='+@loginid+') as goORgoing'
    End
	Else
	Begin
	SET @SQLQ=@SQLQ +','''' as goORgoing'
	End
	

 SET @SQLQ=@SQLQ + ' FROM            dbo.CityMaster INNER JOIN
                         dbo.tbl_eventmaster ON dbo.CityMaster.city_id = dbo.tbl_eventmaster.city INNER JOIN
                         dbo.ReasonMaster ON dbo.tbl_eventmaster.reason = dbo.ReasonMaster.reas_id INNER JOIN
                         dbo.tbl_country_master ON dbo.tbl_eventmaster.country = dbo.tbl_country_master.count_id INNER JOIN
                         dbo.tbl_state_master ON dbo.tbl_eventmaster.state = dbo.tbl_state_master.state_id INNER JOIN
                         dbo.tbl_login ON dbo.tbl_eventmaster.uid = dbo.tbl_login.id
WHERE        (dbo.tbl_eventmaster.status = 1) and dbo.tbl_eventmaster.edate>=getdate()'


	if @cat != 'null'
	begin
		SET @SQLQ = @SQLQ + ' and dbo.tbl_eventmaster.cat in ('+@cat+')'
	end

	if @spons != 'null'
	begin
		SET @SQLQ = @SQLQ + ' and dbo.tbl_eventmaster.sponsorship in ('+@spons+')'
	end

	if @eventdue != '0'
	begin
		if @eventdue = '1'
		begin
			SET @SQLQ = @SQLQ + ' and cast(dbo.tbl_eventmaster.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,2,GETDATE())) as date)'
		end
		if @eventdue = '7'
		begin
			SET @SQLQ = @SQLQ + ' and cast(dbo.tbl_eventmaster.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,7,GETDATE())) as date)'
		end
		if @eventdue = '14'
		begin
			SET @SQLQ = @SQLQ + ' and cast(dbo.tbl_eventmaster.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,14,GETDATE())) as date)'
		end
		if @eventdue = '30'
		begin
			SET @SQLQ = @SQLQ + ' and cast(dbo.tbl_eventmaster.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,30,GETDATE())) as date)'
		end
	end
    
	if @country != '0'
	begin
		SET @SQLQ = @SQLQ + ' and dbo.tbl_eventmaster.country='+@country
	end

	if @state != '0'
	begin
		SET @SQLQ = @SQLQ + ' and dbo.tbl_eventmaster.state='+@state
	end

	if @keyword != 'null'
	begin

	SET @SQLQ = @SQLQ + ' and dbo.tbl_eventmaster.title like ''%' + @keyword + '%'''
	end
	
	print @SQLQ
	EXEC sp_executesql @SQLQ
END TRY
BEGIN CATCH
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[AdvanceSearchEventMap]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AdvanceSearchEventMap] 
	-- Add the parameters for the stored procedure here
@cat nvarchar(max) = NULL,
@eventdue nvarchar(max) = NULL,
@country nvarchar(max) = NULL,
@state nvarchar(max) = NULL,
@keyword nvarchar(max) = NULL,
@spons nvarchar(max) = NULL

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @SQLQ NVARCHAR(MAX)

	SET @SQLQ = 'SELECT  a.*,g.category,e.city as cityname,f.reason as regionname,b.country_name,c.state_name,(select count(*) from eventgoingmaster where eid=a.eid) as going from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d,citymaster e,ReasonMaster f,tbl_eventcat_master g where g.ecat_id=a.cat and e.city_id=a.city and f.reas_id=a.reason and b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.status = 1'
    
	if @cat != 'null'
	begin
		SET @SQLQ = @SQLQ + ' and a.cat in ('+@cat+')'
	end

	if @spons != ''
	begin
		SET @SQLQ = @SQLQ + ' and a.sponsorship in ('+@spons+')'
	end

	if @eventdue != '0'
	begin
		if @eventdue = '1'
		begin
			SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,2,GETDATE())) as date)'
		end
		if @eventdue = '7'
		begin
			SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,7,GETDATE())) as date)'
		end
		if @eventdue = '14'
		begin
			SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,14,GETDATE())) as date)'
		end
		if @eventdue = '30'
		begin
			SET @SQLQ = @SQLQ + ' and cast(a.edate as date) between cast(GETDATE() as date) and cast((DATEADD(day,30,GETDATE())) as date)'
		end
	end
    
	if @country != '0'
	begin
		SET @SQLQ = @SQLQ + ' and a.country='+@country
	end

	if @state != '0'
	begin
		SET @SQLQ = @SQLQ + ' and a.state='+@state
	end

	if @keyword != 'null'
	begin
	SET @SQLQ = @SQLQ + ' and a.title like ''%' + @keyword + '%'''
	end

	EXEC sp_executesql @SQLQ
END TRY
BEGIN CATCH
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[CarCount]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CarCount]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT COUNT(*) FROM tbl_carmaster  where status = 1 and gstatus = 0 
END



GO
/****** Object:  StoredProcedure [dbo].[CarDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[CarDetails] 
	-- Add the parameters for the stored procedure here
@cid int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',r.city as 'cityname',n.ensize_name,o.Inter_Mat_Name,p.Inter_color_name,q.body_color_name,b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,l.condition,m.drive,k.id,a.*,k.name,k.zip,k.cno,k.orgname,isnull(k.showphone,0) as 'showphone',s.Body_Type as 'bodytypename',t.reason as 'regionname',u.speedtypename,v.cylinder_name,k.email from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k, ConditionMaster l,DrivetrainMaster m,EngineSizeMaster n,Interior_MaterialMaster o,Interior_ColorMaster p,Body_ColorMaster q,CityMaster r,Body_TypeMaster s,ReasonMaster t,SpeedTypeMaster u,Cylinder_Master v  where v.cylinder_id=a.cylinder and u.speedtypeid=a.speedtype and t.reas_id=k.regions and s.Body_type_id=a.body_type and r.city_id=k.city and n.ensize_id=a.engine and o.Inter_Mat_Id=a.material and p.Inter_color_id=a.icolor and q.body_color_id=a.bcolor and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.count_id=b.count_id and j.odo_id=a.matrics and k.id=a.uid and b.count_id=k.country and k.state=c.state_id and a.cid=@cid and l.cond_id=a.condition and m.driv_id=a.drive
END



GO
/****** Object:  StoredProcedure [dbo].[ChangeCarGStatus]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChangeCarGStatus]
	-- Add the parameters for the stored procedure here
	@cid int,
	@status nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_carmaster set gstatus = @status,created_date=GETUTCDATE() where cid = @cid
END



GO
/****** Object:  StoredProcedure [dbo].[ChangeCarStatus]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChangeCarStatus]
	-- Add the parameters for the stored procedure here
	@cid int,
	@status nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_carmaster set status = @status,created_date=GETUTCDATE() where cid = @cid

	DECLARE @uid nvarchar(max)
	DECLARE @msg nvarchar(max)
	DECLARE @year nvarchar(max)
	DECLARE @make nvarchar(max)
	DECLARE @model nvarchar(max)
	DECLARE @badge nvarchar(max)
	set @uid = (select uid from tbl_carmaster where cid = @cid)
	SET @year = (select year from tbl_carmaster where cid = @cid)
	SET @make = (select a.make_type from MakeTypeMaster a,tbl_carmaster b where a.make_id=b.make and b.cid=@cid)
	SET @model = (select a.model from ModelMaster a,tbl_carmaster b where a.model_id=b.model and b.cid=@cid)
	SET @badge = (select a.badge_type from BadgeTypeMaster a,tbl_carmaster b where a.bad_id=b.badge and b.cid=@cid)

	SET @msg = 'Your Car ' + @year + ' ' + @make + ' ' + @model + ' ' + @badge 

	if @status = '0'
	begin
		SET @msg += ' is being reviewed by the MYCARYARD team.'
	end
	else if @status = '1'
	begin
	   SET @msg += ' is Approved By Super Admin'
	end
	else 
	begin
		SET @msg += ' is DisApproved By Super Admin'
	end

	insert into usernotification 
	(
	edate,
	fromuid,
	touid,
	msg,
	status
	)
	values
	(
	GETUTCDATE(),
	@uid,
	@uid,
	@msg,
	'1'
	)


END



GO
/****** Object:  StoredProcedure [dbo].[ChangeEventStatus]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ChangeEventStatus]
	-- Add the parameters for the stored procedure here
	@eid int,
	@status nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_eventmaster set status = @status where eid = @eid


	Declare @title as nvarchar(max)
	Declare @uid as int
	Declare @msg as nvarchar(max)
	select @title = title,@uid=uid from tbl_eventmaster where eid=@eid

	SET @msg = 'Your Event ' + @title	
	
	if @status = '0'
	begin
		SET @msg += ' is being reviewed by the MYCARYARD team.'
	end
	else if @status = '1'
	begin
	   SET @msg += ' is Approved By Super Admin'
	end
	else 
	begin
		SET @msg += ' is DisApproved By Super Admin'
	end


	insert into usernotification 
	(
	edate,
	fromuid,
	touid,
	msg,
	status
	)
	values
	(
	GETUTCDATE(),
	@uid,
	@uid,
	@msg,
	'1'
	)


END



GO
/****** Object:  StoredProcedure [dbo].[changepassword]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[changepassword]
	-- Add the parameters for the stored procedure here
	@id nvarchar(max),
	@oldpass nvarchar(max),
	@newpass nvarchar(max),
	@status nvarchar(max) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if(@oldpass='forgotpassword')
	begin
	if EXISTS(select 1 from tbl_login where id = @id)
	begin
		Update tbl_login set pass=@newpass where id = @id
		SET @status = 'Success'
	end
	end 
	Else
	begin
	if EXISTS(select 1 from tbl_login where id = @id and pass=@oldpass)
	begin
		Update tbl_login set pass=@newpass where id = @id
		SET @status = 'Success'
	end
	else
	begin
		SET @status = 'Old Password does not match please enter correct password'
	end
	end
	
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteBadgeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBadgeType]
	-- Add the parameters for the stored procedure here
	@badid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from BadgeTypeMaster where bad_id=@badid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteBodyColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBodyColor]
	-- Add the parameters for the stored procedure here
	@bodycolorid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Body_ColorMaster where body_color_id=@bodycolorid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteBodyType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBodyType]
	-- Add the parameters for the stored procedure here
	@bodytypeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
delete from Body_TypeMaster  where Body_type_id=@bodytypeid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCar]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCar]
	-- Add the parameters for the stored procedure here
	@cid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from tbl_carmaster where cid = @cid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCity]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCity]
	-- Add the parameters for the stored procedure here
	@cityid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from CityMaster where city_id=@cityid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCondition]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCondition]
	-- Add the parameters for the stored procedure here
	@conditionid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from ConditionMaster where cond_id=@conditionid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCountry]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCountry]
	-- Add the parameters for the stored procedure here
	@count_id int
	as
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select 1 from tbl_state_master where count_id=@count_id)
	begin
	
		Select 'ExistsChild'
	end
	else
	begin
    -- Insert statements for procedure here
	Delete from tbl_country_master where count_id=@count_id
	Select 'Success'
	end
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCurrency]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCurrency] 
	-- Add the parameters for the stored procedure here
	@cur_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from tbl_currency_master where cur_id=@cur_id
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteCylinder]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteCylinder]
	-- Add the parameters for the stored procedure here
	@cylinderid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from Cylinder_Master where cylinder_id=@cylinderid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteDriveTrain]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDriveTrain]
	-- Add the parameters for the stored procedure here
	@drivetid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from DrivetrainMaster where driv_id = @drivetid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteEngineSizeMaster]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEngineSizeMaster]
	-- Add the parameters for the stored procedure here
@engsizeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from EngineSizeMaster where ensize_id=@engsizeid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEvent]
	-- Add the parameters for the stored procedure here
	@eid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from tbl_eventmaster where eid = @eid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteEventCategoryNew]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteEventCategoryNew]
	-- Add the parameters for the stored procedure here
  @catid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from tbl_eventcat_master where ecat_id=@catid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteFuelMaster]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteFuelMaster]
	-- Add the parameters for the stored procedure here
	@fuelid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Fuel_Master where fuel_id=@fuelid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteGoindToEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteGoindToEvent]
	-- Add the parameters for the stored procedure here
	@uid int,
	@eid int,
	@email nvarchar(50),
	--output
	@errorCode int output,
	@errorMessage nvarchar(200) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	DELETE FROM EventGoingMaster WHERE uid=@uid AND eid=@eid AND email=@email
	
	SET @errorCode = 0
	SET @errorMessage = 'Success'
	
END TRY
BEGIN CATCH
set @errorCode = 2002
set @errorMessage = ERROR_MESSAGE()
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[DeleteInteriorColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteInteriorColor]
	-- Add the parameters for the stored procedure here
	@intcolorid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Interior_ColorMaster where Inter_color_id=@intcolorid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteInteriorMaterial]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteInteriorMaterial]
	-- Add the parameters for the stored procedure here
	@intmatid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from Interior_MaterialMaster where Inter_Mat_Id=@intmatid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteListedAs]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteListedAs]
	-- Add the parameters for the stored procedure here
	@listid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from ListedAs_Master where listed_id=@listid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteMakeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMakeType]
	-- Add the parameters for the stored procedure here
	@makeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from MakeTypeMaster where make_id=@makeid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteMeter]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteMeter]
	-- Add the parameters for the stored procedure here
	@meterid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from OdoMeterMaster where odo_id= @meterid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteModel]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteModel]
	-- Add the parameters for the stored procedure here
	@modelid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from ModelMaster where model_id=@modelid
END



GO
/****** Object:  StoredProcedure [dbo].[DeletePlan]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeletePlan]
	-- Add the parameters for the stored procedure here
	@planid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from tbl_plan_master where plan_id=@planid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteReason]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteReason]
	-- Add the parameters for the stored procedure here
	@regionid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from ReasonMaster where reas_id=@regionid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteRegion]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteRegion]
	-- Add the parameters for the stored procedure here
@regionid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from NewRegionMaster where  regionid=@regionid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteSeriesType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSeriesType]
	-- Add the parameters for the stored procedure here
	@serid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from SeriesTypeMaster where ser_id=@serid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteSpeedtype]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSpeedtype]
	-- Add the parameters for the stored procedure here
	@speedtypeid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from speedtypemaster where speedtypeid = @speedtypeid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteState]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteState]
	-- Add the parameters for the stored procedure here
@state_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists(select 1 from [CityMaster] where [state_id]=@state_id)
	begin
	
		Select 'ExistsChild'
	end
	else
	begin
    -- Insert statements for procedure here
	Delete from tbl_state_master where state_id=@state_id
	Select 'Success'
	end

    -- Insert statements for procedure here
	
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteTransmision]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTransmision]
	-- Add the parameters for the stored procedure here
	@transid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Delete from TransmisionMaster where trans_id=@transid
END



GO
/****** Object:  StoredProcedure [dbo].[DeleteUser]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	delete from tbl_login where id = @id
END



GO
/****** Object:  StoredProcedure [dbo].[EditCar]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditCar]
	-- Add the parameters for the stored procedure here
	@cid int,
		--@uid int,
	@make nvarchar(200),
	@price nvarchar(200),
@badge int,
@series int,
@descr nvarchar(max),
@body_type nvarchar(200),
@bcolor nvarchar(200),
@icolor nvarchar(200),
@year nvarchar(200),
@transmition nvarchar(200),
@currency int,
@list nvarchar(200),
@model nvarchar(200),
@engine nvarchar(200),
@condition int,
@material nvarchar(max),
@drive int ,
@cylinder int,
@meter nvarchar(max),
@matrics int,
@speedtype nvarchar(50),
@fuel nvarchar(50),
@addeddate nvarchar(50),
@status nvarchar(50),
@gstatus nvarchar(50),
@listid nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
--	insert into tbl_carmaster(uid,make,price,subject,date,time,descr,body_type,color,year,fuel,transmition,gear,brand,model,engine,km,status,img,img1,img2) values(@uid,@make,@price,@subject,@date,@time,@descr,@body_type,@color,@year,@fuel,@transmition,@gear,@brand,@model,@engine,@km,0,@img,@img1,@img2)
	update  tbl_carmaster set make=@make,price=@price,descr=@descr,body_type=@body_type,bcolor=@bcolor,year=@year,transmition=@transmition,model=@model,engine=@engine,status=@status,badge=@badge,series=@series,currency=@currency,list=@list,condition=@condition,icolor=@icolor,material=@material,drive=@drive,cylinder=@cylinder,meter=@meter,matrics=@matrics,speedtype=@speedtype,fuel=@fuel,gstatus=@gstatus,created_date=GETUTCDATE(),listid = @listid where cid = @cid



	DECLARE @uid nvarchar(max)
	DECLARE @msg nvarchar(max)
	DECLARE @year1 nvarchar(max)
	DECLARE @make1 nvarchar(max)
	DECLARE @model1 nvarchar(max)
	DECLARE @badge1 nvarchar(max)
	set @uid = (select uid from tbl_carmaster where cid = @cid)
	SET @year1 = (select year from tbl_carmaster where cid = @cid)
	SET @make1 = (select a.make_type from MakeTypeMaster a,tbl_carmaster b where a.make_id=b.make and b.cid=@cid)
	SET @model1 = (select a.model from ModelMaster a,tbl_carmaster b where a.model_id=b.model and b.cid=@cid)
	SET @badge1 = (select a.badge_type from BadgeTypeMaster a,tbl_carmaster b where a.bad_id=b.badge and b.cid=@cid)

	SET @msg = 'Your Car ' + @year1 + ' ' + @make1 + ' ' + @model1 + ' ' + @badge1 

	if @status = '0'
	begin
		SET @msg += ' is being reviewed by the MYCARYARD team.'
	end
	else if @status = '1'
	begin
	   SET @msg += ' is Approved By Super Admin'
	end
	else 
	begin
		SET @msg += ' is DisApproved By Super Admin'
	end

	insert into usernotification 
	(
	edate,
	fromuid,
	touid,
	msg,
	status
	)
	values
	(
	GETUTCDATE(),
	'1',
	@uid,
	@msg,
	'1'
	)

END



GO
/****** Object:  StoredProcedure [dbo].[editcustomer]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[editcustomer]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@plan_id int=null,
	@regdate nvarchar(50)=null,
	@validdate nvarchar(50)=null,
	@name nvarchar(50)=null,
	@cno nvarchar(50)=null,
	@email nvarchar(50)=null,
	@gender nvarchar(20)=null,
	@country int=null,
	@state int=null,
	@city int=null,
	@region int=null,
	@zipcode nvarchar(50)=null,
	--@suburb nvarchar(200)=null,
	@streetname nvarchar(200)=null,
	@street nvarchar(200)=null,
	@pass nvarchar(50)=null,
	@lat nvarchar(200)=null,
	@longi nvarchar(200)=null,
	@apprstatus nvarchar(50)=null,
	--Return values 
	@errorCode int output,
	@errorMessage nvarchar(100) output,
	@customerid nvarchar(200)=null,
	@bname nvarchar(200)=null,
	@usertype nvarchar(200) = NUll

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if exists (select * from tbl_login where Cust_id=@customerid)
	begin
		set @errorCode = 4004
		set @errorMessage = 'Customer Information is successfully Updated'
	
		update tbl_login SET
	plan_id = @plan_id,
	reg_date = @regdate,
	valid_date  = @validdate,
	name = @name,
	cno = @cno,
	email = @email,
	gender = @gender,
	country = @country,
	state = @state,
	city  = @city,
	regions = @region,
	zip = @zipcode,
	--suburb  =@suburb,
	streetname = @streetname,
	street = @street,
	pass = @pass,
	late = @lat,
	long = @longi,
	status = @apprstatus,
	
	orgname=@bname,
	type = @usertype
	 
	where id = @cust_id
	
		return
	end
    -- Insert statements for procedure here
	update tbl_login SET
	plan_id = @plan_id,
	reg_date = @regdate,
	valid_date  = @validdate,
	name = @name,
	cno = @cno,
	email = @email,
	gender = @gender,
	country = @country,
	state = @state,
	city  = @city,
	regions = @region,
	zip = @zipcode,
	--suburb  =@suburb,
	streetname = @streetname,
	street = @street,
	pass = @pass,
	late = @lat,
	long = @longi,
	status = @apprstatus,
	Cust_id=@customerid,
	orgname=@bname,
	type = @usertype
	 
	where id = @cust_id
	
	Declare @msg nvarchar(max)

	if @apprstatus = '0'
	begin
		SET @msg = 'Your details are being reviewed by the MYCARYARD team.'
	end
	else if @apprstatus = '1'
	begin
	   SET @msg = 'Your Profile is Approved By Super Admin'
	end
	else 
	begin
		SET @msg = 'Your Profile is DisApproved By Super Admin'
	end


	insert into usernotification 
	(
	edate,
	fromuid,
	touid,
	msg,
	status
	)
	values
	(
	GETUTCDATE(),
	@cust_id,
	@cust_id,
	@msg,
	'1'
	)


	SET @errorCode = 0
	SET @errorMessage = 'Success'

END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = 'Internal Server Error'
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[EditEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditEvent] 
	-- Add the parameters for the stored procedure here
	@eid int=0,
@title nvarchar(max)=null,
@subject nvarchar(max)=null,
@edate nvarchar(200)=null,
@etime nvarchar(200)=null,
@address nvarchar(200)=null,
@cno nvarchar(200)=null,
@country int=0,
@state int=0,
@city int=0,
@reason int=0,
--@suburb int,
@code nvarchar(200)=null,
@unit nvarchar(max)=null,
@street nvarchar(max)=null,
@sname nvarchar(max)=null,
@descr nvarchar(max)=null,
@late nvarchar (max)=null,
@long nvarchar (max)=null,
@cat int=0,
@ispaid int=0,
@price int=0,
@status int=0,
@showphone int=0,
@listid nvarchar(200) = NULL,
@sponsorship nvarchar(200)=null,
@sponsorname nvarchar(200)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update tbl_eventmaster SET title=@title,subject=@subject,edate=@edate,etime=@etime,address=@address,cno=@cno,country=@country,state=@state,city=@city,reason=@reason,code=@code,unit=@unit,street=@street,sname=@sname,descr=@descr,late=@late,long=@long,cat=@cat,price=@price,ispaid=@ispaid,status=@status,shownumber=@showphone,listid = @listid,sponsorship=@sponsorship,sponsorname=@sponsorname where eid=@eid

	---Change on 20/5/2017
	Declare @title1 as nvarchar(max)
	Declare @uid1 as int
	Declare @msg1 as nvarchar(max)
	select @title1 = title,@uid1=uid from tbl_eventmaster where eid=@eid

	SET @msg1 = 'Your Event ' + @title	
	
	if @status = '0'
	begin
		SET @msg1 += ' is being reviewed by the MYCARYARD team.'
	end
	else if @status = '1'
	begin
	   SET @msg1 += ' is Approved By Super Admin'
	end
	else 
	begin
		SET @msg1 += ' is DisApproved By Super Admin'
	end


	insert into usernotification 
	(
	edate,
	fromuid,
	touid,
	msg,
	status
	)
	values
	(
	GETUTCDATE(),
	@uid1,
	@uid1,
	@msg1,
	'1'
	)
	---Changes
END



GO
/****** Object:  StoredProcedure [dbo].[EditPlan]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EditPlan] 
	-- Add the parameters for the stored procedure here
	@planid int,
	@planname nvarchar(50),
	@duration int,
	@amnt float,
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_plan_master SET plan_name = @planname,duration=@duration,amnt = @amnt,status  = @status where plan_id=@planid
END



GO
/****** Object:  StoredProcedure [dbo].[FetchCountry]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FetchCountry]
	-- Add the parameters for the stored procedure here
	@count_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_country_master where count_id=@count_id  order by count_id desc
END



GO
/****** Object:  StoredProcedure [dbo].[FetchState]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[FetchState] 
	-- Add the parameters for the stored procedure here
@state_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_state_master where state_id=@state_id 
END



GO
/****** Object:  StoredProcedure [dbo].[ForgotUserPassword]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ForgotUserPassword]
	-- Add the parameters for the stored procedure here
	@UserData nvarchar(100),
	@DataType int
AS
BEGIN
Declare @id int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	if (@DataType=0 )
	begin

			select @id=id from tbl_login where email = @UserData
		
			if (@id>0 )
			begin
			declare @uniqueid nvarchar(50) =  newid()
			Insert into tbl_Tmp_ForgotUserPassword values(@id,@uniqueid,Getdate())
			select @uniqueid
			end
			else
			begin
			select 'incorrect'
			end

	End
	ELSE
	begin
			select @id=Userid from tbl_Tmp_ForgotUserPassword where uniqueId = @UserData
	    	if (@id>0 )
			begin
			
			Delete from tbl_Tmp_ForgotUserPassword where Userid=@id and uniqueId = @UserData
			
			select @id
			end
			else
			begin
			select 'incorrect'
			end

	End
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllCarList]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCarList]
	-- Add the parameters for the stored procedure here
	@cid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.*,b.make_type,c.model as 'modelname',d.badge_type from tbl_carmaster a,MakeTypeMaster b,ModelMaster c,BadgeTypeMaster d where d.bad_id=a.badge and c.model_id=a.model and b.make_id=a.make and a.uid = @cid order by a.cid desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomerListing]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCustomerListing]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.*,(select count(*) from tbl_carmaster b where b.status = '0' and b.uid=a.id) as 'pendingcount' from tbl_login a where a.type != 'Super' order by a.id desc
END



GO
/****** Object:  StoredProcedure [dbo].[getAllCustomers]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getAllCustomers]  
	-- Add the parameters for the stored procedure here
	
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_login where type != 'Super' order by id desc

	END TRY
BEGIN CATCH
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[GetAllCylinders]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllCylinders]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Cylinder_master order by cylinder_id 
END



GO
/****** Object:  StoredProcedure [dbo].[GetAllEventList]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllEventList]
	-- Add the parameters for the stored procedure here
	@cid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from dbo.eventgoingmaster where dbo.eventgoingmaster.eid=a.eid) as going from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.uid=@cid  ORDER BY a.eid DESC 

	--SELECT  b.country_name,c.state_name,a.*,d.name,EGM.eid from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d,EventGoingMaster EGM where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and EGM.uid=a.uid and a.uid=@cid

	--UNION

	--SELECT  b.country_name,c.state_name,a.*,d.name,EGM.eid from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d,EventGoingMaster EGM where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and EGM.eid=a.eid and EGM.uid=@cid ORDER BY a.eid DESC

END



GO
/****** Object:  StoredProcedure [dbo].[GetAllState]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetAllState]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.*,b.country_name from tbl_state_master a,tbl_country_master b where b.count_id=a.count_id  order by a.state_id desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetBadge]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBadge] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*,b.*,c.* from BadgeTypeMaster a,ModelMaster b,MakeTypeMaster c where b.model_id=a.model_id and c.make_id=b.make_id 
END



GO
/****** Object:  StoredProcedure [dbo].[GetBadgeDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBadgeDetails] 
	-- Add the parameters for the stored procedure here
	@make_id int,
	@model_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from BadgeTypeMaster where make_id=@make_id and model_id=@model_id 
END



GO
/****** Object:  StoredProcedure [dbo].[GetBadgeDetailsWithCount]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBadgeDetailsWithCount]
	-- Add the parameters for the stored procedure here
		
	@List VarChar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	--SELECT a.*,ISNULL((select count(*) from tbl_carmaster where status =1 and gstatus = 0 and badge=a.bad_id),0) as 'badgecount' from BadgeTypeMaster a where  a.model_id=@model_id

	SELECT        dbo.BadgeTypeMaster.*, dbo.ModelMaster.model, dbo.MakeTypeMaster.make_type
, ISNULL((select count(*) from tbl_carmaster where status =1 and gstatus = 0 and badge=dbo.BadgeTypeMaster.bad_id),0) as 'badgecount'
FROM            dbo.ModelMaster INNER JOIN
                         dbo.BadgeTypeMaster ON dbo.ModelMaster.model_id = dbo.BadgeTypeMaster.model_id INNER JOIN
                         dbo.MakeTypeMaster ON dbo.ModelMaster.make_id = dbo.MakeTypeMaster.make_id
						 Where dbo.BadgeTypeMaster.model_id in (SELECT model_id = Item FROM dbo.SplitInts(@List, ',')) Order by dbo.MakeTypeMaster.make_type,dbo.ModelMaster.model,dbo.BadgeTypeMaster.badge_type
END



GO
/****** Object:  StoredProcedure [dbo].[GetBodyColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBodyColor]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from Body_ColorMaster  order by body_color_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetBodyType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetBodyType]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from body_typeMaster  order by body_type_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetCarDetailById]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarDetailById]
	-- Add the parameters for the stored procedure here
	@cid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select a.*,c.cur_id  from tbl_carmaster a,tbl_login b,tbl_currency_master c where c.count_id=b.country and b.id=a.uid and a.cid = @cid
END



GO
/****** Object:  StoredProcedure [dbo].[GetCarDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarDetails]
	-- Add the parameters for the stored procedure here
	@sortby NVARCHAR(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	
	-- Insert statements for procedure here
	SELECT 
		p.city AS 'cityname'
		,b.country_name
		,c.state_name
		,d.make_type
		,e.model
		,f.badge_type
		,g.series_type
		,h.transmision
		,i.currency AS 'currencyname'
		,j.odometer
		,k.id
		,a.*
		,k.NAME
		,l.cylinder_name
		,m.speedtypename
		,n.ensize_name
		,o.Body_Type AS 'bodytypename'
		,k.zip
		,k.cno
		,k.orgname
		,isnull(k.showphone,0) as 'showphone'
		,q.reason as 'regionname'
		,k.email
	FROM tbl_carmaster a
		,tbl_country_master b
		,tbl_state_master c
		,MakeTypeMaster d
		,ModelMaster e
		,BadgeTypeMaster f
		,SeriesTypeMaster g
		,TransmisionMaster h
		,tbl_currency_master i
		,OdoMeterMaster j
		,tbl_login k
		,Cylinder_Master l
		,SpeedTypeMaster m
		,EngineSizeMaster n
		,Body_TypeMaster o
		,CityMaster p
		,ReasonMaster q
	WHERE q.reas_id = k.regions
		AND p.city_id = k.city
		AND o.Body_type_id = a.body_type
		AND n.ensize_id = a.engine
		AND m.speedtypeid = a.speedtype
		AND l.cylinder_id = a.cylinder
		AND d.make_id = a.make
		AND e.model_id = a.model
		AND f.bad_id = a.badge
		AND g.ser_id = a.series
		AND h.trans_id = a.transmition
		AND i.count_id = b.count_id
		AND j.odo_id = a.matrics
		AND k.id = a.uid
		AND b.count_id = k.country
		AND k.STATE = c.state_id
		AND a.STATUS = 1
		AND a.gstatus = 0
	ORDER BY 
	CASE WHEN @sortby = 'CID' THEN cid END DESC,
    CASE WHEN @sortby = 'price' THEN price END DESC,
	CASE WHEN @sortby = 'pricel' THEN price END ,
	CASE WHEN @sortby = 'edate' THEN created_date END DESC 
END


GO
/****** Object:  StoredProcedure [dbo].[GetCarDetailsbyID]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarDetailsbyID]
	-- Add the parameters for the stored procedure here
	@uid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT q.reason as 'regionname',ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p,ReasonMaster q where q.reas_id=k.regions and p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and j.odo_id=a.matrics  and  c.state_id=k.state and  i.count_id=k.country and b.count_id=k.country and k.id = a.uid and a.uid=@uid order by a.cid desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetCarListing]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarListing]
	-- Add the parameters for the stored procedure here
	@sortby NVARCHAR(max),
	@uid int
AS
BEGIN

DECLARE @pid int
DECLARE @pid2 int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	select @pid= parentstore from tbl_login where tbl_login.id=@uid
	if(@pid!=0)
	Begin
	select @pid2= @pid
	End
	else
	Begin
	select @pid2= @uid
	End

	-- Insert statements for procedure here
	SELECT        dbo.CityMaster.city AS cityname, dbo.tbl_country_master.country_name, dbo.tbl_state_master.state_name, dbo.MakeTypeMaster.make_type, dbo.ModelMaster.model AS Model, dbo.BadgeTypeMaster.badge_type, 
                         dbo.SeriesTypeMaster.series_type, dbo.TransmisionMaster.transmision, dbo.tbl_currency_master.currency AS currencyname, dbo.OdoMeterMaster.odometer, dbo.tbl_login.id, dbo.tbl_carmaster.*, dbo.tbl_login.name, 
                         dbo.Cylinder_Master.cylinder_name, dbo.SpeedTypeMaster.speedtypename, dbo.EngineSizeMaster.ensize_name, dbo.Body_TypeMaster.Body_Type AS bodytypename, dbo.tbl_login.zip, dbo.tbl_login.cno, 
                         dbo.tbl_login.orgname,isnull(dbo.tbl_login.showphone,0) as 'showphone', dbo.ReasonMaster.reason as 'regionname', dbo.tbl_login.email
    FROM            dbo.tbl_state_master INNER JOIN
                         dbo.tbl_country_master INNER JOIN
                         dbo.tbl_currency_master ON dbo.tbl_country_master.count_id = dbo.tbl_currency_master.count_id INNER JOIN
                         dbo.ReasonMaster INNER JOIN
                         dbo.tbl_login ON dbo.ReasonMaster.reas_id = dbo.tbl_login.regions INNER JOIN
                         dbo.CityMaster ON dbo.tbl_login.city = dbo.CityMaster.city_id INNER JOIN
                         dbo.OdoMeterMaster INNER JOIN
                         dbo.tbl_carmaster INNER JOIN
                         dbo.Body_TypeMaster ON dbo.tbl_carmaster.body_type = dbo.Body_TypeMaster.Body_type_id INNER JOIN
                         dbo.EngineSizeMaster ON dbo.tbl_carmaster.engine = dbo.EngineSizeMaster.ensize_id INNER JOIN
                         dbo.SpeedTypeMaster ON dbo.tbl_carmaster.speedtype = dbo.SpeedTypeMaster.speedtypeid INNER JOIN
                         dbo.Cylinder_Master ON dbo.tbl_carmaster.cylinder = dbo.Cylinder_Master.cylinder_id INNER JOIN
                         dbo.MakeTypeMaster ON dbo.tbl_carmaster.make = dbo.MakeTypeMaster.make_id INNER JOIN
                         dbo.ModelMaster ON dbo.tbl_carmaster.model = dbo.ModelMaster.model_id INNER JOIN
                         dbo.BadgeTypeMaster ON dbo.tbl_carmaster.badge = dbo.BadgeTypeMaster.bad_id INNER JOIN
                         dbo.SeriesTypeMaster ON dbo.tbl_carmaster.series = dbo.SeriesTypeMaster.ser_id INNER JOIN
                         dbo.TransmisionMaster ON dbo.tbl_carmaster.transmition = dbo.TransmisionMaster.trans_id ON dbo.OdoMeterMaster.odo_id = dbo.tbl_carmaster.matrics ON dbo.tbl_login.id = dbo.tbl_carmaster.uid ON 
                         dbo.tbl_country_master.count_id = dbo.tbl_login.country ON dbo.tbl_state_master.state_id = dbo.tbl_login.state

						 WHERE (dbo.tbl_login.id=@uid OR dbo.tbl_login.parentstore=@pid2 OR dbo.tbl_login.id=@pid2) AND dbo.tbl_carmaster.STATUS = 1 AND dbo.tbl_carmaster.gstatus = 0
						
						ORDER BY 
						CASE WHEN @sortby = 'CID' THEN cid END DESC,
						CASE WHEN @sortby = 'price' THEN price END DESC,
						CASE WHEN @sortby = 'pricel' THEN price END ,
						CASE WHEN @sortby = 'edate' THEN created_date END DESC 

				--		 Union
						 
						 

				--		 SELECT  dbo.CityMaster.city AS cityname, dbo.tbl_country_master.country_name, dbo.tbl_state_master.state_name, dbo.MakeTypeMaster.make_type, dbo.ModelMaster.model AS Model, dbo.BadgeTypeMaster.badge_type, 
    --                     dbo.SeriesTypeMaster.series_type, dbo.TransmisionMaster.transmision, dbo.tbl_currency_master.currency AS currencyname, dbo.OdoMeterMaster.odometer, dbo.tbl_login.id, dbo.tbl_carmaster.*, dbo.tbl_login.name, 
    --                     dbo.Cylinder_Master.cylinder_name, dbo.SpeedTypeMaster.speedtypename, dbo.EngineSizeMaster.ensize_name, dbo.Body_TypeMaster.Body_Type AS bodytypename, dbo.tbl_login.zip, dbo.tbl_login.cno, 
    --                     dbo.tbl_login.orgname,isnull(dbo.tbl_login.showphone,0) as 'showphone', dbo.ReasonMaster.reason as 'regionname', dbo.tbl_login.email
    --FROM            dbo.tbl_state_master INNER JOIN
    --                     dbo.tbl_country_master INNER JOIN
    --                     dbo.tbl_currency_master ON dbo.tbl_country_master.count_id = dbo.tbl_currency_master.count_id INNER JOIN
    --                     dbo.ReasonMaster INNER JOIN
    --                     dbo.tbl_login ON dbo.ReasonMaster.reas_id = dbo.tbl_login.regions INNER JOIN
    --                     dbo.CityMaster ON dbo.tbl_login.city = dbo.CityMaster.city_id INNER JOIN
    --                     dbo.OdoMeterMaster INNER JOIN
    --                     dbo.tbl_carmaster INNER JOIN
    --                     dbo.Body_TypeMaster ON dbo.tbl_carmaster.body_type = dbo.Body_TypeMaster.Body_type_id INNER JOIN
    --                     dbo.EngineSizeMaster ON dbo.tbl_carmaster.engine = dbo.EngineSizeMaster.ensize_id INNER JOIN
    --                     dbo.SpeedTypeMaster ON dbo.tbl_carmaster.speedtype = dbo.SpeedTypeMaster.speedtypeid INNER JOIN
    --                     dbo.Cylinder_Master ON dbo.tbl_carmaster.cylinder = dbo.Cylinder_Master.cylinder_id INNER JOIN
    --                     dbo.MakeTypeMaster ON dbo.tbl_carmaster.make = dbo.MakeTypeMaster.make_id INNER JOIN
    --                     dbo.ModelMaster ON dbo.tbl_carmaster.model = dbo.ModelMaster.model_id INNER JOIN
    --                     dbo.BadgeTypeMaster ON dbo.tbl_carmaster.badge = dbo.BadgeTypeMaster.bad_id INNER JOIN
    --                     dbo.SeriesTypeMaster ON dbo.tbl_carmaster.series = dbo.SeriesTypeMaster.ser_id INNER JOIN
    --                     dbo.TransmisionMaster ON dbo.tbl_carmaster.transmition = dbo.TransmisionMaster.trans_id ON dbo.OdoMeterMaster.odo_id = dbo.tbl_carmaster.matrics ON dbo.tbl_login.id = dbo.tbl_carmaster.uid ON 
    --                     dbo.tbl_country_master.count_id = dbo.tbl_login.country ON dbo.tbl_state_master.state_id = dbo.tbl_login.state

				--		  WHERE dbo.tbl_login.parentstore=@pid2 AND dbo.tbl_carmaster.STATUS = 1 AND dbo.tbl_carmaster.gstatus = 0


				--		   Union
						 
						 

				--		 SELECT  dbo.CityMaster.city AS cityname, dbo.tbl_country_master.country_name, dbo.tbl_state_master.state_name, dbo.MakeTypeMaster.make_type, dbo.ModelMaster.model AS Model, dbo.BadgeTypeMaster.badge_type, 
    --                     dbo.SeriesTypeMaster.series_type, dbo.TransmisionMaster.transmision, dbo.tbl_currency_master.currency AS currencyname, dbo.OdoMeterMaster.odometer, dbo.tbl_login.id, dbo.tbl_carmaster.*, dbo.tbl_login.name, 
    --                     dbo.Cylinder_Master.cylinder_name, dbo.SpeedTypeMaster.speedtypename, dbo.EngineSizeMaster.ensize_name, dbo.Body_TypeMaster.Body_Type AS bodytypename, dbo.tbl_login.zip, dbo.tbl_login.cno, 
    --                     dbo.tbl_login.orgname,isnull(dbo.tbl_login.showphone,0) as 'showphone', dbo.ReasonMaster.reason as 'regionname', dbo.tbl_login.email
    --FROM            dbo.tbl_state_master INNER JOIN
    --                     dbo.tbl_country_master INNER JOIN
    --                     dbo.tbl_currency_master ON dbo.tbl_country_master.count_id = dbo.tbl_currency_master.count_id INNER JOIN
    --                     dbo.ReasonMaster INNER JOIN
    --                     dbo.tbl_login ON dbo.ReasonMaster.reas_id = dbo.tbl_login.regions INNER JOIN
    --                     dbo.CityMaster ON dbo.tbl_login.city = dbo.CityMaster.city_id INNER JOIN
    --                     dbo.OdoMeterMaster INNER JOIN
    --                     dbo.tbl_carmaster INNER JOIN
    --                     dbo.Body_TypeMaster ON dbo.tbl_carmaster.body_type = dbo.Body_TypeMaster.Body_type_id INNER JOIN
    --                     dbo.EngineSizeMaster ON dbo.tbl_carmaster.engine = dbo.EngineSizeMaster.ensize_id INNER JOIN
    --                     dbo.SpeedTypeMaster ON dbo.tbl_carmaster.speedtype = dbo.SpeedTypeMaster.speedtypeid INNER JOIN
    --                     dbo.Cylinder_Master ON dbo.tbl_carmaster.cylinder = dbo.Cylinder_Master.cylinder_id INNER JOIN
    --                     dbo.MakeTypeMaster ON dbo.tbl_carmaster.make = dbo.MakeTypeMaster.make_id INNER JOIN
    --                     dbo.ModelMaster ON dbo.tbl_carmaster.model = dbo.ModelMaster.model_id INNER JOIN
    --                     dbo.BadgeTypeMaster ON dbo.tbl_carmaster.badge = dbo.BadgeTypeMaster.bad_id INNER JOIN
    --                     dbo.SeriesTypeMaster ON dbo.tbl_carmaster.series = dbo.SeriesTypeMaster.ser_id INNER JOIN
    --                     dbo.TransmisionMaster ON dbo.tbl_carmaster.transmition = dbo.TransmisionMaster.trans_id ON dbo.OdoMeterMaster.odo_id = dbo.tbl_carmaster.matrics ON dbo.tbl_login.id = dbo.tbl_carmaster.uid ON 
    --                     dbo.tbl_country_master.count_id = dbo.tbl_login.country ON dbo.tbl_state_master.state_id = dbo.tbl_login.state

				--		  WHERE dbo.tbl_login.id=@pid2 AND dbo.tbl_carmaster.STATUS = 1 AND dbo.tbl_carmaster.gstatus = 0
						


END


GO
/****** Object:  StoredProcedure [dbo].[GetCarMapListing]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarMapListing]
	-- Add the parameters for the stored procedure here
		@uid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT q.city as 'cityname',r.reason as 'regionname',ISNULL(((select status from carwatchlist  where cid=a.cid and uid=k.id)),0) as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,k.showphone,k.email from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p,CityMaster q,ReasonMaster r where q.city_id=k.city and r.reas_id=k.regions and p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.count_id=b.count_id and j.odo_id=a.matrics and k.id=a.uid and b.count_id=k.country and k.state=c.state_id  and a.status = 1  and a.gstatus = 0 and  a.uid = @uid order by cid desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetCarWatchlist]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCarWatchlist]
	-- Add the parameters for the stored procedure here
	@uid int
	AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT r.reason as 'regionname',q.status as 'carstar',p.city as 'cityname',b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency as 'currencyname',j.odometer,k.id,a.*,k.name,l.cylinder_name,m.speedtypename,n.ensize_name,o.Body_Type as 'bodytypename',k.zip,k.cno,k.orgname,ISNULL(k.showphone,0) as 'showphone',k.email from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k,Cylinder_Master l,SpeedTypeMaster m,EngineSizeMaster n,Body_TypeMaster o,CityMaster p,carwatchlist q,ReasonMaster r where r.reas_id=k.regions and p.city_id=k.city and o.Body_type_id=a.body_type and n.ensize_id=a.engine and m.speedtypeid=a.speedtype and l.cylinder_id=a.cylinder and d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.count_id=b.count_id and j.odo_id=a.matrics and k.id=a.uid and b.count_id=k.country and k.state=c.state_id and a.cid=q.cid and  q.uid = @uid and a.status=1 and q.status=1 order by cid desc
	
END



GO
/****** Object:  StoredProcedure [dbo].[GetCategory]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCategory] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT * from tbl_eventcat_master order by ecat_id desc -------Change 27April2017 

	SELECT a.*,ISNULL((select count(*) from tbl_Eventmaster where status=1 and cat=a.ecat_id),0) 
	as 'catcount' from tbl_eventcat_master as a order by ecat_id desc ----- Change 6/5/2017

	--SELECT a.*,ISNULL((select count(*) from tbl_Eventmaster where status=1 and cat=a.ecat_id),0) 
	--as 'catcount' from tbl_eventcat_master as a where (select count(*) from tbl_Eventmaster where status=1 and cat=a.ecat_id)!=0 order by ecat_id desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetCity]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCity]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.* , b.*,c.* from CityMaster a,tbl_state_master b, tbl_country_master c where b.state_id=a.state_id and c.count_id=b.count_id  Order by a.city
END



GO
/****** Object:  StoredProcedure [dbo].[GetCityDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCityDetails] 
	-- Add the parameters for the stored procedure here
@count_id int,
@state_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from CityMaster where count_id=@count_id and state_id=@state_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetCondition]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCondition] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT        dbo.ConditionMaster.*,(SELECT COUNT(dbo.tbl_carmaster.cid)from dbo.tbl_carmaster WHERE dbo.ConditionMaster.cond_id = dbo.tbl_carmaster.condition and dbo.tbl_carmaster.status=1 and dbo.tbl_carmaster.gstatus=0) as CarCount 
FROM            dbo.ConditionMaster 
	--SELECT * from ConditionMaster

END



GO
/****** Object:  StoredProcedure [dbo].[GetCountry]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCountry] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


	----SELECT * from tbl_country_master order by count_id desc

------ Change Query on 5/10/2017--------------
--SELECT        dbo.tbl_country_master.count_id, dbo.tbl_country_master.country_name, dbo.tbl_country_master.status, 
--		isnull((SELECT       count( b.country)
--		FROM            dbo.tbl_carmaster a INNER JOIN
--								 dbo.tbl_login b ON a.uid = b.id INNER JOIN
--								 dbo.tbl_country_master c ON b.country = c.count_id where c.count_id=dbo.tbl_country_master.count_id AND a.status=1 AND a.gstatus=0
--		GROUP BY b.country),0) as carcount,

--isnull((SELECT count( b.country)
--		FROM            dbo.tbl_eventmaster a INNER JOIN
--								 dbo.tbl_login b ON a.uid = b.id INNER JOIN
--								 dbo.tbl_country_master c ON b.country = c.count_id where c.count_id=dbo.tbl_country_master.count_id AND a.status=1
--		GROUP BY b.country),0) AS eventcount FROM            dbo.tbl_country_master
--GROUP BY dbo.tbl_country_master.count_id, dbo.tbl_country_master.country_name, dbo.tbl_country_master.status Order by dbo.tbl_country_master.country_name


SELECT        dbo.tbl_country_master.count_id, dbo.tbl_country_master.country_name, dbo.tbl_country_master.status, 
		isnull((SELECT       count( b.country)
		FROM            dbo.tbl_carmaster a INNER JOIN
								 dbo.tbl_login b ON a.uid = b.id INNER JOIN
								 dbo.tbl_country_master c ON b.country = c.count_id where c.count_id=dbo.tbl_country_master.count_id AND a.status=1 AND a.gstatus=0
		GROUP BY b.country),0) as carcount,

isnull((SELECT count(a.country)
		FROM            dbo.tbl_eventmaster a INNER JOIN
								 dbo.tbl_country_master c ON a.country = c.count_id where c.count_id=dbo.tbl_country_master.count_id AND a.status=1
		GROUP BY a.country),0) AS eventcount FROM            dbo.tbl_country_master
GROUP BY dbo.tbl_country_master.count_id, dbo.tbl_country_master.country_name, dbo.tbl_country_master.status Order by dbo.tbl_country_master.country_name

END



GO
/****** Object:  StoredProcedure [dbo].[GetCurrency]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCurrency]
	-- Add the parameters for the stored procedure here

AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*,b.count_id,b.country_name from tbl_currency_master a,tbl_country_master b where b.count_id=a.count_id order by a.cur_id

END 




GO
/****** Object:  StoredProcedure [dbo].[GetDrive]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDrive]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from DrivetrainMaster
END



GO
/****** Object:  StoredProcedure [dbo].[GetDriveTrain]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetDriveTrain]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from DrivetrainMaster
END



GO
/****** Object:  StoredProcedure [dbo].[GetEngine]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEngine] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from EngineMaster
END



GO
/****** Object:  StoredProcedure [dbo].[GetEngineSize]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEngineSize]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.*,b.make_type,c.model,d.badge_type,e.series_type from EngineSizeMaster a,MakeTypeMaster b,ModelMaster c,BadgeTypeMaster d,SeriesTypeMaster e where e.ser_id=a.ser_id and d.bad_id=a.bad_id and c.model_id=a.model_id and b.make_id=a.make_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetEngineSizeDetail]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEngineSizeDetail]
	-- Add the parameters for the stored procedure here
@make_id int,
@model_id int,
@bad_id int,
@series int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM EngineSizeMaster WHERE make_id=@make_id AND model_id=@model_id AND bad_id=@bad_id AND ser_id=@series ORDER BY ensize_name
END



GO
/****** Object:  StoredProcedure [dbo].[GetEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEvent]
	-- Add the parameters for the stored procedure here
	@sortby NVARCHAR(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- Insert statements for procedure here
	SELECT e.city AS 'cityname'
		,f.reason as 'regionname'
		,b.country_name
		,c.state_name
		,a.*
		,d.NAME
		,ISNULL((
				SELECT count(*)
				FROM eventgoingmaster
				WHERE eid = a.eid
				), 0) AS 'going'
	FROM tbl_eventmaster a
		,tbl_country_master b
		,tbl_state_master c
		,tbl_login d
		,CityMaster e
		,ReasonMaster f
	WHERE f.reas_id = a.reason
		AND e.city_id = a.city
		AND b.count_id = a.country
		AND c.state_id = a.STATE
		AND d.id = a.uid
		AND a.STATUS = 1
	ORDER BY 
	CASE WHEN @sortby = 'CID' THEN a.eid END DESC,
    CASE WHEN @sortby = 'price' THEN price END DESC,
	CASE WHEN @sortby = 'pricel' THEN price END ,
	CASE WHEN @sortby = 'edate' THEN created_date END DESC 
END


GO
/****** Object:  StoredProcedure [dbo].[GetEventCategory]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEventCategory]
	-- Add the parameters for the stored procedure here
		@errorCode int output,
	@errorMessage nvarchar(200) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_eventcat_master 

	SET @errorCode=0
	SET @errorMessage ='SUCCESS'

END  TRY
BEGIN CATCH
	SET @errorCode = '10001'
	SET @errorMessage = 'Internal Server Error - 1'
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[GetEventDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEventDetails] 
	-- Add the parameters for the stored procedure here
	@eid int
AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going',d.email from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d where b.count_id=a.country and c.state_id=a.state and a.eid=@eid and d.id=a.uid

END 





GO
/****** Object:  StoredProcedure [dbo].[GetEventListing]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[GetEventListing]
	-- Add the parameters for the stored procedure here
	@sortby NVARCHAR(max),
	@uid int
AS
BEGIN

DECLARE @pid int
DECLARE @pid2 int
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select @pid= parentstore from tbl_login where tbl_login.id=@uid
	if(@pid!=0)
	Begin
	select @pid2= @pid
	End
	else
	Begin
	select @pid2= @uid
	End

	-- Insert statements for procedure here
	SELECT e.city AS 'cityname'
		,f.reason as 'regionname'
		,b.country_name
		,c.state_name
		,a.*
		,d.NAME
		,ISNULL((
				SELECT count(*)
				FROM eventgoingmaster
				WHERE eid = a.eid
				), 0) AS 'going'
	FROM tbl_eventmaster a
		,tbl_country_master b
		,tbl_state_master c
		,tbl_login d
		,CityMaster e
		,ReasonMaster f
	WHERE f.reas_id = a.reason
		AND e.city_id = a.city
		AND b.count_id = a.country
		AND c.state_id = a.STATE
		AND d.id = a.uid
		AND a.STATUS = 1 AND (d.id=@uid OR d.parentstore=@pid2 OR d.id=@pid2)
	ORDER BY 
	CASE WHEN @sortby = 'CID' THEN a.eid END DESC,
    CASE WHEN @sortby = 'price' THEN price END DESC,
	CASE WHEN @sortby = 'pricel' THEN price END ,
	CASE WHEN @sortby = 'edate' THEN created_date END DESC 
END


GO
/****** Object:  StoredProcedure [dbo].[GetEventWatchList]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetEventWatchList] 
	-- Add the parameters for the stored procedure here
	@uid as int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  e.status as 'eventstar',b.country_name,c.state_name,a.*,d.name from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d,EventWatchlist e where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and  e.status=1 and a.eid=e.eid and e.uid=@uid  ORDER BY a.eid DESC

END



GO
/****** Object:  StoredProcedure [dbo].[GetFuel]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetFuel]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from fuel_master order by fuel_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetGoingEvents]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetGoingEvents]
	-- Add the parameters for the stored procedure here
	@uid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT  b.country_name,c.state_name,a.*,d.name,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_country_master b,tbl_state_master c,tbl_login d,EventGoingMaster e where b.count_id=a.country and c.state_id=a.state and  d.id=a.uid and a.eid=e.eid and e.uid=@uid and a.status =1 and a.edate>=getdate() order by a.eid
END



GO
/****** Object:  StoredProcedure [dbo].[GetInteriorColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetInteriorColor] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from interior_colorMaster order by Inter_color_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetInteriorMaterial]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetInteriorMaterial] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Select * from interior_MaterialMAster order by inter_mat_id
END



GO
/****** Object:  StoredProcedure [dbo].[getlatelong]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getlatelong]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
		select isnull((select count(e.cid) from tbl_carmaster e where e.uid=a.id and e.status=1 and e.gstatus=0),0) as 'carcount',isnull((select count(f.eid) from tbl_eventmaster f where f.uid=a.id and f.status=1),0) as 'eventcount',a.*,d.reason as 'resonname',c.state_name as 'statename',b.country_name as 'countryname' from tbl_login a,tbl_country_master b,tbl_state_master c,ReasonMaster d where  d.reas_id=a.regions and c.state_id=a.state and b.count_id=a.country and a.type != 'Super' and a.type='Paid' and a.status = 1 order by a.id desc

END



GO
/****** Object:  StoredProcedure [dbo].[getlatelongevent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getlatelongevent]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.*, (Select country_name from [tbl_country_master] where [count_id]= [country]) as country_name
	  ,(Select state_name from [tbl_state_master] where [state_id]= [state]) as state_name
	  ,(Select city from [citymaster] where [city_id]= a.[city]) as city_name,b.category,(select count(*) from eventgoingmaster where eid=a.eid) as 'going' from tbl_eventmaster a,tbl_eventcat_master b where a.cat=b.ecat_id and CAST(a.edate as date)>=CAST(GETDATE() as date) and a.status = 1 order by a.eid desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetListedAs]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetListedAs]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from listedas_master order by listed_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetMakeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMakeType] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from MakeTypeMaster
END



GO
/****** Object:  StoredProcedure [dbo].[GetMakeTypeWithCount]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetMakeTypeWithCount] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*,ISNULL((select count(*) from tbl_carmaster b,tbl_login c where b.uid=c.id and b.status=1 and b.gstatus=0 and b.make=a.make_id and c.status=1),0) as 'makecount' from MakeTypeMaster a Order by make_type
END



GO
/****** Object:  StoredProcedure [dbo].[GetModel]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetModel] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.make_type,b.* from MakeTypeMaster a,ModelMaster b where b.make_id=a.make_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetModelDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetModelDetails] 
	-- Add the parameters for the stored procedure here
@make_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from ModelMaster where  make_id=@make_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetModelDetailsWithCount]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetModelDetailsWithCount]
	-- Add the parameters for the stored procedure here
	@List VarChar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT a.*,ISNULL((select count(*) from tbl_carmaster where status=1 and gstatus=0 and model=a.model_id),0) as 'modelcount',(Select make_type from MakeTypeMaster where make_id=@make_id order by make_type) as make from ModelMaster a where a.make_id=@make_id Order by a.model

	SELECT        dbo.ModelMaster.*,dbo.MakeTypeMaster.make_type,ISNULL((select count(*) from tbl_carmaster where status =1 and gstatus = 0 and model=dbo.ModelMaster.model_id),0) as 'modelcount'
FROM            dbo.ModelMaster INNER JOIN
                         dbo.MakeTypeMaster  ON dbo.ModelMaster.make_id = dbo.MakeTypeMaster.make_id
						 Where dbo.ModelMaster.make_id in (SELECT make_id = Item FROM dbo.SplitInts(@List, ',')) Order by dbo.MakeTypeMaster.make_type,dbo.ModelMaster.model
END



GO
/****** Object:  StoredProcedure [dbo].[GetNewRegion]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNewRegion]
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT a.*,b.country_name,c.state_name,d.city,e.reason from NewRegionMaster a,tbl_country_master b,tbl_state_master c,CityMaster d,ReasonMaster e where e.reas_id=a.reas_id and d.city_id=a.city_id and c.state_id=a.state_id and b.count_id=a.coun_id  order by a.regionid desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetNewRegionDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetNewRegionDetails]
	-- Add the parameters for the stored procedure here
	@count_id int,
	@state_id int,
	@city_id int,
	@region nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from NewRegionMaster where coun_id=@count_id and state_id=@state_id and city_id=@city_id and reas_id=@region order by regionname 
END



GO
/****** Object:  StoredProcedure [dbo].[GetOdoMeter]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetOdoMeter]
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from OdoMeterMaster 
END



GO
/****** Object:  StoredProcedure [dbo].[GetPlan]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPlan] 
	-- Add the parameters for the stored procedure here
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_plan_master order by plan_id 
END



GO
/****** Object:  StoredProcedure [dbo].[GetPlanById]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetPlanById] 
	-- Add the parameters for the stored procedure here
	@plan_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_plan_master where  plan_id=@plan_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetReason]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReason] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select a.country_name,b.state_name,c.city,d.* from tbl_country_master a,tbl_state_master b,CityMaster c,ReasonMaster d where a.count_id = d.count_id and b.state_id=d.state_id and c.city_id=d.city_id  order by d.reason
END



GO
/****** Object:  StoredProcedure [dbo].[GetReasonDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetReasonDetails] 
	-- Add the parameters for the stored procedure here
@count_id int,
@state_id int,
@city_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from ReasonMaster where count_id=@count_id and state_id=@state_id and city_id=@city_id 
END



GO
/****** Object:  StoredProcedure [dbo].[GetSeries]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSeries] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	select a.make_type,b.model,c.badge_type,d.* from MakeTypeMaster a,ModelMaster b,BadgeTypeMaster c,SeriesTypeMaster d where a.make_id = d.make_id and c.bad_id=d.bad_id and b.model_id=d.model_id
END



GO
/****** Object:  StoredProcedure [dbo].[GetSeriesDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSeriesDetails]
	-- Add the parameters for the stored procedure here
@make_id int,
@model_id int,
@bad_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from SeriesTypeMaster where make_id=@make_id and model_id=@model_id and bad_id=@bad_id 
END



GO
/****** Object:  StoredProcedure [dbo].[GetSeriesDetailsWithCount]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSeriesDetailsWithCount] 
	-- Add the parameters for the stored procedure here
	--@make_id int,
--@model_id int,
@List VarChar(MAX)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--SELECT a.*,ISNULL((select count(*) from tbl_carmaster where status =1 and gstatus = 0 and series=a.ser_id),0) as 'seriescount' from SeriesTypeMaster a where  a.bad_id=@bad_id

	SELECT        dbo.SeriesTypeMaster.*, dbo.BadgeTypeMaster.badge_type, dbo.ModelMaster.model, dbo.MakeTypeMaster.make_type,ISNULL((select count(*) from tbl_carmaster where status =1 and gstatus = 0 and series=dbo.SeriesTypeMaster.ser_id),0) as 'seriescount'
FROM            dbo.SeriesTypeMaster INNER JOIN
                         dbo.BadgeTypeMaster ON dbo.SeriesTypeMaster.bad_id = dbo.BadgeTypeMaster.bad_id INNER JOIN
                         dbo.ModelMaster ON dbo.BadgeTypeMaster.model_id = dbo.ModelMaster.model_id INNER JOIN
                         dbo.MakeTypeMaster ON dbo.ModelMaster.make_id = dbo.MakeTypeMaster.make_id
						 Where dbo.SeriesTypeMaster.bad_id in (SELECT bad_id = Item FROM dbo.SplitInts(@List, ',')) Order by dbo.MakeTypeMaster.make_type,dbo.ModelMaster.model,dbo.BadgeTypeMaster.badge_type,dbo.SeriesTypeMaster.series_type
END



GO
/****** Object:  StoredProcedure [dbo].[GetSpeedType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSpeedType] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from speedTypeMaster  order by speedtypeid desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetState]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetState]
	-- Add the parameters for the stored procedure here
@count_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT * from tbl_state_master where  count_id =@count_id order by state_name
	
END



GO
/****** Object:  StoredProcedure [dbo].[GetStoreByParentStore]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetStoreByParentStore]
	-- Add the parameters for the stored procedure here
	@parentstore int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from tbl_login where type != 'Super' AND parentstore=@parentstore order by id desc
END



GO
/****** Object:  StoredProcedure [dbo].[GetSuburbDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetSuburbDetails]
	-- Add the parameters for the stored procedure here
	@count_id int,
	@state_id int,
	@city_id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from ReasonMaster where count_id=@count_id and state_id=@state_id and city_id=@city_id order by reason 
END



GO
/****** Object:  StoredProcedure [dbo].[getTransDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[getTransDetails]
	-- Add the parameters for the stored procedure here
	@transid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from TransmisionMaster where trans_id = @transid 
END



GO
/****** Object:  StoredProcedure [dbo].[GetTransmision]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetTransmision] 
	-- Add the parameters for the stored procedure here

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT *,(Select Count(dbo.tbl_carmaster.cid) From dbo.tbl_carmaster Where dbo.tbl_carmaster.transmition=TransmisionMaster.trans_id and dbo.tbl_carmaster.status=1 and dbo.tbl_carmaster.gstatus=0) as CarCount from TransmisionMaster  order by trans_id
END



GO
/****** Object:  StoredProcedure [dbo].[InsertBodyColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertBodyColor]
	-- Add the parameters for the stored procedure here
	@colorname nvarchar(max),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
INSERT INTO Body_colormaster (body_color_name,status) values(@colorname,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertBodyType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertBodyType]
	-- Add the parameters for the stored procedure here
	@bodytype nvarchar(max),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Body_TypeMaster(body_type,status) values(@bodytype,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertCountry]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCountry]
	-- Add the parameters for the stored procedure here
	@countryname nvarchar(max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select 1 from tbl_country_master where  country_name= RTRIM(LTRIM(@countryname)))
	begin
	
		Select 'Exists'
	end
	else
	begin
    -- Insert statements for procedure here
	insert into tbl_country_master(country_name,status) values(@countryname,@status)
	Select 'Success'
   end
END


GO
/****** Object:  StoredProcedure [dbo].[InsertCurrency]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCurrency]
	-- Add the parameters for the stored procedure here
	@currency nvarchar(200),
	@count_id int,
	@status int,
	@errormessage nvarchar(max) output 


AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	

	if exists(select 1 from tbl_currency_master where  count_id=@count_id)
	begin
		SET @errormessage = 'Currency Already Present'
		RETURN
	end
	else
	begin

    -- Insert statements for procedure here
	insert into tbl_currency_master(
	currency,
	count_id,
	status
	
	)
	values(
	@currency,
	@count_id,
	@status
	)

	SET @errormessage = '0'
	end

	
END



GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertCustomer] 
	-- Add the parameters for the stored procedure here
	@name nvarchar(200),
	@email nvarchar(50),
	@pass nvarchar(50),
	@type nvarchar(50),
	
	--return values
	@id int output,
	@errorCode int output,
	@errorMessage nvarchar(200) output,
	@businessname nvarchar(200) = NULL,
	@contactnumber nvarchar(200) = NULL,
	@country nvarchar(200) = NULL,
	@state nvarchar(200) = NULL,
	@zipcode nvarchar(200) = NULL,
	@city nvarchar(200) = NULL,
	@region nvarchar(200) = NULL,
	@parentstore nvarchar(200) = NULL,
	@facebookId nvarchar(200) = NULL
	
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM tbl_login WHERE email=@email)
	BEGIN
		SET @errorCode = 2001
		SET @errorMessage = 'EMAIL ALREADY EXIST'
		RETURN 
	END 
	IF @type = 'Paid'
	BEGIN
	INSERT INTO tbl_login
	(
		name,
		email,
		pass,
		type,
		status,
		reg_date,
		plan_id,
		city,
		state,
		country,
		regions,
		valid_date,
		cno,
		orgname,
		zip,
		parentstore,
		facebookId
	
		

	)
	values
	(
		@name,
		@email,
		@pass,
		@type,
		'2',
		GETDATE(),
		'0',
		@city,
		@state,
		@country,
		@region,
		GETDATE(),
		@contactnumber,
		@businessname,
		@zipcode,
		@parentstore,
		@facebookId

		--@suburb
		
		
	)
	END
	ELSE 
	BEGIN
	INSERT INTO tbl_login
	(
		name,
		email,
		pass,
		type,
		status,
		reg_date,
		plan_id,
		city,
		state,
		country,
		regions,
		valid_date,
		zip,
		facebookId
		--suburb
		

	)
	values
	(
		@name,
		@email,
		@pass,
		@type,
		'0',
		GETDATE(),
		'0',
		@city,
		@state,
		@country,
		@region,
		GETDATE(),
		@zipcode,
		@facebookId
		--@suburb
		
	)
	END

	IF @@ROWCOUNT > 0 
	BEGIN
		SET @id = @@IDENTITY
		INSERT INTO UserNotification 
		(
			edate,
			fromuid,
			touid,
			msg,
			status
		)
		VALUES
		(
		GETDATE(),
		@id,
		@id,
		'Your details are being reviewed by the MYCARYARD team.',
		'1'
		)
	END
	SET @errorCode = 0
	SET @errorMessage = 'SUCCESS'
END TRY
BEGIN CATCH
	SET @errorCode = 4004
	SET @errorMessage = ERROR_MESSAGE()
END CATCH




GO
/****** Object:  StoredProcedure [dbo].[InsertEvent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertEvent]
	-- Add the parameters for the stored procedure here
	@cust_id int,
	@cost_event nvarchar(50),
	@currency int,
	@price int,
	@title nvarchar(max),
	@category int ,
	@time_form int,
	@time_to int,
	@location nvarchar(max),
	@comment nvarchar(max),
	@description nvarchar(max),
	@status int 
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
insert into tbl_event_master(
cust_id,
cost_event,
currency,
price,
title,
category,
time_form,
time_to,
location,
comment,
description,
status
)
values(
@cust_id,
@cost_event,
@currency,
@price,
@title,
@category,
@time_form,
@time_to,
@location,
@comment,
@description,
@status
)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertEventCategory]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertEventCategory]
	-- Add the parameters for the stored procedure here
	@category nvarchar(max),
	@status int 

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
insert into tbl_eventcat_master(
category,
status
)
values
(
@category,
@status
)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertFuelMaster]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertFuelMaster]
	-- Add the parameters for the stored procedure here
	@fuelname nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into fuel_master(fuel_name,status) values(@fuelname,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[insertgoingevent]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[insertgoingevent] 
	-- Add the parameters for the stored procedure here
	@uid int,
	@eid int,
	@email nvarchar(50),
	--output
	@errorCode int output,
	@errorMessage nvarchar(200) output
AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	IF EXISTS(SELECT 1 FROM EventGoingMaster where @uid = uid and @eid = eid)
	BEGIN
		SET @errorCode = 2002
		SET @errorMessage = 'Already Going'
		RETURN
	END

	INSERT INTO eventgoingmaster
	(
	uid,
	eid,
	email,
	status
	)
	values
	(
	@uid,
	@eid,
	@email,
	'1'
	)
    -- Insert statements for procedure here
	SET @errorCode = 0
	SET @errorMessage = 'Success'
	
END TRY
BEGIN CATCH
set @errorCode = 2002
set @errorMessage = ERROR_MESSAGE()
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[InsertInteriorColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertInteriorColor]
	-- Add the parameters for the stored procedure here
@colorname nvarchar(max),
@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into Interior_ColorMaster (Inter_color_name,status) values(@colorname,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertInteriorMaterial]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertInteriorMaterial]
	-- Add the parameters for the stored procedure here
	@matname nvarchar(max),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into interior_MaterialMAster(Inter_mat_Name,status) values(@matname,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertListedAs]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertListedAs]
	-- Add the parameters for the stored procedure here
	@listed nvarchar(max),
	@status nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into ListedAs_master(listed_name,status) values(@listed,@status)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertPlan]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertPlan] 
	-- Add the parameters for the stored procedure here
@plan_name nvarchar (max),
@duration int,
@amnt int,
@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	insert into tbl_plan_master(plan_name,duration,amnt,status) values(
	@plan_name,
	@duration,
	@amnt,
	@status
	)
END



GO
/****** Object:  StoredProcedure [dbo].[InsertState]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsertState] 
	-- Add the parameters for the stored procedure here
	@count_id int ,
	@state_name nvarchar (max),
	@status int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	if exists(select 1 from tbl_state_master where  state_name= RTRIM(LTRIM(@state_name)) and count_id=@count_id)
	begin
	
		Select 'Exists'
	end
	else
	begin
    -- Insert statements for procedure here
	insert into tbl_state_master(count_id,state_name,status) values (@count_id,@state_name,@status)
	Select 'Success'
     END
END



GO
/****** Object:  StoredProcedure [dbo].[SearchCarDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SearchCarDetails]
	-- Add the parameters for the stored procedure here
	@make int = NULL,
	@model int = NULL,
	@fyear int = NULL,
	@tyear int = NULL,
	@country int = NULL,
	@state int = NULL,
	@minprice int = NULL,
	@maxprice int = NULL,
	@keyword nvarchar(200) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT b.country_name,c.state_name,d.make_type,e.model,f.badge_type,g.series_type,h.transmision,i.currency,j.odometer,k.id,a.*,k.name from tbl_carmaster a,tbl_country_master b,tbl_state_master c,MakeTypeMaster d,ModelMaster e,BadgeTypeMaster f,SeriesTypeMaster g,TransmisionMaster h,tbl_currency_master i,OdoMeterMaster j,tbl_login k where d.make_id=a.make and e.model_id=a.model and f.bad_id=a.badge and g.ser_id=a.series and h.trans_id=a.transmition and i.cur_id=a.currency and j.odo_id=a.matrics and k.id=a.uid and k.country=b.count_id and k.state=c.state_id and a.status = 1 OR a.make=@make OR a.model=@model OR a.year between @fyear and @tyear OR a.price BETWEEN @maxprice and @minprice
	
END



GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteMultipleId]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE PROCEDURE [dbo].[sp_DeleteMultipleId]
 @make_id VARCHAR(MAX)
 AS
 BEGIN
      SET NOCOUNT ON;
     SELECT        dbo.ModelMaster.*,dbo.MakeTypeMaster.make_type,ISNULL((select count(*) from tbl_carmaster where status =1 and gstatus = 0 and model=dbo.ModelMaster.model_id),0) as 'modelcount'
FROM            dbo.ModelMaster INNER JOIN
                         dbo.MakeTypeMaster  ON dbo.ModelMaster.make_id = dbo.MakeTypeMaster.make_id
						 Where dbo.ModelMaster.make_id in (SELECT make_id = Item FROM dbo.SplitInts(@make_id, ',')) Order by dbo.MakeTypeMaster.make_type,dbo.ModelMaster.model
 END


GO
/****** Object:  StoredProcedure [dbo].[UpdataBodyType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdataBodyType]
	-- Add the parameters for the stored procedure here
	@bodytypeid int,
	@bodytype nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Body_TypeMaster set Body_Type=@bodytype,status = @status where Body_type_id=@bodytypeid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateBadgeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBadgeType]
	-- Add the parameters for the stored procedure here
	@badid int,
	@make_id int,
	@model_id int,
	@badge nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update BadgeTypeMaster SET make_id=@make_id,model_id=@model_id,badge_type=@badge,status=@status where bad_id=@badid 
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateBodyColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBodyColor]
	-- Add the parameters for the stored procedure here
	@bodycolorid int,
	@colorname nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Body_ColorMaster SET body_color_name=@colorname,status=@status where body_color_id=@bodycolorid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateBodyType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateBodyType]
	-- Add the parameters for the stored procedure here
	@bodytypeid int,
	@bodytype nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Body_TypeMaster set Body_Type=@bodytype,status = @status where Body_type_id=@bodytypeid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateCity]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCity] 
	-- Add the parameters for the stored procedure here
	@cityid int,
	@count_id int,
	@state_id int,
	@city nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update CityMaster set count_id=@count_id , state_id = @state_id , city = @city, status = @status where city_id = @cityid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateCondition]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCondition]
	-- Add the parameters for the stored procedure here
	@conditionid int,
	@condition nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update ConditionMaster set condition=@condition,status=@status where cond_id=@conditionid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateCountry]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCountry] 
	-- Add the parameters for the stored procedure here
	@count_id int,
	@country_name nvarchar (max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_country_master set country_name=@country_name,status=@status where count_id=@count_id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateCurrency]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCurrency] 
	-- Add the parameters for the stored procedure here
@cur_id int,
@currency nvarchar(20),
@status nvarchar(20),
@count_id int

AS
BEGIN 
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_currency_master
	SET [currency]= @currency,
	[status] = @status,
	[count_id] = @count_id

	where cur_id=@cur_id

END 



GO
/****** Object:  StoredProcedure [dbo].[UpdateCylinder]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateCylinder]
	-- Add the parameters for the stored procedure here
	@cylinderid int,
	@cylinder nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Cylinder_Master set cylinder_name=@cylinder,status=@status where cylinder_id=@cylinderid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateDriveTrain]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateDriveTrain]
	-- Add the parameters for the stored procedure here
	@drivetid int,
	@drive nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update DrivetrainMaster SET drive=@drive,status=@status WHERE driv_id=@drivetid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateEngineSizeMaster]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEngineSizeMaster]
	-- Add the parameters for the stored procedure here
	@engsizeid int,
	@serid int,
	@make_id int,
	@model_id int,
	@bad_id int,
	@engsize nvarchar(100),
	@status int

AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update enginesizemaster set make_id=@make_id,model_id = @model_id,bad_id=@bad_id, ser_id =@serid , ensize_name=@engsize,status=@status where ensize_id = @engsizeid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateEventCategory]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEventCategory]
	-- Add the parameters for the stored procedure here
@ecat_id int,
@category nvarchar(max),
@status int,

@errorCode int output,
@errorMessage nvarchar(100) output
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_eventcat_master 
	SET [category]=@category,
	[status]=@status
	 where ecat_id=@ecat_id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateEventCategoryNew]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEventCategoryNew]
	-- Add the parameters for the stored procedure here
	@catid int,
	@category nvarchar(50),
	@status nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update tbl_eventcat_master SET category=@category,status=@status where ecat_id=@catid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateEventDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEventDetails] 
	-- Add the parameters for the stored procedure here
	@e_id int,
	@cust_id int,
	@cost_event nvarchar(50),
	@currency int,
	@price int,
	@title nvarchar(max),
	@category int ,
	@time_form int,
	@time_to int,
	@location nvarchar(max),
	@comment nvarchar(max),
	@description nvarchar(max),
	@status int ,

	@errorCode int output,
@errorMessage nvarchar(100) output


AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_event_master 
	SET [cust_id]=@cust_id,
	[cost_event]=@cost_event,
	[currency]=@currency,
	[price]=@price,
	[title]=@title,
	[category]=@category,
	[time_form]=@time_form,
	[time_to]=@time_to,
	[location]=@location,
	[comment]=@comment,
	[description]=@description,
	[status]=@status
	where e_id=@e_id


	SET @errorCode=0
	SET @errorMessage='SUCCESS'
END TRY
BEGIN CATCH
SET @errorCode = '10001'
	SET @errorMessage = 'Internal Server Error'
END CATCH



GO
/****** Object:  StoredProcedure [dbo].[UpdateEventWatchliststatus]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateEventWatchliststatus]
	-- Add the parameters for the stored procedure here
	@eid int,
	@uid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select 1 from EventWatchlist where eid=@eid and uid=@uid)
	begin
		if exists(select 1 from EventWatchlist where eid=@eid and uid=@uid and status = 1)
		begin
		update EventWatchlist set status='0' where eid=@eid and uid=@uid
		end
		else 
		begin
		update EventWatchlist set status='1' where eid=@eid and uid=@uid
		end
	end
	else 
	begin
	insert into EventWatchlist(eid,uid,status) values(@eid,@uid,'1')
	end
	
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateFuelMaster]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateFuelMaster]
	-- Add the parameters for the stored procedure here
	@fuelid int,
	@fuelname nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Fuel_Master SET fuel_name=@fuelname,status=@status where fuel_id=@fuelid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateInteriorColor]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInteriorColor]
	-- Add the parameters for the stored procedure here
	@intcolorid int,
	@colorname nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Interior_ColorMaster set Inter_color_name=@colorname,status=@status where Inter_color_id=@intcolorid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateInteriorMaterial]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateInteriorMaterial]
	-- Add the parameters for the stored procedure here
	@intmatid int,
	@matname nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update Interior_MaterialMaster set Inter_Mat_Name=@matname,status=@status where Inter_Mat_Id=@intmatid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateListedAs]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateListedAs]
	-- Add the parameters for the stored procedure here
	@listid int,
	@listed nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE ListedAs_Master SET listed_name=@listed,status=@status where listed_id=@listid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateMakeType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateMakeType]
	-- Add the parameters for the stored procedure here
	@makeid int,
	@make nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update MakeTypeMaster set make_type = @make , status = @status where make_id=@makeid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateModel]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateModel] 
	-- Add the parameters for the stored procedure here
   @modelid int,
   @make_id int,
   @model nvarchar(50),
   @status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update ModelMaster set make_id=@make_id,status=@status,model=@model where model_id= @modelid 
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateOdometer]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateOdometer]
	-- Add the parameters for the stored procedure here
	@meterid int,
	@meter nvarchar(50),
	@status nvarchar(20)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE OdoMeterMaster set odometer=@meter,status=@status where odo_id=@meterid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateReason]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateReason]
	-- Add the parameters for the stored procedure here
	@regionid int,
	@count_id int,
	@state_id int,
	@city_id int,
	@reason nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update ReasonMaster SET count_id = @count_id, state_id= @state_id, city_id = @city_id, reason=@reason , status = @status where reas_id=@regionid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateRegion]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRegion]
	-- Add the parameters for the stored procedure here
	@regionid int,
	@count_id int,
	@state_id int,
	@city_id int,
	@suburb int,
	@region nvarchar(50),
	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE NewRegionMaster SET coun_id=@count_id,state_id=@state_id, city_id=@city_id, reas_id=@suburb, regionname=@region,status=@status where regionid=@regionid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateSeriesType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSeriesType]
	-- Add the parameters for the stored procedure here
	@serid int,
	@make_id int,
	@model_id int,
	@bad_id int,
	@series nvarchar(50),
	@status nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	Update SeriesTypeMaster set make_id=@make_id,model_id=@model_id,bad_id=@bad_id,series_type=@series,status=@status where ser_id=@serid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateSpeedType]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateSpeedType]
	-- Add the parameters for the stored procedure here
	@speedtypeid int,
	@speedtypename nvarchar(200),
	@status nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update speedtypemaster set speedtypename = @speedtypename,status = @status where speedtypeid=@speedtypeid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateState]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateState] 
	-- Add the parameters for the stored procedure here
	@state_id int,
	@count_id int,
	@state_name nvarchar (max),
	@status int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
update tbl_state_master set count_id=@count_id , state_name=@state_name ,status =@status where state_id=@state_id
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateStatus]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateStatus] 
	-- Add the parameters for the stored procedure here
	@id int,
	@status nvarchar(200)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	declare @msg nvarchar(max)
	update tbl_login set status=@status where id=@id
	if @status = '0'
	begin
		SET @msg = ' Your details are being reviewed by the MYCARYARD team.'
	end
	else if @status = '1'
	begin
	   SET @msg = ' Your Profile is Approved By Super Admin'
	end
	else 
	begin
		SET @msg = ' Your Profile is DisApproved By Super Admin'
	end

	insert into usernotification 
	(
	edate,
	fromuid,
	touid,
	msg,
	status
	)
	values
	(
	GETUTCDATE(),
	'1',
	@id,
	@msg,
	'1'
	)
	
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateTransmision]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateTransmision]
	-- Add the parameters for the stored procedure here
	@transid int,
	@transmision nvarchar(50),

	@status nvarchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update TransmisionMaster SET transmision=@transmision,status =@status where trans_id=@transid
END



GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateUser]
	-- Add the parameters for the stored procedure here
@id int,
@dname nvarchar(100) = null,
@city nvarchar(max) = null,
@state nvarchar(max) = null,
@country nvarchar(max) = null,
@zip nvarchar(max) = null,
@gender nvarchar(max) = null,
@cno nvarchar(max) = null,
@regions nvarchar(max) = null,
--@suburb nvarchar(max) = null,
@street nvarchar(max) = null,
@streetname nvarchar(max) = null,
@fname nvarchar(max) = null,
@lname nvarchar(max) = null,
@other nvarchar(max) = null,
@other1 nvarchar(max) = null,
@other2 nvarchar(max)= null,
@late nvarchar(max) = null,
@long nvarchar(max) = null,
@showphone nvarchar(max) = null,
@bname nvarchar(max) = NULL

--@errorCode int output,
--@errorMessage nvarchar (200) output

AS
BEGIN TRY
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	update tbl_login
	 SET	
	[name] = @dname,
	 [gender]=@gender,
	 [cno] =@cno,
	 [country]=@country,
	 [state]=@state,
	 [city]=@city,
	 [other]=@other,
	 [other1]=@other1,
	[other2]=@other2,
	[fname]=@fname,
	[lname]=@lname,
	[regions]=@regions,
--[suburb]=@suburb,
	[zip]=@zip,
	[street]=@street,
	[streetname]=@streetname,
	[late]=@late,
	[long]=@long,
	showphone = @showphone,
	orgname = @bname


	where id =@id

	--SET @errorCode =0
--	SET @errorMessage ='SUCCESS'

END TRY
BEGIN CATCH
 --SET @errorCode = '10001'
	--SET @errorMessage = 'Internal Server Error - 1'
	END CATCH





GO
/****** Object:  StoredProcedure [dbo].[UpdateWatchliststatus]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdateWatchliststatus]
	-- Add the parameters for the stored procedure here
	@cid int,
	@uid int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	if exists(select 1 from CarWatchList where cid=@cid and uid=@uid)
	begin
		if exists(select 1 from carwatchlist where cid=@cid and uid=@uid and status = 1)
		begin
		update carwatchlist set status='0' where cid=@cid and uid=@uid
		end
		else 
		begin
		update carwatchlist set status='1' where cid=@cid and uid=@uid
		end
	end
	else 
	begin
	insert into carwatchlist(cid,uid,status) values(@cid,@uid,'1')
	end
	
END



GO
/****** Object:  StoredProcedure [dbo].[UserDetails]    Script Date: 2/15/2018 6:06:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UserDetails]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from tbl_login where id= @id
END



GO
USE [master]
GO
ALTER DATABASE [myCarYard_mycaryard] SET  READ_WRITE 
GO
