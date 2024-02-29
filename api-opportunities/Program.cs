using api_opportunities.Data;
using api_opportunities.Models.Opportunities;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost3000",
        builderO =>
        {
            builderO.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowLocalhost3000");

app.UseHttpsRedirection();
OpportunitiesEndpoints.AddEndPoints(app);

// Criando database:
{
    var scope = app.Services.CreateScope();
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.Run();
