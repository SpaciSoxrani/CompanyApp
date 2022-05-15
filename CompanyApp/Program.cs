using System.Configuration;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using CompanyApp.Controllers;
using CompanyApp.Core;
using CompanyApp.Core.Domain.Models;
using CompanyApp.Core.Domain.Services;
using CompanyApp.Extensions;
using CompanyApp.Infrastructure.Database;
using CompanyApp.Infrastructure.Database.Repositories;
using MusicApp;
using MusicApp.Infrastructure.Database.Repositories;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
//builder.Services.AddHostedService<MyTestHostedService>();
builder.Services.AddDbContext<CompanyAppContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IParserRiaNewsService), typeof(ParserRiaNewsService));
builder.Services.AddScoped(typeof(IClassificationService<>), typeof(TextClassificationService<>));
builder.Services.AddScoped(typeof(IParserRiaNewsService), typeof(ParserRiaNewsService));

builder.Host
    .ConfigureServices(services =>
    {
        services.AddScoped<IMyScopedService, MyScopedService>();

        services.AddCronJob<ParserRiaNewsCronJob>(c =>
        {
            c.TimeZoneInfo = TimeZoneInfo.Local;
            c.CronExpression = @"*/5 * * * *";
        });
    });

var app = builder.Build();


//вызов сервиса парсера РИА новостей
 // using (var serviceScope = app.Services.CreateScope())
 // {
 //     var services = serviceScope.ServiceProvider;
 //
 //     var myDependency = services.GetRequiredService<IParserRiaNewsService>();
 //
 //     myDependency.SaveAllAsync();
 // }


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseDefaultFiles(new DefaultFilesOptions()
{
    DefaultFileNames = new List<string>() {"Index.html"}
});

app.UseExceptionHandler(builder =>
    {
        builder.Run(
            async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                var error = context.Features.Get<IExceptionHandlerFeature>();
                if (error != null)
                {
                    context.Response.AddApplicationError(error.Error.Message);
                    await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                }
            });
    }
);



app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();