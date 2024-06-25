using Microsoft.EntityFrameworkCore;
using OnlineShopping.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OnlineShopping.WebApi.Middlewares.ApiExceptionHandler;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;
using AutoMapper;
using OnlineShopping.Application.Profiles;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region [-AddMvcCore-]
builder.Services.AddMvcCore().AddApiExplorer(); 
#endregion

#region [-mappingConfig-]
builder.Services.AddAutoMapper(typeof(Program));

var mappingConfig = new MapperConfiguration
            (a => a.AddProfile(new AutoMap())).CreateMapper();

builder.Services.AddSingleton(mappingConfig); 
#endregion


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

#region [-AddSwaggerGen-]
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo
{
Version = "v1",
Title = "ToDo API",
Description = "An ASP.NET Core Web API for managing ToDo items",
TermsOfService = new Uri("https://example.com/terms"),
Contact = new OpenApiContact
{
    Name = "Example Contact",
    Email = string.Empty,
    Url = new Uri("https://example.com/contact")
},
License = new OpenApiLicense
{
    Name = "Example License",
    Url = new Uri("https://example.com/license")
}
});
});

//builder.services.AddSwaggerDocument(config =>
//{
//    config.PostProcess = document =>
//    {
//        document.Info.Version = "v1";
//        document.Info.Title = "ToDo API";
//        document.Info.Description = "A simple ASP.NET Core web API";
//        document.Info.TermsOfService = "None";
//        document.Info.Contact = new NSwag.OpenApiContact
//        {
//            Name = "Shayne Boyer",
//            Email = string.Empty,
//            Url = "https://twitter.com/spboyer"
//        };
//        document.Info.License = new NSwag.OpenApiLicense
//        {
//            Name = "Use under LICX",
//            Url = "https://example.com/license"
//        };
//    };
//});

#endregion


builder.Services.AddServicesOfAllTypes();

builder.Services.AddServicesWithAttributeOfType<ScopedServiceAttribute>();

#region [-Cookie-]
builder.Services.Configure<CookiePolicyOptions>(options =>
{
options.CheckConsentNeeded = context => true;
options.MinimumSameSitePolicy = SameSiteMode.Lax;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
    {
        o.LoginPath = new PathString("/Account");
        o.LogoutPath = new PathString("/Account");
        o.AccessDeniedPath = new PathString("/AccessDenied");
    });

#endregion

#region [-AddDbContext-]
builder.Services.AddDbContext<ShopManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))); 
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
#region [-Configure-]
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(a => { a.SerializeAsV2 = true; });
    app.UseSwaggerUI();
    app.UseSwaggerUi3();
}
else
{
    app.UseMiddleware<ApiExceptionMiddleware>();
}

app.UseCookiePolicy();

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion