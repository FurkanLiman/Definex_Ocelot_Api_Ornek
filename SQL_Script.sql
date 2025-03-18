USE master
GO

-- Eğer veritabanı varsa siliyoruz
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'DefineX_Ocelot_API')
BEGIN
    ALTER DATABASE DefineX_Ocelot_API SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DefineX_Ocelot_API;
END
GO

-- Yeni veritabanı oluşturuyoruz
CREATE DATABASE DefineX_Ocelot_API;
GO

USE DefineX_Ocelot_API;
GO

-- Category tablosunu oluşturuyoruz
CREATE TABLE Categories (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500) NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive TINYINT NOT NULL DEFAULT 1
);
GO

-- Örnek kategori verileri ekliyoruz
INSERT INTO Categories (Name, Description, CreatedDate, IsActive)
VALUES 
    (N'Teknoloji', N'Bilim ve teknoloji ile ilgili makaleler', GETDATE(), 1),
    (N'Spor', N'Spor haberleri ve makaleler', GETDATE(), 1),
    (N'Kültür-Sanat', N'Sanat, müzik, edebiyat ve kültürel içerikler', GETDATE(), 1),
    (N'Ekonomi', N'Finans ve ekonomi haberleri', GETDATE(), 1),
    (N'Sağlık', N'Sağlık ve wellness konuları', GETDATE(), 1),
    (N'Eğitim', N'Eğitim ve öğrenme konuları', GETDATE(), 1);
GO

-- =============================================
-- 2. Writer.Api Veritabanı
-- =============================================

USE master
GO

-- Eğer veritabanı varsa siliyoruz
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'WriterDb')
BEGIN
    ALTER DATABASE WriterDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE WriterDb;
END
GO

-- Yeni veritabanı oluşturuyoruz
CREATE DATABASE WriterDb;
GO

USE DefineX_Ocelot_API;
GO

-- Writer tablosunu oluşturuyoruz
CREATE TABLE Writers (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(50) NOT NULL,
    Surname NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100) NOT NULL,
    Password NVARCHAR(200) NOT NULL, -- Gerçek uygulamada hash değeri saklanmalı
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    IsActive TINYINT NOT NULL DEFAULT 1
);
GO

-- Email için unique index oluşturuyoruz
CREATE UNIQUE INDEX IX_Writers_Email ON Writers(Email);
GO

-- Örnek yazar verileri ekliyoruz
INSERT INTO Writers (Name, Surname, Email, Password, CreatedDate, IsActive)
VALUES 
    (N'Ahmet', N'Yılmaz', N'ahmet.yilmaz@example.com', N'123456', GETDATE(), 1),
    (N'Mehmet', N'Öztürk', N'mehmet.ozturk@example.com', N'123456', GETDATE(), 1),
    (N'Ayşe', N'Demir', N'ayse.demir@example.com', N'123456', GETDATE(), 1),
    (N'Fatma', N'Kaya', N'fatma.kaya@example.com', N'123456', GETDATE(), 1),
    (N'Ali', N'Çelik', N'ali.celik@example.com', N'123456', GETDATE(), 1);
GO

-- =============================================
-- 3. Article.Api Veritabanı
-- =============================================

USE master
GO

-- Eğer veritabanı varsa siliyoruz
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'ArticleDb')
BEGIN
    ALTER DATABASE ArticleDb SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE ArticleDb;
END
GO

-- Yeni veritabanı oluşturuyoruz
CREATE DATABASE ArticleDb;
GO

USE DefineX_Ocelot_API;
GO

-- Article tablosunu oluşturuyoruz
CREATE TABLE Articles (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(200) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
    PublishedDate DATETIME NOT NULL DEFAULT GETDATE(),
    WriterId INT NOT NULL,
    CategoryId INT NOT NULL,
    IsActive TINYINT NOT NULL DEFAULT 1
);
GO

-- Örnek makale verileri ekliyoruz
INSERT INTO Articles (Title, Content, CreatedDate, PublishedDate, WriterId, CategoryId, IsActive)
VALUES 
    (N'Yapay Zeka ve Gelecek', 
     N'Yapay zekanın geleceğe etkisi hakkında detaylı bir inceleme. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod, nisl vel tincidunt luctus, nisl nisl aliquam nunc, eget aliquam nisl nisl sit amet nisl.', 
     GETDATE(), GETDATE(), 1, 1, 1),
     
    (N'2023 Olimpiyat Hazırlıkları', 
     N'Gelecek olimpiyatlara hazırlanan sporcularımız ve beklentiler. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod, nisl vel tincidunt luctus.', 
     GETDATE(), GETDATE(), 2, 2, 1),
     
    (N'Modern Sanat Akımları', 
     N'Günümüz sanat akımları ve öncü sanatçılar üzerine bir değerlendirme. Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 
     GETDATE(), GETDATE(), 3, 3, 1),
     
    (N'Ekonomide 2023 Trendleri', 
     N'2023 yılında ekonomik trendler ve yatırım fırsatları. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod, nisl vel tincidunt luctus.', 
     GETDATE(), GETDATE(), 4, 4, 1),
     
    (N'Sağlıklı Beslenme İpuçları', 
     N'Günlük hayatta uygulayabileceğiniz sağlıklı beslenme önerileri. Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 
     GETDATE(), GETDATE(), 5, 5, 1),
     
    (N'Uzaktan Eğitimin Geleceği', 
     N'Pandemi sonrası uzaktan eğitim modelleri ve eğitimin geleceği. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed euismod.', 
     GETDATE(), GETDATE(), 1, 6, 1),
     
    (N'Mobil Teknolojideki Son Gelişmeler', 
     N'Akıllı telefon sektöründeki yenilikler ve gelecek trendler. Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 
     GETDATE(), GETDATE(), 2, 1, 1),
     
    (N'E-Spor ve Yeni Nesil Spor Anlayışı', 
     N'E-Sporun geleneksel sporlar arasındaki yeri ve geleceği. Lorem ipsum dolor sit amet, consectetur adipiscing elit.', 
     GETDATE(), GETDATE(), 3, 2, 1);
GO
