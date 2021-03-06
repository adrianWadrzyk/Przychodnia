USE [master]
GO
/****** Object:  Database [projekt6]    Script Date: 19.02.2021 18:45:54 ******/
CREATE DATABASE [projekt6]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'projekt6', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\projekt6.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'projekt6_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\projekt6_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [projekt6] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [projekt6].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [projekt6] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [projekt6] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [projekt6] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [projekt6] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [projekt6] SET ARITHABORT OFF 
GO
ALTER DATABASE [projekt6] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [projekt6] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [projekt6] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [projekt6] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [projekt6] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [projekt6] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [projekt6] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [projekt6] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [projekt6] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [projekt6] SET  DISABLE_BROKER 
GO
ALTER DATABASE [projekt6] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [projekt6] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [projekt6] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [projekt6] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [projekt6] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [projekt6] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [projekt6] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [projekt6] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [projekt6] SET  MULTI_USER 
GO
ALTER DATABASE [projekt6] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [projekt6] SET DB_CHAINING OFF 
GO
ALTER DATABASE [projekt6] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [projekt6] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [projekt6] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [projekt6] SET QUERY_STORE = OFF
GO
USE [projekt6]
GO
/****** Object:  Table [dbo].[choroby]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[choroby](
	[id_choroby] [int] IDENTITY(1,1) NOT NULL,
	[kod_choroby] [varchar](6) NOT NULL,
	[nazwa_choroby] [varchar](100) NOT NULL,
 CONSTRAINT [pk_kod_chor] PRIMARY KEY CLUSTERED 
(
	[kod_choroby] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[dawka_leku]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dawka_leku](
	[id_dawki] [int] IDENTITY(1,1) NOT NULL,
	[dawka] [int] NOT NULL,
	[jednostka] [int] NULL,
 CONSTRAINT [pk_id_dawk] PRIMARY KEY CLUSTERED 
(
	[id_dawki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[jednostka_leku]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[jednostka_leku](
	[id_jednostki] [int] IDENTITY(1,1) NOT NULL,
	[nazwa_jednostki] [varchar](5) NOT NULL,
 CONSTRAINT [pk_id_jedn] PRIMARY KEY CLUSTERED 
(
	[id_jednostki] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[karta_pacjenta]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[karta_pacjenta](
	[id_karty] [int] IDENTITY(1,1) NOT NULL,
	[id_pacjenta] [int] NULL,
	[wykonane_uslugi] [int] NULL,
	[kod_choroby] [varchar](6) NULL,
	[id_leku] [int] NULL,
	[lekarz_prowadzacy] [int] NULL,
	[diagnoza] [varchar](255) NULL,
 CONSTRAINT [pk_id_kart] PRIMARY KEY CLUSTERED 
(
	[id_karty] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lek]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lek](
	[id_leku] [int] IDENTITY(1,1) NOT NULL,
	[nazwa_leku] [varchar](30) NOT NULL,
	[dawka] [int] NULL,
 CONSTRAINT [pk_id_leku] PRIMARY KEY CLUSTERED 
(
	[id_leku] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[lekarz]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[lekarz](
	[id_lekarza] [int] IDENTITY(1,1) NOT NULL,
	[imie] [varchar](20) NOT NULL,
	[nazwisko] [varchar](20) NOT NULL,
	[id_specjalizacji] [int] NULL,
 CONSTRAINT [pk_id_leka] PRIMARY KEY CLUSTERED 
(
	[id_lekarza] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[pacjent]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[pacjent](
	[id_pacjenta] [int] IDENTITY(1,1) NOT NULL,
	[imie] [varchar](20) NOT NULL,
	[nazwisko] [varchar](20) NOT NULL,
	[PESEL] [char](11) NOT NULL,
	[telefon] [char](9) NOT NULL,
	[miasto] [varchar](30) NOT NULL,
	[ulica] [varchar](30) NOT NULL,
	[nr_lokalu] [char](10) NULL,
 CONSTRAINT [pk_id_pacj] PRIMARY KEY CLUSTERED 
(
	[id_pacjenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rejestracja]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rejestracja](
	[id_rejestracji] [int] IDENTITY(1,1) NOT NULL,
	[id_pacjenta] [int] NULL,
	[id_lekarza] [int] NULL,
	[data_rejestracji] [date] NOT NULL,
	[godzina] [time](0) NOT NULL,
 CONSTRAINT [pk_id_reje] PRIMARY KEY CLUSTERED 
(
	[id_rejestracji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[specjalizacja]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[specjalizacja](
	[id_specjalizacji] [int] IDENTITY(1,1) NOT NULL,
	[nazwa_specjalizacji] [varchar](40) NOT NULL,
 CONSTRAINT [pk_id_spec] PRIMARY KEY CLUSTERED 
(
	[id_specjalizacji] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[uslugi]    Script Date: 19.02.2021 18:45:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[uslugi](
	[id_uslugi] [int] IDENTITY(1,1) NOT NULL,
	[nazwa_uslugi] [varchar](30) NOT NULL,
	[cena_uslugi] [decimal](8, 2) NOT NULL,
 CONSTRAINT [pk_id_uslu] PRIMARY KEY CLUSTERED 
(
	[id_uslugi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[choroby] ON 

INSERT [dbo].[choroby] ([id_choroby], [kod_choroby], [nazwa_choroby]) VALUES (12, N'A12XSD', N'gruźlica')
INSERT [dbo].[choroby] ([id_choroby], [kod_choroby], [nazwa_choroby]) VALUES (5, N'A46', N'RÓŻA')
INSERT [dbo].[choroby] ([id_choroby], [kod_choroby], [nazwa_choroby]) VALUES (2, N'H00.1', N'GRADÓWKA ')
INSERT [dbo].[choroby] ([id_choroby], [kod_choroby], [nazwa_choroby]) VALUES (1, N'I21.0', N'OSTRY ZAWAŁ SERCA PEŁNOŚCIENNY ŚCIANY PRZEDNIEJ')
INSERT [dbo].[choroby] ([id_choroby], [kod_choroby], [nazwa_choroby]) VALUES (4, N'Z08.0 ', N'BADANIE KONTROLNE PO LECZENIU CHIRURGICZNYM NOWOTWORU ZŁOŚLIWEGO ')
INSERT [dbo].[choroby] ([id_choroby], [kod_choroby], [nazwa_choroby]) VALUES (3, N'Z30.0', N'PORADNICTWO I WSKAZÓWKI OGÓLNE W ZAKRESIE ANTYKONCEPCJI ')
SET IDENTITY_INSERT [dbo].[choroby] OFF
SET IDENTITY_INSERT [dbo].[dawka_leku] ON 

INSERT [dbo].[dawka_leku] ([id_dawki], [dawka], [jednostka]) VALUES (1, 200, 1)
INSERT [dbo].[dawka_leku] ([id_dawki], [dawka], [jednostka]) VALUES (2, 500, 2)
INSERT [dbo].[dawka_leku] ([id_dawki], [dawka], [jednostka]) VALUES (3, 100, 1)
INSERT [dbo].[dawka_leku] ([id_dawki], [dawka], [jednostka]) VALUES (4, 150, 2)
INSERT [dbo].[dawka_leku] ([id_dawki], [dawka], [jednostka]) VALUES (5, 300, 2)
SET IDENTITY_INSERT [dbo].[dawka_leku] OFF
SET IDENTITY_INSERT [dbo].[jednostka_leku] ON 

INSERT [dbo].[jednostka_leku] ([id_jednostki], [nazwa_jednostki]) VALUES (1, N'ml')
INSERT [dbo].[jednostka_leku] ([id_jednostki], [nazwa_jednostki]) VALUES (2, N'mg')
SET IDENTITY_INSERT [dbo].[jednostka_leku] OFF
SET IDENTITY_INSERT [dbo].[karta_pacjenta] ON 

INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (1, 1, 1, N'I21.0', 3, 1, N'ostry zawal serca, pacjent hospitalizowany')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (2, 2, 2, N'Z08.0', 1, 2, N'Przepisano środki przeciwbólowe')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (3, 3, 3, NULL, NULL, 4, N'Udzielono porady')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (4, 4, 4, N'H00.1', 3, 4, N'Przepisano antybiotyk')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (5, 5, 4, N'A46', 2, 1, N'Wykryto chorobę. Przepisano antybiotyk')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (22, 24, 4, N'H00.1', 2, 4, N'Diagnozasdsdsa dsadsadds dsadsd sdsdsd dsadsd sdsadsad sadsadsa')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (23, 24, 4, N'H00.1', 2, 4, N'Diagnozasdsdsa dsadsadds dsadsd sdsdsd dsadsd sdsadsad sadsadsa')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (24, 24, 4, N'H00.1', 2, 4, N'Diagnozasdsdsa dsadsadds dsadsd sdsdsd dsadsd sdsadsad sadsadsa')
INSERT [dbo].[karta_pacjenta] ([id_karty], [id_pacjenta], [wykonane_uslugi], [kod_choroby], [id_leku], [lekarz_prowadzacy], [diagnoza]) VALUES (25, 24, 3, N'I21.0', 3, 1, N'Diagnozasadsads sdsadsads sasadsasad sdsasadsa sdsad')
SET IDENTITY_INSERT [dbo].[karta_pacjenta] OFF
SET IDENTITY_INSERT [dbo].[lek] ON 

INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (1, N'apap', 2)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (2, N'Aprokam', 1)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (3, N'Aprokam', 2)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (4, N'Ceclor', 4)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (5, N'Ceroxim', 3)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (12, N'TextBox', 1)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (13, N'TextBox', 1)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (14, N'TextBox', 1)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (15, N'TextBox', 1)
INSERT [dbo].[lek] ([id_leku], [nazwa_leku], [dawka]) VALUES (16, N'TextBox', 1)
SET IDENTITY_INSERT [dbo].[lek] OFF
SET IDENTITY_INSERT [dbo].[lekarz] ON 

INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (1, N'Robert', N'Nowakowski', 1)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (2, N'Adrian', N'Kowalski', 2)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (3, N'Jan', N'Urlop', 3)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (4, N'Anastazja', N'Gajowy', 4)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (5, N'Łucja', N'Lwiewska', 5)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (6, N'TextBox', N'TextBox', 6)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (7, N'TextBox', N'TextBox', 3)
INSERT [dbo].[lekarz] ([id_lekarza], [imie], [nazwisko], [id_specjalizacji]) VALUES (8, N'Adrian', N'Wadrzyk', 7)
SET IDENTITY_INSERT [dbo].[lekarz] OFF
SET IDENTITY_INSERT [dbo].[pacjent] ON 

INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (1, N'Jan', N'Nowak', N'12345678919', N'123456789', N'Wadowice', N'Slowackiego', N'12a       ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (2, N'Adrian', N'Wądrzyk', N'12325612412', N'345678923', N'Krakow', N'Matecznego', N'23/12     ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (3, N'Patryk', N'Fizykowski', N'92124512332', N'123478923', N'Krakow', N'Lenartowicza', N'43c       ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (4, N'Anom', N'Waszkowski', N'54324512451', N'345672512', N'Skawina', N'Glowna', N'34a       ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (5, N'Janina', N'Bogucka', N'92123412124', N'125346373', N'Zator', N'Wczorajsza', N'          ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (24, N'23', N'123', N'12345678911', N'123456789', N'', N'', N'          ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (25, N'23', N'sds', N'12345678910', N'123456578', N'', N'', N'          ')
INSERT [dbo].[pacjent] ([id_pacjenta], [imie], [nazwisko], [PESEL], [telefon], [miasto], [ulica], [nr_lokalu]) VALUES (26, N'Adrian', N'Wadrzyk', N'12345678923', N'123456789', N'Wadowice', N'Kraów', N'23        ')
SET IDENTITY_INSERT [dbo].[pacjent] OFF
SET IDENTITY_INSERT [dbo].[rejestracja] ON 

INSERT [dbo].[rejestracja] ([id_rejestracji], [id_pacjenta], [id_lekarza], [data_rejestracji], [godzina]) VALUES (1, 1, 3, CAST(N'2020-02-02' AS Date), CAST(N'07:00:00' AS Time))
INSERT [dbo].[rejestracja] ([id_rejestracji], [id_pacjenta], [id_lekarza], [data_rejestracji], [godzina]) VALUES (2, 2, 2, CAST(N'2020-03-02' AS Date), CAST(N'08:00:00' AS Time))
INSERT [dbo].[rejestracja] ([id_rejestracji], [id_pacjenta], [id_lekarza], [data_rejestracji], [godzina]) VALUES (3, 3, 5, CAST(N'2020-04-02' AS Date), CAST(N'09:00:00' AS Time))
INSERT [dbo].[rejestracja] ([id_rejestracji], [id_pacjenta], [id_lekarza], [data_rejestracji], [godzina]) VALUES (4, 4, 1, CAST(N'2020-04-02' AS Date), CAST(N'10:00:00' AS Time))
SET IDENTITY_INSERT [dbo].[rejestracja] OFF
SET IDENTITY_INSERT [dbo].[specjalizacja] ON 

INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (1, N'lekarz rodzinny')
INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (2, N'pediatra')
INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (3, N'laryngolog')
INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (4, N'pielęgniarka')
INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (5, N'okulista')
INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (6, N'TextBox')
INSERT [dbo].[specjalizacja] ([id_specjalizacji], [nazwa_specjalizacji]) VALUES (7, N'czarna magia')
SET IDENTITY_INSERT [dbo].[specjalizacja] OFF
SET IDENTITY_INSERT [dbo].[uslugi] ON 

INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (1, N'rezonans', CAST(5.20 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (2, N'rengent', CAST(3.60 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (3, N'tomografia', CAST(2.00 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (4, N'pobranie krwi', CAST(4.30 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (5, N'badanie moczu', CAST(4.30 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (8, N'TextBox', CAST(20.00 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (9, N'TextBox', CAST(200.00 AS Decimal(8, 2)))
INSERT [dbo].[uslugi] ([id_uslugi], [nazwa_uslugi], [cena_uslugi]) VALUES (10, N'TextBox', CAST(200.00 AS Decimal(8, 2)))
SET IDENTITY_INSERT [dbo].[uslugi] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__pacjent__4F16EE7FC99221CD]    Script Date: 19.02.2021 18:45:55 ******/
ALTER TABLE [dbo].[pacjent] ADD UNIQUE NONCLUSTERED 
(
	[PESEL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[dawka_leku]  WITH CHECK ADD  CONSTRAINT [ref_id_jedn] FOREIGN KEY([jednostka])
REFERENCES [dbo].[jednostka_leku] ([id_jednostki])
GO
ALTER TABLE [dbo].[dawka_leku] CHECK CONSTRAINT [ref_id_jedn]
GO
ALTER TABLE [dbo].[karta_pacjenta]  WITH CHECK ADD  CONSTRAINT [ref_id_lek] FOREIGN KEY([id_leku])
REFERENCES [dbo].[lek] ([id_leku])
GO
ALTER TABLE [dbo].[karta_pacjenta] CHECK CONSTRAINT [ref_id_lek]
GO
ALTER TABLE [dbo].[karta_pacjenta]  WITH CHECK ADD  CONSTRAINT [ref_id_leka_karta] FOREIGN KEY([lekarz_prowadzacy])
REFERENCES [dbo].[lekarz] ([id_lekarza])
GO
ALTER TABLE [dbo].[karta_pacjenta] CHECK CONSTRAINT [ref_id_leka_karta]
GO
ALTER TABLE [dbo].[karta_pacjenta]  WITH CHECK ADD  CONSTRAINT [ref_id_pacj_karta] FOREIGN KEY([id_pacjenta])
REFERENCES [dbo].[pacjent] ([id_pacjenta])
GO
ALTER TABLE [dbo].[karta_pacjenta] CHECK CONSTRAINT [ref_id_pacj_karta]
GO
ALTER TABLE [dbo].[karta_pacjenta]  WITH CHECK ADD  CONSTRAINT [ref_id_uslu] FOREIGN KEY([wykonane_uslugi])
REFERENCES [dbo].[uslugi] ([id_uslugi])
GO
ALTER TABLE [dbo].[karta_pacjenta] CHECK CONSTRAINT [ref_id_uslu]
GO
ALTER TABLE [dbo].[karta_pacjenta]  WITH CHECK ADD  CONSTRAINT [ref_kod_chor] FOREIGN KEY([kod_choroby])
REFERENCES [dbo].[choroby] ([kod_choroby])
GO
ALTER TABLE [dbo].[karta_pacjenta] CHECK CONSTRAINT [ref_kod_chor]
GO
ALTER TABLE [dbo].[lek]  WITH CHECK ADD  CONSTRAINT [ref_id_dawk] FOREIGN KEY([dawka])
REFERENCES [dbo].[dawka_leku] ([id_dawki])
GO
ALTER TABLE [dbo].[lek] CHECK CONSTRAINT [ref_id_dawk]
GO
ALTER TABLE [dbo].[lekarz]  WITH CHECK ADD  CONSTRAINT [ref_id_spec] FOREIGN KEY([id_specjalizacji])
REFERENCES [dbo].[specjalizacja] ([id_specjalizacji])
GO
ALTER TABLE [dbo].[lekarz] CHECK CONSTRAINT [ref_id_spec]
GO
ALTER TABLE [dbo].[rejestracja]  WITH CHECK ADD  CONSTRAINT [ref_id_leka] FOREIGN KEY([id_lekarza])
REFERENCES [dbo].[lekarz] ([id_lekarza])
GO
ALTER TABLE [dbo].[rejestracja] CHECK CONSTRAINT [ref_id_leka]
GO
ALTER TABLE [dbo].[rejestracja]  WITH CHECK ADD  CONSTRAINT [ref_id_pacj] FOREIGN KEY([id_pacjenta])
REFERENCES [dbo].[pacjent] ([id_pacjenta])
GO
ALTER TABLE [dbo].[rejestracja] CHECK CONSTRAINT [ref_id_pacj]
GO
USE [master]
GO
ALTER DATABASE [projekt6] SET  READ_WRITE 
GO
