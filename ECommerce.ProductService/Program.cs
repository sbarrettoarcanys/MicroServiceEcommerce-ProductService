using ECommerce.ProductService.DataAccess.Data;
using ECommerce.ProductService.DataAccess.Repository.IRepository;
using ECommerce.ProductService.DataAccess.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ECommerce.ProductService.BusinessLogic.IManagers;
using ECommerce.ProductService.BusinessLogic.Managers;
using System;
using ECommerce.ProductService.Utility;
using Microsoft.AspNetCore.Authentication.Cookies;
using ECommerce.ProductService.BusinessLogic.AsyncDataServices;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContextConnection' not found.");
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.EnableSensitiveDataLogging();


});

//builder.Services.AddSession(options => {
//    options.IdleTimeout = TimeSpan.FromMinutes(100);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(10);
        options.LoginPath = "/api/productUser/Login";
        options.AccessDeniedPath = "/api/productUser/Login";
    });

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


#region Managers
builder.Services.AddHostedService<MessageBusSubscriber>();
builder.Services.AddHttpClient<IAuthManager, AuthManager>();

ConstantValues.AuthAPIBase = builder.Configuration["ServiceUrls:AuthAPI"];

builder.Services.AddScoped<ICategoryManager, CategoryManager>();
builder.Services.AddScoped<IProductManager, ProductManager>();
builder.Services.AddScoped<IProductImageManager, ProductImageManager>();
builder.Services.AddScoped<IProductCategoryManager, ProductCategoryManager>();
builder.Services.AddScoped<IShoppingCartManager, ShoppingCartManager>();

builder.Services.AddScoped<ITokenProviderManager, TokenProviderManager>();
builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IHttpRequestManager, HttpRequestManager>();
builder.Services.AddScoped<IUserManager, UserManager>();

builder.Services.AddSingleton<IEventProcessManager, EventProcessManager>();
builder.Services.AddSingleton<IEventProcessManager, EventProcessManager>();

#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    if (!app.Environment.IsDevelopment())
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cart API");
        c.RoutePrefix = string.Empty;
    }
});
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
ApplyMigration();
app.Run();

void ApplyMigration()
{
    using (var scope = app.Services.CreateScope())
    {
        var _db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        if (_db.Database.GetPendingMigrations().Count() > 0)
        {
            _db.Database.Migrate();
        }
    }
}