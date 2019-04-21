USE [master]
GO

WHILE EXISTS(select NULL from sys.databases where name='NOMNOM')
BEGIN
    DECLARE @SQL varchar(max)
    SELECT @SQL = COALESCE(@SQL,'') + 'Kill ' + Convert(varchar, SPId) + ';'
    FROM MASTER..SysProcesses
    WHERE DBId = DB_ID(N'NOMNOM') AND SPId <> @@SPId
    EXEC(@SQL)
    DROP DATABASE [NOMNOM]
END
GO

CREATE DATABASE [NOMNOM]
GO
USE [NOMNOM]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[id] [nvarchar](10) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[loai_id] [nvarchar](10) NOT NULL,
	[thuonghieu_id] [nvarchar](10) NOT NULL,
	[hinhanh] [nvarchar](255) NOT NULL,
	[thongtin] [nvarchar](255) NOT NULL,
	[soluongton] [int] NOT NULL,	
	[giaban] [int] NOT NULL,
	[soview] [int] NOT NULL,
	[tinhtrang] [int] NOT NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[id] [nvarchar](10) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[tinhtrang] [int] NOT NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[NhaCungCap](
	[id] [nvarchar](10) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[tinhtrang] [int] NOT NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ThuongHieu](
	[id] [nvarchar](10) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[tinhtrang] [int] NOT NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[DonHang](
	[id] [nvarchar](10) NOT NULL,
	[ngay] [datetime] NOT NULL,
	[khachhang_id] [nvarchar](10) NOT NULL,
	[trigia] [int] NOT NULL,
	[tinhtrang_id] [int] NOT NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[TinhTrang](
	[id] [int] NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TinhTrang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[donhang_id] [nvarchar](10) NOT NULL,
	[sanpham_id] [nvarchar](10) NOT NULL,
	[soluong] [int] NOT NULL,
	[giaorder] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[donhang_id] ASC,
	[sanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[HoaDon](
	[id] [nvarchar](10) NOT NULL,
	[ngay] [datetime] NOT NULL,
	[khachhang_id] [nvarchar](10) NOT NULL,
	[trigia] [int] NOT NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[hoadon_id] [nvarchar](10) NOT NULL,
	[sanpham_id] [nvarchar](10) NOT NULL,
	[soluong] [int] NOT NULL,
	[giaban] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietHoaDon] PRIMARY KEY CLUSTERED 
(
	[hoadon_id] ASC,
	[sanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[PhieuNhap](
	[id] [nvarchar](10) NOT NULL,
	[ngay] [datetime] NOT NULL,
	[nhacungcap_id] [nvarchar](10) NOT NULL,
	[chi] [int] NOT NULL,
 CONSTRAINT [PK_PhieuNhap] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[ChiTietPhieuNhap](
	[phieunhap_id] [nvarchar](10) NOT NULL,
	[sanpham_id] [nvarchar](10) NOT NULL,
	[soluong] [int] NOT NULL,
	[gianhap] [int] NOT NULL,
 CONSTRAINT [PK_ChiTietPhieuNhap] PRIMARY KEY CLUSTERED 
(
	[phieunhap_id] ASC,
	[sanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[KhachHang](
	[id] [nvarchar](10) NOT NULL,
	[ten] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL,
	[sdt] [nvarchar](20) NULL,
	[diachi] [nvarchar](255) NULL,
	[account_id] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[TaiKhoan](
	[id] [nvarchar](10) NOT NULL,
	[password] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE TABLE [dbo].[GioHang](
	[taikhoan_id] [nchar](128) NOT NULL,
	[sanpham_id] [nvarchar](10) NOT NULL,
	[soluong] [int] NOT NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[taikhoan_id] ASC,
	[sanpham_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT INTO [dbo].[TinhTrang]([id],[ten]) VALUES(1,N'Chờ duyệt')
GO
INSERT INTO [dbo].[TinhTrang]([id],[ten]) VALUES(2,N'Đang giao')
GO
INSERT INTO [dbo].[TinhTrang]([id],[ten]) VALUES(3,N'Hoàn tất')
GO
INSERT INTO [dbo].[LoaiSanPham]([id],[ten],[tinhtrang]) VALUES('1',N'Đồ đóng hộp',1)
GO
INSERT INTO [dbo].[LoaiSanPham]([id],[ten],[tinhtrang]) VALUES('2',N'Trái cây',1)
GO
INSERT INTO [dbo].[NhaCungCap]([id],[ten],[tinhtrang]) VALUES('1',N'Nhà cung cấp 1',1)
GO
INSERT INTO [dbo].[NhaCungCap]([id],[ten],[tinhtrang]) VALUES('2',N'Nhà cung cấp 2',1)
GO
INSERT INTO [dbo].[ThuongHieu]([id],[ten],[tinhtrang]) VALUES('1',N'Hảo hảo',1)
GO
INSERT INTO [dbo].[ThuongHieu]([id],[ten],[tinhtrang]) VALUES('2',N'Thương hiệu 2',1)
GO

INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('1',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,0141,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('2',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,546,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('3',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,01,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('4',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',7,5000,05445,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('5',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',241,5000,04545,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('6',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',1244,5000,07845,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('7',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',11,5000,08745,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('8',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',252,5000,04547,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('9',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',4552,5000,7870,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('10',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,08754,1,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang],[thuonghieu_id]) VALUES('11',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,07875,1,1)
GO

