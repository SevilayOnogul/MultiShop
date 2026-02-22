# MultiShop

MultiShop, **ASP.NET Core 8** kullanılarak geliştirilen, mikroservis mimarisine sahip bir e-ticaret uygulamasıdır.

Bu proje; mikroservis mimarisi, farklı veri tabanı teknolojileri, modern yazılım mimarileri ve kimlik doğrulama altyapılarını gerçek bir e-ticaret senaryosu üzerinden uygulamalı olarak deneyimlemek amacıyla geliştirilmiştir.

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

---

# 🔒 Security Architecture

- JWT tabanlı authentication
- Scope bazlı authorization
- `[Authorize]` attribute ile endpoint koruması
- Gateway seviyesinde token doğrulama
- Servisler arası güvenli erişim

Token üretimi ve konfigürasyonu Identity Service üzerinden yönetilmektedir.

---

# 🛠 Infrastructure

- Docker & Docker Compose
- Portainer
- MSSQL (Container)
- Redis (Container)
- MongoDB
- DBeaver

---

# 🌐 Servis Port Bilgileri

| Service    | API Port | Database | Database Port |
|------------|----------|----------|---------------|
| Gateway    | 5000     | -        | -             |
| Identity   | 5001     | MSSQL    | 1435          |
| Catalog    | 7070     | MongoDB  | 27017         |
| Discount   | 7071     | MSSQL    | 1434          |
| Order      | 7072     | MSSQL    | 1440          |
| Cargo      | 7073     | MSSQL    | 1441          |
| Basket     | 7074     | Redis    | 6379          |
| Comment    | 7075     | MSSQL    | 1442          |
| Payment    | 7076     | -        | -             |
| Images     | 7077     | -        | -             |

> Not: MSSQL ve Redis servisleri Docker container üzerinde çalışmaktadır. MongoDB geliştirme ortamında local olarak konumlandırılmıştır.

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

---

# 📌 Proje Durumu

Bu proje mikroservis mimarisi, dağıtık sistem tasarımı ve modern .NET ekosistemini öğrenmek amacıyla geliştirilmektedir.  
Geliştirme süreci aktif olarak devam etmektedir.
