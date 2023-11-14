using AutoMapper;
using DataBase;
using DataBase.Interface;
using DataBase.Repository;
using DataBase.UnitOfWork;
using DTO.AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Services.Interface;
using Services.ServicesRepos;


var builder = WebApplication.CreateBuilder(args);

//Azure Role based Authentication and Authorization
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

//For CORS
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy", policy =>
{
    policy.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins(builder.Configuration["ui_url"]);
}));

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuditOutcomeMasterRepository, AuditOutcomeMasterRepository>();

builder.Services.AddScoped<IAccountDetailsService, AccountDetailsService>();

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


//Services
builder.Services.AddScoped<IEngagementSevice, EngagementService>();
builder.Services.AddScoped<ICommanService, CommanService>();
builder.Services.AddScoped<IAudtiMasterService, AudtiMasterService>();
builder.Services.AddScoped<IAuditOutcomeMasterService, AuditOutcomeMasterService>();




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

app.UseCors(options =>
{
    options.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
});
app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
