**Task Management Projesi**

Bu proje, .NET Core 8.0 kullanılarak geliştirilmiş bir görev yönetim uygulamasıdır. Aşağıda proje detayları ve kullanılan teknolojiler hakkında bilgi bulabilirsiniz.

**Giriş**

Task Management Projesi, kullanıcıların görevlerini yönetmelerine olanak tanır. Proje, kullanıcıların farklı rollerdeki yetkilerine göre görevleri oluşturmasına, güncellemesine ve takibini yapmasına olanak sağlar. Ayrıca, kullanıcılar görevlerin durumlarını güncellediklerinde bildirim alır.

**Özellikler**

- Rol bazlı yetkilendirme sistemi
- JWT token tabanlı kimlik doğrulama
- Fluent Validation kullanımı
- Hangfire ve SMTP MailKit ile görev bazlı e-posta gönderme
- Bellek önbelleği kullanımı
- Entity Framework Core ORM kullanımı
- CQRS ve MediatR uyumlu katmanlı mimari

**Teknolojiler**

- .NET Core 8.0
- JWT (JSON Web Token)
- Fluent Validation
- Hangfire
- SMTP MailKit (E-posta gönderimi için)
- Memory Cache
- Entity Framework Core (ORM)
- CQRS (Command Query Responsibility Segregation)
- MediatR
- MSSQL Veritabanı

**Katmanlı Mimari**

Proje, aşağıdaki katmanlardan oluşur:

1. **API Katmanı:** HTTP isteklerini alır ve iş mantığı katmanına iletilir.
1. **Business Katmanı:** İş mantığı ve uygulama kurallarını içerir.
1. **Data Access Katmanı:** Veritabanı işlemlerini gerçekleştirir.
1. **Entities Katmanı:** Veritabanı tablolarını temsil eden sınıfları içerir.
1. **Infrastructure Katmanı:** Genel yardımcı sınıflar ve araçlar bulunur. Mail gönderme işlemleri bu katmanda yer alır.

