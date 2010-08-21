USE [master]
GO
/****** 对象:  Database [KnowledgeManagementSystem]    脚本日期: 08/20/2010 13:30:14 ******/
CREATE DATABASE [KnowledgeManagementSystem] ON  PRIMARY 
( NAME = N'KnowledgeManagementSystem', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\KnowledgeManagementSystem.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'KnowledgeManagementSystem_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\KnowledgeManagementSystem_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Chinese_PRC_CI_AS
GO
EXEC dbo.sp_dbcmptlevel @dbname=N'KnowledgeManagementSystem', @new_cmptlevel=90
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [KnowledgeManagementSystem].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [KnowledgeManagementSystem] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET ARITHABORT OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET  DISABLE_BROKER 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET  READ_WRITE 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET  MULTI_USER 
GO
ALTER DATABASE [KnowledgeManagementSystem] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [KnowledgeManagementSystem] SET DB_CHAINING OFF 