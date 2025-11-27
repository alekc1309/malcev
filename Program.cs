using DotNetEnv;
using Project.Api.Modules.Applicants.Extensions;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddApplicantsModule(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
