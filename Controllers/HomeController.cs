using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using LearnSpace.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LearnSpace.Controllers
{
    public class HomeController : Controller
    {
        private MyContext db;
        public HomeController(MyContext database)
        {
            db = database;
        }

        [HttpGet("/")] 
        public IActionResult Registration() => View();

        [HttpPost("/registration")]

        public IActionResult Registration(User newUser)
        {
            if (ModelState.IsValid)
            // checking to see if email or username exists
            {
                if (db.Users.Any(e => e.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email alrady taken");
                    return View("Registration");
                }
                if (db.Users.Any(usr => usr.Username == newUser.Username))
                {
                    ModelState.AddModelError("Username", "Username alrady taken");
                    return View("Registration");
                }


                PasswordHasher<User> PwdHash = new PasswordHasher<User>();
                newUser.Password = PwdHash.HashPassword(newUser, newUser.Password);
                db.Add(newUser);
                db.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserID);
                 TempData["WelcomeMsg"] = $"Welcome {newUser.FirstName}!";

                return RedirectToAction("LearnDashboard");
            }
            return View("Registration");
        }


        

        [HttpGet("/login")]
        public IActionResult Login() => View();

        [HttpPost("/login")]
        public IActionResult Login(LoginUser user)
        {
            if (ModelState.IsValid)
            {
                User Username = db.Users.FirstOrDefault(usr => usr.Username == user.LoginUserName);
                if (Username == null)
                {
                    ModelState.AddModelError("LoginUserName", "Invalid Username and/or Password");
                    return View("Login");
                }
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(user, Username.Password, user.LoginPassword);
                if (result == 0)
                {
                    ModelState.AddModelError("LoginUserName", "Invalid Username and/or Password");
                    return View("Login");
                }
                HttpContext.Session.SetInt32("UserId", Username.UserID);
                 TempData["WelcomeMsg"] = $"Welcome Back {user.LoginUserName}!";
                return RedirectToAction("LearnDashboard");
            }
            return View("Login");
        }


        //View of the user's dashboard
        [HttpGet("/learndashboard")]
        public IActionResult LearnDashboard()
        {
            List<Topic> AllTopics = db.Topics
            .ToList();
            return View(AllTopics);
        }


        [HttpGet("/accomplishments")]
        public IActionResult Accomplishment() 
        {
            List<Accomplishment> AllAccomplishments = db.Accomplishments
            .ToList();
            return View(AllAccomplishments);
        }

        [HttpGet("/newaccomplishment")]
        public IActionResult NewAccomplishment() => View();

        [HttpPost("/newaccomplishment")]
        public IActionResult NewAccomplishment(Accomplishment data)
        {
            // Topic Validation
            if (ModelState.IsValid)
            {
                Accomplishment accomplished = db.Accomplishments.FirstOrDefault(accomp => accomp.AccomplishmentName == data.AccomplishmentName);
                if (accomplished != null)
                {
                    ModelState.AddModelError("AccomplishmentName", "You already accomplished this!");
                    return View("NewAccomplishment");

                }
                User user = db.Users.FirstOrDefault(usr => usr.UserID == (int)HttpContext.Session.GetInt32("UserId"));
                data.UserId = user.UserID;
                db.Accomplishments.Add(data);
                db.SaveChanges();
                return RedirectToAction("Accomplishment");
            }
            return View("NewAccomplishment");

        }


        [HttpGet("/newtopic")]
        public IActionResult NewTopic() => View();


        [HttpPost("/newTopic")]
        public IActionResult NewTopic(Topic data)
        {
            // Topic Validation
            if (ModelState.IsValid)
            {
                Topic uniqueTopic = db.Topics.FirstOrDefault(top => top.TopicName == data.TopicName);
                if (uniqueTopic != null)
                {
                    ModelState.AddModelError("TopicName", "You are already learning this topic.");
                    return View("LearnDashboard");

                }
                User user = db.Users.FirstOrDefault(usr => usr.UserID == (int)HttpContext.Session.GetInt32("UserId"));
                data.UserId = user.UserID;
                db.Topics.Add(data);
                db.SaveChanges();
                return RedirectToAction("LearnDashboard");
            }
            return View("LearnDashboard");

        }

    }
}