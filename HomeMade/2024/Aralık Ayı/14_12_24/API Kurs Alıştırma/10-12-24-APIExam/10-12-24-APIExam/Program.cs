using Exam.Data.Abstract;
using Exam.Data.Concrete;
using Exam.Data.Concrete.Repositories;
using Exam.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SQLExamContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));

// �imdi nesnelerimi olu�turucam ve istedi�im zaman �a��rabilmemi sa�licam

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(); //somut olan IUnitOfWork� olu�turmay� unutma   bu i�lemi yapaca��n zaman somut olan� olu�tur her sak�n unutma
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); // type of dememizin sebebi b�rdaki metotdun i�indek� <>  i�aret her t�rden bir nesne alabilir ve genele hitap eder yaln�z InutiOFWork sdece generic repoda kullanaca��m�z i�in genel bir kullan�ma hitap etmiyor

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
