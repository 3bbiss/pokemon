using MySql.Data.MySqlClient;
using Pokemon;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

string connstring = app.Configuration.GetConnectionString("db");
DAL.CS = connstring;
DAL.DB = new MySqlConnection(connstring); // Need the using statement above. Can comment this out if we're using the DAL.CS Connection String

app.Run();
