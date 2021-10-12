using Appoinment_Schedule.Models;
using Appoinment_Schedule.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Appoinment_Schedule.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;

        UserManager<ApplicationUser> _UserManager;
        SignInManager<ApplicationUser> _SignInManager;

        RoleManager<IdentityRole> _RoleManager;

        public AccountController(ApplicationDbContext dbcontext, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> RoleManager, SignInManager<ApplicationUser> SignInManager)
        {
          _db = dbcontext;

            _UserManager = userManager; 
            _SignInManager = SignInManager;
            _RoleManager = RoleManager;
        }
        public IActionResult Login()
        {
         
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>   Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);


                if (result.Succeeded)
                {

                  
                    return RedirectToAction("index", "Appointment");
                }
                ModelState.AddModelError("","invalid login attempt");
            }
            return View(model);
        }
        public async Task<IActionResult> Register()
        {
            if(!_RoleManager.RoleExistsAsync(Utility.Helper.admin).GetAwaiter().GetResult())
            {
              await   _RoleManager.CreateAsync(new IdentityRole(Utility.Helper.admin));
                await _RoleManager.CreateAsync(new IdentityRole(Utility.Helper.doctor));
                await  _RoleManager.CreateAsync(new IdentityRole(Utility.Helper.patient));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    Name = model.Name
                };
                var result = await _UserManager.CreateAsync(user,model.Password);
                if(result.Succeeded)
                {
                    await _UserManager.AddToRoleAsync(user, model.RoleName);
                    await _SignInManager.SignInAsync(user,isPersistent:false);
                    return RedirectToAction("index", "Home");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
