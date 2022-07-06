using BettingDataProvider.Context;
using BettingDataProvider.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connString = builder.Configuration.GetConnectionString("BettingDataProviderApiConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(optins => {
    optins.AddPolicy("AllowAll", b => b.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowAnyOrigin());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

var scope = app.Services.CreateScope();

SportsEventsDataRetriever dataRetriever = new SportsEventsDataRetriever(
    scope.ServiceProvider.GetService<ApplicationDbContext>()
);

dataRetriever.PollSportsData();

app.Run();
