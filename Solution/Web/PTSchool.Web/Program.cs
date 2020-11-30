using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace PTSchool.Web
{
    public class Program
    {
        //PT: Run IIS or Run Console (MvcSchool.Web)
        public static void Main(string[] args)
        {
            //PT: Console.WriteLine("Hello, World!");

            CreateHostBuilder(args).Build().Run();

            //PT: Console.WriteLine("Goodbye, World!");
        }

        //PT: WebHost is responsible for app startup and lifetime management. At minimum, the host configures a server and request pipeline.
        //PT: WebHost is the ENTRY-POINT of this WebApp!
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

//PT: DEFAULT PROGRAM.CS

//namespace WebApplication1
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            CreateHostBuilder(args).Build().Run();
//        }

//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}



//PT: 1. appsettings.json => CHANGE "DefaultConnection": "Server=PT\\SQLEXPRESS;Database=MvcSchoolAuthentication;Trusted_Connection=True;MultipleActiveResultSets=true" ADD_PATH, ADD_DATABASE_NAME.
//PT: 2. BUILD, RUN => Register => Apply Migrations => Refresh => Go and check your new DATABASE in SQL SERVER.

//PT: TestController.cs CONTROLLER created!
//PT: Views/Test/Testify.cshtml VIEW created!

//PT: USE AUTHORIZATION:
//PT: [Authorize] on Controller, [AllowAnonymous] on View that you want to make exception for.
//PT: using Microsoft.AspNetCore.Authorization; 

//PT: ADD ROLE TO USER:
//PT: 1. Dependency Inject RoleManager<IdentityRole> roleManager into public Controller(CTOR).
//PT: 2.1. Go to Startup.cs, find public void ConfigureServices(IServiceCollection services), services.AddDefaultIdentity<IdentityUser>(options =>.
//PT: 2.2. Add this: .AddRoles<IdentityRole>() above this: .AddEntityFrameworkStores<ApplicationDbContext>();
//PT: Controller -> Action ->
//PT: public async Task<IActionResult> Testify()
//PT: {
//PT:     var result = await roleManager.CreateAsync(new IdentityRole
//PT:     {
//PT:         Name = "Admin"
//PT:     });
//PT:     var user = await this.userManager.GetUserAsync(this.User);
//PT:     await userManager.AddToRoleAsync(user, "Admin");
//PT:     return this.Json(result);
//PT: }

//PT: ADD FACEBOOK LOG-IN:
//PT: Manage NuGet Packages... => INSTALL: Microsoft.AppNetCore.Authentication.Facebook
//PT: Go to Startup.cs => public void ConfigureServices => 
//PT: services.AddAuthentication()
//PT:                 .AddFacebook(facebookOptions =>
//PT:                 {
//PT:     facebookOptions.AppId = Configuration["Authentication:Facebook:AppId"];
//PT:     facebookOptions.AppSecret = Configuration["Authentication:Facebook:AppSecret"];
//PT: });

//PT: CHANGE LOG-IN TEMPLATE PAGES (REGISTER/LOG-IN/LOG-OUT)
//PT: Project -> mouse right click -> Add -> NewScaffoldedItem... -> Choose Identity -> Choose Identity -> Add -> Choose ApplicationDbContext from DropDownMenu -> Add

//PT: CHANGE USER SETTINGS:
//PT: 1. Data -> ApplicationUser.cs / Create new CLASS ApplicationUser : IdentityUser with the new PROPERTIES
//PT: 2. ApplicationDbContext.cs => : IdentityDbContext<ApplicationUser> / Add <ApplicationUser>
//PT: 3. Add-Migration, Update-Database
//PT: 4. Change "IdentityUser" to "ApplicationUser" EVERYWHERE but in the ApplicationUser.cs!
//PT: 5.1. Areas->Identity->Pages->Account->Register.cshtml->Register.cshtml.cs =>
//PT: Add [Required] public string FirstName {get; set; }, [Required] public string LastName {get; set; } to 
//PT: 5.2. Areas->Identity->Pages->Account->Register.cshtml->Register.cshtml.cs =>
//PT: var user = new MvcSchool.Web.Data.ApplicationUser { UserName = Input.Email, Email = Input.Email, FirstName = Input.FirstName, LastName = Input.LastName};
//PT: 5.3. Areas->Identity->Pages->Account->Register.cshtml =>
//PT: <div class="form-group">
//PT:     <label asp-for="Input.FirstName"></label>
//PT:     <input asp-for="Input.FirstName" class="form-control" />
//PT:     <span asp-validation-for="Input.FirstName" class="text-danger"></span>
//PT: </div>

//PT: ADD SERVICE-MODEL -> SERVICE -> 
//PT: 1. Add Services.Models.StudentCouncilMembersListingServiceModel;
//PT: 2. Add Services.IStudentCouncilService;
//PT: 3. Add Services.Implemenetations.StudentCouncilService : IStudentCouncilService;
//PT: 4. New Controller(Inject IInterfaceService)
//PT: 5. Startup.cs => services.AddDbContext<MvcSchoolDbContext>();
//PT: 6. Startup.cs => services.AddTransient<IStudentCouncilService, StudentCouncilService>();

//PT: IThisService All(int page = 1)

//PT: INSTALL AUTOMAPPER -> ASP.NET CORE
//PT: Install package: AutoMapper.Extensions.Microsoft.DependencyInjection (this will also install the main AutoMapper NuGet package)

//PT: 2020-05-22_14_ADVANCED_TOPICS_WEB_HOST
//PT: IIS vs Kestrel/Console Web App Run => settings of these 2 options can be found in MvcSchool.Web -> Properties -> launchSettings.json

//PT: 2020-05-22_14_ADVANCED_TOPICS_LOGGING
//PT: 2020-05-22_14_ADVANCED_TOPICS_CACHE
//PT: 2020-05-22_14_ADVANCED_TOPICS_SESSIONS
//PT: 2020-05-22_14_ADVANCED_TOPICS_TEMP_DATA
//PT: 2020-05-22_14_ADVANCED_TOPICS_AREAS
//PT: 2020-05-22_14_ADVANCED_TOPICS_PERFORMANCE
//PT: 2020-05-22_14_ADVANCED_TOPICS_SEO
//PT: 2020-05-22_14_ADVANCED_TOPICS_GDPR



//PT: SIGNALR
//PT: 0000. NuGet => Install => jQuery?
//PT: 000. NuGet => Install => Microsoft.AspNetCore.SignalR.Protocols.MessagePack
//PT: 00. Startup.cs => ConfigureServices() => services.AddSignalR(options => { options.EnableDetailedErrors = true; }).AddMessagePackProtocol();
//PT: 0. Startup.cs => Configure() => app.UseEndPoints(endpoints => { endpoints.MapHub<ChatHub>("/chat"); }
//PT: 1. Project => r.click => |Add| => |Client-Side Library...| => Provider: unpkg, @microsoft/signalr@3.1.3, Choose specific files: Files -> dist -> browser -> signalr.js, signalr.min.js
//PT: 2. Project => libman.json?
//PT: 3. _Layout.cshtml => <script src="~/lib/microsoft/signalr/dist/browser/signalr.min.js" asp-append-version="true"></script> </body> </html>
//PT: 4. Create new folder Project/Hubs
//PT: 5. Create new controller [Authorize] ChatHub : Hub
//public async Task Send(string message)
//{
//    await this.Clients.All.SendAsync(
//        "NewMessage",
//        new Message { User = this.Context.User.Identity.Name, Text = message, });
//}
//PT: 6. Create new folder Project/Models/Chat/
//PT: 7. Create new Message.cs => Properties: string User {get; set;}, string Message {get;set;}
//PT: 8. HomeController => Chat() => return this.View().
//PT: 9. Project/Views/Home/Chat.cshtml
//PT: 10. Copy content for Chat.cshtml from here:

//@{
//    this.ViewBag.Title = "Chat";
//}

//<h1>@this.ViewBag.Title</h1>

//<div class="container">
//    <div id = "message-holder" class="mt-3 d-flex justify-content-start">
//        <h4>Message</h4>
//        <input class="w-75 ml-4 pl-3" type="text" id="messageInput" placeholder="Message..." />
//        <button id = "sendButton" class="ml-4 btn btn-dark btn-lg">Send</button>
//    </div>
//    <hr style = "height: 5px;" class="bg-dark" />
//    <div id = "messagesList" style="font-size: 28px;">
//    </div>
//</div>

//@section Scripts
//{
//<script>
//    var connection =
//        new signalR.HubConnectionBuilder()
//            .withUrl("/chat")
//            .build();

//connection.on("NewMessage",
//        function(message)
//{
//    var chatInfo = `< div >[${ message.user}] ${ escapeHtml(message.text)}</ div >`;
//            $("#messagesList").append(chatInfo);
//});

//    $("#sendButton").click(function() {
//    var message = $("#messageInput").val();
//    connection.invoke("Send", message);
//});

//    connection.start().catch(function (err) {
//        return console.error(err.toString());        
//    });

//    //PT: To escape HTML injection in chat:
//    function escapeHtml(unsafe) {
//        return unsafe
//            .replace(/&/g, "&amp;")
//            .replace(/</g, "&lt;")
//            .replace(/>/g, "&gt;")
//            .replace(/"/g, "&quot;")
//            .replace(/'/g, "&#039;");
//    }
//</script>
//}