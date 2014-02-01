﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using Movies.Mappings;
using Movies.Repositories;
using System.Web.Security;
using System.Web.Helpers;
using Movies.Models;
using System.Web;
using Movies.Security;

namespace Movies.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        private  UsersRepository dbUser;
        private MoviesRepository dbMovie;

        public UserController()
        {
            dbUser = new UsersRepository();
            dbMovie = new MoviesRepository();
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(LogInUserModel user)
        {
            if (ModelState.IsValid)
            {
                if (IsValid(user.login, user.password))
                {
                    string userData;

                    if (dbUser.getUserByLogin(user.login).admin == true)
                        userData = "Admin";
                    else
                        userData = "User";

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                        user.login,
                        DateTime.Now,
                        DateTime.Now.AddDays(1),
                        false,
                        userData,
                        FormsAuthentication.FormsCookiePath);

                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Login and password doesn't match");
                }
            }

            return View(user);
        }

        [AllowAnonymous]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(RegistrationUserModel temp)
        {
            if (ModelState.IsValid)
            {
                user newUser = new user();
                newUser.login = temp.login;
                newUser.password =  Crypto.HashPassword(temp.password);
                newUser.admin = false;
                newUser.email = temp.email;

                if (dbUser.addUser(newUser))
                {
                    return RedirectToAction("LogIn", "User");
                }

                ModelState.AddModelError("", "Login or email address is already taken");
            }

            return View(temp);
        }

        [MyAuthorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [MyAuthorize]
        public ActionResult Vote(voteForSimilarityModel newVote)
        {
            users_vote temp = new users_vote();

            temp.relation_id = newVote.relationId;
            temp.user_id = newVote.userId;
            temp.vote = newVote.vote;

            dbUser.addVote(temp);

            return View();   
        }

        private bool IsValid(string login, string password)
        {
            user temp = dbUser.getUserByLogin(login);

            bool IsValid = false;

            if ((login != null) && (password != null) && (temp != null))
            {
                if(Crypto.VerifyHashedPassword(temp.password, password))
                {
                    IsValid = true;
                }
            }

            return IsValid;
        }

        [MyAuthorize(Roles = "Admin")]
        public ActionResult AdminPanel()
        {
            return View();
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "addAdmin")]
        public ActionResult addAdmin(basicUserModel userModel)
        {
            dbUser.addAdminRights(userModel.login, userModel.adminRights);

            return RedirectToAction("AdminPanel", "User");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "deleteUser")]
        public ActionResult deleteUser(basicUserModel userModel)
        {
            dbUser.deleteUserbyId(userModel.id);

            return RedirectToAction("AdminPanel", "User");
        }

        [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
        public class MultipleButtonAttribute : ActionNameSelectorAttribute
        {
            public string Name { get; set; }
            public string Argument { get; set; }

            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                var isValidName = false;
                var keyValue = string.Format("{0}:{1}", Name, Argument);
                var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

                if (value != null)
                {
                    controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                    isValidName = true;
                }

                return isValidName;
            }
        }
    }
}
