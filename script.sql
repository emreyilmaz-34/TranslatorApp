USE [master]
GO
/****** Object:  Database [TranslatorAppDb]    Script Date: 12/20/2021 1:23:24 PM ******/
CREATE DATABASE [TranslatorAppDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TranslatorAppDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TranslatorAppDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TranslatorAppDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TranslatorAppDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TranslatorAppDb] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TranslatorAppDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TranslatorAppDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TranslatorAppDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TranslatorAppDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TranslatorAppDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TranslatorAppDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TranslatorAppDb] SET  MULTI_USER 
GO
ALTER DATABASE [TranslatorAppDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TranslatorAppDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TranslatorAppDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TranslatorAppDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TranslatorAppDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TranslatorAppDb] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TranslatorAppDb] SET QUERY_STORE = OFF
GO
USE [TranslatorAppDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/20/2021 1:23:24 PM ******/
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
/****** Object:  Table [dbo].[Languages]    Script Date: 12/20/2021 1:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CratedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TestModels]    Script Date: 12/20/2021 1:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TestModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Surname] [nvarchar](max) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CratedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_TestModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Translations]    Script Date: 12/20/2021 1:23:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Translated] [nvarchar](max) NULL,
	[Text] [nvarchar](max) NOT NULL,
	[LanguageId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CratedBy] [nvarchar](max) NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211215051531_Initial', N'5.0.13')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20211218203542_AddTestModels', N'5.0.13')
GO
SET IDENTITY_INSERT [dbo].[Languages] ON 

INSERT [dbo].[Languages] ([Id], [Name], [CreatedAt], [IsDeleted], [IsActive], [CratedBy]) VALUES (7, N'dothraki', CAST(N'2021-12-19T15:40:25.7901975' AS DateTime2), 0, 1, N'Admin')
INSERT [dbo].[Languages] ([Id], [Name], [CreatedAt], [IsDeleted], [IsActive], [CratedBy]) VALUES (9, N'valyrian', CAST(N'2021-12-19T17:17:33.2219449' AS DateTime2), 0, 1, N'Admin')
SET IDENTITY_INSERT [dbo].[Languages] OFF
GO
SET IDENTITY_INSERT [dbo].[TestModels] ON 

INSERT [dbo].[TestModels] ([Id], [Name], [Surname], [CreatedAt], [IsDeleted], [IsActive], [CratedBy]) VALUES (1, N'test', NULL, CAST(N'2021-12-18T23:49:44.8658790' AS DateTime2), 0, 1, N'Admin')
SET IDENTITY_INSERT [dbo].[TestModels] OFF
GO
/****** Object:  Index [IX_Translations_LanguageId]    Script Date: 12/20/2021 1:23:24 PM ******/
CREATE NONCLUSTERED INDEX [IX_Translations_LanguageId] ON [dbo].[Translations]
(
	[LanguageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Languages_LanguageId] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[Languages] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Languages_LanguageId]
GO
USE [master]
GO
ALTER DATABASE [TranslatorAppDb] SET  READ_WRITE 
GO
