USE [master]
GO
/****** Object:  Database [JSP]    Script Date: 15-07-2018 12:46:40 AM ******/
CREATE DATABASE [JSP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JSP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\JSP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JSP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.SQLEXPRESS01\MSSQL\DATA\JSP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [JSP] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JSP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JSP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JSP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JSP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JSP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JSP] SET ARITHABORT OFF 
GO
ALTER DATABASE [JSP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JSP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JSP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JSP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JSP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JSP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JSP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JSP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JSP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JSP] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JSP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JSP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JSP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JSP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JSP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JSP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JSP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JSP] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [JSP] SET  MULTI_USER 
GO
ALTER DATABASE [JSP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JSP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JSP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JSP] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [JSP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JSP] SET QUERY_STORE = OFF
GO
USE [JSP]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [JSP]
GO
/****** Object:  Table [dbo].[AccessYear]    Script Date: 15-07-2018 12:46:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AccessYear](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AY] [nvarchar](max) NULL,
 CONSTRAINT [PK_AccessYear] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_Details]    Script Date: 15-07-2018 12:46:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AY] [varchar](50) NULL,
	[ClientId] [int] NOT NULL,
 CONSTRAINT [PK_Client_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client_Invoice]    Script Date: 15-07-2018 12:46:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client_Invoice](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Client_Id] [int] NULL,
	[InvoiceNumber] [varchar](max) NULL,
	[Client_DetailsId] [int] NOT NULL,
	[Path] [varchar](max) NULL,
 CONSTRAINT [PK_Client_Invoice] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 15-07-2018 12:46:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Address1] [varchar](max) NULL,
	[Address2] [varchar](max) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[PinCode] [varchar](50) NULL,
	[Email] [nvarchar](150) NULL,
	[Mobile] [varchar](50) NULL,
	[ReturnTypeId] [int] NOT NULL,
	[PAN] [varchar](50) NULL,
	[GST] [varchar](max) NULL,
	[DOB] [varchar](50) NULL,
 CONSTRAINT [PK_Clients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_Details]    Script Date: 15-07-2018 12:46:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_Details](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NULL,
	[Address1] [varchar](max) NULL,
	[Address2] [varchar](max) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[PinCode] [varchar](50) NULL,
	[Email] [nvarchar](150) NULL,
	[Mobile] [varchar](50) NULL,
	[PAN] [varchar](50) NULL,
	[BankName] [varchar](150) NULL,
	[AccountNumber] [varchar](150) NULL,
	[IFSCCode] [varchar](150) NULL,
	[BranchName] [varchar](150) NULL,
 CONSTRAINT [PK_Company_Details] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Logins]    Script Date: 15-07-2018 12:46:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Logins](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](150) NULL,
	[Password] [varchar](150) NULL,
 CONSTRAINT [PK_Logins] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReturnTypes]    Script Date: 15-07-2018 12:46:42 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReturnTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nchar](10) NULL,
 CONSTRAINT [PK_ReturnTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ClientClient_Details]    Script Date: 15-07-2018 12:46:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ClientClient_Details] ON [dbo].[Client_Details]
(
	[ClientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Client_DetailsClient_Invoice]    Script Date: 15-07-2018 12:46:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_Client_DetailsClient_Invoice] ON [dbo].[Client_Invoice]
(
	[Client_DetailsId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_ReturnTypeClient]    Script Date: 15-07-2018 12:46:42 AM ******/
CREATE NONCLUSTERED INDEX [IX_FK_ReturnTypeClient] ON [dbo].[Clients]
(
	[ReturnTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Client_Details]  WITH CHECK ADD  CONSTRAINT [FK_ClientClient_Details] FOREIGN KEY([ClientId])
REFERENCES [dbo].[Clients] ([Id])
GO
ALTER TABLE [dbo].[Client_Details] CHECK CONSTRAINT [FK_ClientClient_Details]
GO
ALTER TABLE [dbo].[Client_Invoice]  WITH CHECK ADD  CONSTRAINT [FK_Client_DetailsClient_Invoice] FOREIGN KEY([Client_DetailsId])
REFERENCES [dbo].[Client_Details] ([Id])
GO
ALTER TABLE [dbo].[Client_Invoice] CHECK CONSTRAINT [FK_Client_DetailsClient_Invoice]
GO
ALTER TABLE [dbo].[Clients]  WITH CHECK ADD  CONSTRAINT [FK_ReturnTypeClient] FOREIGN KEY([ReturnTypeId])
REFERENCES [dbo].[ReturnTypes] ([Id])
GO
ALTER TABLE [dbo].[Clients] CHECK CONSTRAINT [FK_ReturnTypeClient]
GO
USE [master]
GO
ALTER DATABASE [JSP] SET  READ_WRITE 
GO
