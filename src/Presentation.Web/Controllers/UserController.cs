using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;
using Core.Interface;
using Presentation.Web.Models.Input;
using Presentation.Web.Services;
using Repository.Entities;

namespace Presentation.Web.Controllers
{
    public class UserController : Controller
    {
        //protected IRepository<User> Users;
        protected IAuthenticationService Auth;
        private readonly IUserTaskService _userTaskService;

        public UserController(IAuthenticationService auth, IUserTaskService userTaskService)
        {
           // Users = users;
            Auth = auth;
            _userTaskService = userTaskService;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterInput input)
        {
            if (!ModelState.IsValid) return View(input);

            var user = new User() {Email = input.Email, Name = input.Name, Password = input.Password};
            //user.HashPassword();

           await _userTaskService.CreateUser(user);

            Auth.Authenticate(user, ControllerContext.HttpContext.Response);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LogIn(LoginInput input)
        {
            if (!ModelState.IsValid) return View(input);

            try
            {
                var user = await _userTaskService.GetUserByCredentials(input.Email, input.Password);

                if (user == null)
                {
                    return BadRequest();
                }

                Auth.Authenticate(user, HttpContext.Response);

                return RedirectToAction("Index", "Home");

            }
            catch (Exception)
            {
                return BadRequest();
            }           
        }

        private ActionResult BadRequest()
        {
            //  todo: return a user-friendly error message
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        public RedirectToRouteResult LogOut()
        {
            Auth.SignOut();
            return RedirectToAction("LogIn");
        }
    }
}
