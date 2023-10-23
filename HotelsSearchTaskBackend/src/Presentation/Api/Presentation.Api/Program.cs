using Ardalis.Result;
using Ardalis.Result.AspNetCore;
using Core.Application.Extentions;
using Infrastructure.Persistence.Extentions;
using Presentation.Api.Extentions;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// add services
builder.Services.AddControllers(options =>
{
    options.AddDefaultResultConvention();
});
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddPresentationApiServices();

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
app.MapControllers();
app.UseLogMiddleware();
app.UseExceptionHandlerMiddleware();

app.Run();
