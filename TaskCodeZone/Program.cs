using Microsoft.EntityFrameworkCore;
using TaskCodeZone.BL;
using TaskCodeZone.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region DataBase
string? connectionString = builder.Configuration.GetConnectionString("Stock");
builder.Services.AddDbContext<StockContext>(options =>
    options.UseSqlServer(connectionString));
#endregion
#region Repos
builder.Services.AddScoped<IItemRepo, ItemRepo>();
builder.Services.AddScoped<IStoreRepo, StoreRepo>();
builder.Services.AddScoped<IStoreItemRepo, StoreItemRepo>();

#endregion
#region Unit of work

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

#endregion
#region Managers
builder.Services.AddScoped<IItemManager, ItemManager>();
builder.Services.AddScoped<IStoreManager, StoreManager>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=GetAllSotres}/{id?}");

app.Run();
