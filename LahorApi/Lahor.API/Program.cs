using Lahor.API.Services.AccessManager;
using Lahor.API.Services.ActivityLogger;
using Lahor.API.Services.EnumManager;
using Lahor.API.Services.FileManager;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure;
using Lahor.Infrastructure.Mapper;
using Lahor.Infrastructure.Repositories.ApplicationRolesRepository;
using Lahor.Infrastructure.Repositories.ApplicationUserRolesRepository;
using Lahor.Infrastructure.Repositories.ApplicationUsersRepository;
using Lahor.Infrastructure.Repositories.DeviceBrandRepository;
using Lahor.Infrastructure.Repositories.DeviceRepository;
using Lahor.Infrastructure.Repositories.DeviceTypeRepository;
using Lahor.Infrastructure.Repositories.CitiesRepository;
using Lahor.Infrastructure.Repositories.CountriesRepository;
using Lahor.Infrastructure.Repositories.LevelOfServiceExecutionsRepository;
using Lahor.Infrastructure.Repositories.LogsRepository;
using Lahor.Infrastructure.Repositories.MaterialRepository;
using Lahor.Infrastructure.Repositories.MaterialRequestsRepository;
using Lahor.Infrastructure.Repositories.NewsRepository;
using Lahor.Infrastructure.Repositories.NotificationsRepository;
using Lahor.Infrastructure.Repositories.OrdersRepository;
using Lahor.Infrastructure.Repositories.OrdersServicesLevelsRepository;
using Lahor.Infrastructure.Repositories.PurchaseRequestRepository;
using Lahor.Infrastructure.Repositories.ServicesLevelsPriceRepository;
using Lahor.Infrastructure.Repositories.ServicesRepository;
using Lahor.Infrastructure.Repositories.TypeOfServicesRepository;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.ApplicationRolesService;
using Lahor.Services.ApplicationUserRolesService;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.DeviceBrandService;
using Lahor.Services.DeviceService;
using Lahor.Services.DeviceTypeService;
using Lahor.Services.LdevelOfServiceExecutionsService;
using Lahor.Services.LevelOfServiceExecutionsService;
using Lahor.Services.MaterialRequestsService;
using Lahor.Services.MaterialService;
using Lahor.Services.CitiesService;
using Lahor.Services.CountriesService;
using Lahor.Services.NewsService;
using Lahor.Services.NotificationsService;
using Lahor.Services.OrdersService;
using Lahor.Services.OrdersServicesLevelsService;
using Lahor.Services.PurchaseRequestService;
using Lahor.Services.ReportService;
using Lahor.Services.ServicesService;
using Lahor.Services.TypeOfServicesService;
using Lahor.Shared.Constants;
using Lahor.Shared.LoggedUserData;
using Lahor.Shared.Models;
using Lahor.Shared.Services.Crypto;
using Lahor.Shared.Services.Email;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;
using Lahor.Infrastructure.Repositories.PersonsRepository;
using Microsoft.ReportingServices.Interfaces;
using Lahor.API;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

#region DBContext

builder.Services.AddDbContext<DatabaseContext>(options =>
               options.UseSqlServer(
                   builder.Configuration.GetConnectionString("DefaultConnection")));


#endregion

#region MappingAndValidation

builder.Services.AddScoped<ILoggedUserData, LoggedUserData>();
builder.Services.AddAutoMapper(typeof(Program), typeof(Profiles));

#endregion

#region Api

// Add services to the container.
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddSignalR();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

#endregion

#region CustomServices

builder.Services.AddScoped<IAccessManager, AccessManager>();
builder.Services.AddScoped<IActivityLogger, ActivityLogger>();
builder.Services.AddSingleton<ICrypto, Crypto>();
builder.Services.AddSingleton<IEmail, Email>();
builder.Services.AddScoped<IFileManager, FileManager>();
builder.Services.AddScoped<IEnumManager, EnumManager>();


#endregion

