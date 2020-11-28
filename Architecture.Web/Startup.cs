using Architecture.BLL.Services.Interfaces;
using Architecture.Web.Core;
using Architecture.Web.Models.IdentityModels;
using Architecture.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Architecture.Core.Repository.Context;
using Microsoft.EntityFrameworkCore;
using Architecture.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using NetCore.AutoRegisterDi;
using Architecture.BLL.Services.Implements;
using Architecture.Core.Repository.Implements;
using Architecture.Core.Repository.Interfaces;
using System;
using Microsoft.AspNetCore.Identity.UI.Services;
using Architecture.BLL.Services.Notification;
using Serilog;
using System.IO;
using System.Diagnostics;
using Architecture.BLL.Services.Interfaces.ClientProfile;
using Architecture.BLL.Services.Implements.ClientProfile;

namespace Architecture.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(Configuration)
                .Enrich.FromLogContext()
                .WriteTo.File($@"{Directory.GetCurrentDirectory()}\log\log.txt", rollingInterval: RollingInterval.Day)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}")
                .CreateLogger();


            Serilog.Debugging.SelfLog.Enable(msg => Debug.WriteLine(msg));

            services.AddControllers().AddNewtonsoftJson();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<PhotoSettings>(Configuration.GetSection("PhotoSettings"));

            //http://ajitgoel.net/send-emails-using-sendgrid-email-provider-and-asp-net-core/
            services.Configure<AuthMessageSenderOptions>(options =>
                        Configuration.GetSection("SendGridEmailSettings").Bind(options));

            //https://stackoverflow.com/a/53196846
            services.Configure<DataProtectionTokenProviderOptions>(options => options.TokenLifespan = TimeSpan.FromHours(5));

            services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
            services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
            
            // Add repository and UnitOfWork here
            #region Repository and UnitOfWork
            services.AddScoped<IExampleRepository, ExampleRepository>();
            services.AddScoped<IExampleUnitOfWork, ExampleUnitOfWork>();
           // services.AddScoped<IClientProfileRepository, ClientProfileRepository>();
            #endregion

            services.AddHttpContextAccessor();

            // Add service here
            #region Service
            services.AddTransient<IDateTime, DateTimeService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddTransient<IApplicationUserService, ApplicationUserService>();
            services.AddTransient<IApplicationRoleService, ApplicationRoleService>();
            services.AddTransient<IApplicationUserRoleMappingService, ApplicationUserRoleMappingService>();
            services.AddTransient<IDashboardService, DashboardService>();
            services.AddTransient<IExampleService, ExampleService>();
            services.AddSingleton<IHostedService, NotificationService>();
            services.AddTransient<IFamilyInfoService, FamilyInfoService>();
            services.AddTransient<IEducationInfoService, EducationInfoService>();
            services.AddTransient<IAddressInfoService, AddressInfoService>();
            //services.AddTransient<IClientProfileService, ClientProfileService>();
            services.AddTransient<IBasicInfoService, BasicInfoService>();
            #endregion

            //services.RegisterAssemblyPublicNonGenericClasses(AppDomain.CurrentDomain.GetAssemblies())
            //        .Where(c => c.Name.EndsWith("Repository"))
            //        .AsPublicImplementedInterfaces();

            //services.RegisterAssemblyPublicNonGenericClasses(AppDomain.CurrentDomain.GetAssemblies())
            //        .Where(c => c.Name.EndsWith("UnitOfWork"))
            //        .AsPublicImplementedInterfaces();

            //services.RegisterAssemblyPublicNonGenericClasses(AppDomain.CurrentDomain.GetAssemblies())
            //        .Where(c => c.Name.EndsWith("Service"))
            //        .AsPublicImplementedInterfaces();

            services.AddTransient<IPhotoStorage, FileSystemPhotoStorage>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddMemoryCache();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders()
                .AddClaimsPrincipalFactory<ApplicationClaimsPrincipalFactory>();

            services.Configure<IdentityOptions>(options =>
            {
                // Default Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.Password.RequiredUniqueChars = 0;

                // SignIn settings
                //options.SignIn.RequireConfirmedAccount = true;
            });

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            // configure authentication
            var appSettings = Configuration.GetSection("AppSettings").Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.TokenSecretKey);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddControllersWithViews();

            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                //options.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });
                       

            //Start Notification Service
            //new NotificationService().GetAllAsync();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
             });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";
                //spa.Options.StartupTimeout = new TimeSpan(0, 5, 0);
                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    spa.Options.StartupTimeout = TimeSpan.FromSeconds(1000);
                }
            });
        }
    }
}
