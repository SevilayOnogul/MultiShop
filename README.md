# MultiShop

MultiShop, **ASP.NET Core 8** kullanılarak geliştirilen, mikroservis mimarisine sahip bir e-ticaret uygulamasıdır.

Bu proje; mikroservis mimarisini, farklı veri tabanları, modern yazılım mimarileri ve kimlik doğrulama altyapılarını bir arada kullanarak gerçek bir e-ticaret senaryosu üzerinden öğrenmek ve uygulamak amacıyla geliştirilmektedir.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core 8
- MongoDB
- Microsoft SQL Server
- Entity Framework Core
- Dapper
- AutoMapper
- MediatR
- CQRS
- Onion Architecture
- IdentityServer4
- JSON Web Token (JWT)
- Authentication & Authorization Middleware
- Docker
- Portainer
- Mikroservis Mimarisi

---

## 🧩 Mikroservisler

### 🛒 Basket Service (Single Layer Architecture)
- Redis kullanılarak geliştirilmiştir.
- Single Layer mimari ile basit ve hızlı geliştirme hedeflenmiştir.
- Kullanıcıların sepet işlemlerini yönetir.
- Redis, primary data store olarak kullanılmaktadır.

### 🚚 Cargo Service (N-Tier Architecture)
- MSSQL kullanılarak geliştirilmiştir.
- N-Tier Architecture prensiplerine uygun olarak tasarlanmıştır.
- Kargo ve teslimat süreçlerinin yönetiminden sorumludur.
- Siparişlerin gönderim takibini sağlar.

### 📦 Catalog Service
- MongoDB kullanılarak geliştirilmiştir.
- Ürün ve kategori yönetiminden sorumludur.

### 🎟 Discount Service
- MSSQL ve Dapper kullanılarak geliştirilmiştir.
- Kupon ve indirim işlemlerini yönetir.

### 🧾 Order Service (Onion Architecture + CQRS)
- Onion Architecture ile kurgulanmıştır.
- CQRS ve MediatR tasarım desenleri uygulanmıştır.
- Sipariş süreçlerini yönetir.

### 🔐 Identity Service
- MSSQL kullanılarak geliştirilmiştir.
- Docker ve Portainer ile container ortamında çalıştırılmaktadır.
- IdentityServer4 altyapısı ile kimlik doğrulama işlemleri sağlanmaktadır.
- JSON Web Token (JWT) ile token üretimi gerçekleştirilmektedir.

---

## 🔒 Security Architecture

- Mikroservisler JWT tabanlı kimlik doğrulama ile korunmaktadır.
- Authorization middleware kullanılarak yetkisiz erişimler engellenmektedir.
- Protected endpoint’lerde `[Authorize]` attribute uygulanmıştır.
- Servisler arası güvenli erişim token doğrulaması ile sağlanmaktadır.
- Access token doğrulaması ASP.NET Core authentication middleware pipeline içerisinde gerçekleştirilmektedir.


---

## 🛠️ Altyapı ve Araçlar (Infrastructure)

- **Docker & Portainer:** Mikroservislerin container ortamında çalıştırılması ve yönetimi.
- **Microsoft SQL Server (Container):** Order, Identity, Discount ve Cargo servisleri için Docker üzerinde konumlandırılmıştır.
- **MongoDB:** Catalog servisi için NoSQL veri tabanı çözümü.
- **Redis (Container):** Basket servisi için in-memory veri saklama çözümü.
- **IdentityServer4:** OAuth2 ve OpenID Connect tabanlı kimlik doğrulama altyapısı.
- **DBeaver:** MSSQL ve MongoDB veritabanlarının yönetimi.


---

## 🌐 Servis Port Bilgileri

| Service    | API Port | Database | Database Port |
|------------|----------|----------|---------------|
| Identity   | 5001     | MSSQL    | 1435          |
| Catalog    | 7070     | MongoDB  | 27017         |
| Discount   | 7071     | MSSQL    | 1434          |
| Order      | 7072     | MSSQL    | 1440          |
| Cargo      | 7073     | MSSQL    | 1441          |
| Basket     | 7074     | Redis    | 6379          |


> Not: MSSQL ve Redis servisleri Docker container üzerinde çalıştırılmaktadır. MongoDB ise development ortamında yerel olarak konfigüre edilmiştir.


---

## ▶️ Projeyi Çalıştırma

### 1️⃣ Repository’yi Klonla

```bash
git clone https://github.com/your-username/your-repo-name.git
```

### 2️⃣ Docker Container’ları Başlat

```bash
docker-compose up -d
```

### 3️⃣ Servisleri Çalıştır

- Identity → http://localhost:5001
- Catalog → http://localhost:7070
- Discount → http://localhost:7071
- Order → http://localhost:7072
- Cargo → http://localhost:7073
- Basket → http://localhost:7074


---

## 📌 Proje Durumu

Proje geliştirme aşamasındadır ve eğitim kapsamında adım adım ilerlemektedir.  
Yeni mikroservisler ve altyapı bileşenleri eklenmeye devam etmektedir.
