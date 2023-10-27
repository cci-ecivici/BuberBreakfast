using BuberBreakfast.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IBreakfastService, breakfastService>();

var app = builder.Build();
{

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();  
}



