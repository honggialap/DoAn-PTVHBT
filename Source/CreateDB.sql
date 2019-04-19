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
INSERT INTO [dbo].[LoaiSanPham]([id],[ten],[tinhtrang]) VALUES('1',N'Đồ đóng hộp',1)
GO
INSERT INTO [dbo].[LoaiSanPham]([id],[ten],[tinhtrang]) VALUES('2',N'Trái cây',1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('1',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,0141,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('2',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,546,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('3',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,01,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('4',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',7,5000,05445,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('5',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',241,5000,04545,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('6',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',1244,5000,07845,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('7',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',11,5000,08745,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('8',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',252,5000,04547,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('9',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',4552,5000,7870,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('10',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,08754,1)
GO
INSERT INTO [dbo].[SanPham]([id],[ten],[loai_id],[hinhanh],[thongtin],[soluongton],[giaban],[soview],[tinhtrang]) VALUES('11',N'Mì hảo hảo',N'1','1.jpg',N'Mì ăn liền hảo hảo',0,5000,07875,1)
GO

