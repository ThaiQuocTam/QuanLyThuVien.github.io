USE [QuanLyThuVien]
GO
/****** Object:  Table [dbo].[TheLoai]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TheLoai](
	[IdTL] [int] IDENTITY(1,1) NOT NULL,
	[MaTheLoai] [varchar](50) NOT NULL,
	[TenTheLoai] [nvarchar](50) NULL,
 CONSTRAINT [PK_TheLoai] PRIMARY KEY CLUSTERED 
(
	[MaTheLoai] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LoaiDG]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LoaiDG](
	[MaLoaiDG] [varchar](50) NOT NULL,
	[TenLoaiDG] [nvarchar](50) NULL,
 CONSTRAINT [PK_LoaiDG] PRIMARY KEY CLUSTERED 
(
	[MaLoaiDG] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[IdPhanQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenPhanQuyen] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[IdPhanQuyen] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Login]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[UserName] [varchar](50) NOT NULL,
	[PassWord] [varchar](50) NULL,
	[PhanQuyen] [int] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocGia]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocGia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaDocGia] [varchar](50) NOT NULL,
	[HoTen] [nvarchar](50) NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[GioiTinh] [bit] NULL,
	[SoDienThoai] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[LoaiDG] [varchar](50) NULL,
 CONSTRAINT [PK_DocGia_1] PRIMARY KEY CLUSTERED 
(
	[MaDocGia] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sach]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sach](
	[IdSach] [int] IDENTITY(1,1) NOT NULL,
	[MaSach] [varchar](50) NOT NULL,
	[TenSach] [nvarchar](max) NULL,
	[TheLoai] [varchar](50) NULL,
	[TacGia] [nvarchar](50) NULL,
	[NgayXuatBan] [date] NULL,
	[AnhBia] [nvarchar](max) NULL,
 CONSTRAINT [PK_Sach_1] PRIMARY KEY CLUSTERED 
(
	[IdSach] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuMuon]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuMuon](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuMuon] [varchar](50) NOT NULL,
	[MaDocGia] [varchar](50) NULL,
	[NhanVien] [varchar](50) NULL,
	[NgayLapPhieu] [date] NULL,
	[TinhTrang] [nvarchar](50) NULL,
 CONSTRAINT [PK_PhieuMuon_1] PRIMARY KEY CLUSTERED 
(
	[MaPhieuMuon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_PhieuMuon]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_PhieuMuon](
	[IdCTPhieuMuon] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuMuon] [varchar](50) NOT NULL,
	[MaDocGia] [varchar](50) NULL,
	[TenDocGia] [nvarchar](50) NULL,
	[TenSach] [nvarchar](max) NULL,
	[SoLuong] [int] NULL,
	[HanTra] [date] NULL,
 CONSTRAINT [PK_CT_PhieuMuon] PRIMARY KEY CLUSTERED 
(
	[IdCTPhieuMuon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuTra]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuTra](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuTra] [varchar](50) NOT NULL,
	[MaPhieuMuon] [varchar](50) NULL,
	[NgayLapPhieuTra] [date] NULL,
	[NhanVien] [varchar](50) NULL,
 CONSTRAINT [PK_PhieuTra] PRIMARY KEY CLUSTERED 
(
	[MaPhieuTra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PhieuPhat]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PhieuPhat](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuPhat] [varchar](50) NOT NULL,
	[MaPhieuMuon] [varchar](50) NULL,
	[NhanVien] [varchar](50) NULL,
	[NgayLapPhieu] [nchar](10) NULL,
	[SoNgayQuaHan] [int] NULL,
	[TienPhat] [int] NULL,
 CONSTRAINT [PK_PhieuPhat_1] PRIMARY KEY CLUSTERED 
(
	[MaPhieuPhat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CT_PhieuTra]    Script Date: 06/08/2022 14:10:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CT_PhieuTra](
	[IdCTPhieuTra] [int] IDENTITY(1,1) NOT NULL,
	[MaPhieuTra] [varchar](50) NULL,
	[MaDocGia] [varchar](50) NULL,
	[TenDocGia] [nvarchar](50) NULL,
	[HanTra] [date] NULL,
	[NgayTraThucTe] [date] NULL,
 CONSTRAINT [PK_CT_PhieuTra] PRIMARY KEY CLUSTERED 
(
	[IdCTPhieuTra] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_CT_PhieuMuon_DocGia]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[CT_PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuMuon_DocGia] FOREIGN KEY([MaDocGia])
REFERENCES [dbo].[DocGia] ([MaDocGia])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[CT_PhieuMuon] CHECK CONSTRAINT [FK_CT_PhieuMuon_DocGia]
GO
/****** Object:  ForeignKey [FK_CT_PhieuMuon_PhieuMuon]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[CT_PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuMuon_PhieuMuon] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
GO
ALTER TABLE [dbo].[CT_PhieuMuon] CHECK CONSTRAINT [FK_CT_PhieuMuon_PhieuMuon]
GO
/****** Object:  ForeignKey [FK_CT_PhieuTra_DocGia]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[CT_PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuTra_DocGia] FOREIGN KEY([MaDocGia])
REFERENCES [dbo].[DocGia] ([MaDocGia])
GO
ALTER TABLE [dbo].[CT_PhieuTra] CHECK CONSTRAINT [FK_CT_PhieuTra_DocGia]
GO
/****** Object:  ForeignKey [FK_CT_PhieuTra_PhieuTra]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[CT_PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_CT_PhieuTra_PhieuTra] FOREIGN KEY([MaPhieuTra])
REFERENCES [dbo].[PhieuTra] ([MaPhieuTra])
GO
ALTER TABLE [dbo].[CT_PhieuTra] CHECK CONSTRAINT [FK_CT_PhieuTra_PhieuTra]
GO
/****** Object:  ForeignKey [FK_DocGia_LoaiDG]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[DocGia]  WITH CHECK ADD  CONSTRAINT [FK_DocGia_LoaiDG] FOREIGN KEY([LoaiDG])
REFERENCES [dbo].[LoaiDG] ([MaLoaiDG])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[DocGia] CHECK CONSTRAINT [FK_DocGia_LoaiDG]
GO
/****** Object:  ForeignKey [FK_Login_PhanQuyen]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_PhanQuyen] FOREIGN KEY([PhanQuyen])
REFERENCES [dbo].[PhanQuyen] ([IdPhanQuyen])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_PhanQuyen]
GO
/****** Object:  ForeignKey [FK_PhieuMuon_DocGia]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_DocGia] FOREIGN KEY([MaDocGia])
REFERENCES [dbo].[DocGia] ([MaDocGia])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_DocGia]
GO
/****** Object:  ForeignKey [FK_PhieuMuon_Login]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[PhieuMuon]  WITH CHECK ADD  CONSTRAINT [FK_PhieuMuon_Login] FOREIGN KEY([NhanVien])
REFERENCES [dbo].[Login] ([UserName])
GO
ALTER TABLE [dbo].[PhieuMuon] CHECK CONSTRAINT [FK_PhieuMuon_Login]
GO
/****** Object:  ForeignKey [FK_PhieuPhat_Login]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[PhieuPhat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuPhat_Login] FOREIGN KEY([NhanVien])
REFERENCES [dbo].[Login] ([UserName])
GO
ALTER TABLE [dbo].[PhieuPhat] CHECK CONSTRAINT [FK_PhieuPhat_Login]
GO
/****** Object:  ForeignKey [FK_PhieuPhat_PhieuMuon]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[PhieuPhat]  WITH CHECK ADD  CONSTRAINT [FK_PhieuPhat_PhieuMuon] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PhieuPhat] CHECK CONSTRAINT [FK_PhieuPhat_PhieuMuon]
GO
/****** Object:  ForeignKey [FK_PhieuTra_PhieuMuon]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[PhieuTra]  WITH CHECK ADD  CONSTRAINT [FK_PhieuTra_PhieuMuon] FOREIGN KEY([MaPhieuMuon])
REFERENCES [dbo].[PhieuMuon] ([MaPhieuMuon])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[PhieuTra] CHECK CONSTRAINT [FK_PhieuTra_PhieuMuon]
GO
/****** Object:  ForeignKey [FK_Sach_TheLoai1]    Script Date: 06/08/2022 14:10:39 ******/
ALTER TABLE [dbo].[Sach]  WITH CHECK ADD  CONSTRAINT [FK_Sach_TheLoai1] FOREIGN KEY([TheLoai])
REFERENCES [dbo].[TheLoai] ([MaTheLoai])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Sach] CHECK CONSTRAINT [FK_Sach_TheLoai1]
GO
