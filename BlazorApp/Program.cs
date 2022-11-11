using BlazorApp.Areas.Identity;
using BlazorApp.Data;

using ClassLibrary.Data;
using ClassLibrary.Data.Handlers;
using ClassLibrary.Data.Repositories;
using ClassLibrary.Factories;

using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddSingleton<IConnectionProvider, SqlServerConnectionProvider>(builder =>
{
    var factory = SqlClientFactory.Instance;
    var connection = factory.CreateConnection();
    connection.ConnectionString = connectionString;
    return SqlServerConnectionProvider.CreateInstance(connection);
});
builder.Services.AddSingleton<IAppointmentsFactory, AppointmentsFactory>();
builder.Services.AddSingleton<IAppointmentsRepository, AppointmentsRepository>();
builder.Services.AddSingleton<IAppointmentsHandler, AppointmentsHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
