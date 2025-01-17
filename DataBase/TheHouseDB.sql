USE [master]
GO
/****** Object:  Database [TheHouseDb]    Script Date: 12/7/2019 3:11:45 AM ******/
CREATE DATABASE [TheHouseDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TheHouseDb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TheHouseDb.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'TheHouseDb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\TheHouseDb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [TheHouseDb] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TheHouseDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TheHouseDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TheHouseDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TheHouseDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TheHouseDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TheHouseDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [TheHouseDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TheHouseDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TheHouseDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TheHouseDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TheHouseDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TheHouseDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TheHouseDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TheHouseDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TheHouseDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TheHouseDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TheHouseDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TheHouseDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TheHouseDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TheHouseDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TheHouseDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TheHouseDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TheHouseDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TheHouseDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TheHouseDb] SET  MULTI_USER 
GO
ALTER DATABASE [TheHouseDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TheHouseDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TheHouseDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TheHouseDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [TheHouseDb] SET DELAYED_DURABILITY = DISABLED 
GO
USE [TheHouseDb]
GO
/****** Object:  Table [dbo].[tbl_Booking]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Booking](
	[B_Id] [int] IDENTITY(1,1) NOT NULL,
	[ArrivalDate] [date] NULL,
	[DepartureDate] [date] NULL,
	[TotalPerson] [int] NULL,
	[BookedBy] [varchar](100) NULL,
	[Booking_Date] [date] NULL,
	[B_Status] [varchar](max) NULL,
 CONSTRAINT [PK_tbl_Booking] PRIMARY KEY CLUSTERED 
(
	[B_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_BookingBridge]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_BookingBridge](
	[BB_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_BookingID] [int] NULL,
	[FK_HouseID] [int] NULL,
	[FK_RoomID] [int] NULL,
	[FK_GuestID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[BB_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_CardDetails]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_CardDetails](
	[C_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_GuestID] [int] NULL,
	[Card_Type] [varchar](10) NULL,
	[Card_Number] [nvarchar](20) NULL,
	[ExpiryDate] [nvarchar](20) NULL,
	[NameOnCard] [varchar](50) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[C_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[Cat_Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_HouseID] [int] NULL,
	[Cat_Name] [varchar](max) NULL,
	[Cat_Description] [text] NULL,
	[Cat_Status] [bit] NULL,
 CONSTRAINT [PK_tbl_Category] PRIMARY KEY CLUSTERED 
(
	[Cat_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Guest]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Guest](
	[G_Id] [int] IDENTITY(1,1) NOT NULL,
	[G_Name] [varchar](100) NULL,
	[G_Email] [varchar](100) NULL,
	[G_Pass] [varchar](20) NULL,
	[G_Phone] [nvarchar](15) NULL,
	[G_Gender] [varchar](20) NULL,
	[G_City] [varchar](100) NULL,
	[G_Country] [varchar](100) NULL,
	[G_CNIC] [varchar](20) NULL,
	[G_Passport] [varchar](30) NULL,
	[G_Status] [char](1) NULL,
	[Type] [char](5) NULL,
PRIMARY KEY CLUSTERED 
(
	[G_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_House]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_House](
	[H_ID] [int] IDENTITY(1,1) NOT NULL,
	[FK_UserID] [int] NOT NULL,
	[H_Name] [varchar](max) NULL,
	[H_Location] [varchar](max) NULL,
	[H_City] [varchar](max) NULL,
	[H_Address] [varchar](max) NULL,
	[H_NoOfRoom] [int] NULL,
	[H_Image] [nvarchar](max) NULL,
	[H_Status] [bit] NULL,
 CONSTRAINT [PK_tbl_House] PRIMARY KEY CLUSTERED 
(
	[H_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Payment]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Payment](
	[P_Id] [int] IDENTITY(1,1) NOT NULL,
	[PK_BookingBridgeID] [int] NULL,
	[Total_Amount] [decimal](10, 1) NULL,
	[Status] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[P_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_RoomCharges]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RoomCharges](
	[RC_Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_TypeID] [int] NULL,
	[FK_CatID] [int] NULL,
	[Charges] [decimal](10, 1) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[RC_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_RoomsDetails]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_RoomsDetails](
	[R_Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_HouseID] [int] NULL,
	[FK_TypeID] [int] NULL,
	[FK_CateID] [int] NULL,
	[R_Desc] [varchar](200) NULL,
	[R_Capacity] [int] NULL,
	[R_Image] [nvarchar](max) NULL,
	[R_Status] [bit] NULL,
 CONSTRAINT [PK_tbl_RoomsDetails] PRIMARY KEY CLUSTERED 
(
	[R_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Type]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Type](
	[Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[FK_CateID] [int] NULL,
	[Type_Name] [varchar](max) NULL,
	[Type_Description] [text] NULL,
	[Type_Status] [bit] NULL,
 CONSTRAINT [PK_tbl_Type] PRIMARY KEY CLUSTERED 
(
	[Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_User]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_User](
	[User_Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [varchar](100) NULL,
	[UserEmail] [varchar](100) NULL,
	[UserPass] [varchar](20) NULL,
	[UserContact] [varchar](20) NULL,
	[UserAddress] [varchar](200) NULL,
	[UserImage] [nvarchar](max) NULL,
	[CreatedDate] [nvarchar](max) NULL,
	[UserType] [varchar](20) NULL,
	[isActive] [bit] NULL,
 CONSTRAINT [PK_tbl_User] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Category] ON 

INSERT [dbo].[tbl_Category] ([Cat_Id], [FK_HouseID], [Cat_Name], [Cat_Description], [Cat_Status]) VALUES (1, 1, N'Master', N'This is master category of hotel', 1)
INSERT [dbo].[tbl_Category] ([Cat_Id], [FK_HouseID], [Cat_Name], [Cat_Description], [Cat_Status]) VALUES (2, 2, N'CLASSIC', N'Our contemporary Classic Rooms are furnished in soft earthy tones and offer a 35 sqm space with your choice of a king-size bed or twin beds', 1)
INSERT [dbo].[tbl_Category] ([Cat_Id], [FK_HouseID], [Cat_Name], [Cat_Description], [Cat_Status]) VALUES (3, 2, N'SUPERIOR', N'Benefit from extra space, relaxing pool views and complimentary advantages like free buffet breakfast and an airport shuttle transfer in our Superior Rooms', 1)
SET IDENTITY_INSERT [dbo].[tbl_Category] OFF
SET IDENTITY_INSERT [dbo].[tbl_Guest] ON 

INSERT [dbo].[tbl_Guest] ([G_Id], [G_Name], [G_Email], [G_Pass], [G_Phone], [G_Gender], [G_City], [G_Country], [G_CNIC], [G_Passport], [G_Status], [Type]) VALUES (1, N'TestGuest', N'test@gmail.com', N'123', N'03003216547', N'Male', N'Karachi', N'pak', N'11323232323565', N'5545662323', N'T', N'G    ')
INSERT [dbo].[tbl_Guest] ([G_Id], [G_Name], [G_Email], [G_Pass], [G_Phone], [G_Gender], [G_City], [G_Country], [G_CNIC], [G_Passport], [G_Status], [Type]) VALUES (8, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'T', N'G    ')
SET IDENTITY_INSERT [dbo].[tbl_Guest] OFF
SET IDENTITY_INSERT [dbo].[tbl_House] ON 

INSERT [dbo].[tbl_House] ([H_ID], [FK_UserID], [H_Name], [H_Location], [H_City], [H_Address], [H_NoOfRoom], [H_Image], [H_Status]) VALUES (1, 3, N'The Rest Place', N'DHA', N'Karachi', N'DHA-Phase-5', 10, N'1 Hotel01.jpg .jpg', 1)
INSERT [dbo].[tbl_House] ([H_ID], [FK_UserID], [H_Name], [H_Location], [H_City], [H_Address], [H_NoOfRoom], [H_Image], [H_Status]) VALUES (2, 3, N'The Rest Place-II', N'Qasimabad', N'Hyderabad', N'Main Road ', 5, N'slider4.jpg 0 .jpg', 1)
INSERT [dbo].[tbl_House] ([H_ID], [FK_UserID], [H_Name], [H_Location], [H_City], [H_Address], [H_NoOfRoom], [H_Image], [H_Status]) VALUES (3, 3, N'The Rest Place-III', N'DHA', N'Islamabad', N'Main Road ', 10, N'slider5.jpg 0 .jpg', 1)
INSERT [dbo].[tbl_House] ([H_ID], [FK_UserID], [H_Name], [H_Location], [H_City], [H_Address], [H_NoOfRoom], [H_Image], [H_Status]) VALUES (4, 2, N'Special House', N'DHA', N'lahore', N'Gulburg Lahore', 4, N'12.jpg 0 .jpg', 1)
INSERT [dbo].[tbl_House] ([H_ID], [FK_UserID], [H_Name], [H_Location], [H_City], [H_Address], [H_NoOfRoom], [H_Image], [H_Status]) VALUES (5, 2, N'Special House II', N'Bahria Town', N'Karachi', N'Bahrai Town Karachi', 4, N'5 Hotel02.jpg .jpg', 1)
SET IDENTITY_INSERT [dbo].[tbl_House] OFF
SET IDENTITY_INSERT [dbo].[tbl_RoomCharges] ON 

INSERT [dbo].[tbl_RoomCharges] ([RC_Id], [FK_TypeID], [FK_CatID], [Charges], [Status]) VALUES (1, 1, 1, CAST(3000.0 AS Decimal(10, 1)), 1)
INSERT [dbo].[tbl_RoomCharges] ([RC_Id], [FK_TypeID], [FK_CatID], [Charges], [Status]) VALUES (2, 2, 2, CAST(5000.0 AS Decimal(10, 1)), 1)
SET IDENTITY_INSERT [dbo].[tbl_RoomCharges] OFF
SET IDENTITY_INSERT [dbo].[tbl_RoomsDetails] ON 

INSERT [dbo].[tbl_RoomsDetails] ([R_Id], [FK_HouseID], [FK_TypeID], [FK_CateID], [R_Desc], [R_Capacity], [R_Image], [R_Status]) VALUES (5, 4, 2, 3, N'This room can be reserved for max two people.', 2, N'Room1c326635-cee9-4066-ad26-ab8d87c81493 .jpg', 1)
INSERT [dbo].[tbl_RoomsDetails] ([R_Id], [FK_HouseID], [FK_TypeID], [FK_CateID], [R_Desc], [R_Capacity], [R_Image], [R_Status]) VALUES (6, 1, 1, 1, N'This is Room Description ', 1, N'Room75fb1b7d-a0d6-4e80-b4c2-d6baf41c644a .jpg', 1)
SET IDENTITY_INSERT [dbo].[tbl_RoomsDetails] OFF
SET IDENTITY_INSERT [dbo].[tbl_Type] ON 

INSERT [dbo].[tbl_Type] ([Type_Id], [FK_CateID], [Type_Name], [Type_Description], [Type_Status]) VALUES (1, 1, N'Single Room', N'This is single bed room with attached bath and it is for only one person.', 1)
INSERT [dbo].[tbl_Type] ([Type_Id], [FK_CateID], [Type_Name], [Type_Description], [Type_Status]) VALUES (2, 2, N'Double Room', N'This is two bed room for max 2 people.', 1)
INSERT [dbo].[tbl_Type] ([Type_Id], [FK_CateID], [Type_Name], [Type_Description], [Type_Status]) VALUES (3, 3, N'Singl Room', N'This is single bed room with attached bath and it is for only one person.', 1)
SET IDENTITY_INSERT [dbo].[tbl_Type] OFF
SET IDENTITY_INSERT [dbo].[tbl_User] ON 

INSERT [dbo].[tbl_User] ([User_Id], [FullName], [UserEmail], [UserPass], [UserContact], [UserAddress], [UserImage], [CreatedDate], [UserType], [isActive]) VALUES (1, N'admin', N'admin@admin.com', N'123', N'03003216547', N'Karachi', N'admin@admin.com .png', N'2019-09-12', N'Admin', 1)
INSERT [dbo].[tbl_User] ([User_Id], [FullName], [UserEmail], [UserPass], [UserContact], [UserAddress], [UserImage], [CreatedDate], [UserType], [isActive]) VALUES (2, N'Nazar Muhammad', N'nazar@gmail.com', N'123', N'03003216547', N'Model Colony', N'nazar@gmail.com .jpg', N'2019-11-01', N'User', 1)
INSERT [dbo].[tbl_User] ([User_Id], [FullName], [UserEmail], [UserPass], [UserContact], [UserAddress], [UserImage], [CreatedDate], [UserType], [isActive]) VALUES (3, N'Saquib', N'saquib@gmail.com', N'000', N'03003216547', N'Malir Cantt', N'saquib@gmail.com .jpg', N'Sunday, November 17, 2019', N'User', 1)
INSERT [dbo].[tbl_User] ([User_Id], [FullName], [UserEmail], [UserPass], [UserContact], [UserAddress], [UserImage], [CreatedDate], [UserType], [isActive]) VALUES (6, N'Nazar Muhammad', N'inazar@gmail.com', N'123', N'03002316547', N'Model Colony', N'pic.jpg 0 .jpg', N'Sunday, November 17, 2019', N'User', 1)
INSERT [dbo].[tbl_User] ([User_Id], [FullName], [UserEmail], [UserPass], [UserContact], [UserAddress], [UserImage], [CreatedDate], [UserType], [isActive]) VALUES (8, N'Testing user', N'testing@user.com', N'123', N'03003216547', N'Model Colony', N'default.png', N'Tuesday, November 19, 2019', N'User', 1)
INSERT [dbo].[tbl_User] ([User_Id], [FullName], [UserEmail], [UserPass], [UserContact], [UserAddress], [UserImage], [CreatedDate], [UserType], [isActive]) VALUES (9, N'user testing', N'user@gmail.com', N'1230', N'03003216547', N'Model Colony', N'user@gmail.com .jpg', N'Friday, December 6, 2019', N'User', 1)
SET IDENTITY_INSERT [dbo].[tbl_User] OFF
ALTER TABLE [dbo].[tbl_BookingBridge]  WITH CHECK ADD  CONSTRAINT [FK_tbl_BookingBridge_tbl_Booking] FOREIGN KEY([FK_BookingID])
REFERENCES [dbo].[tbl_Booking] ([B_Id])
GO
ALTER TABLE [dbo].[tbl_BookingBridge] CHECK CONSTRAINT [FK_tbl_BookingBridge_tbl_Booking]
GO
ALTER TABLE [dbo].[tbl_BookingBridge]  WITH CHECK ADD  CONSTRAINT [FK_tbl_BookingBridge_tbl_Guest] FOREIGN KEY([FK_GuestID])
REFERENCES [dbo].[tbl_Guest] ([G_Id])
GO
ALTER TABLE [dbo].[tbl_BookingBridge] CHECK CONSTRAINT [FK_tbl_BookingBridge_tbl_Guest]
GO
ALTER TABLE [dbo].[tbl_BookingBridge]  WITH CHECK ADD  CONSTRAINT [FK_tbl_BookingBridge_tbl_House] FOREIGN KEY([FK_HouseID])
REFERENCES [dbo].[tbl_House] ([H_ID])
GO
ALTER TABLE [dbo].[tbl_BookingBridge] CHECK CONSTRAINT [FK_tbl_BookingBridge_tbl_House]
GO
ALTER TABLE [dbo].[tbl_BookingBridge]  WITH CHECK ADD  CONSTRAINT [FK_tbl_BookingBridge_tbl_RoomsDetails] FOREIGN KEY([FK_RoomID])
REFERENCES [dbo].[tbl_RoomsDetails] ([R_Id])
GO
ALTER TABLE [dbo].[tbl_BookingBridge] CHECK CONSTRAINT [FK_tbl_BookingBridge_tbl_RoomsDetails]
GO
ALTER TABLE [dbo].[tbl_CardDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_CardDetails_tbl_Guest] FOREIGN KEY([FK_GuestID])
REFERENCES [dbo].[tbl_Guest] ([G_Id])
GO
ALTER TABLE [dbo].[tbl_CardDetails] CHECK CONSTRAINT [FK_tbl_CardDetails_tbl_Guest]
GO
ALTER TABLE [dbo].[tbl_Category]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Category_tbl_House] FOREIGN KEY([FK_HouseID])
REFERENCES [dbo].[tbl_House] ([H_ID])
GO
ALTER TABLE [dbo].[tbl_Category] CHECK CONSTRAINT [FK_tbl_Category_tbl_House]
GO
ALTER TABLE [dbo].[tbl_House]  WITH CHECK ADD  CONSTRAINT [FK_tbl_House_tbl_User] FOREIGN KEY([FK_UserID])
REFERENCES [dbo].[tbl_User] ([User_Id])
GO
ALTER TABLE [dbo].[tbl_House] CHECK CONSTRAINT [FK_tbl_House_tbl_User]
GO
ALTER TABLE [dbo].[tbl_Payment]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Payment_tbl_BookingBridge] FOREIGN KEY([PK_BookingBridgeID])
REFERENCES [dbo].[tbl_BookingBridge] ([BB_ID])
GO
ALTER TABLE [dbo].[tbl_Payment] CHECK CONSTRAINT [FK_tbl_Payment_tbl_BookingBridge]
GO
ALTER TABLE [dbo].[tbl_RoomCharges]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoomCharges_tbl_Category] FOREIGN KEY([FK_CatID])
REFERENCES [dbo].[tbl_Category] ([Cat_Id])
GO
ALTER TABLE [dbo].[tbl_RoomCharges] CHECK CONSTRAINT [FK_tbl_RoomCharges_tbl_Category]
GO
ALTER TABLE [dbo].[tbl_RoomCharges]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoomCharges_tbl_Type] FOREIGN KEY([FK_TypeID])
REFERENCES [dbo].[tbl_Type] ([Type_Id])
GO
ALTER TABLE [dbo].[tbl_RoomCharges] CHECK CONSTRAINT [FK_tbl_RoomCharges_tbl_Type]
GO
ALTER TABLE [dbo].[tbl_RoomsDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoomsDetails_tbl_Category] FOREIGN KEY([FK_CateID])
REFERENCES [dbo].[tbl_Category] ([Cat_Id])
GO
ALTER TABLE [dbo].[tbl_RoomsDetails] CHECK CONSTRAINT [FK_tbl_RoomsDetails_tbl_Category]
GO
ALTER TABLE [dbo].[tbl_RoomsDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoomsDetails_tbl_House] FOREIGN KEY([FK_HouseID])
REFERENCES [dbo].[tbl_House] ([H_ID])
GO
ALTER TABLE [dbo].[tbl_RoomsDetails] CHECK CONSTRAINT [FK_tbl_RoomsDetails_tbl_House]
GO
ALTER TABLE [dbo].[tbl_RoomsDetails]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoomsDetails_tbl_Type] FOREIGN KEY([FK_TypeID])
REFERENCES [dbo].[tbl_Type] ([Type_Id])
GO
ALTER TABLE [dbo].[tbl_RoomsDetails] CHECK CONSTRAINT [FK_tbl_RoomsDetails_tbl_Type]
GO
ALTER TABLE [dbo].[tbl_Type]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Type_tbl_Category] FOREIGN KEY([FK_CateID])
REFERENCES [dbo].[tbl_Category] ([Cat_Id])
GO
ALTER TABLE [dbo].[tbl_Type] CHECK CONSTRAINT [FK_tbl_Type_tbl_Category]
GO
/****** Object:  StoredProcedure [dbo].[sp_RoomCategoryByUserId]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[sp_RoomCategoryByUserId] 
(
	@userId int
)
as
begin
declare @roletype varchar(50) = (select distinct(UserType) from tbl_User where User_Id=@userId)
		if @roletype = 'admin'
		begin
		Select 
		tbl_House.H_ID,tbl_House.H_Name,tbl_Category.Cat_Description,tbl_Category.Cat_Id,tbl_Category.Cat_Name,tbl_Category.Cat_Status
		from tbl_Category
		inner join tbl_House on tbl_House.H_ID= tbl_Category.FK_HouseID
		end
		else
		begin
		Select 
		tbl_House.H_ID,tbl_House.H_Name,tbl_Category.Cat_Description,tbl_Category.Cat_Id,tbl_Category.Cat_Name,tbl_Category.Cat_Status
		from tbl_Category
		inner join tbl_House on tbl_House.H_ID= tbl_Category.FK_HouseID
		where tbl_House.FK_UserID = @userId
		end
end



GO
/****** Object:  StoredProcedure [dbo].[sp_RoomDetails]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create procedure [dbo].[sp_RoomDetails]
as
begin
Select
H_Name,Cat_Name,Type_Name,R_Id,R_Desc,R_Capacity,R_Status
from tbl_RoomsDetails
join tbl_Type on tbl_RoomsDetails.FK_TypeID=tbl_Type.Type_Id
join tbl_Category on tbl_Type.FK_CateID=tbl_Category.Cat_Id
join tbl_House on tbl_Category.FK_HouseID=tbl_House.H_ID

end




GO
/****** Object:  StoredProcedure [dbo].[sp_SelectHouseDetailById]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SelectHouseDetailById]
@userId int
as
begin
		declare @roletype varchar(50) = (select distinct(UserType) from tbl_User where User_Id=@userId)
		if @roletype = 'admin'
		begin
				select 
				tbl_User.FullName,
				tbl_House.H_ID,tbl_House.H_Name,tbl_House.H_Location,tbl_House.H_City,
				tbl_House.H_Address,tbl_House.H_NoOfRoom,tbl_House.H_Image,tbl_House.H_Status
				from tbl_User
				inner join tbl_House on tbl_House.FK_UserID = tbl_User.User_Id
		end
		else
		begin
				select 
				tbl_User.FullName,
				tbl_House.H_ID,tbl_House.H_Name,tbl_House.H_Location,tbl_House.H_City,
				tbl_House.H_Address,tbl_House.H_NoOfRoom,tbl_House.H_Image,tbl_House.H_Status
				from tbl_User
				inner join tbl_House on tbl_House.FK_UserID = tbl_User.User_Id
				where tbl_House.FK_UserID = @userId
		end
end





GO
/****** Object:  StoredProcedure [dbo].[sp_SelectUserDetailById]    Script Date: 12/7/2019 3:11:45 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_SelectUserDetailById]
@userId int
as
begin
		declare @roletype varchar(50) = (select distinct(UserType) from tbl_User where User_Id=@userId)
		if @roletype = 'admin'
		begin
				select * from tbl_User
		end
		else
		begin
				select * from
				tbl_User
				where tbl_User.User_Id = @userId
		end
end


GO
USE [master]
GO
ALTER DATABASE [TheHouseDb] SET  READ_WRITE 
GO
