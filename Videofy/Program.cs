using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Videofy.Models;
using Videofy.Models.Interfaces;
using Videofy.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AluraChallenge5DatabaseSettings>(
    builder.Configuration.GetSection(nameof(AluraChallenge5DatabaseSettings)));

builder.Services.AddSingleton<IAluraChallenge5DatabaseSettings>(ac =>
    ac.GetRequiredService<IOptions<AluraChallenge5DatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("AluraChallenge5DatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IVideoService, VideoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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