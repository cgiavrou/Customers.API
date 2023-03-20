using CustomerWebProject.API.DataModels;
using CustomerWebProject.API.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

/*builder.Services.AddCors( (options) => 
{
    options.AddPolicy("angularApplication", (polbuilder) =>
        {
            polbuilder.WithOrigins("http://localhost:42000")
            .AllowAnyHeader()
            .WithMethods("GET", "POST", "PUT", "DELETE")
            .WithExposedHeaders("*");
        });
});
*/

builder.Services.AddControllers();

builder.Services.AddDbContext<CustomerContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerDataVerseDB")));

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

//app.UseCors("angularApplication");
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();
