using SchoolWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//builder.Services.AddSingleton
//builder.Services.AddScoped
//builder.Services.AddTransient

builder.Services.AddSingleton<ITools, Tools>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//app.Run(context =>
//{
//    if(context.Response.StatusCode == 404)

//});
