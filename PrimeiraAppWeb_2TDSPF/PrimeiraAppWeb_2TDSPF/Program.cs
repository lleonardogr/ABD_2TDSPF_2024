using Microsoft.EntityFrameworkCore;
using PrimeiraAppWeb_2TDSPF.Data;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext Oracle on the project
builder.Services.AddDbContext<BoardgameDbContext>(options =>
{
    options.UseOracle(builder.Configuration.GetConnectionString("OracleFiap"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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