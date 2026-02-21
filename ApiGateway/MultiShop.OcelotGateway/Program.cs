using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. Konfigürasyonu ayarla
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("ocelot.json").Build();

// 2. Kimlik Doðrulama Þemasýný ekle (ocelot.json içindeki isimle ayný olmalý)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("OcelotAuthenticationScheme", options =>
    {
        options.Authority = "http://localhost:5001"; // IdentityServer adresin
        options.Audience = "ResourceOcelot"; // IdentityServer'da tanýmladýðýn Audience
        options.RequireHttpsMetadata = false;
    });

// 3. Ocelot servislerini ekle
builder.Services.AddOcelot(configuration);

var app = builder.Build();

// 4. Ocelot'u kullan
await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();