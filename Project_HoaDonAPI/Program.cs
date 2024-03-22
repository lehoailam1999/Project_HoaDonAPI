using Project_HoaDonAPI.Payloads.Converters;
using Project_HoaDonAPI.Payloads.DataResponse;
using Project_HoaDonAPI.Payloads.Response;
using Project_HoaDonAPI.Service.Implement;
using Project_HoaDonAPI.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPhotoServices, PhotoService>();

builder.Services.AddScoped<IHoaDonService, HoaDonService>();
builder.Services.AddSingleton<HoaDonConverter>();
builder.Services.AddSingleton<ResponseObject<DataResponseHoaDon>>();
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
