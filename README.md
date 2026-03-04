# MultiShop
ASP.NET Core 8 | Microservices Architecture | Ocelot API Gateway | JWT Auth | Dockerized

MultiShop, **ASP.NET Core 8** kullanılarak geliştirilen, mikroservis mimarisine sahip bir e-ticaret uygulamasıdır.

Bu proje; mikroservis mimarisi, farklı veri tabanı teknolojileri ve modern yazılım mimarilerini gerçek bir e-ticaret senaryosu üzerinden uygulayarak uçtan uca dağıtık bir sistem tasarlamak ve hayata geçirmek amacıyla geliştirilen kapsamlı bir referans uygulamadır. Geliştirme süreci aktif olarak devam etmektedir.

# 🎯 Projenin Amacı

Bu proje, modern .NET teknolojileri kullanılarak gerçek dünya senaryosuna uygun bir mikroservis mimarisi tasarlamak ve uygulamak amacıyla geliştirilmiştir.

Projede özellikle aşağıdaki konulara odaklanılmıştır:

- Mikroservis mimarisi tasarımı
- API Gateway yönetimi (Ocelot)
- Servisler arası güvenli iletişim (Client Credentials Flow)
- Merkezi kimlik doğrulama ve yetkilendirme (JWT & IdentityServer)
- Dağıtık veri yönetimi (MongoDB, MSSQL, Redis)
- Katmanlı mimari ve CQRS yaklaşımı
- Güvenli ve ölçeklenebilir sistem tasarımı
 
---

# 🏗 Architecture Overview

Proje, bağımsız olarak geliştirilebilen ve dağıtılabilen mikroservislerden oluşmaktadır.  
Her servis kendi veri tabanına sahiptir ve merkezi bir API Gateway üzerinden erişilir.

## Kullanılan Mimari Yaklaşımlar

- Mikroservis Mimarisi
- Database per Service Pattern
- API Gateway Pattern
- CQRS Pattern
- Onion Architecture
- N-Tier Architecture
- Containerization (Docker)

---

# 🧭 API Gateway (Ocelot)

Projede API Gateway olarak **Ocelot** kullanılmıştır.  
Tüm istemci istekleri gateway üzerinden ilgili mikroservislere yönlendirilir.

Gateway sistemin tek giriş noktasıdır:

```
http://localhost:5000
```

## Gateway Özellikleri

- Merkezi routing yönetimi
- JWT tabanlı authentication doğrulaması
- Scope bazlı authorization kontrolü
- Mikroservis bazlı route ayrımı
- Single Entry Point mimarisi

## Routing Yapısı

İstemciden gelen istek formatı:

```
/services/{service-name}/{everything}
```

Örnek:

```
/services/catalog/products
```

Gateway bu isteği ilgili mikroservisin şu endpoint’ine yönlendirir:

```
/api/{everything}
```

Bu yapı sayesinde istemci tarafı servislerin gerçek port ve adres bilgilerini bilmez.

---

# 🚀 Kullanılan Teknolojiler

- ASP.NET Core 8
- MongoDB
- Microsoft SQL Server
- Redis
- PostgreSQL
- Entity Framework Core
- Dapper
- AutoMapper
- MediatR
- CQRS
- Onion Architecture
- IdentityServer4
- JSON Web Token (JWT)
- Docker & Docker Compose
- Portainer
- SignalR (Real-Time Communication)
  
---

# 🧩 Mikroservisler

## 🛒 Basket Service (Single Layer Architecture)
- Redis kullanılarak geliştirilmiştir.
- Kullanıcıların sepet işlemlerini yönetir.
- Primary data store olarak Redis kullanılmaktadır.

## 🚚 Cargo Service (N-Tier Architecture)
- MSSQL kullanılarak geliştirilmiştir.
- Katmanlı mimariye uygun olarak tasarlanmıştır.
- Kargo ve teslimat süreçlerini yönetir.

## 📦 Catalog Service
- MongoDB kullanılarak geliştirilmiştir.
- Ürün ve kategori yönetiminden sorumludur.

## 💬 Comment Service
- MSSQL & Entity Framework Core kullanır.
- Ürün yorumlarını yönetir.

## 💬 Message Service (N-Tier Architecture)
- PostgreSQL kullanılarak geliştirilmiştir.
- Katmanlı (N-Tier) mimariye uygun olarak tasarlanmıştır.
- Kullanıcılar arası mesajlaşma ve bildirim süreçlerini yönetir.
- Web UI katmanındaki User Area içerisinde entegre edilmiştir.
- JWT tabanlı authentication ile korunmaktadır.

## 🎟 Discount Service
- MSSQL & Dapper kullanır.
- Kupon ve indirim işlemlerini yönetir.

## 🧾 Order Service (Onion Architecture + CQRS)
- Onion Architecture uygulanmıştır.
- CQRS ve MediatR pattern kullanılmıştır.
- Sipariş yönetimini sağlar.

## 🔐 Identity Service
- IdentityServer4 altyapısı kullanılmıştır.
- JWT üretimi sağlar.
- OAuth2 & OpenID Connect standartlarına uygundur.
- Docker container üzerinde çalışmaktadır.

## 💳 Payment Service
- Ödeme süreçlerinin simülasyonunu gerçekleştirir.

## 🖼 Images Service
- Ürün görsellerinin yönetimini sağlar.