#region Repositories

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILogsRepository, LogsRepository>();
builder.Services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
builder.Services.AddScoped<IApplicationRolesRepository, ApplicationRolesRepository>();
builder.Services.AddScoped<IApplicationUserRolesRepository, ApplicationUserRolesRepository>();
builder.Services.AddScoped<INotificationsRepository, NotificationsRepository>();
builder.Services.AddScoped<IOrdersRepository, OrdersRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IServicesRepository, ServicesRepository>();
builder.Services.AddScoped<ITypeOfServicesRepository, TypeOfServicesRepository>();
builder.Services.AddTransient<IServicesLevelsPriceRepository, ServicesLevelsPriceRepository>();
builder.Services.AddTransient<ILevelOfServiceExecutionsRepository, LevelOfServiceExecutionsRepository>();
builder.Services.AddScoped<IOrdersServicesLevelsRepository, OrdersServicesLevelsRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceBrandRepository, DeviceBrandRepository>();
builder.Services.AddScoped<IDeviceTypeRepository, DeviceTypeRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<IPurchaseRequestRepository, PurchaseRequestRepository>();
builder.Services.AddScoped<IMaterialRequestsRepository, MaterialRequestsRepository>();
builder.Services.AddScoped<IServicesLevelsPriceRepository, ServicesLevelsPriceRepository>();
builder.Services.AddScoped<ILevelOfServiceExecutionsRepository, LevelOfServiceExecutionsRepository>();
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();
builder.Services.AddScoped<ICitiesRepository, CitiesRepository>();
builder.Services.AddScoped<IPersonsRepository, PersonsRepository>();

#endregion

#region Services

builder.Services.AddScoped<IApplicationUsersService, ApplicationUsersService>();
builder.Services.AddScoped<IApplicationUserRolesService, ApplicationUserRolesService>();
builder.Services.AddScoped<IApplicationRolesService, ApplicationRolesService>();
builder.Services.AddScoped<INotificationsService, NotificationsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<ITypeOfServicesService, TypeOfServicesServices>();
builder.Services.AddScoped<ILevelOfServiceExecutionsService, LevelOfServiceExecutionsService>();
builder.Services.AddScoped<IOrdersServicesLevelsService, OrdersServicesLevelsService>();
builder.Services.AddScoped<IDeviceService, DeviceService>();
builder.Services.AddScoped<IDeviceBrandService, DeviceBrandService>();
builder.Services.AddScoped<IDeviceTypeService, DeviceTypeService>();
builder.Services.AddScoped<IMaterialRequestsService, MaterialRequestsService>();
builder.Services.AddScoped<IMaterialService,MaterialService>();
builder.Services.AddScoped<IPurchaseRequestService, PurchaseRequestService>();
builder.Services.AddScoped<ICitiesService, CitiesService>();
builder.Services.AddScoped<ICountriesService, CountriesService>();
builder.Services.AddScoped<IReportService, ReportService>();

#endregion

#region AspNetCoreIdentity

builder.Services.Configure<JWTConfig>(builder.Configuration.GetSection("JWTConfig"));
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = _ => false;
    options.Secure = CookieSecurePolicy.SameAsRequest;
    options.HttpOnly = Microsoft.AspNetCore.CookiePolicy.HttpOnlyPolicy.Always;
});
builder.Services.AddDistributedMemoryCache();

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.Password = new PasswordOptions
    {
        RequireDigit = true,
        RequiredLength = 6,
        RequireLowercase = true,
        RequireUppercase = true,
        RequireNonAlphanumeric = false,
        RequiredUniqueChars = 0
    };
})
.AddEntityFrameworkStores<DatabaseContext>()
.AddDefaultTokenProviders();


builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();

});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
              options =>
              {
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection(ConfigurationValues.TokenKey).Value)),
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true
                  };
              });

#endregion

var app = builder.Build();

#region App

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});
app.UseDeveloperExceptionPage();
//}

app.UseHttpsRedirection();
app.UseSession();
app.UseAuthentication();
app.UseStaticFiles();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials
app.UseAuthorization();

app.MapControllers();
app.MapHub<NotificationsHub>("/hubs/notifications");

await app.RunAsync();
#endregion