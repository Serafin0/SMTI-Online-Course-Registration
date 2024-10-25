USE [master]
GO
/****** Object:  Database [SMTIOnlineCourseRegistrationDB]    Script Date: 2024-10-17 5:35:10 PM ******/
CREATE DATABASE [SMTIOnlineCourseRegistrationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SMTIOnlineCourseRegistrationDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS2022\MSSQL\DATA\SMTIOnlineCourseRegistrationDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SMTIOnlineCourseRegistrationDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS2022\MSSQL\DATA\SMTIOnlineCourseRegistrationDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SMTIOnlineCourseRegistrationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET  MULTI_USER 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET QUERY_STORE = ON
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SMTIOnlineCourseRegistrationDB]
GO
/****** Object:  Table [dbo].[Courses]    Script Date: 2024-10-17 5:35:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Courses](
	[CourseNumber] [nvarchar](10) NOT NULL,
	[CourseTitle] [nvarchar](100) NULL,
	[TotalHour] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Registrations]    Script Date: 2024-10-17 5:35:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Registrations](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[StudentNumber] [int] NULL,
	[CourseNumber] [nvarchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Students]    Script Date: 2024-10-17 5:35:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Students](
	[StudentNumber] [int] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 2024-10-17 5:35:10 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserCode] [int] NOT NULL,
	[Password] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD FOREIGN KEY([CourseNumber])
REFERENCES [dbo].[Courses] ([CourseNumber])
GO
ALTER TABLE [dbo].[Registrations]  WITH CHECK ADD FOREIGN KEY([StudentNumber])
REFERENCES [dbo].[Students] ([StudentNumber])
GO
USE [master]
GO
ALTER DATABASE [SMTIOnlineCourseRegistrationDB] SET  READ_WRITE 
GO
