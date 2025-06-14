using Microsoft.EntityFrameworkCore;
using InfrastructureLayer;
using ApplicationLayer.ProductLogic;
using InfrastructureLayer.ProductRepository;
using InfrastructureLayer.InvoiceRepository;
using ApplicationLayer.InvoiceLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ProductOrchestLogic>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<InvoiceOrchestLogic>();
builder.Services.AddScoped<InvoiceHelperLogic>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();

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
