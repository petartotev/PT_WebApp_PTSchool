using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PTSchool.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PTSchool.Web.Controllers
{
    //// PT: [Authorize] <-> using Microsoft.AspNetCore.Authorization; 
    //// PT: [Authorize] onto CONTROLLER works on all the ACTIONS the Controller has.
    //// PT: If you want to exclude an ACTION from being [Authorize], please use [AllowAnonymous] attribute.
    //// PT: If a USER tries to access /Controller/Action without being logged-in - the application automatically transfers him to the log-in page, saving the link to the last action:
    //// PT: localhost:44301/Identity/Account/Login?ReturnUrl=%2FController%2FAction
    
    [Authorize]
    public class TestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        //// PT: ROLES? => Dependency Inject RoleManager<IdentityRole> roleManager
        public TestController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [Authorize(Policy = "BulgariansOnly")]
        public IActionResult Testify()
        {
            return this.View();
        }

        //// PT: ROLES? => SET A VIEW ACCESSIBLE ONLY FOR ROLE "ADMIN"
        //[Authorize(Roles = "Admin")]
        [Authorize(Roles = "Admin, Owner")]
        public IActionResult Adminize()
        {
            return this.View();
        }


        //// PT: CLAIM => ADD CLAIM TO THIS.USER
        public async Task<IActionResult> AddClaimToUser()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var result = await userManager.AddClaimAsync(user, new System.Security.Claims.Claim(ClaimTypes.Country, "Bulgaria"));
            return this.Json(result);
        }

        //// PT: ROLES? => SET A NEW ROLE "ADMIN" AND ADD IT TO USER
        [AllowAnonymous]
        public async Task<IActionResult> AddRoleAdmin()
        {
            //// PT: Check if this.User is "Admin":
            var isUserAdmin = this.User.IsInRole("Admin");
            var result = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Admin"
            });
            var user = await this.userManager.GetUserAsync(this.User);
            await userManager.AddToRoleAsync(user, "Admin");
            return this.Json(result);
        }
        
        //// PT: ROLES? => SET A NEW ROLE "PARENT" AND ADD IT TO USER
        public async Task<IActionResult> AddRoleParent()
        {
            var result = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Parent"
            });
            var user = await this.userManager.GetUserAsync(this.User);
            await userManager.AddToRoleAsync(user, "Parent");
            return this.Json(result);
        }

        //// PT: ROLES? => SET A NEW ROLE "TEACHER" AND ADD IT TO USER
        public async Task<IActionResult> AddRoleTeacher()
        {
            var result = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Teacher"
            });
            var user = await this.userManager.GetUserAsync(this.User);
            await userManager.AddToRoleAsync(user, "Teacher");
            return this.Json(result);
        }

        //// PT: ROLES? => SET A NEW ROLE "STUDENT" AND ADD IT TO USER
        public async Task<IActionResult> AddRoleStudent()
        {
            var result = await roleManager.CreateAsync(new IdentityRole
            {
                Name = "Student"
            });
            var user = await this.userManager.GetUserAsync(this.User);
            await userManager.AddToRoleAsync(user, "Student");
            return this.Json(result);
        }

        //// PT: This ACTION returns a Json with the whole information of the logged-in-USER.
        //public async Task<IActionResult> WhoAmI2()
        //{
        //    var user = await this.userManager.GetUserAsync(this.User);
        //    return this.Json(user);
        //}


        //// PT: CHECK-USER-IDENTITY
        //public IActionResult WhoAmI()
        //{
        //    if (!this.User.Identity.IsAuthenticated)
        //    {
        //        return this.BadRequest(); //Status: 400
        //    }
        //    else
        //    {
        //        return this.Ok(this.User.Identity.Name);
        //    }
        //}


        //// PT: PASSWORD-SIGN-IN
        //public async Task<IActionResult> Testify()
        //{
        //    //this.signInManager.SignOutAsync() / this.signInManager.SignInAsync() / 
        //    var result = await this.signInManager.PasswordSignInAsync("Abcde1@abv.bg", "Abcde1@", true, true);
        //    return this.Json(result);
        //}


        //// PT: CREATE NEW USER AND RETURN JSON WITH INFORMATION ABOUT RESULT.    
        //public async Task<IActionResult> Testify()
        //{                    
        //    var result = await this.userManager.CreateAsync(new IdentityUser
        //    {
        //        Email = "test@softuni.bg",
        //        UserName = "test@softuni.bg",
        //        EmailConfirmed = true,
        //        PhoneNumber = "0888123456",
        //    }, "Abc123.");
        //    return this.Json(result);
        //}
    }
}
