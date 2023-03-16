using Lahor.API.Services.ActivityLogger;
using Lahor.API.Services.FileManager;
using Lahor.API.Services.UserManager;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure;
using Lahor.Infrastructure.Mapper;
using Lahor.Infrastructure.Repositories.ApplicationUserRolesRepository;
using Lahor.Infrastructure.Repositories.ApplicationUsersRepository;
using Lahor.Infrastructure.Repositories.DeviceBrandRepository;
using Lahor.Infrastructure.Repositories.DeviceRepository;
using Lahor.Infrastructure.Repositories.DeviceTypeRepository;
using Lahor.Infrastructure.Repositories.LevelOfServiceExecutionsRepository;
using Lahor.Infrastructure.Repositories.LogsRepository;
using Lahor.Infrastructure.Repositories.MaterialRepository;
using Lahor.Infrastructure.Repositories.MaterialRequestsRepository;
using Lahor.Infrastructure.Repositories.NewsRepository;
using Lahor.Infrastructure.Repositories.NotesRepository;
using Lahor.Infrastructure.Repositories.OrdersRepository;
using Lahor.Infrastructure.Repositories.OrdersServicesLevelsRepository;
using Lahor.Infrastructure.Repositories.PurchaseRequestRepository;
using Lahor.Infrastructure.Repositories.ServicesLevelsPriceRepository;
using Lahor.Infrastructure.Repositories.ServicesRepository;
using Lahor.Infrastructure.Repositories.TypeOfServicesRepository;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.ApplicationUserRolesService;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.DeviceBrandService;
using Lahor.Services.DeviceService;
using Lahor.Services.DeviceTypeService;
using Lahor.Services.LdevelOfServiceExecutionsService;
using Lahor.Services.LevelOfServiceExecutionsService;
using Lahor.Services.MaterialRequestsService;
using Lahor.Services.MaterialService;
using Lahor.Services.NewsService;
using Lahor.Services.NotesServices;
using Lahor.Services.OrdersService;
using Lahor.Services.OrdersServicesLevelsService;
using Lahor.Services.PurchaseRequestService;
using Lahor.Services.ServicesService;
using Lahor.Services.TypeOfServicesService;
using Lahor.Shared.LoggedUserData;
using Lahor.Shared.Models;
using Lahor.Shared.Services.Crypto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region CustomServices

builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddScoped<IActivityLogger, ActivityLogger>();
builder.Services.AddSingleton<ICrypto, Crypto>();
builder.Services.AddScoped<IFileManager, FileManager>();


#endregion

#region Repositories

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ILogsRepository, LogsRepository>();
builder.Services.AddScoped<IApplicationUsersRepository, ApplicationUsersRepository>();
builder.Services.AddScoped<IApplicationUserRolesRepository, ApplicationUserRolesRepository>();
builder.Services.AddScoped<INotesRepository, NotesRepository>();
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

#endregion

#region Services

builder.Services.AddScoped<IApplicationUsersService, ApplicationUsersService>();
builder.Services.AddScoped<IApplicationUserRolesService, ApplicationUserRolesService>();
builder.Services.AddScoped<INotesService, NotesService>();
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


builder.Services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromMinutes(30));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new PathString("/access/sigin");
            options.LogoutPath = new PathString("/access/signOut");
            options.AccessDeniedPath = new PathString("/error/403");
        });

builder.Services.Configure<AuthenticationOptions>(options =>
{
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(
              options =>
              {
                  var key = Encoding.ASCII.GetBytes(builder.Configuration["JWTConfig:Key"]);
                  var issuer = builder.Configuration["JWTConfig:Issuer"];
                  var audience = builder.Configuration["JWTConfig:Audience"];
                  options.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidateIssuerSigningKey = true,
                      IssuerSigningKey = new SymmetricSecurityKey(key),
                      ValidateIssuer = true,
                      ValidateAudience = true,
                      RequireExpirationTime = true,
                      ValidIssuer = issuer,
                      ValidAudience = audience
                  };
              });

#endregion

var app = builder.Build();

#region App

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseAuthentication();

// global cors policy
app.UseCors(x => x
    .AllowAnyMethod()
    .AllowAnyHeader()
    .SetIsOriginAllowed(origin => true) // allow any origin
                                        //.WithOrigins("https://localhost:44351")); // Allow only this origin can also have multiple origins separated with comma
    .AllowCredentials()); // allow credentials
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
#endregion