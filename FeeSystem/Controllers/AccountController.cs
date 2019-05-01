﻿using FeeSystem.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace FeeSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByNameAsync(loginVM.UserName);

            if(user !=null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Nazwa użytkownika lub hasło jest niewłaściwe");
            return View(loginVM);
        }
        public IActionResult Register()
        {
            return View(new LoginVM());
        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginVM loginVM)
        {
            if(ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = loginVM.UserName };
                var result = await _userManager.CreateAsync(user, loginVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    var errList = "";
                    var error = result.Errors.ToList(); 
                    foreach (var err in error) 
                    {
                        this.ModelState.AddModelError("Password", err.Description);
                    }
                }
            }
            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}