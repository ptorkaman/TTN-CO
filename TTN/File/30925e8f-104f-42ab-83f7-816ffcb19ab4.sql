USE [TTNCO]
GO
/****** Object:  Schema [TTN]    Script Date: 8/9/2021 9:42:55 AM ******/
CREATE SCHEMA [TTN]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 8/9/2021 9:42:55 AM ******/
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[BijakBins]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[BijakBins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BijakId] [bigint] NOT NULL,
	[BinId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BijakBins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[BijakDtls]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[BijakDtls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BijakId] [bigint] NOT NULL,
	[GoodsName] [nvarchar](max) NULL,
	[GoodsId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[UsnitId] [int] NOT NULL,
	[weight] [decimal](18, 4) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BijakDtls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Bijaks]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Bijaks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[BijakNo] [int] NOT NULL,
	[ReferenceNo] [nvarchar](max) NULL,
	[senderId] [int] NOT NULL,
	[RecieverId] [int] NOT NULL,
	[StartwarhouseId] [int] NULL,
	[DestinationWarhouseId] [int] NULL,
	[Istransport1] [bit] NULL,
	[Istransport2] [bit] NULL,
	[StartingCity] [int] NOT NULL,
	[DestinationCity] [int] NOT NULL,
	[NeedIncurance] [int] NULL,
	[Remark] [int] NOT NULL,
	[StatusId] [int] NOT NULL,
	[FreightAmt] [decimal](18, 4) NOT NULL,
	[InsuranceAmt] [decimal](18, 4) NOT NULL,
	[CityAmt] [decimal](18, 4) NOT NULL,
	[PassingAmt] [decimal](18, 4) NOT NULL,
	[DerricAmt] [decimal](18, 4) NOT NULL,
	[DownloadAmt] [decimal](18, 4) NOT NULL,
	[InstitutionAmt] [decimal](18, 4) NOT NULL,
	[PerfixAmt] [decimal](18, 4) NOT NULL,
	[TotalAmt] [decimal](18, 4) NOT NULL,
	[TipAmt] [decimal](18, 4) NOT NULL,
	[Startlatitude] [decimal](18, 4) NOT NULL,
	[Startlongitude] [decimal](18, 4) NOT NULL,
	[Destinationlatitude] [decimal](18, 4) NOT NULL,
	[Destinationlongtude] [decimal](18, 4) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Bijaks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [TTN]
GO
/****** Object:  Table [TTN].[BijakStatuses]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[BijakStatuses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BijakStatuses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Bins]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Bins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehoseId] [int] NOT NULL,
	[BinName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Bins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Cities]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Cities](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProvinceId] [int] NOT NULL,
	[WarhouseId] [int] NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Latitude] [decimal](18, 4) NOT NULL,
	[Longitude] [decimal](18, 4) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
	[SortBy] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Countries]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[EnglishName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[GroupUser]    Script Date: 8/9/2021 9:42:55 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[GroupUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupName] [nvarchar](50) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_GCS_GroupUser] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[MenuPermissions]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[MenuPermissions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[PermissionId] [bigint] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_MenuPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[MenuId] ASC,
	[PermissionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Menus]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Menus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ParentId] [bigint] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Menus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Parishes]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Parishes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegionId] [int] NOT NULL,
	[ParishName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Parishes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Permissions]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Permissions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EnglishName] [nvarchar](50) NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Permissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Persons]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Persons](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](150) NULL,
	[LastName] [nvarchar](150) NULL,
	[NationalCode] [nvarchar](50) NULL,
	[Identity] [nvarchar](50) NULL,
	[FatherName] [nvarchar](50) NULL,
	[BirthDate] [datetime2](7) NULL,
	[GenderId] [tinyint] NOT NULL,
	[MarriageId] [tinyint] NOT NULL,
	[MillitaryId] [tinyint] NULL,
	[Address] [nvarchar](256) NULL,
	[CityId] [int] NULL,
	[Gender] [bit] NULL,
	[IdNumber] [nvarchar](20) NULL,
	[ImagePath] [nvarchar](50) NULL,
	[IsMarried] [bit] NULL,
	[Mobile] [nvarchar](11) NULL,
	[PersonalNo] [nvarchar](20) NULL,
	[Phone] [nvarchar](11) NULL,
	[ProvinceId] [int] NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Provinces]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Provinces](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[ProvinceName] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Provinces] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Recivers]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Recivers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Recivers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Regions]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Regions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[Name] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[RolePermissions]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[RolePermissions](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[PermissionId] [bigint] NOT NULL,
 CONSTRAINT [PK_RolePermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Roles]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Roles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Senders]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Senders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NOT NULL,
	[CompanyName] [nvarchar](max) NULL,
	[CompanyCode] [nvarchar](max) NULL,
	[Name] [nvarchar](max) NULL,
	[Mobile] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Senders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[SenderWarehouses]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[SenderWarehouses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SenderId] [int] NOT NULL,
	[WarehouseId] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SenderWarehouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[TransportationDtls]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[TransportationDtls](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TransportationId] [int] NOT NULL,
	[Remark] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TransportationDtls] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Units]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Units](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Dimension] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[UserMenus]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[UserMenus](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Userid] [bigint] NOT NULL,
	[MenuId] [bigint] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Userid] ASC,
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[UserRoles]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[UserRoles](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleId] [bigint] NOT NULL,
	[UserId] [bigint] NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Users]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Users](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[PersonId] [bigint] NOT NULL,
	[Code] [uniqueidentifier] NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](200) NULL,
	[Email] [nvarchar](max) NULL,
	[EmailVerifiedAt] [datetime2](7) NULL,
	[IsEnable] [tinyint] NULL,
	[IsVerified] [tinyint] NULL,
	[IsTwoStepVerification] [tinyint] NULL,
	[TwoStepCode] [nvarchar](10) NULL,
	[TwoStepExpiration] [datetime2](7) NULL,
	[IsLoginNotify] [tinyint] NULL,
	[VerificationCode] [nvarchar](max) NULL,
	[VerificationExpiration] [datetime2](7) NULL,
	[LastLogOnDate] [datetime2](7) NULL,
	[CreatedDate] [datetime2](7) NULL,
	[ChangePasswordCode] [varchar](10) NULL,
	[DepartmentId] [int] NULL,
	[DisplayName] [nvarchar](max) NULL,
	[PersonalId] [int] NULL,
	[UserType] [int] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[UserTypes]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[UserTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[UserWarhouses]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[UserWarhouses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[WareouseId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_UserWarhouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [TTN].[Warehouses]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[Warehouses](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseCode] [nvarchar](max) NULL,
	[CityId] [int] NOT NULL,
	[WarhouseName] [nvarchar](max) NULL,
	[ContactPerson] [nvarchar](max) NULL,
	[ContactMobile1] [nvarchar](max) NULL,
	[ContactMobile2] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Latitude] [decimal](18, 4) NOT NULL,
	[Longitude] [decimal](18, 4) NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Warehouses] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [TTN].[WehicleType]    Script Date: 8/9/2021 9:42:56 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [TTN].[WehicleType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Dimension] [nvarchar](max) NULL,
	[FactoryId] [nvarchar](max) NULL,
	[DownloadType] [nvarchar](max) NULL,
	[MinimumCapacity] [int] NOT NULL,
	[MaximumCapacity] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[CreatedBy] [int] NOT NULL,
	[ModifiedDate] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_WehicleType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210803104715_initi', N'5.0.8')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210803121648_ts', N'5.0.8')
SET IDENTITY_INSERT [TTN].[Cities] ON 

INSERT [TTN].[Cities] ([Id], [ProvinceId], [WarhouseId], [Name], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive], [SortBy]) VALUES (1, 1, NULL, N'تهران', CAST(30.0000 AS Decimal(18, 4)), CAST(10.0000 AS Decimal(18, 4)), CAST(N'2021-08-09T09:05:28.4235506' AS DateTime2), 1, NULL, NULL, 1, 0)
SET IDENTITY_INSERT [TTN].[Cities] OFF
SET IDENTITY_INSERT [TTN].[Countries] ON 

INSERT [TTN].[Countries] ([Id], [Name], [EnglishName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'ایران', N'iran', CAST(N'2021-08-09T08:54:19.7304217' AS DateTime2), 0, NULL, NULL, 1)
SET IDENTITY_INSERT [TTN].[Countries] OFF
SET IDENTITY_INSERT [TTN].[Parishes] ON 

INSERT [TTN].[Parishes] ([Id], [RegionId], [ParishName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 1, N'Parish 1', CAST(N'2021-08-09T09:06:55.8005482' AS DateTime2), 1, NULL, NULL, 1)
INSERT [TTN].[Parishes] ([Id], [RegionId], [ParishName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, 1, N'Parish 2', CAST(N'2021-08-09T09:07:02.0438974' AS DateTime2), 1, NULL, NULL, 1)
INSERT [TTN].[Parishes] ([Id], [RegionId], [ParishName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (3, 1, N'Parish 3', CAST(N'2021-08-09T09:07:04.1671197' AS DateTime2), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [TTN].[Parishes] OFF
SET IDENTITY_INSERT [TTN].[Persons] ON 

INSERT [TTN].[Persons] ([Id], [Code], [FirstName], [LastName], [NationalCode], [Identity], [FatherName], [BirthDate], [GenderId], [MarriageId], [MillitaryId], [Address], [CityId], [Gender], [IdNumber], [ImagePath], [IsMarried], [Mobile], [PersonalNo], [Phone], [ProvinceId]) VALUES (1, N'78be80c2-739c-47b2-90cd-a253d44c0d10', N'string', N'string', N'string', N'string', N'string', NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [TTN].[Persons] ([Id], [Code], [FirstName], [LastName], [NationalCode], [Identity], [FatherName], [BirthDate], [GenderId], [MarriageId], [MillitaryId], [Address], [CityId], [Gender], [IdNumber], [ImagePath], [IsMarried], [Mobile], [PersonalNo], [Phone], [ProvinceId]) VALUES (2, N'7c6f6ed1-bb79-456a-85c3-4735ec636c8b', N'string', N'string', N'string', N'string', N'string', NULL, 0, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [TTN].[Persons] OFF
SET IDENTITY_INSERT [TTN].[Provinces] ON 

INSERT [TTN].[Provinces] ([Id], [CountryId], [ProvinceName], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 1, N'تهران', CAST(N'2021-08-09T08:58:30.0410406' AS DateTime2), 0, NULL, NULL, 1)
SET IDENTITY_INSERT [TTN].[Provinces] OFF
SET IDENTITY_INSERT [TTN].[Regions] ON 

INSERT [TTN].[Regions] ([Id], [CityId], [Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 1, N'region 1', CAST(N'2021-08-09T09:06:14.5708424' AS DateTime2), 1, NULL, NULL, 1)
INSERT [TTN].[Regions] ([Id], [CityId], [Name], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (2, 1, N'region 2', CAST(N'2021-08-09T09:06:21.5612230' AS DateTime2), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [TTN].[Regions] OFF
SET IDENTITY_INSERT [TTN].[Users] ON 

INSERT [TTN].[Users] ([Id], [PersonId], [Code], [Username], [Password], [Email], [EmailVerifiedAt], [IsEnable], [IsVerified], [IsTwoStepVerification], [TwoStepCode], [TwoStepExpiration], [IsLoginNotify], [VerificationCode], [VerificationExpiration], [LastLogOnDate], [CreatedDate], [ChangePasswordCode], [DepartmentId], [DisplayName], [PersonalId], [UserType]) VALUES (1, 2, N'c948b5c4-e4b7-4b2c-a524-bc1175c8c97a', N'torkaman', N'pmWkWSBCL51Bfkhn79xPuKBKHz//H6B+mY6G9/eieuM=', N'string', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2021-08-09T09:38:22.7775029' AS DateTime2), NULL, N'deb7ebd6', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [TTN].[Users] OFF
SET IDENTITY_INSERT [TTN].[UserWarhouses] ON 

INSERT [TTN].[UserWarhouses] ([Id], [UserId], [WareouseId], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, 1, 1, CAST(N'2021-08-09T09:12:05.5828204' AS DateTime2), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [TTN].[UserWarhouses] OFF
SET IDENTITY_INSERT [TTN].[Warehouses] ON 

INSERT [TTN].[Warehouses] ([Id], [WarehouseCode], [CityId], [WarhouseName], [ContactPerson], [ContactMobile1], [ContactMobile2], [Phone], [Address], [Latitude], [Longitude], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy], [IsActive]) VALUES (1, N'warehouse Code', 1, N'warhouse Name', N'contact Person', N'contact Mobile1', N'contact Mobile2', N'09365540839', N'address address', CAST(60.0000 AS Decimal(18, 4)), CAST(40.0000 AS Decimal(18, 4)), CAST(N'2021-08-09T09:11:45.8531337' AS DateTime2), 1, NULL, NULL, 1)
SET IDENTITY_INSERT [TTN].[Warehouses] OFF
ALTER TABLE [TTN].[Users] ADD  CONSTRAINT [DF__User__Code__5812160E]  DEFAULT (newid()) FOR [Code]
GO
ALTER TABLE [TTN].[RolePermissions]  WITH CHECK ADD  CONSTRAINT [FK_RolePermissions_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [TTN].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [TTN].[RolePermissions] CHECK CONSTRAINT [FK_RolePermissions_Roles_RoleId]
GO
ALTER TABLE [TTN].[UserMenus]  WITH CHECK ADD  CONSTRAINT [FK_UserMenus_Menus] FOREIGN KEY([MenuId])
REFERENCES [TTN].[Menus] ([Id])
GO
ALTER TABLE [TTN].[UserMenus] CHECK CONSTRAINT [FK_UserMenus_Menus]
GO
ALTER TABLE [TTN].[UserMenus]  WITH CHECK ADD  CONSTRAINT [FK_UserMenus_User] FOREIGN KEY([Userid])
REFERENCES [TTN].[Users] ([Id])
GO
ALTER TABLE [TTN].[UserMenus] CHECK CONSTRAINT [FK_UserMenus_User]
GO
ALTER TABLE [TTN].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [TTN].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [TTN].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [TTN].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_User_UserId] FOREIGN KEY([UserId])
REFERENCES [TTN].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [TTN].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_User_UserId]
GO
ALTER TABLE [TTN].[Warehouses]  WITH CHECK ADD  CONSTRAINT [FK_Warehouses_Cities] FOREIGN KEY([CityId])
REFERENCES [TTN].[Cities] ([Id])
GO
ALTER TABLE [TTN].[Warehouses] CHECK CONSTRAINT [FK_Warehouses_Cities]
GO
