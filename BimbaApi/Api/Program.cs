using Api.Modules;
using Application;
using Application.Common.Interfaces.Queries;
using Application.Common.Interfaces.Repositories;
using Infrastructure;
using Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.SetupServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

await app.InitialiseDb();
app.MapControllers();

app.Run();