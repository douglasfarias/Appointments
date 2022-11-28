// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Globalization;
using ClassLibrary.Data.Base;
using ClassLibrary.Data.Handlers;
using ClassLibrary.Data.Repositories;
using ClassLibrary.Factories;
using Microsoft.AspNetCore.Localization;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddTransient<IConnectionProvider, ConnectionProvider>(provider =>
{
	var connection = SqlClientFactory.Instance.CreateConnection();
	connection.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");
	return ConnectionProviderFactory.CreateSqlServerConnectionProvider(connection);
});

builder.Services.AddTransient<ICommandFactory, CommandFactory>();
builder.Services.AddTransient<IUserFactory, UserFactory>();
builder.Services.AddTransient<IAppointmentsFactory, AppointmentsFactory>();

builder.Services.AddTransient<ICustomersRepository, CustomersRepository>();
builder.Services.AddTransient<IEmployeesRepository, EmployeesRepository>();
builder.Services.AddTransient<IAppointmentsRepository, AppointmentsRepository>();

builder.Services.AddTransient<ICustomersHandler, CustomersHandler>();
builder.Services.AddTransient<IEmployeesHandler, EmployeesHandler>();
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

app.UseRequestLocalization(new RequestLocalizationOptions
{
	DefaultRequestCulture = new RequestCulture("pt-BR"),
	SupportedUICultures = new List<CultureInfo>() { CultureInfo.CreateSpecificCulture("pt-BR") }
});
CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

app.Run();
