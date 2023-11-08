using AutoMapper;
using DataBase;
using DataBase.Interface;
using DataBase.Repository;
using DataBase.UnitOfWork;
using DTO.AutoMapper;
using Microsoft.EntityFrameworkCore;
using Services.Interface;
using Services.ServicesRepos;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Repos:
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IEngagementRepository, EngagementRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IAudtiMasterRepository, AudtiMasterRepository>();
builder.Services.AddScoped<IEmailService, EmailServices>();
builder.Services.AddScoped<IAuditReportService, AuditReportService>();
builder.Services.AddScoped<IFileRepository, FileRepository>();
builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


//Services
builder.Services.AddScoped<IEngagementSevice, EngagementService>();
builder.Services.AddScoped<ICommanService, CommanService>();
builder.Services.AddScoped<IAudtiMasterService, AudtiMasterService>();




// SQL Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(x => x.UseSqlServer(connectionString));

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
