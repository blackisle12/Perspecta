using Perspecta.Domain.Configurations;
using Perspecta.Service;
using Perspecta.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure settings
builder.Services.Configure<RapidApiSettings>(builder.Configuration.GetSection("RapidApi"));
builder.Services.Configure<ApiNinjaSettings>(builder.Configuration.GetSection("ApiNinjas"));

// Configure injection
builder.Services.AddScoped<IApiNinjaService, ApiNinjaService>();
builder.Services.AddScoped<IRapidApiService, RapidApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
