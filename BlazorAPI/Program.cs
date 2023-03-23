using Azure.Identity;
using BlazorAPI.Models;
using Microsoft.EntityFrameworkCore;
using MyBackgroundWorkerService;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://blazorapp220230112184211pipes.azurewebsites.net",
                                              "http://www.contoso.com")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                      });
});


builder.Services.AddSingleton<Worker>(); // Register Worker as a singleton
builder.Services.AddHostedService(provider => provider.GetRequiredService<Worker>());


builder.Configuration.AddAzureKeyVault(new Uri($"https://balzorexamplepoevault.vault.azure.net/"), new DefaultAzureCredential());


builder.Services.AddDbContext<PoEDBContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetSection("PoESqlCon").Value));

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

app.UseAuthorization();

app.MapControllers();

app.Run();