## 🔔 SignalR Real-Time Service
- ASP.NET Core SignalR kullanılarak geliştirilmiştir.
- Gerçek zamanlı veri iletimi sağlar.
- Mesaj sayısı ve bildirim badge güncellemeleri için kullanılmaktadır.
- Web UI ile WebSocket bağlantısı üzerinden iletişim kurar.
  
---

# 🔒 Security Architecture

- JWT tabanlı authentication
- Scope bazlı authorization
- `[Authorize]` attribute ile endpoint koruması
- Gateway seviyesinde token doğrulama
- Servisler arası güvenli erişim

Token üretimi ve konfigürasyonu Identity Service üzerinden yönetilmektedir.
- Client Credentials Flow ile servisler arası güvenli erişim sağlanmaktadır.
- Service-to-service iletişim için özel Token Handler implementasyonu yapılmıştır.

---

# 🖥 Web UI Layer

Projede ASP.NET Core MVC tabanlı bir Web UI katmanı bulunmaktadır.

Bu katman:

- API Gateway üzerinden mikroservislerle iletişim kurar
- Client Credential Token Handler ile servisler arası güvenli iletişim sağlar
- Kullanıcı ve admin panellerini içerir
- SignalR ile gerçek zamanlı bildirim ve mesaj sayısı güncellemesi sağlar

## User Area

- Kullanıcı dashboard
- Sipariş geçmişi
- Sepet yönetimi
- Kupon uygulama (Discount Service entegrasyonu)
- Ödeme ekranı (Payment Service entegrasyonu)
- Mesajlaşma / Bildirim ekranı (Message Service entegrasyonu)

## Admin Panel

- Ürün yönetimi
- Kategori yönetimi
- Görsel yönetimi
- Yorum yönetimi
- İçerik yönetimi

# 🛠 Infrastructure

- Docker & Docker Compose
- Portainer
- MSSQL (Container)
- Redis (Container)
- MongoDB
- PostgreSQL (Local Development)
- DBeaver

---

# 🌐 Servis Port Bilgileri

| Service    | API Port |  Database  | Database Port |
|------------|----------|------------|---------------|
| Gateway    | 5000     | -          | -             |
| Identity   | 5001     | MSSQL      | 1435          |
| Catalog    | 7070     | MongoDB    | 27017         |
| Discount   | 7071     | MSSQL      | 1434          |
| Order      | 7072     | MSSQL      | 1440          |
| Cargo      | 7073     | MSSQL      | 1441          |
| Basket     | 7074     | Redis      | 6379          |
| Comment    | 7075     | MSSQL      | 1442          |
| Payment    | 7076     | -          | -             |
| Images     | 7077     | -          | -             |
| Message    | 7078     | PostgreSQL | 5432          |
| SignalR    | 7079     | -          | -             |


> Not: MSSQL ve Redis servisleri Docker container üzerinde çalışmaktadır. 
> MongoDB ve PostgreSQL geliştirme ortamında local olarak konumlandırılmıştır.
> 
---

# 🔄 Request Flow (İstek Akışı)

1. Client → API Gateway  
2. Gateway → JWT doğrulaması  
3. Gateway → İlgili mikroservise routing  
4. Mikroservis → Kendi veri tabanı ile iletişim  
5. Response → Gateway → Client  

Bu yapı ile merkezi güvenlik ve bağımsız servis yönetimi sağlanmaktadır.

---

# 🧱 Architecture Diagram (Logical)

```
Client
   |
   v
API Gateway (Ocelot)
   |
   |---- Catalog Service (MongoDB)
   |---- Basket Service (Redis)
   |---- Order Service (MSSQL)
   |---- Discount Service (MSSQL)
   |---- Cargo Service (MSSQL)
   |---- Comment Service (MSSQL)
   |---- Message Service (PostgreSQL)
   |---- SignalR Real-Time Service
   |---- Identity Service (MSSQL)
   |---- Payment Service
   |---- Images Service
```

---

# 📦 Gelecek Geliştirmeler (Roadmap)

- Service Discovery (Consul)
- Centralized Logging (ELK / Seq)
- Distributed Tracing
- Event-Driven Communication (RabbitMQ)
- CI/CD Pipeline
- Kubernetes Deployment

---

# ▶️ Projeyi Çalıştırma

## 1️⃣ Repository’yi Klonla

```bash
git clone https://github.com/your-username/your-repo-name.git
```

## 2️⃣ Docker Container’ları Başlat

```bash
docker-compose up -d
```

## 3️⃣ Servisleri Çalıştır

- Gateway → http://localhost:5000
- Identity → http://localhost:5001
- Catalog → http://localhost:7070
- Discount → http://localhost:7071
- Order → http://localhost:7072
- Cargo → http://localhost:7073
- Basket → http://localhost:7074
- Comment → http://localhost:7075
- Message → http://localhost:7078
- SignalR → http://localhost:7079


---

# 📌 Proje Durumu

Bu proje mikroservis mimarisi, dağıtık sistem tasarımı ve modern .NET ekosistemini öğrenmek amacıyla geliştirilmektedir.  
Geliştirme süreci aktif olarak devam etmektedir.


# 📚 Teknik Yetkinlikler

Bu proje kapsamında;

- Mikroservisler arası güvenli iletişim
- Merkezi kimlik doğrulama ve token yönetimi
- API Gateway üzerinden routing ve authorization
- Farklı veri tabanı teknolojilerinin birlikte kullanımı
- Katmanlı ve sürdürülebilir mimari tasarım

konularında uçtan uca uygulama deneyimi kazanılmıştır.
