using CreditProcess.Api;
using CreditProcess.ApplicationCore;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddPublicApi();
    builder.Services.AddApplicationServices();
}

var app = builder.Build();
{
    app.MapControllers();
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Run();
}



