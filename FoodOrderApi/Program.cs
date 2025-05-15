using FoodOrderApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("https://localhost:49850")  // Allow the React app to make requests
              .AllowAnyHeader()                      // Allow any headers
              .AllowAnyMethod();                     // Allow any HTTP method (GET, POST, etc.)
    });
});
builder.Services.AddSingleton<IOrderService, OrderService>();

var app = builder.Build();
app.UseCors("AllowLocalhost");

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
