<<<<<<< HEAD
// Project.Api\Program.cs
using Microsoft.EntityFrameworkCore;
=======
using DotNetEnv;
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
using Project.Api.Modules.Applicants.Extensions;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
// ��������� ������������� ������� �����������
builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001"); // ��� ������ ����� �� �������������

// �������� ������� � ���������.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ��������� CORS - ��������� ��� ��������� (��� ����������)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ����������� ������ Applicants
=======
// 1. Загружаем .env
Env.Load();
builder.Configuration.AddEnvironmentVariables();

// 2. Собираем connection string ВРУЧНУЮ
var host = Environment.GetEnvironmentVariable("DB_HOST");
var port = Environment.GetEnvironmentVariable("DB_PORT");
var user = Environment.GetEnvironmentVariable("DB_USER");
var pass = Environment.GetEnvironmentVariable("DB_PASS");

var dynamicConn =
    $"Server={host},{port};User Id={user};Password={pass};Encrypt=False;TrustServerCertificate=True;";

// 3. Записываем внутрь configuration
builder.Configuration["ConnectionStrings:sqlServer"] = dynamicConn;

builder.WebHost.UseUrls("http://0.0.0.0:5000", "https://0.0.0.0:5001");
// Сервисы
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(o => o.AddDefaultPolicy(b =>
    b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
));

>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
builder.Services.AddApplicantsModule(builder.Configuration);

var app = builder.Build();

<<<<<<< HEAD
// ��������� ��������� HTTP-��������.
=======
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

<<<<<<< HEAD
// �������� CORS (������� ����� - �� UseAuthorization)
app.UseCors();

=======
app.UseCors();
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

<<<<<<< HEAD
app.Run();
=======
app.Run();
>>>>>>> 96cbb32499ee99eeee01b23d0bc07d0078e622dd
