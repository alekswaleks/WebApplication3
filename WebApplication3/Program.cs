using System.Text.Json.Serialization;
using WebApplication3.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

builder.Services.AddHttpClient<MyHttpClient>(c =>
{
    c.BaseAddress = new Uri("http://localhost:5278");
});


var app = builder.Build();


app.UseAuthorization();

app.MapControllers();

app.Run();
