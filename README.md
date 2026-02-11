# MultiShop

MultiShop, **ASP.NET Core 8** kullanılarak geliştirilen, mikroservis mimarisine sahip bir e-ticaret uygulamasıdır.

Bu proje; mikroservis mimarisini, farklı veri tabanları, modern yazılım mimarileri ve kimlik doğrulama altyapılarını bir arada kullanarak gerçek bir e-ticaret senaryosu üzerinden öğrenmek ve uygulamak amacıyla geliştirilmektedir.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core 8
- MongoDB
- Microsoft SQL Server
- Dapper
- Entity Framework Core
- AutoMapper
- MediatR
- CQRS
- Onion Architecture
- IdentityServer4
- JSON Web Token (JWT)
- Docker
- Portainer
- Mikroservis Mimarisi

---

## 🧩 Mikroservisler

### 📦 Catalog Service
- MongoDB kullanılarak geliştirilmiştir.
- Ürün ve kategori yönetiminden sorumludur.

### 🎟 Discount Service
- MSSQL ve Dapper kullanılarak geliştirilmiştir.
- Kupon ve indirim işlemlerini yönetir.

### 🧾 Order Service
- Onion Architecture ile kurgulanmıştır.
- CQRS ve MediatR tasarım desenleri uygulanmıştır.
- Sipariş süreçlerini yönetir.

### 🔐 Identity Service
- MSSQL kullanılarak geliştirilmiştir.
- Docker ve Portainer ile container ortamında çalıştırılmaktadır.
- IdentityServer4 altyapısı ile kimlik doğrulama ve yetkilendirme işlemlerini yönetir.
- JSON Web Token (JWT) ile token üretimi ve doğrulama mekanizması uygulanmıştır.

---

## 🛠️ Altyapı ve Araçlar (Infrastructure)

- **Docker & Portainer:** Mikroservislerin container ortamında çalıştırılması ve yönetimi için kullanılmıştır.
- **Microsoft SQL Server (Container):** Order ve Identity servisleri için Docker üzerinde konumlandırılmıştır.
- **MongoDB:** Catalog servisi için NoSQL veri tabanı çözümü olarak kullanılmıştır.
- **IdentityServer4:** OAuth2 ve OpenID Connect protokolleri üzerinden güvenli kimlik doğrulama ve yetkilendirme altyapısı sağlar.
- **DBeaver:** MSSQL ve MongoDB veritabanlarının yönetimi için kullanılmıştır.

---

## 📌 Proje Durumu

Proje geliştirme aşamasındadır ve eğitim kapsamında adım adım ilerlemektedir.  
Yeni mikroservisler ve altyapı bileşenleri eklenmeye devam etmektedir.
