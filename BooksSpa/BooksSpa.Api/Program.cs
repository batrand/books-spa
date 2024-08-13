using AspNetCore.Authentication.ApiKey;
using BooksSpa.Api.Infrastructure;
using BooksSpa.Api.Options;
using BooksSpa.Api.Services;

var builder = WebApplication.CreateBuilder(args);

// ASP.NET Core Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>();

// Auth
builder.Services.AddAuthentication(ApiKeyDefaults.AuthenticationScheme)
    .AddApiKeyInHeader<ApiKeyProvider>(o =>
    {
        o.Realm = "Books SPA API";
        o.KeyName = "X-Api-Token";
    });

// Options
builder.Services.Configure<AppDbOptions>(builder.Configuration.GetSection(AppDbOptions.Key));
builder.Services.Configure<AuthOptions>(builder.Configuration.GetSection(AuthOptions.Key));

// Services
builder.Services.AddTransient<IBookRepositoryService, BookRepositoryService>();

var app = builder.Build();

// Middleware pipeline
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();