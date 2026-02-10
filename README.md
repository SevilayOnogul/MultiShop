# MultiShop

MultiShop, ASP.NET Core 8 kullanılarak geliştirilen, mikroservis mimarisine sahip bir e-ticaret uygulamasıdır.

Bu proje; mikroservis mimarisini, farklı veri tabanı ve teknolojileri bir arada kullanarak gerçek bir e-ticaret senaryosu üzerinden öğrenmek ve uygulamak amacıyla geliştirilmektedir.

## Kullanılan Teknolojiler
- ASP.NET Core 8
- MongoDB
- MSSQL
- Dapper
- AutoMapper
- Mikroservis Mimarisi

## Mikroservisler

- **Catalog Service**
  - MongoDB kullanılarak geliştirilmiştir.
  - Ürün ve kategori yönetiminden sorumludur.

- **Discount Service**
  - MSSQL ve Dapper kullanılarak geliştirilmiştir.
  - Kupon ve indirim işlemlerini yönetir.
 
- **Order Service**
  - Onion Architecture kullanılarak geliştirilmiştir.
  - CQRS ve MediatR tasarım desenleri uygulanmıştır.


## Proje Durumu
Proje geliştirme aşamasındadır ve eğitim kapsamında adım adım ilerlemektedir.
