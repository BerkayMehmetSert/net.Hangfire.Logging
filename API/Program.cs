using API.Application;
using API.Application.Jobs;
using API.Persistence;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistenceServices();
builder.Services.AddHangfireServices(builder.Configuration);
builder.Services.AddApplicationServices();

    var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.AddHangfireJobs();

app.MapControllers();

app.Run();
