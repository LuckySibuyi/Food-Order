using FoodOrderApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost", policy =>
    {
        policy.WithOrigins("http://localhost:49850")
              .AllowAnyHeader()
              .AllowAnyMethod();
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
