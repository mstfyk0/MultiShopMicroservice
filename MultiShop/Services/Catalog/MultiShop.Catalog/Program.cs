
using MultiShop.Catalog.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

//burasý extension sýnýfýna taþýndý.
builder.Services.ConfigureAuthentication(builder.Configuration);


//burasý serivce extension sýnýfýna taþýndý.
builder.Services.ConfigureDatabaseSettings(builder.Configuration);  

// Add services to the container.
//Burasý extension sýnýfa taþýndý.
builder.Services.ConfigureServiceRegistration();


//Automapper 13 versiyon ve dependencyinjection 12.0 versyionu ile programcs e register yapmaya gerek kalmýor.
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
