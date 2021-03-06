USE [QLMonAn]
GO
/****** Object:  Table [dbo].[ThongTinMonAn]    Script Date: 10/22/2021 4:03:32 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThongTinMonAn](
	[MaLoai] [nvarchar](20) NOT NULL,
	[TenMonAn] [nvarchar](50) NOT NULL,
	[Loai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ThongTinMonAn] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'1', N'Khai vị', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'10', N'Nước Ngọt', N'0')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'11', N'Cà Phê', N'0')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'12', N'Trà đá', N'0')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'2', N'Hải Sản', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'3', N'Gà', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'4', N'Cơm', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'5', N'Thịt', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'6', N'Rau', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'7', N'Canh', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'8', N'Lẩu', N'1')
INSERT [dbo].[ThongTinMonAn] ([MaLoai], [TenMonAn], [Loai]) VALUES (N'9', N'Bia', N'0')
GO
