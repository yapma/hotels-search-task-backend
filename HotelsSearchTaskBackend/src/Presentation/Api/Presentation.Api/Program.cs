using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Core.Application.Extentions;
using Infrastructure.Persistence.Extentions;
using Presentation.Api.Extentions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// add services
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers(options =>
{
    options.AddDefaultResultConvention();
});
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddPresentationApiServices();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader();
                          builder.AllowAnyMethod();
                          builder.AllowAnyOrigin();
                      });
});

//
var app = builder.Build();
//

// request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.DocumentTitle = "Hotels Search";
    });
}
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();
app.UseLogMiddleware();
app.UseExceptionHandlerMiddleware();

app.Run();
