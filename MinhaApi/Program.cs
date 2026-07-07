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

// Executa as migrações do banco de dados na inicialização do contêiner
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}


app.UseCors("React");


// Habilita o Swagger em qualquer ambiente para que os recrutadores possam testar os endpoints
app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();


app.Run();