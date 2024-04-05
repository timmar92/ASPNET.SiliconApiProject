using Microsoft.EntityFrameworkCore;
using WebApi.Config;
using WebApi.Contexts;
using WebApi.Repositories;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.RegisterSwagger();
builder.Services.RegisterJwt(builder.Configuration);



builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddScoped<CourseService>();
builder.Services.AddScoped<SubscriberService>();
builder.Services.AddScoped<TokenService>();
builder.Services.AddScoped<ContactService>();



builder.Services.AddScoped<CourseRepository>();
builder.Services.AddScoped<AuthorRepository>();
builder.Services.AddScoped<DetailsListRepository>();
builder.Services.AddScoped<PointListRepository>();
builder.Services.AddScoped<ReviewsRepository>();
builder.Services.AddScoped<SubscriberRepository>();
builder.Services.AddScoped<ContactRepository>();
builder.Services.AddScoped<CategoryRepository>();




var app = builder.Build();
app.UseCors(x => x.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
app.UseSwagger();
app.UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Silicon Web Api v1"));
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
