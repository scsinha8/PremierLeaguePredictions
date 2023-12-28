using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictions.Areas.Identity.Data;
using PremierLeaguePredictions.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PLPredsDBContextConnection") ?? throw new InvalidOperationException("Connection string 'PLPredsDBContextConnection' not found.");

builder.Services.AddDbContext<PLPredsDBContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PredictionsDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<PremierLeaguePredictionsUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<PLPredsDBContext>();

// Add services to the container.
builder.Services.AddRazorPages(options =>
    options.Conventions.AuthorizePage("/Privacy", "Admin"));
builder.Services.AddMemoryCache();
builder.Services.AddAuthorization(options =>
    options.AddPolicy("Admin", policy =>
        policy.RequireAuthenticatedUser()
            .RequireClaim("IsAuthorized", bool.TrueString)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
