using System.Collections.Immutable;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NLayer.API.Modules;
using NLayer.Repository;
using NLayer.Service.Mapping;
using System.Reflection;
using System.Text;
using Microsoft.OpenApi.Models;
using NLayer.API.UtilityClasses;

var builder = WebApplication.CreateBuilder(args);


BuilderConfigurator.AddAuthenticationWithOptions(builder);

builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();


BuilderConfigurator.AddSwaggerGenWithBearer(builder);


builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));



BuilderConfigurator.DbContextConfiguration(builder);



builder.Host.UseServiceProviderFactory(
    new AutofacServiceProviderFactory());

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => containerBuilder.RegisterModule(new RepoServiceModule()));



var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();




app.MapControllers();

app.Run();
