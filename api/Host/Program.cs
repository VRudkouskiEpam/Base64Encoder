using Host.Extensions;
using Host.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSignalR();

builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapHub<EncoderHub>("/hubs/encode");

app.UseCors(policyBuilder => 
    policyBuilder
        .WithOrigins(app.Configuration.GetValue<string>("FrontendUrl")!)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

app.Run();
