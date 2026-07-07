using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gastos.db")
);



builder.Services.AddCors(options =>
{
    options.AddPolicy("React",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});



var app = builder.Build();



app.UseCors("React");


if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();


app.Run();