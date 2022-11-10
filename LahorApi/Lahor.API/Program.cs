using Lahor.API.Services.ActivityLogger;
using Lahor.API.Services.FileManager;
using Lahor.API.Services.UserManager;
using Lahor.Core.Entities.Identity;
using Lahor.Infrastructure;
using Lahor.Infrastructure.Mapper;
using Lahor.Infrastructure.Repositories.ApplicationUserRolesRepository;
using Lahor.Infrastructure.Repositories.ApplicationUsersRepository;
using Lahor.Infrastructure.Repositories.LevelOfServiceExecutionsRepository;
using Lahor.Infrastructure.Repositories.LogsRepository;
using Lahor.Infrastructure.Repositories.NewsRepository;
using Lahor.Infrastructure.Repositories.NotesRepository;
using Lahor.Infrastructure.Repositories.OrdersRepository;
using Lahor.Infrastructure.Repositories.ServicesLevelsPriceRepository;
using Lahor.Infrastructure.Repositories.ServicesRepository;
using Lahor.Infrastructure.Repositories.TypeOfServicesRepository;
using Lahor.Infrastructure.UnitOfWork;
using Lahor.Services.ApplicationUserRolesService;
using Lahor.Services.ApplicationUsersService;
using Lahor.Services.NewsService;
using Lahor.Services.NotesServices;
using Lahor.Services.OrdersService;
using Lahor.Services.ServicesService;
using Lahor.Services.TypeOfServicesService;
using Lahor.Shared.LoggedUserData;
using Lahor.Shared.Models;
using Lahor.Shared.Services.Crypto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
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
builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

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

#endregion

#region Services

builder.Services.AddScoped<IApplicationUsersService, ApplicationUsersService>();
builder.Services.AddScoped<IApplicationUserRolesService, ApplicationUserRolesService>();
builder.Services.AddScoped<INotesService, NotesService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IServicesService, ServicesService>();
builder.Services.AddScoped<ITypeOfServicesService, TypeOfServicesServices>();

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
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"Resources")),
    RequestPath = new PathString("/Resources")
});

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