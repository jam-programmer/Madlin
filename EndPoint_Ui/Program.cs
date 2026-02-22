using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Application;
using Infrastructure;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Application.Contract;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.
    LanguageViewLocationExpanderFormat.Suffix);
builder.Services.AddLocalization(option =>
{
    option.ResourcesPath = "Resources";
});
builder.Services.Application(builder.Configuration);
builder.Services.Infrastructure(builder.Configuration);
builder.Services.Scan(scan => scan
	.FromAssemblies(typeof(Infrastructure.Configuration).Assembly)

	.AddClasses(classes => classes.AssignableTo(typeof(IRepository<>))
		.Where(t => t.IsGenericTypeDefinition))
	.AsImplementedInterfaces()
	.WithScopedLifetime());
builder.Services.Scan(scan => scan
	.FromAssemblies(typeof(Infrastructure.Configuration).Assembly)
	.AddClasses(classes => classes.Where(t => t.Name.EndsWith("Repository")))
	.AsImplementedInterfaces()
	.WithScopedLifetime());

builder.Services.Scan(scan => scan
	.FromAssemblies(typeof(Application.Configuration).Assembly)
	.AddClasses(classes => classes.Where(t => t.Name.EndsWith("Service")))
	.AsImplementedInterfaces()
	.WithScopedLifetime());
var app = builder.Build();

var supportedCultures = new List<CultureInfo>()
            {
                new CultureInfo("en-US"),
        new CultureInfo("fa-IR"),
            };
var options = new RequestLocalizationOptions()
{
    DefaultRequestCulture = new RequestCulture("fa-IR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>()
                {
                    new QueryStringRequestCultureProvider(),
                    new CookieRequestCultureProvider()
                }
};
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization(options);
app.UseAuthentication();
app.UseAuthorization();
app.UseStatusCodePages(async context =>
{
    if (context.HttpContext.Response.StatusCode == 404)
    {
        context.HttpContext.Response.Redirect("/404");
    }

    if (context.HttpContext.Response.StatusCode == 401 || context.HttpContext.Response.StatusCode == 403)
    {
        context.HttpContext.Response.Redirect("/Forbidden");
    }



});

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
