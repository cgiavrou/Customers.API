using CustomerWebProject.API.DataModels;
using CustomerWebProject.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors( (options) => 
{
    options.AddPolicy("angularApplication", (builder) =>
        {
            builder.WithOrigins("http://localhost:61461")
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELEte")
            .WithExposedHeaders("*");
        });
});

builder.Services.AddControllers();

builder.Services.AddDbContext<CustomerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerWebProjectDB")));

builder.Services.AddScoped<ICustomerRepository, SqlCustomerRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("angularApplication");

app.UseAuthorization();

app.MapControllers();

app.Run();
