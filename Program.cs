using Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();

builder.Services.AddControllers();

builder.Services.AddDbContext<CareerContext>();

builder.Services.AddEndpointsApiExplorer();

//TODO: replace with real origin before prod
// var allowedOrigins = "localhost";
// builder.Services.AddCors(options =>
//     options.AddPolicy(name: allowedOrigins,
//     policy =>
//     {
//         policy.WithOrigins("https://localhost");
//     })
// );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

// app.UseHttpsRedirection();

app.MapControllers();

// app.UseCors(allowedOrigins);

app.Run();
