# Definex Ocelot API Gateway Demo

Bu proje, Ocelot API Gateway kullanarak mikroservis mimarisi ile geliştirilmiş bir örnek uygulamadır. Üç mikroservis (Article.Api, Writer.Api ve Category.Api) ve bu servislerle API Gateway üzerinden iletişim kuran bir WebUI uygulaması içermektedir.

## Proje Yapısı

```
DefinexOcelotApiOrnek/
├── ApiGateway/                 # Ocelot API Gateway
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
   - Her mikroservisin kendi veritabanı vardır
   - Gerekirse `appsettings.json` dosyalarındaki bağlantı dizelerini güncelleyin
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
1. Her mikroservisin kendi veritabanı vardır
2. Servisler arası iletişim API Gateway üzerinden sağlanır
3. WebUI uygulaması mikroservislerle API Gateway üzerinden iletişim kurar
4. Yatay ölçeklendirme için birden fazla API Gateway örneği desteklenir

## Sınıf Diyagramı

```mermaid
classDiagram
    class IArticleService {
        <<interface>>
        +GetAllAsync()
        +GetByIdAsync(int id)
        +CreateAsync(Article article)
        +UpdateAsync(Article article)
        +DeleteAsync(int id)
    }

    class IWriterService {
        <<interface>>
        +GetAllAsync()
        +GetByIdAsync(int id)
        +CreateAsync(Writer writer)
        +UpdateAsync(Writer writer)
        +DeleteAsync(int id)
    }

    class ICategoryService {
        <<interface>>
        +GetAllAsync()
        +GetByIdAsync(int id)
        +CreateAsync(Category category)
        +UpdateAsync(Category category)
        +DeleteAsync(int id)
    }

    class ArticleService {
        -_context: DbContext
        -_mapper: IMapper
        +GetAllAsync()
        +GetByIdAsync(int id)
        +CreateAsync(Article article)
        +UpdateAsync(Article article)
        +DeleteAsync(int id)
    }

    class WriterService {
        -_context: DbContext
        -_mapper: IMapper
        +GetAllAsync()
        +GetByIdAsync(int id)
        +CreateAsync(Writer writer)
        +UpdateAsync(Writer writer)
        +DeleteAsync(int id)
    }

    class CategoryService {
        -_context: DbContext
        -_mapper: IMapper
        +GetAllAsync()
        +GetByIdAsync(int id)
        +CreateAsync(Category category)
        +UpdateAsync(Category category)
        +DeleteAsync(int id)
    }

    class Article {
        +int Id
        +string Title
        +string Content
        +DateTime CreatedDate
        +DateTime PublishedDate
        +byte IsActive
        +int WriterId
        +int CategoryId
        +Writer Writer
        +Category Category
    }

    class Writer {
        +int Id
        +string Name
        +string Surname
        +string Email
        +string Password
        +DateTime CreatedDate
        +byte IsActive
        +List~Article~ Articles
    }

    class Category {
        +int Id
        +string Name
        +string Description
        +DateTime CreatedDate
        +byte IsActive
        +List~Article~ Articles
    }

    class ArticleController {
        -_articleService: IArticleService
        +GetAll()
        +GetById(int id)
        +Create(Article article)
        +Update(int id, Article article)
        +Delete(int id)
    }

    class WriterController {
        -_writerService: IWriterService
        +GetAll()
        +GetById(int id)
        +Create(Writer writer)
        +Update(int id, Writer writer)
        +Delete(int id)
    }

    class CategoryController {
        -_categoryService: ICategoryService
        +GetAll()
        +GetById(int id)
        +Create(Category category)
        +Update(int id, Category category)
        +Delete(int id)
    }

    IArticleService <|.. ArticleService : implements
    IWriterService <|.. WriterService : implements
    ICategoryService <|.. CategoryService : implements

    ArticleService --> Article : manages
    WriterService --> Writer : manages
    CategoryService --> Category : manages

    ArticleController --> IArticleService : uses
    WriterController --> IWriterService : uses
    CategoryController --> ICategoryService : uses

    Article --> Writer : belongs to
    Article --> Category : belongs to
    Writer --> Article : has many
    Category --> Article : has many
```

## Veritabanı Şeması

```mermaid
erDiagram
    ARTICLE ||--o{ WRITER : "belongs to"
    ARTICLE ||--o{ CATEGORY : "belongs to"
    
    ARTICLE {
        int Id PK "Primary Key"
        string Title "Article Title"
        string Content "Article Content"
        datetime CreatedDate "Creation Date"
        datetime PublishedDate "Publication Date"
        byte IsActive "Active Status"
        int WriterId FK "References Writer(Id)"
        int CategoryId FK "References Category(Id)"
    }
    
    WRITER {
        int Id PK "Primary Key"
        string Name "Writer's First Name"
        string Surname "Writer's Last Name"
        string Email "Writer's Email"
        string Password "Hashed Password"
        datetime CreatedDate "Creation Date"
        byte IsActive "Active Status"
    }
    
    CATEGORY {
        int Id PK "Primary Key"
        string Name "Category Name"
        string Description "Category Description"
        datetime CreatedDate "Creation Date"
        byte IsActive "Active Status"
    }

    note for ARTICLE "Articles are associated with both Writers and Categories"
    note for WRITER "Writers can have multiple articles"
    note for CATEGORY "Categories can contain multiple articles"
```

## Hata Yönetimi

- Her mikroservis uygun hata yönetimi içerir
- API Gateway hata yönetimi ve rate limiting içerir
- WebUI kullanıcı dostu hata mesajları gösterir
- Tüm bileşenlerde loglama uygulanmıştır

## Güvenlik

- Tüm servisler için HTTPS etkinleştirilmiştir
- API Gateway rate limiting içerir
- Tüm formlarda giriş doğrulama uygulanmıştır
- Entity Framework ile SQL injection önlemi

## Katkıda Bulunma

1. Projeyi fork edin
2. Feature branch oluşturun
3. Değişikliklerinizi commit edin
4. Branch'inizi push edin
5. Pull Request oluşturun

## Lisans

Bu proje MIT Lisansı altında lisanslanmıştır - detaylar için LICENSE dosyasına bakın. "# Definex_Ocelot_Api_Ornek" 
