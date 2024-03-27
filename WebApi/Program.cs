using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<SubscriberService>();



builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<DetailsListRepository>();
builder.Services.AddScoped<PointListRepository>();
builder.Services.AddScoped<ReviewsRepository>();
builder.Services.AddScoped<SubscriberRepository>();




var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
