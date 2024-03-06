using Microsoft.Extensions.Options;
using ReportAPI.Infrastructure;
using ReportAPI.Service.Services;
using ReportAPI.Service.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRabbitMQService, RabbitMQService>();
builder.Services.AddScoped<IReportProcessor, ReportProcessor>();
builder.Services.AddScoped<IReportQueue, ReportQueue>();
builder.Services.AddScoped<IReportService, ReportService>();

var app = builder.Build();

//mongoDB
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddSingleton<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

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
