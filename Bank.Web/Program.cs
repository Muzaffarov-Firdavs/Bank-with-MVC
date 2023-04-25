using Bank.Data.DbContexts;
using Bank.Data.IRepositories;
using Bank.Data.Repositories;
using Bank.Domain.Entites;
using Bank.Service.Interfaces;
using Bank.Service.Mappers;
using Bank.Service.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// add dbContext to the conteiner
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Database not found or cannot be accessed")));


// add repository to the conteiner
builder.Services.AddScoped<IRepository<User>, Repository<User>>();

// add services to the conteiner
builder.Services.AddScoped<IUserService, UserService>();

// add Automapper to the conteiner
builder.Services.AddAutoMapper(typeof(MapperProfile));



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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
