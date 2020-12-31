using AutoMapper;
using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PTSchool.Data;
using PTSchool.Data.Models;
using PTSchool.Services;
using PTSchool.Services.Contracts;
using PTSchool.Web.ConfigurationMapper;
using PTSchool.Web.Hubs;
using PTSchool.Web.Middlewares;
using System;
using System.Security.Claims;

namespace PTSchool.Web
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
            // PT: CACHE (IN-MEMORY CACHING) (step 1)
            services.AddMemoryCache();

            // PT: CACHE (DISTRIBUTED CACHING - SQLSERVER) (step 1) + (step 2)
            // PT: NuGet => Install => Microsoft.Extensions.Caching.SqlServer.
            services.AddDistributedSqlServerCache(options =>
            {
                options.ConnectionString = this.Configuration.GetConnectionString("DefaultConnection");
                options.SchemaName = "dbo";
                options.TableName = "CacheRecords";
            });

            // PT: COOKIES (step 1)
            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            // PT: SESSION / COOKIES (step 1 - DISTRIBUTED CACHING NEEDED) + (step 2)
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(2);
                options.Cookie.HttpOnly = true; // so that JavaScript doesn't see the cookie (XSS security?).
                options.Cookie.IsEssential = true;
            });

            // PT: CACHE (RESPONSE CACHING - RECOMMENDED TO BROWSER) (step 1):
            //services.AddResponseCaching();


            // PT: SIGNALR (step 1) + (step 2)       
            // PT: NuGet => Install => Microsoft.AspNetCore.SignalR.Protocols.MessagePack.
            // PT: .AddMessagePackProtocol() makes the App work with MessagePack, not JSON.
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            }).AddMessagePackProtocol();

            // PT: ADD CROSS-ORIGIN RESOURCE SHARING /CORS/ (1)
            services.AddCors();

            // PT: COMPRESSION (ZIPPING TO TRANSFER DATA) (step 1)
            services.AddResponseCompression(option =>
            {
                option.EnableForHttps = true;
            });

            services.AddDbContext<PTSchoolDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IParentService, ParentService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITeacherService, TeacherService>();
            services.AddTransient<ISubjectService, SubjectService>();
            services.AddTransient<IClassService, ClassService>();
            services.AddTransient<IClubService, ClubService>();
            services.AddTransient<IMarkService, MarkService>();
            services.AddTransient<INoteService, NoteService>();
            services.AddTransient<ITictactoeService, TictactoeService>();
            services.AddTransient<IHomeService, HomeService>();

            services.AddHangfire(configuration =>
            {
                configuration.UseSqlServerStorage(Configuration.GetConnectionString("HangfireConnection"));
            });

            // PT: USE WEB SOCKETS! (2)
            services.AddHttpContextAccessor();

            // PT: OBLIGATORY FOR Authentication/Authorization processes...
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //.AddEntityFrameworkStores<PTSchoolDbContext>(); //Default.

            services.AddDefaultIdentity<User>(options =>
            {
                options.SignIn.RequireConfirmedAccount = true; //Default.

                // PT: Settings, additionally set, that are valid throughout the whole application!
                //options.SignIn.RequireConfirmedEmail = true;
                //options.SignIn.RequireConfirmedPhoneNumber = true;
                options.Lockout.AllowedForNewUsers = true;
                options.Lockout.DefaultLockoutTimeSpan = new TimeSpan(0, 10, 0); //Default is 5 minutes, now it is set to 0 hours, 10 minutes, 0 seconds.
                options.Lockout.MaxFailedAccessAttempts = 3; //Default is 5.
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 1; //Default is 1.
            })
            .AddRoles<Role>()
            .AddUserManager<UserManager<User>>()
            .AddEntityFrameworkStores<PTSchoolDbContext>();

            // PT: Add Authentication FACEBOOK! LOG-IN!: 
            //services.AddAuthentication()
            //    .AddFacebook(facebookOptions =>
            //    {
            //        facebookOptions.AppId = Configuration["Authentication:Facebook:"];
            //        facebookOptions.AppSecret = Configuration["Authentication:Facebook:"];
            //    });

            // PT: Add Authorization Policy Attribute => BULGARIANS ONLY!
            services.AddAuthorization(options =>
            options.AddPolicy("BulgariansOnly", policy =>
            policy.RequireClaim(ClaimTypes.Country, "Bulgaria")));


            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation();
            // PT: Identity
            services.AddRazorPages();

            services.AddAutoMapper(cfg => cfg.AddProfile<PTSchoolProfile>());

            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PTSchool.Web", Version = "v1" });
                //options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline (middlewares).
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IHomeService homeService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // PT: CACHE (RESPONSE CACHING - RECOMMENDED TO BROWSER) (step 2)
            //app.UseResponseCaching();

            // PT: WEB SOCKETS (step 1)
            // NB: WEB SOCKETS = Computer communication protocol providing full-duplex (2-way) communication channels over a single TCP connection.
            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024,
            });

            // PT: COMPRESSION (ZIPPING TO TRANSFER DATA) (step 2)
            app.UseResponseCompression();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PTSchool.Web");
            });

            // PT: ADD CROSS-ORIGIN RESOURCE SHARING /CORS/ (2)
            //app.UseCors(builder => builder.WithOrigins("https://ptschool.com"));

            // PT: COOKIES (step 2)
            app.UseCookiePolicy();

            // PT: SESSION / COOKIES (step 3)
            app.UseSession();

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // NB: Authentication = Who are you? Authorization = What are you allowed to do?            
            // NB: These 2 middlewares are included by default. They are necessary for Authentication and Authorization processes.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireServer();
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate(() => homeService.UpdateNewsLocalDb(), "59 4 * * *"); // minute hourUtc * * *, a.k.a. CRON

            app.UseEndpoints(endpoints =>
            {
                // PT: SIGNALR (step 2)
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<PlayHub>("/playhubbb");
                endpoints.MapHub<CanvasHub>("/canvashub");

                // PT: AREAS (step 1 - register Areas Controller Route)
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                // PT: DEFAULT
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // PT: Identity
                endpoints.MapRazorPages();
            });
        }
    }
}