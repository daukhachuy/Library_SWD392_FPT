USE [SWD392_Group2]
GO
/****** Object:  Table [dbo].[Books]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [varchar](255) NOT NULL,
	[author] [varchar](255) NULL,
	[description] [text] NULL,
	[availability] [bit] NULL,
	[quantity] [int] NULL,
	[category_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BorrowRecords]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BorrowRecords](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[book_id] [int] NULL,
	[borrow_date] [date] NULL,
	[due_date] [date] NULL,
	[return_date] [date] NULL,
	[status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categories]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NOT NULL,
	[parent_id] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NULL,
	[amount] [decimal](10, 2) NULL,
	[reason] [text] NULL,
	[status] [varchar](50) NULL,
	[created_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Reservations]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservations](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_id] [int] NULL,
	[reserved_date] [date] NULL,
	[status] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ReservationUser]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationUser](
	[reservation_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[reservation_id] ASC,
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 18/07/2025 12:25:39 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](100) NOT NULL,
	[email] [varchar](100) NULL,
	[password] [varchar](255) NULL,
	[role] [varchar](50) NULL,
	[status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Books] ON 

INSERT [dbo].[Books] ([id], [title], [author], [description], [availability], [quantity], [category_id]) VALUES (1, N'L?p trình C# co b?n', N'Nguy?n Van A', N'Giáo trình C# can b?n.', 1, 6, 3)
INSERT [dbo].[Books] ([id], [title], [author], [description], [availability], [quantity], [category_id]) VALUES (2, N'HTML và CSS', N'Lê Th? B', N'Thi?t k? web v?i HTML và CSS.', 1, 3, 3)
INSERT [dbo].[Books] ([id], [title], [author], [description], [availability], [quantity], [category_id]) VALUES (3, N'Doraemon và x? s? th?n tiên ', N'Fujiko F Fujio', N'B? truy?n n?i ti?ng.', 1, 10, 6)
SET IDENTITY_INSERT [dbo].[Books] OFF
GO
SET IDENTITY_INSERT [dbo].[BorrowRecords] ON 

INSERT [dbo].[BorrowRecords] ([id], [user_id], [book_id], [borrow_date], [due_date], [return_date], [status]) VALUES (1, 2, 1, CAST(N'2025-07-01' AS Date), CAST(N'2025-07-10' AS Date), CAST(N'2025-07-08' AS Date), N'Returned')
SET IDENTITY_INSERT [dbo].[BorrowRecords] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([id], [name], [parent_id]) VALUES (1, N'Sách', NULL)
INSERT [dbo].[Categories] ([id], [name], [parent_id]) VALUES (2, N'Truy?n', NULL)
INSERT [dbo].[Categories] ([id], [name], [parent_id]) VALUES (3, N'L?p trình', 1)
INSERT [dbo].[Categories] ([id], [name], [parent_id]) VALUES (4, N'Thi?u nhi', 1)
INSERT [dbo].[Categories] ([id], [name], [parent_id]) VALUES (5, N'Anime', 2)
INSERT [dbo].[Categories] ([id], [name], [parent_id]) VALUES (6, N'Doraemon', 2)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([id], [user_id], [amount], [reason], [status], [created_at]) VALUES (1, 2, CAST(50000.00 AS Decimal(10, 2)), N'Phí mu?n sách tr? h?n', N'Paid', CAST(N'2025-07-10T08:00:00.000' AS DateTime))
INSERT [dbo].[Payments] ([id], [user_id], [amount], [reason], [status], [created_at]) VALUES (2, 2, CAST(100000.00 AS Decimal(10, 2)), N'Phí m?t sách', N'Unpaid', CAST(N'2025-07-15T10:30:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Payments] OFF
GO
SET IDENTITY_INSERT [dbo].[Reservations] ON 

INSERT [dbo].[Reservations] ([id], [book_id], [reserved_date], [status]) VALUES (1, 2, CAST(N'2025-07-15' AS Date), N'Pending')
SET IDENTITY_INSERT [dbo].[Reservations] OFF
GO
INSERT [dbo].[ReservationUser] ([reservation_id], [user_id]) VALUES (1, 2)
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([id], [username], [email], [password], [role], [status]) VALUES (1, N'Admin', N'admin@example.com', N'admin123', N'Admin', 1)
INSERT [dbo].[Users] ([id], [username], [email], [password], [role], [status]) VALUES (2, N'Student', N'student@example.com', N'pass123', N'User', 1)
INSERT [dbo].[Users] ([id], [username], [email], [password], [role], [status]) VALUES (3, N'Test', N'test@example.com', N'test123', N'User', 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Books]  WITH CHECK ADD FOREIGN KEY([category_id])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[BorrowRecords]  WITH CHECK ADD FOREIGN KEY([book_id])
REFERENCES [dbo].[Books] ([id])
GO
ALTER TABLE [dbo].[BorrowRecords]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD FOREIGN KEY([parent_id])
REFERENCES [dbo].[Categories] ([id])
GO
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
ALTER TABLE [dbo].[Reservations]  WITH CHECK ADD FOREIGN KEY([book_id])
REFERENCES [dbo].[Books] ([id])
GO
ALTER TABLE [dbo].[ReservationUser]  WITH CHECK ADD FOREIGN KEY([reservation_id])
REFERENCES [dbo].[Reservations] ([id])
GO
ALTER TABLE [dbo].[ReservationUser]  WITH CHECK ADD FOREIGN KEY([user_id])
REFERENCES [dbo].[Users] ([id])
GO
