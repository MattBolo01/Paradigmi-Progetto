using Paradigmi.Lib.Web.Estensioni;
using Paradigmi.Lib.App.Estensione;
using Paradigmi.Lib.Models.Estensioni;


var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddWebServices(builder.Configuration)
    .AddModelServices(builder.Configuration)
    .AddApplicationServices(builder.Configuration);

var app = builder.Build();

app.AddWebMiddleware();

app.Run();