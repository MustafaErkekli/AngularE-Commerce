using API.Extentions;
using API.Helpers;
using API.Infrastructure.DataContext;
using API.Middleware;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<StoreContext>();
//ApplicationServiceExtentions
builder.Services.AddApplicationServices();
//AddSwaggerDocumentation
builder.Services.AddSwaggerDocumentation();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddCors(opt =>
{
	opt.AddPolicy("CorsPolicy", policy =>
	{
		policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200");
	});
});

// Add services to the container.
builder.Services.AddDbContext<StoreContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSingleton<IConnectionMultiplexer>(x =>

{
	var configuration =ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"),true);
	return ConnectionMultiplexer.Connect(configuration);

	});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseMiddleware<ExceptionMiddleware>();
//swagger
app.UserSwaggerDocumentation();
app.UseStatusCodePagesWithReExecute("/error/{0}");//hata yönetimi
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
