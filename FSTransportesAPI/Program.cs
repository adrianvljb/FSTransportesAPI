using FSTransportesAPI.Infrastructure.Extensions;
using FSTransportesAPI.WebApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// 1. REGISTRO DE TODAS LAS DEPENDENCIAS (Llamada única a nuestra extensión)
builder.Services.AddFSTransportesDependencies(builder.Configuration);

var app = builder.Build();

// 2. CONFIGURACIÓN DEL PIPELINE HTTP
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();