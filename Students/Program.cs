using Microsoft.EntityFrameworkCore;
using Students;
using Students.BLL;
using Students.DbContext;
using Students.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// builder.Services.AddSingleton<StudentsDataStore>();
// builder.Services.AddDbContext<StudentsInfoContext>(
//     dbContextOptions => dbContextOptions.UseSqlite(
//         builder.Configuration["ConnectionStrings:StudentsInfoDBConnectionString"]));
// builder.Services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.InjectDependencies(builder.Configuration);
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