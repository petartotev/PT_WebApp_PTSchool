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
            // PT: CACHE (IN-MEMORY CACHING):
            services.AddMemoryCache();

            // PT: CACHE (DISTRIBUTED CACHING - SQLSERVER):
            // PT: NuGet => Install => Microsoft.Extensions.Caching.SqlServer. (step 1)
            //services.AddDistributedSqlServerCache(options =>
            //{
            //    options.ConnectionString = this.Configuration.GetConnectionString("DefaultConnection");
            //    options.SchemaName = "dbo";
            //    options.TableName = "CacheRecords";
            //});

            // PT: CACHE (RESPONSE CACHING - RECOMMENDED TO BROWSER) (step 1):
            //services.AddResponseCaching();

            // PT: ADD SIGNALR (1)            
            // PT: 1) NuGet => Install => Microsoft.AspNetCore.SignalR.Protocols.MessagePack.
            // PT: 2) .AddMessagePackProtocol() makes the App work with MessagePack, not JSON.
            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            }).AddMessagePackProtocol();

            // PT: ADD SESSION!
            // PT: USE COOKIES! (2)
            services.AddSession(options =>
            {
                //options.IdleTimeout = TimeSpan.FromDays(2);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // PT: ADD CROSS-ORIGIN RESOURCE SHARING /CORS/ (1)
            services.AddCors();

            // PT: USE COMPRESSION! (ZIPPING) TO TRANSFER DATA
            // PT: USE IN COMBINATION WITH app.UseResponseCompression();
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

            // PT: USE COOKIES (3)
            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();

            services.AddAutoMapper(cfg => cfg.AddProfile<PTSchoolProfile>());

            services.AddSwaggerGen((options) =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "PTSchool.Web", Version = "v1" });
                //options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // PT: MIDDLEWARES!
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

            // PT: USE WEB SOCKETS! (1) (Computer communication protocol that provides full-duplex (two-way) communication channels, which are provided over a single TCP connection.
            app.UseWebSockets(new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
                ReceiveBufferSize = 4 * 1024,
            });

            // PT: USE COMPRESSION (ZIPPING) TO TRANSFER DATA!
            // PT: USE IN COMBINATION WITH services.AddResponseCompression(option => { option.EnableForHttps = true; });
            //app.UseResponseCompression();

            // PT: CACHE (RESPONSE CACHING - RECOMMENDED TO BROWSER) (step 2)
            //app.UseResponseCaching();
            //app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "PTSchool.Web");
            });

            // PT: USE COOKIES! (1)
            //app.UseCookiePolicy();

            // PT: ADD CROSS-ORIGIN RESOURCE SHARING /CORS/ (2)
            //app.UseCors(builder => builder.WithOrigins("https://mvcschool.com"));

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // PT: Authentication = The process of verifying the identity of a user or computer. Question = Who are you?
            // PT: Authorization = The process of determining what a user is permitted to do on a computer or network. Question = What are you allowed to do?            
            // PT: The 2 following MIDDLEWARES ARE OBLIGATORY FOR Authentication/Authorization processes... By defaul they are here.
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHangfireServer();
            app.UseHangfireDashboard();
            RecurringJob.AddOrUpdate(() => homeService.UpdateNewsLocalDb(), "59 4 * * *"); // minute hourUtc * * *, a.k.a. CRON

            app.UseEndpoints(endpoints =>
            {
                // PT: CREATE NEW AREAS:
                // PT: 1. Areas(Folder) -> r.cl. -> Add -> |Area...| -> ADMIN...
                // PT: 2.2. Put Attribute [Area("Admin")]
                // PT: 2.1. Create Controller -> DashboardController : Controller
                // PT: 2.3. Create new Action Index() => return this.View()
                // PT: 3. Create new View(Folder) -> Dashboard(Folder) -> Index.cshtml(View)
                // PT: 4. Put the next 3 lines here:
                //endpoints.MapControllerRoute(
                //    "areaRoute",
                //    "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                // PT: 5. Copy the 2 files from Projects' Views(Folder) - _ViewImports.cshtml, _ViewStart.cshtml  
                // PT: 6. Paste the 2 files here: Areas(Folder) -> Admin(Folder) -> Views(Folder)
                // PT: 7. Now you can access it here: https://localhost:5001/Admin/Dashboard/Index/1
                // PT: ADD SIGNALR (2)
                endpoints.MapHub<ChatHub>("/chat");
                endpoints.MapHub<PlayHub>("/playhubbb");
                endpoints.MapHub<CanvasHub>("/canvashub");
                // PT: BY DEFAULT:
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}