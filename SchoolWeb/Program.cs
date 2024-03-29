using Microsoft.EntityFrameworkCore;
using SchoolWeb.Data;
using SchoolWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton
//builder.Services.AddScoped
//builder.Services.AddTransient

builder.Services.AddSingleton<ITools, Tools>();

builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDb"));
});

var app = builder.Build();

app.Logger.Log(LogLevel.Warning, "hello wold");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.Use(async (context, next) =>
{
    app.Logger.LogInformation("Middleware start");
    await next.Invoke();
    app.Logger.LogInformation("Middleware end");
});

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "Privacy",
//    pattern: "Private/{name=Ted}",
//    defaults: new { controller = "Home", action = "Privacy" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.MapControllerRoute(
//    name: "today",
//    pattern: "Today",
//    defaults: new { controller = "Home", action = "Today" });

// old default route
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller}/{action}/{id?}",
//    defaults: new { controller = "Home", action = "Index" });

//app.Use(async (context, next) =>
//{
//    await next.Invoke();

//    if (context.Response.StatusCode == 404)
//        context.Response.Redirect("http://www.contoso.com");

//});

app.Run();

//app.Run(async context =>
//{
//    // TODO : enable custom routes

//    if (context.Response.StatusCode == 404)
//        context.Response.Redirect("http://www.contoso.com");
//});