using Microsoft.EntityFrameworkCore;
using dotnet.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//mysql���ݿ�����
builder.Services.AddDbContext<TesTalContext>(opt => {
    string connectionString = builder.Configuration.GetConnectionString("MySQLConnection");//������appsetting���MySQLConnectionֱ��д����Ҳ������...�±���д�����У�ΪʲôҪ��ô��㡣��
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
