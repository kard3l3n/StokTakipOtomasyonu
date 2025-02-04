USE [Stok_Takip]
GO
/****** Object:  Table [dbo].[kategoribilgileri]    Script Date: 13.05.2020 11:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kategoribilgileri](
	[kategori] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[markabilgileri]    Script Date: 13.05.2020 11:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[markabilgileri](
	[kategori] [nvarchar](50) NOT NULL,
	[marka] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[musteri]    Script Date: 13.05.2020 11:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[musteri](
	[tc] [nvarchar](50) NOT NULL,
	[adsoyad] [nvarchar](50) NOT NULL,
	[telefon] [nvarchar](50) NOT NULL,
	[adres] [nvarchar](50) NOT NULL,
	[email] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[satis]    Script Date: 13.05.2020 11:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[satis](
	[tc] [nvarchar](50) NOT NULL,
	[adsoyad] [nvarchar](50) NOT NULL,
	[telefon] [nvarchar](50) NOT NULL,
	[barkodno] [nvarchar](50) NOT NULL,
	[urunadi] [nvarchar](50) NOT NULL,
	[miktari] [int] NOT NULL,
	[satisfiyati] [decimal](18, 2) NOT NULL,
	[toplamfiyati] [decimal](18, 2) NOT NULL,
	[tarih] [nvarchar](50) NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[sepet]    Script Date: 13.05.2020 11:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sepet](
	[tc] [nvarchar](50) NULL,
	[adsoyad] [nvarchar](50) NULL,
	[telefon] [nvarchar](50) NULL,
	[barkodno] [nvarchar](50) NULL,
	[urunadi] [nvarchar](50) NULL,
	[miktari] [int] NULL,
	[satisfiyati] [decimal](18, 2) NULL,
	[toplamfiyati] [decimal](18, 2) NULL,
	[tarih] [nvarchar](50) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[urun]    Script Date: 13.05.2020 11:57:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[urun](
	[barkodno] [nvarchar](50) NULL,
	[kategori] [nvarchar](50) NULL,
	[marka] [nvarchar](50) NULL,
	[urunadi] [nvarchar](50) NULL,
	[miktari] [int] NULL,
	[alisfiyati] [decimal](18, 2) NULL,
	[satisfiyati] [decimal](18, 2) NULL,
	[tarih] [nvarchar](50) NULL
) ON [PRIMARY]

GO
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'gıda')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N' içecek')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'gofret')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N' süt')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N' manav')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N' et')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'gıda', N'tadım')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' içecek', N'fanta')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'gıda', N'eti')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' içecek', N'soda')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'gofret', N'şölen')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'gıda', N'ülker')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'gofret', N' alpella')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' süt', N'pınar')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' manav', N'elma')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' manav', N' armut')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' manav', N' kayısı')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' et', N' biftek')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N' et', N'kuşbaşı')
INSERT [dbo].[musteri] ([tc], [adsoyad], [telefon], [adres], [email]) VALUES (N'32', N'kar', N'77777777', N'aaaa', N'aaaaa')
INSERT [dbo].[musteri] ([tc], [adsoyad], [telefon], [adres], [email]) VALUES (N'64646', N'sevim özdemir', N'66666', N'maltepee', N'fhfhffh@')
INSERT [dbo].[musteri] ([tc], [adsoyad], [telefon], [adres], [email]) VALUES (N'1234', N'selma ayca', N'5656', N'jsjsjs', N'dfdfd')
INSERT [dbo].[satis] ([tc], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'', N'', N'', N'90', N'laviva', 1, CAST(3.00 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), N'11.05.2020 17:58:03')
INSERT [dbo].[satis] ([tc], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'', N'', N'', N'1', N'light süt', 1, CAST(2.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), N'11.05.2020 17:58:03')
INSERT [dbo].[satis] ([tc], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'32', N'kar', N'77777777', N'45', N'amasya', 2, CAST(11.00 AS Decimal(18, 2)), CAST(22.00 AS Decimal(18, 2)), N'11.05.2020 18:04:20')
INSERT [dbo].[sepet] ([tc], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'32', N'kar', N'77777777', N'100a', N'çilekli', 1, CAST(0.95 AS Decimal(18, 2)), CAST(0.95 AS Decimal(18, 2)), N'12.05.2020 16:08:54')
INSERT [dbo].[sepet] ([tc], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'32', N'kar', N'77777777', N'345', N'fanta', 1, CAST(5.55 AS Decimal(18, 2)), CAST(5.55 AS Decimal(18, 2)), N'12.05.2020 20:14:27')
INSERT [dbo].[sepet] ([tc], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'32', N'kar', N'77777777', N'111', N'meşhur malatya ', 1, CAST(7.80 AS Decimal(18, 2)), CAST(7.80 AS Decimal(18, 2)), N'12.05.2020 21:32:47')
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [alisfiyati], [satisfiyati], [tarih]) VALUES (N'111', N' manav', N' kayısı', N'meşhur malatya ', 125, CAST(5.40 AS Decimal(18, 2)), CAST(7.80 AS Decimal(18, 2)), N'11.05.2020 12:53:49')
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [alisfiyati], [satisfiyati], [tarih]) VALUES (N'100a', N' süt', N'pınar', N'çilekli', 5, CAST(0.33 AS Decimal(18, 2)), CAST(0.95 AS Decimal(18, 2)), N'11.05.2020 00:18:21')
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [alisfiyati], [satisfiyati], [tarih]) VALUES (N'345', N'gofret', N' alpella', N'fanta', 7, CAST(1.45 AS Decimal(18, 2)), CAST(5.55 AS Decimal(18, 2)), N'11.05.2020 00:42:18')
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [alisfiyati], [satisfiyati], [tarih]) VALUES (N'45', N' manav', N'elma', N'amasya', 3, CAST(10.00 AS Decimal(18, 2)), CAST(11.00 AS Decimal(18, 2)), N'11.05.2020 16:27:23')
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [alisfiyati], [satisfiyati], [tarih]) VALUES (N'90', N'gofret', N'şölen', N'laviva', 15, CAST(2.50 AS Decimal(18, 2)), CAST(3.00 AS Decimal(18, 2)), N'11.05.2020 16:41:56')
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [alisfiyati], [satisfiyati], [tarih]) VALUES (N'1', N' süt', N'pınar', N'light süt', 99, CAST(1.00 AS Decimal(18, 2)), CAST(2.00 AS Decimal(18, 2)), N'11.05.2020 17:19:59')
