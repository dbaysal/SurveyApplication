using System.Collections.Immutable;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using NLayer.API.Modules;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Service.Services;
using NLayer.Service.Mapping;
using SteamReplica.UtilityClasses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");



builder.Services.AddAutoMapper(typeof(MapProfile));
builder.Host.UseServiceProviderFactory(
	new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);


BuilderConfigurator.AddScopes(builder);
BuilderConfigurator.SqlConnection(builder, connectionString);
BuilderConfigurator.AddAuthentication(builder);


var app = builder.Build();

app.UseAuthentication();

AppConfigurator.UseMvc(app);
AppConfigurator.HttpRequestPipeline(app);



using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<AppDbContext>();
context.Database.EnsureCreated();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}");

app.Run();