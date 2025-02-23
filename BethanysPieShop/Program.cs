using BethanysPieShop.App;
using BethanysPieShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

//test without database
//builder.Services.AddScoped<ICategoryRepository, MockCategoryRepository>();
//builder.Services.AddScoped<IPieRepository, MockPieRepository>();

var builder = WebApplication.CreateBuilder(args);

// Database setup (if using a real database, otherwise mock repositories)
var connectionString = builder.Configuration.GetConnectionString("BethanysPieShopDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BethanysPieShopDbContextConnection' not found.");

builder.Services.AddDbContext<BethanysPieShopDbContext>(options =>
    options.UseSqlServer(connectionString));

// Adding MVC support
builder.Services.AddControllersWithViews();//if using AddControllers() for APIs this is not needed unless you already have views
                                           //.AddJsonOptions
                                           //(options =>
                                           //{
                                           //    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                                           //}
                                           //);


// Repositories for MVC
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IPieRepository, PieRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

//blazor
builder.Services.AddRazorPages();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<BethanysPieShopDbContext>(options => {
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:BethanysPieShopDbContextConnection"]);
});

//builder.Services.AddControllers();//for APIs this is all that is needed but if using AddControllersWithViews() then this is not needed

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();//middleware for static files
app.UseSession();//middleware for AddSession()
//app.UseAuthentication();//for security

//reversed here from video to turn Razor pages
//app.MapDefaultControllerRoute();//"{controller=Home}/{action=Index}/{id?}");//needed for APIs if not using app.MapControllers()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");//not needed for APIs

app.UseAntiforgery();//for security
app.MapRazorPages();

//blazor
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

//app.MapControllers();//for APIs unless MapDefaultControllerRoute() is already used


DbInitializer.Seed(app);

app.Run();