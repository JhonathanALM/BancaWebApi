USE [master]
GO
/****** Object:  Database [pichincha]    Script Date: 9/3/2022 6:59:36 PM ******/
CREATE DATABASE [pichincha]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'pichincha', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\pichincha.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'pichincha_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\pichincha_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [pichincha] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [pichincha].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [pichincha] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [pichincha] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [pichincha] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [pichincha] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [pichincha] SET ARITHABORT OFF 
GO
ALTER DATABASE [pichincha] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [pichincha] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [pichincha] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [pichincha] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [pichincha] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [pichincha] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [pichincha] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [pichincha] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [pichincha] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [pichincha] SET  ENABLE_BROKER 
GO
ALTER DATABASE [pichincha] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [pichincha] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [pichincha] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [pichincha] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [pichincha] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [pichincha] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [pichincha] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [pichincha] SET RECOVERY FULL 
GO
ALTER DATABASE [pichincha] SET  MULTI_USER 
GO
ALTER DATABASE [pichincha] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [pichincha] SET DB_CHAINING OFF 
GO
ALTER DATABASE [pichincha] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [pichincha] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [pichincha] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [pichincha] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'pichincha', N'ON'
GO
ALTER DATABASE [pichincha] SET QUERY_STORE = OFF
GO
USE [pichincha]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/3/2022 6:59:36 PM ******/
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
/****** Object:  Table [dbo].[Clientes]    Script Date: 9/3/2022 6:59:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[Estado] [nvarchar](max) NOT NULL,
	[Nombre] [nvarchar](max) NOT NULL,
	[Genero] [nvarchar](max) NOT NULL,
	[FechaNacimiento] [datetime2](7) NOT NULL,
	[Cedula] [nvarchar](max) NOT NULL,
	[Telefono] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cuentas]    Script Date: 9/3/2022 6:59:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cuentas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Numero] [nvarchar](max) NOT NULL,
	[Tipo] [nvarchar](max) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[Estado] [nvarchar](max) NOT NULL,
	[ClienteId] [int] NOT NULL,
 CONSTRAINT [PK_Cuentas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movimientos]    Script Date: 9/3/2022 6:59:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movimientos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Tipo] [nvarchar](max) NOT NULL,
	[Fecha] [datetime2](7) NOT NULL,
	[Monto] [decimal](18, 2) NOT NULL,
	[Saldo] [decimal](18, 2) NOT NULL,
	[CuentaId] [int] NOT NULL,
 CONSTRAINT [PK_Movimientos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_Cuentas_ClienteId]    Script Date: 9/3/2022 6:59:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Cuentas_ClienteId] ON [dbo].[Cuentas]
(
	[ClienteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movimientos_CuentaId]    Script Date: 9/3/2022 6:59:36 PM ******/
CREATE NONCLUSTERED INDEX [IX_Movimientos_CuentaId] ON [dbo].[Movimientos]
(
	[CuentaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cuentas]  WITH CHECK ADD  CONSTRAINT [FK_Cuentas_Clientes_ClienteId] FOREIGN KEY([ClienteId])
REFERENCES [dbo].[Clientes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Cuentas] CHECK CONSTRAINT [FK_Cuentas_Clientes_ClienteId]
GO
ALTER TABLE [dbo].[Movimientos]  WITH CHECK ADD  CONSTRAINT [FK_Movimientos_Cuentas_CuentaId] FOREIGN KEY([CuentaId])
REFERENCES [dbo].[Cuentas] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movimientos] CHECK CONSTRAINT [FK_Movimientos_Cuentas_CuentaId]
GO
USE [master]
GO
ALTER DATABASE [pichincha] SET  READ_WRITE 
GO
