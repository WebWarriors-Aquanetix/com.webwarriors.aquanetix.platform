using WebWarriors.Aquanetix.Platform.Subscription.Domain.Services;
using WebWarriors.Aquanetix.Platform.Subscription.Application.Internal.QueryServices;
using WebWarriors.Aquanetix.Platform.Subscription.Domain.Repositories;
using WebWarriors.Aquanetix.Platform.Subscription.Infrastructure.Persistence.EFC.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<
    ISubscriptionQueryService,
    SubscriptionQueryService>();

//builder.Services.AddScoped<
  //  ISubscriptionRepository,
    //SubscriptionRepository>();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();