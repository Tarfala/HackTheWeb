using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HackingTheWeb.Models;
using HackingTheWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace HackingTheWeb.Controllers
{
    public class HackingController : Controller
    {
        private IHackingRepository _repo;

        public HackingController(IHackingRepository repo)
        {
            _repo = repo;         
        }

        public IActionResult LevelOne()
        {
            Guid password;
            password = Guid.NewGuid();
            Login baseLogin = new Login
            {
                Username = "Admin",
                Password = password.ToString()
            };
            _repo.UpdateDatabaseWithNewPassword(baseLogin);
            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult CheckPassword(string password)
        {
            string correctPassword = _repo.GetCorrectPassword();
            if (password == correctPassword)
            {
                return View("~/Views/Hacking/LevelTwo.cshtml");
            }

            Login newLogin = _repo.CheckIfPasswordIsCorrect(password);

            if (newLogin.Password == null)
            {
                ViewBag.LoginInfo = "Sorry, wrong password";
            }
            else
            {
                ViewBag.LoginInfo = $"Good job! here's your reward, the password: {newLogin.Password} ";
            }
            return View("~/Views/Hacking/LevelOne.cshtml");
        }

        public IActionResult LevelTwo()
        {
            return View();
        }

        public IActionResult CheckAnswerForLevelTwo(string input)
        {
            return View("~/Views/Hacking/LevelTwo.cshtml");
        }
    }
}