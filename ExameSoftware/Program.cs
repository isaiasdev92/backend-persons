using WebApi.Helpers;
using Microsoft.EntityFrameworkCore;
using ExameSoftware.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().ConfigureApiBehaviorOptions(x =>
{
    x.SuppressMapClientErrors = true;
    x.SuppressMapClientErrors = true;
});

builder.Services.AddDbContext<DataContext>(opt =>
    opt.UseSqlServer("WebApiDatabase"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddRouting(opt =>
{
    opt.LowercaseUrls = true;
    opt.LowercaseQueryStrings = true;

});

builder.Services.AddCors(options =>
    options.AddPolicy("CorsPolicy", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
);

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();


app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
     .AllowAnyOrigin()
     .AllowAnyMethod()
     .AllowAnyHeader());
//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

