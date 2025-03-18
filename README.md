# Definex Ocelot API Gateway Demo

Bu proje, Ocelot API Gateway kullanarak mikroservis mimarisi ile geliştirilmiş bir örnek uygulamadır. Üç mikroservis (Article.Api, Writer.Api ve Category.Api) ve bu servislerle API Gateway üzerinden iletişim kuran bir WebUI uygulaması içermektedir.

## Proje Yapısı

```
DefinexOcelotApiOrnek/
├── ApiGateway/                # Ocelot API Gateway
├── ApiGateway2/               # Yatay ölçeklendirme için ikinci API Gateway örneği
├── Article.Api/               # Makale mikroservisi
├── Writer.Api/                # Yazar mikroservisi
├── Category.Api/              # Kategori mikroservisi
└── WebUI/                     # Web uygulaması (MVC)
```

## Özellikler

- **Mikroservis Mimarisi**
  - Makale Yönetimi
  - Yazar Yönetimi
  - Kategori Yönetimi
  - Ocelot API Gateway
  - Yatay Ölçeklendirme Desteği

- **Web Arayüzü Özellikleri**
  - İstatistik panosu
  - Makaleler için CRUD işlemleri
  - Yazarlar için CRUD işlemleri
  - Kategoriler için CRUD işlemleri
  - Bootstrap ile responsive tasarım
  - Form doğrulama
  - Hata yönetimi

## Sistem Gereksinimleri

- .NET 7.0 SDK veya üzeri
- Visual Studio 2022 veya üzeri
- SQL Server (LocalDB veya Express)

## Port Yapılandırması

- **API Gateway**: https://localhost:5003
- **API Gateway 2**: https://localhost:5006
- **Article.Api**: https://localhost:5001
- **Writer.Api**: https://localhost:5002
- **Category.Api**: https://localhost:5004
- **WebUI**: https://localhost:5000

## Başlangıç

1. **Projeyi Klonlama**
   ```bash
   git clone [repository-url]
   cd DefinexOcelotApiOrnek
   ```

2. **Veritabanı Kurulumu**

  Projeyi denemek isteyenler için, ana dizinde bulunan `setup.sql` dosyası ile veritabanını hızlıca oluşturabilirsiniz.

2.1. ***SQL Script ile Kurulum***

  -SQL Server Management Studio (SSMS) veya bir SQL istemcisi açın.
  -Ana dizindeki `SQL_Script.sql` dosyasını çalıştırın:

Bu işlem tamamlandıktan sonra, tüm mikroservisler gerekli veritabanlarına bağlanabilecek şekilde yapılandırılmış olacaktır.

2.2. ***Veritabanı Kurulumu***
   - Her mikroservisin kendi veritabanı vardır
   - Gerekirse her proje dosyası içerisindeki `appsettings.json` dosyalarındaki bağlantı dizelerini güncelleyin
   - Her mikroservis için migration'ları çalıştırın:
     ```bash
     cd Article.Api
     dotnet ef database update
     
     cd ../Writer.Api
     dotnet ef database update
     
     cd ../Category.Api
     dotnet ef database update
     ```

3. **Uygulamayı Çalıştırma**
   - Mikroservisleri aşağıdaki sırayla başlatın:
     1. Article.Api
     2. Writer.Api
     3. Category.Api
     4. ApiGateway
     5. ApiGateway2 (isteğe bağlı, yatay ölçeklendirme için)
     6. WebUI

   - Visual Studio'da birden fazla projeyi aynı anda çalıştırmak için:
     1. Solution'a sağ tıklayın
     2. "Configure Startup Projects" seçin
     3. "Multiple startup projects" seçin
     4. Tüm projeler için "Start" aksiyonunu ayarlayın

## API Endpoint'leri

### Article.Api
- GET /api/articles
- GET /api/articles/{id}
- POST /api/articles
- PUT /api/articles/{id}
- DELETE /api/articles/{id}

### Writer.Api
- GET /api/writers
- GET /api/writers/{id}
- POST /api/writers
- PUT /api/writers/{id}
- DELETE /api/writers/{id}

### Category.Api
- GET /api/categories
- GET /api/categories/{id}
- POST /api/categories
- PUT /api/categories/{id}
- DELETE /api/categories/{id}

## API Gateway Rotaları

Tüm istekler API Gateway üzerinden aşağıdaki pattern ile yönlendirilir:
- GET /gateway/articles
- GET /gateway/articles/{id}
- POST /gateway/articles
- PUT /gateway/articles/{id}
- DELETE /gateway/articles/{id}

Benzer pattern'ler yazarlar ve kategoriler için de mevcuttur.

## Kullanılan Teknolojiler

- ASP.NET Core 7.0
- Entity Framework Core
- Ocelot API Gateway
- Bootstrap 5
- jQuery
- SQL Server

## Mimari

Uygulama aşağıdaki özelliklere sahip bir mikroservis mimarisi kullanır:

- Her mikroservisin kendi veritabanı vardır
- Servisler arası iletişim API Gateway üzerinden sağlanır
- WebUI uygulaması mikroservislerle API Gateway üzerinden iletişim kurar
- Yatay ölçeklendirme için birden fazla API Gateway örneği desteklenir

## Sınıf Diyagramı

![lLLXRzCm4FsUNt4VGT3zW6f2Aor2aG1DsX0VaUiSdIN7gUpBHWJyTvJwdDHkwi2qxLESTw_sUywxwvKZOQcjTQ4CeVqX94AvigIanXkqzqeY_2e00DvyH5fflNATaQzU3z3xhgmyfWo1ghYojYW8VO6t0-6VpFYwhsOO6zH866_-fpWM-iqgGljKElrky71uZ2gpzNcDQq6uQsptL2h3VY](https://github.com/user-attachments/assets/ea364289-3ccb-4ba4-b88c-fd4874759e74)

## Veritabanı Şeması

![jPDHQzim4CVV_IaElsnZz0kCKXhIT3CjMt03POyN-neVo5BHdLVCsky-HRRcp0s15PgN-4w_--lkB-bI5BrshSd8AciFYt9JB6zNy3k3yFiCR1MA6ixFrpSN5v2lFRVeUxYXFXy9KSzs1njMGv0ll79bQ0XdoD9P9QiJD2OILgEISXlodb2fla8DYZ5WPs4VlaBNtTQmD0cEOVMQt_PAKCYY](https://github.com/user-attachments/assets/084f1775-a03f-4986-a452-6e08921f395b)

