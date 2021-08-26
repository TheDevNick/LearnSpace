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
            //will need to add a session so only the user will see their own personal dashboard
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return View("Registration");
            }

            User user = db.Users.FirstOrDefault(i => i.UserID == UserId);
            ViewBag.Topics = db.Topics
            .Where(usr => usr.UserId == UserId);
            ViewBag.User = user;

            return View();
        }


        [HttpGet("/accomplishments")]
        public IActionResult Accomplishment() 
        {
             int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return View("Registration");
            }
            // List<Accomplishment> AllAccomplishments = db.Accomplishments
            // .ToList();
            User user = db.Users.FirstOrDefault(i => i.UserID == UserId);
            ViewBag.Accomplish = db.Accomplishments
            .Include(accomp => accomp.User)
            .Include(accomp => accomp.AllLikingUsers);
        
            // .Where(usr => usr.UserId == UserId);
            ViewBag.User = user;

            return View();
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

            [HttpGet("/addcard")]
            public IActionResult AddCard() => View("AddCard");

            // ----------------------------- ADD FLASHCARD ------------------------------
            [HttpPost("/addcard")]
            public IActionResult AddCard(Card data)
            {
                // Card Validation
                if (ModelState.IsValid)
                {
                    Card uniqueCard = db.Flashcards.FirstOrDefault(card => card.CardQuestion == data.CardQuestion);
                    if (uniqueCard != null)
                    {
                        ModelState.AddModelError("CardQuestion", "You are already have a card with this question.");
                        return View("AddCard");

                    }
                    User user = db.Users.FirstOrDefault(usr => usr.UserID == (int)HttpContext.Session.GetInt32("UserId"));
                    db.Flashcards.Add(data);
                    db.SaveChanges();
                    TempData["AddedCard"] = $"You successfully added a flashcard!🎉🎉🎉 ";
                    return RedirectToAction("LearnDashboard");
                }
                return View("AddCard");

            }
            // ----------------------------- ADD FLASHCARD END---------------------------

        [HttpGet("/viewtopic/edit/{TopicId}")]

        public IActionResult Edit(int TopicId)
        {
            var topic = db.Topics.FirstOrDefault(usr => usr.TopicId == TopicId);

            return View(topic);
        }

        [HttpPost("/EditTopic")]
        public IActionResult EditTopic(Topic data, int id)
        {
            if (ModelState.IsValid)
            {

                Topic EditTopic = db.Topics.FirstOrDefault(top => top.TopicId == id);
                EditTopic.TopicFeedback = data.TopicFeedback;
                EditTopic.TopicName = data.TopicName;
                EditTopic.TopicDifficulty = data.TopicDifficulty;
                db.SaveChanges();
                return RedirectToAction("LearnDashboard");
            }
            return RedirectToAction("LearnDashboard");
        }


        [HttpGet("/viewTopic/delete/{TopicId}")]
        public IActionResult Delete(int TopicId)
        {
            var topicDelete = db.Topics.FirstOrDefault(top => top.TopicId == TopicId);
            if(topicDelete == null)
                return RedirectToAction("LearnDashboard");
            db.Topics.Remove(topicDelete);
            db.SaveChanges();
            return RedirectToAction("LearnDashboard");
        }

        [HttpGet("/accomplishment/like/{accompId}")]
        public IActionResult AddLike(int accompId)
        {
            User user = db.Users.FirstOrDefault(usr => usr.UserID == (int)HttpContext.Session.GetInt32("UserId"));
            Accomplishment accomplish = db.Accomplishments.FirstOrDefault(accomp => accomp.AccomplishmentId == accompId);
            // !!!! Confirm that the accomplishment exists
            if ( user == null || accomplish == null ) 
            {
                return RedirectToAction("Accomplishment");
            }


            // the user has not already liked it.

            if (db.Associations.Any(userLikeAccomplishment => userLikeAccomplishment.AccomplishmentId == accomplish.AccomplishmentId && userLikeAccomplishment.UserId == user.UserID))

            {
                return RedirectToAction("Accomplishment");
            }

            // use the accompId and user to create a new record in Associations
           Association assoc = new Association()
            {
                UserId = (int)HttpContext.Session.GetInt32("UserId"),
                AccomplishmentId = accompId
            };

            db.Add(assoc);
            db.SaveChanges();
            return RedirectToAction("Accomplishment");

        }



        [HttpGet("/logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["ComeBackMsg"] = $"Come back tommorrow and learn some more! ";
            return RedirectToAction("Login");
        }


    }
}