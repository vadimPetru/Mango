using AutoMapper;
using Mango.Services.CouponApi.Data;
using Mango.Services.CouponApi.MIdlware;
using Mango.Services.CouponApi.Repository.Implementation;
using Mango.Services.CouponApi.Repository.Interface;
using Mango.Services.CouponApi.Utils;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add DbCOntext in services
builder.Services.AddDbContext<AppDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ICouponRepository, CouponRepository>();
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
app.UseMiddleware<ApplyMigrationMiddleware>();
app.MapControllers();

app.Run();
