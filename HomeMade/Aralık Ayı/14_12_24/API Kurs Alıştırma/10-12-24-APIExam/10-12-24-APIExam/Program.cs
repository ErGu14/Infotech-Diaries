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

// þimdi nesnelerimi oluþturucam ve istediðim zaman çaðýrabilmemi saðlicam

builder.Services.AddScoped<IUnitOfWork,UnitOfWork>(); //somut olan IUnitOfWorkü oluþturmayý unutma   bu iþlemi yapacaðýn zaman somut olaný oluþtur her sakýn unutma
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); // type of dememizin sebebi býrdaki metotdun içindekþ <>  iþaret her türden bir nesne alabilir ve genele hitap eder yalnýz InutiOFWork sdece generic repoda kullanacaðýmýz için genel bir kullanýma hitap etmiyor

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
