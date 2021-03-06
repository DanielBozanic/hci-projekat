USE [master]
GO
/****** Object:  Database [OrganizatorProslava]    Script Date: 09/06/2021 23:10:55 ******/
CREATE DATABASE [OrganizatorProslava]
GO
USE [OrganizatorProslava]
GO
/****** Object:  Table [dbo].[Korisnik]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Korisnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](50) NOT NULL,
	[Prezime] [varchar](50) NOT NULL,
	[KorisnickoIme] [varchar](50) NOT NULL,
	[Lozinka] [varchar](100) NOT NULL,
	[Tip] [int] NOT NULL,
	[Pol] [char](1) NULL,
	[Mobilni] [varchar](20) NULL,
	[Obrisan] [bit] NOT NULL,
 CONSTRAINT [PK_Klijent] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proizvod]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proizvod](
	[ID] [int] NOT NULL,
	[Naziv] [varchar](100) NOT NULL,
	[Cena] [float] NOT NULL,
	[Opis] [varchar](500) NOT NULL,
	[SaradnikID] [int] NOT NULL,
	[LinkSlike] [varchar](100) NULL,
	[SmeDaMenja] [bit] NULL,
 CONSTRAINT [PK_Proizvod] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sala]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sala](
	[ProizvodID] [int] NOT NULL,
	[Opis] [varchar](50) NOT NULL,
	[Kapacitet] [int] NULL,
	[BrojStolova] [int] NULL,
 CONSTRAINT [PK_Sala] PRIMARY KEY CLUSTERED 
(
	[ProizvodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SalaSto]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalaSto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProizvodID] [int] NOT NULL,
	[Opis] [varchar](50) NOT NULL,
	[BrojMesta] [int] NULL,
	[X] [int] NULL,
	[Y] [int] NULL,
 CONSTRAINT [PK_SalaSto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Saradnik]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Saradnik](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Naziv] [varchar](100) NOT NULL,
	[TipSaradnikaID] [int] NOT NULL,
	[Adresa] [varchar](500) NULL,
	[Email] [varchar](100) NOT NULL,
	[Obrisan] [bit] NOT NULL,
 CONSTRAINT [PK_Saradnik] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipSaradnika]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipSaradnika](
	[ID] [int] NOT NULL,
	[Naziv] [varchar](50) NULL,
 CONSTRAINT [PK_TipSaradnika] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zabava]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zabava](
	[ID] [int] NOT NULL,
	[Tip] [varchar](50) NOT NULL,
	[DatumProslave] [datetime] NOT NULL,
	[Trajanje] [int] NOT NULL,
	[Grad] [varchar](50) NOT NULL,
	[Tema] [varchar](100) NOT NULL,
	[BrojGostiju] [int] NOT NULL,
	[VrstaBudzeta] [bit] NOT NULL,
	[Budzet] [float] NOT NULL,
	[SpisakGostiju] [varchar](5000) NOT NULL,
	[Status] [int] NOT NULL,
	[DodatneZelje] [varchar](500) NULL,
	[Organizator] [int] NULL,
	[Kreator] [int] NOT NULL,
	[Vreme] [varchar](15) NULL,
 CONSTRAINT [PK_Zabava] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zabava_Poruke]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zabava_Poruke](
	[PosiljalacID] [int] NOT NULL,
	[ZabavaID] [int] NOT NULL,
	[Poruka] [varchar](500) NOT NULL,
 CONSTRAINT [PK_Zabava_Poruke] PRIMARY KEY CLUSTERED 
(
	[PosiljalacID] ASC,
	[ZabavaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zabava_Proizvod]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zabava_Proizvod](
	[ZabavaID] [int] NOT NULL,
	[ProizvodID] [int] NOT NULL,
	[Kolicina] [int] NOT NULL,
 CONSTRAINT [PK_Zabava_Proizvod] PRIMARY KEY CLUSTERED 
(
	[ZabavaID] ASC,
	[ProizvodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zabava_Saradnik]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zabava_Saradnik](
	[ID_Zabave] [int] NOT NULL,
	[ID_Saradnika] [int] NOT NULL,
 CONSTRAINT [PK_Zabava_Saradnik] PRIMARY KEY CLUSTERED 
(
	[ID_Zabave] ASC,
	[ID_Saradnika] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZabavaSalaSto]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZabavaSalaSto](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ZabavaID] [int] NOT NULL,
	[SalaStoID] [int] NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
 CONSTRAINT [PK_ZabavaSalaSto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ZabavaSalaStoGost]    Script Date: 09/06/2021 23:10:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ZabavaSalaStoGost](
	[ZabavaSalaStoID] [int] NOT NULL,
	[ImeGosta] [varchar](100) NOT NULL,
 CONSTRAINT [PK_ZabavaSalaStoGost] PRIMARY KEY CLUSTERED 
(
	[ZabavaSalaStoID] ASC,
	[ImeGosta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Korisnik] ON 

INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (6, N'administrator', N'', N'admin', N'admin', 1, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (7, N'Mika', N'Mikic', N'mikam', N'123', 3, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (8, N'Pera', N'Peric', N'perap', N'123', 3, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (9, N'Mara', N'Maric', N'maram', N'123', 2, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (10, N'Zak', N'Zero', N'zakz', N'123', 2, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (11, N'Mitar', N'Miric', N'mitarm', N'123', 1, NULL, NULL, 1)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (13, N'Vesna', N'Vesnic', N'vesnav', N'123', 3, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (14, N'Petar', N'Petrovic', N'petarp', N'123', 3, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (15, N'Zuba', N'Zubic', N'zubaz', N'123', 3, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (16, N'Dena', N'Denic', N'denad', N'123', 2, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (17, N'Steva', N'Stevic', N'stevas', N'123', 2, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (18, N'Zombie', N'Zombic', N'zombiez', N'123', 3, NULL, NULL, 0)
INSERT [dbo].[Korisnik] ([ID], [Ime], [Prezime], [KorisnickoIme], [Lozinka], [Tip], [Pol], [Mobilni], [Obrisan]) VALUES (19, N'Testera', N'Testreric', N'testerat', N'123', 3, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Korisnik] OFF
GO
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (1, N'Lale', 120, N'10 crvenih i 10 zutih lala', 1, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (2, N'Ruze', 570, N'10 crvenih ruza', 1, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (3, N'Kale', 980, N'10 belih kala', 1, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (4, N'Sarma', 1200, N'10 domacih sarmi', 2, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (5, N'Rostilj', 2500, N'10 cevapa i pomfrit', 2, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (6, N'Svadbarski kupus', 1700, N'Puno ukusnog kupusa', 2, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (7, N'Kanapei', 3567, N'Preukusni kanapei', 4, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (8, N'Torta', 3412, N'Cokoladna torta', 4, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (9, N'Kolaci', 3122, N'Kolaci za proslave', 4, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (10, N'Muckalice', 5421, N'Disko bend', 3, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (11, N'Lepi Mika', 5421, N'Otrov za zene i glasom i stasom', 3, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (12, N'Lutkice', 5421, N'Narodna muzika', 3, NULL, NULL)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (13, N'Sala', 12345, N'230', 2, N'linkSlike.jpg', 0)
INSERT [dbo].[Proizvod] ([ID], [Naziv], [Cena], [Opis], [SaradnikID], [LinkSlike], [SmeDaMenja]) VALUES (14, N'Sala', 13222, N'150', 4, N'linkSlike.jpg', 1)
GO
INSERT [dbo].[Sala] ([ProizvodID], [Opis], [Kapacitet], [BrojStolova]) VALUES (13, N'Sala 1', 230, 50)
INSERT [dbo].[Sala] ([ProizvodID], [Opis], [Kapacitet], [BrojStolova]) VALUES (14, N'Sala 2', 150, 30)
GO
SET IDENTITY_INSERT [dbo].[SalaSto] ON 

INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (1, 13, N'Sto 1', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (2, 13, N'Sto 2', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (3, 13, N'Sto 3', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (4, 13, N'Sto 4', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (5, 13, N'Sto 5', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (6, 13, N'Sto 6', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (7, 13, N'Sto 7', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (8, 13, N'Sto 8', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (9, 13, N'Sto 9', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (10, 13, N'Sto 10', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (11, 13, N'Sto 11', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (12, 13, N'Sto 12', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (13, 13, N'Sto 13', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (14, 13, N'Sto 14', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (15, 13, N'Sto 15', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (16, 13, N'Sto 16', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (17, 13, N'Sto 17', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (18, 13, N'Sto 18', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (19, 13, N'Sto 19', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (20, 13, N'Sto 20', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (21, 13, N'Sto 21', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (22, 13, N'Sto 22', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (23, 13, N'Sto 23', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (24, 13, N'Sto 24', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (25, 13, N'Sto 25', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (26, 13, N'Sto 26', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (27, 13, N'Sto 27', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (28, 13, N'Sto 28', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (29, 13, N'Sto 29', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (30, 13, N'Sto 30', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (31, 13, N'Sto 31', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (32, 13, N'Sto 32', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (33, 13, N'Sto 33', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (34, 13, N'Sto 34', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (35, 13, N'Sto 35', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (36, 13, N'Sto 36', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (37, 13, N'Sto 37', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (38, 13, N'Sto 38', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (39, 13, N'Sto 39', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (40, 13, N'Sto 40', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (41, 13, N'Sto 41', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (42, 13, N'Sto 42', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (43, 13, N'Sto 43', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (44, 13, N'Sto 44', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (45, 13, N'Sto 45', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (46, 13, N'Sto 46', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (47, 13, N'Sto 47', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (48, 13, N'Sto 48', 5, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (49, 13, N'Sto 49', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (50, 13, N'Sto 50', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (51, 14, N'Sto 1', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (52, 14, N'Sto 2', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (53, 14, N'Sto 3', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (54, 14, N'Sto 4', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (55, 14, N'Sto 5', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (56, 14, N'Sto 6', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (57, 14, N'Sto 7', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (58, 14, N'Sto 8', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (59, 14, N'Sto 9', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (60, 14, N'Sto 10', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (61, 14, N'Sto 11', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (62, 14, N'Sto 12', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (63, 14, N'Sto 13', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (64, 14, N'Sto 14', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (65, 14, N'Sto 15', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (66, 14, N'Sto 16', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (67, 14, N'Sto 17', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (68, 14, N'Sto 18', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (69, 14, N'Sto 19', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (70, 14, N'Sto 20', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (71, 14, N'Sto 21', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (72, 14, N'Sto 22', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (73, 14, N'Sto 23', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (74, 14, N'Sto 24', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (75, 14, N'Sto 25', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (76, 14, N'Sto 26', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (77, 14, N'Sto 27', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (78, 14, N'Sto 28', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (79, 14, N'Sto 29', 4, NULL, NULL)
INSERT [dbo].[SalaSto] ([ID], [ProizvodID], [Opis], [BrojMesta], [X], [Y]) VALUES (80, 14, N'Sto 30', 4, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SalaSto] OFF
GO
SET IDENTITY_INSERT [dbo].[Saradnik] ON 

INSERT [dbo].[Saradnik] ([ID], [Naziv], [TipSaradnikaID], [Adresa], [Email], [Obrisan]) VALUES (1, N'Lula', 1, N'Mirijevska 34, Beograd', N'lula@gmail.com', 0)
INSERT [dbo].[Saradnik] ([ID], [Naziv], [TipSaradnikaID], [Adresa], [Email], [Obrisan]) VALUES (2, N'Kod Marka', 3, N'Bulevar Oslobodjenja 322, Beograd', N'marko_merak@gmail.com', 0)
INSERT [dbo].[Saradnik] ([ID], [Naziv], [TipSaradnikaID], [Adresa], [Email], [Obrisan]) VALUES (3, N'Veseli Becari', 2, N'Ciganska bb, Sabac Mala', N'becariv@gmail.com', 0)
INSERT [dbo].[Saradnik] ([ID], [Naziv], [TipSaradnikaID], [Adresa], [Email], [Obrisan]) VALUES (4, N'Kod Barbe', 3, N'Dunavski kej bb, Novi Sad', N'barba333@gmail.com', 0)
SET IDENTITY_INSERT [dbo].[Saradnik] OFF
GO
INSERT [dbo].[TipSaradnika] ([ID], [Naziv]) VALUES (1, N'Cvecara')
INSERT [dbo].[TipSaradnika] ([ID], [Naziv]) VALUES (2, N'Muzika')
INSERT [dbo].[TipSaradnika] ([ID], [Naziv]) VALUES (3, N'Restoran')
GO
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (1, N'rodjendan', CAST(N'2021-07-30T19:51:09.000' AS DateTime), 120, N'novi sad', N'noc vestica', 20, 0, 210, N'nan.txt', 1, N'Dodatne zeljee', NULL, 7, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (2, N'godisnjica', CAST(N'2021-08-03T17:37:07.000' AS DateTime), 120, N'novi sad', N'ljubav', 50, 0, 3510, N'nan.txt', 2, N'Dodatne zeljee', 9, 15, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (3, N'skup jarana', CAST(N'2022-12-12T17:37:07.000' AS DateTime), 120, N'beli breg', N'najjaci ostaju', 120, 1, 1200, N'nan.txt', 5, N'Dodatne zeljee', NULL, 13, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (4, N'zenski plesni susret', CAST(N'2022-06-02T19:55:07.000' AS DateTime), 120, N'jagodina', N'zabava', 120, 0, 2434, N'nan.txt', 4, N'zalimo dobru hranu', NULL, 14, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (5, N'prvi rodjendan', CAST(N'2022-09-04T13:25:07.000' AS DateTime), 120, N'palic', N'proslava nakon krstenja', 120, 1, 1200, N'Marta Martic, Tika Tikic, Vera Verka, Zuza Zuzic, Mira Miric, Nora Noric, Ela Elic, Filip Filipovic, Nela Nelic, Dragi Dragic, Suza Suzic', 2, N'fleksibilni stolovi', 9, 15, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (6, N'moto zurka', CAST(N'2022-12-12T17:37:07.000' AS DateTime), 120, N'surdulica', N'nprijateljsko okupljanje', 120, 1, 1200, N'nan.txt', 1, N'Dobra klopa', NULL, 13, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (7, N'bake u usponu', CAST(N'2022-12-12T17:37:07.000' AS DateTime), 120, N'becej', N'staracki skup uz caj i kolace', 120, 1, 1200, N'nan.txt', 2, N'Lep caj i kolaci', 10, 13, NULL)
INSERT [dbo].[Zabava] ([ID], [Tip], [DatumProslave], [Trajanje], [Grad], [Tema], [BrojGostiju], [VrstaBudzeta], [Budzet], [SpisakGostiju], [Status], [DodatneZelje], [Organizator], [Kreator], [Vreme]) VALUES (8, N'Zurka', CAST(N'2021-06-17T00:00:00.000' AS DateTime), 5, N'Novi Sad', N'pivo', 100, 0, 100000, N'Marta Martic, Tika Tikic, Vera Verka, Zuza Zuzic, Mira Miric, Nora Noric, Ela Elic, Filip Filipovic, Nela Nelic, Dragi Dragic, Suza Suzic, Sisa Sisic, Luda Ludic', 2, NULL, 9, 7, NULL)
GO
INSERT [dbo].[Zabava_Poruke] ([PosiljalacID], [ZabavaID], [Poruka]) VALUES (9, 2, N'Je li sve okej?')
GO
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (2, 1, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (2, 2, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (2, 13, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (4, 3, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (4, 6, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (4, 14, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (5, 14, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (7, 1, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (7, 9, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (7, 11, 1)
INSERT [dbo].[Zabava_Proizvod] ([ZabavaID], [ProizvodID], [Kolicina]) VALUES (8, 14, 1)
GO
INSERT [dbo].[Zabava_Saradnik] ([ID_Zabave], [ID_Saradnika]) VALUES (1, 1)
GO
SET IDENTITY_INSERT [dbo].[ZabavaSalaSto] ON 

INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (11, 5, 61, 31, 128)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (12, 5, 57, 220, 60)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (13, 5, 53, 27, 16)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (14, 5, 64, 47, 257)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (15, 5, 65, 138, 326)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (16, 5, 59, 324, 191)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (17, 8, 54, 163, 58)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (18, 8, 55, 175, 125)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (19, 8, 56, 212, 187)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (20, 8, 57, 256, 241)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (21, 8, 58, 297, 302)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (22, 8, 59, 365, 218)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (23, 8, 60, 369, 154)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (24, 8, 61, 328, 105)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (25, 8, 62, 318, 50)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (26, 8, 63, 269, 11)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (27, 8, 64, 53, 314)
INSERT [dbo].[ZabavaSalaSto] ([ID], [ZabavaID], [SalaStoID], [X], [Y]) VALUES (28, 8, 65, 116, 315)
SET IDENTITY_INSERT [dbo].[ZabavaSalaSto] OFF
GO
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (12, N' Mira Miric')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (12, N' Tika Tikic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (12, N' Vera Verka')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (12, N'Marta Martic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (13, N' Dragi Dragic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (13, N' Zuza Zuzic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (14, N' Suza Suzic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (16, N' Ela Elic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (16, N' Filip Filipovic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (16, N' Nela Nelic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (16, N' Nora Noric')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (17, N' Tika Tikic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (17, N' Vera Verka')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (17, N'Marta Martic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (20, N' Dragi Dragic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (20, N' Filip Filipovic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (20, N' Nela Nelic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (22, N' Suza Suzic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (27, N' Mira Miric')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (27, N' Zuza Zuzic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (28, N' Ela Elic')
INSERT [dbo].[ZabavaSalaStoGost] ([ZabavaSalaStoID], [ImeGosta]) VALUES (28, N' Nora Noric')
GO
ALTER TABLE [dbo].[Korisnik] ADD  CONSTRAINT [DF_Korisnik_Obrisan]  DEFAULT ((0)) FOR [Obrisan]
GO
ALTER TABLE [dbo].[Saradnik] ADD  CONSTRAINT [DF_Saradnik_Obrisan]  DEFAULT ((0)) FOR [Obrisan]
GO
ALTER TABLE [dbo].[Proizvod]  WITH CHECK ADD  CONSTRAINT [FK_Proizvod_Saradnik] FOREIGN KEY([SaradnikID])
REFERENCES [dbo].[Saradnik] ([ID])
GO
ALTER TABLE [dbo].[Proizvod] CHECK CONSTRAINT [FK_Proizvod_Saradnik]
GO
ALTER TABLE [dbo].[Zabava]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Kreator] FOREIGN KEY([Kreator])
REFERENCES [dbo].[Korisnik] ([ID])
GO
ALTER TABLE [dbo].[Zabava] CHECK CONSTRAINT [FK_Zabava_Kreator]
GO
ALTER TABLE [dbo].[Zabava]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Organizator] FOREIGN KEY([Organizator])
REFERENCES [dbo].[Korisnik] ([ID])
GO
ALTER TABLE [dbo].[Zabava] CHECK CONSTRAINT [FK_Zabava_Organizator]
GO
ALTER TABLE [dbo].[Zabava_Poruke]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Poruke_Korisnik] FOREIGN KEY([PosiljalacID], [ZabavaID])
REFERENCES [dbo].[Zabava_Poruke] ([PosiljalacID], [ZabavaID])
GO
ALTER TABLE [dbo].[Zabava_Poruke] CHECK CONSTRAINT [FK_Zabava_Poruke_Korisnik]
GO
ALTER TABLE [dbo].[Zabava_Proizvod]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Proizvod_Proizvod] FOREIGN KEY([ProizvodID])
REFERENCES [dbo].[Proizvod] ([ID])
GO
ALTER TABLE [dbo].[Zabava_Proizvod] CHECK CONSTRAINT [FK_Zabava_Proizvod_Proizvod]
GO
ALTER TABLE [dbo].[Zabava_Proizvod]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Proizvod_Zabava] FOREIGN KEY([ZabavaID])
REFERENCES [dbo].[Zabava] ([ID])
GO
ALTER TABLE [dbo].[Zabava_Proizvod] CHECK CONSTRAINT [FK_Zabava_Proizvod_Zabava]
GO
ALTER TABLE [dbo].[Zabava_Saradnik]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Saradnik_Saradnik] FOREIGN KEY([ID_Saradnika])
REFERENCES [dbo].[Saradnik] ([ID])
GO
ALTER TABLE [dbo].[Zabava_Saradnik] CHECK CONSTRAINT [FK_Zabava_Saradnik_Saradnik]
GO
ALTER TABLE [dbo].[Zabava_Saradnik]  WITH CHECK ADD  CONSTRAINT [FK_Zabava_Saradnik_Zabava] FOREIGN KEY([ID_Zabave])
REFERENCES [dbo].[Zabava] ([ID])
GO
ALTER TABLE [dbo].[Zabava_Saradnik] CHECK CONSTRAINT [FK_Zabava_Saradnik_Zabava]
GO