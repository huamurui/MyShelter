using Microsoft.EntityFrameworkCore;
using dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//mysql数据库连接
builder.Services.AddDbContext<TesTalContext>(opt => {
    string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");//所以在appsetting里的MySQLConnection直接写这里也可以吗...下边又写了两行，为什么要这么多层。。
    var serverVersion = ServerVersion.AutoDetect(connectionString);
    opt.UseMySql(connectionString, serverVersion);
});

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
