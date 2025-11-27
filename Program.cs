// Project.Api\Program.cs
using Microsoft.EntityFrameworkCore;
using Project.Api.Modules.Applicants.Extensions;

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddApplicantsModule(builder.Configuration);

var app = builder.Build();

// ��������� ��������� HTTP-��������.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// �������� CORS (������� ����� - �� UseAuthorization)
app.UseCors();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();