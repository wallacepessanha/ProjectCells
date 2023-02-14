using PCE.Cells.Domain.Contracts.Repositories;
using PCE.Cells.Domain.Contracts.Services;
using PCE.Cells.Domain.Services;
using PCE.Cells.Infra.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IServiceCell, ServiceCell>();
builder.Services.AddScoped<IRepositoryCell, RepositoryCell>(_ =>
{
    return new RepositoryCell(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
