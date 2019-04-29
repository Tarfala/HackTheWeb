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
                SecretPassWord = password.ToString()
            };
            _repo.UpdateDatabaseWithNewPassword(baseLogin);
            _repo.SeedLevelThreePassword();

            return View();
        }

        [ValidateAntiForgeryToken]
        public IActionResult CheckPassword(string SecretPassWord)
        {
            string correctPassword = _repo.GetCorrectPassword();
            if (SecretPassWord == correctPassword)
            {
                return View("~/Views/Hacking/LevelTwo.cshtml");
            }

            Login newLogin = _repo.CheckIfPasswordIsCorrect(SecretPassWord);

            if (newLogin.SecretPassWord == null)
            {
                ViewBag.LoginInfo = "Sorry, wrong password";
            }
            else
            {
                ViewBag.LoginInfo = $"Good job! here's your reward, the password: {newLogin.SecretPassWord} ";
            }
            return View("~/Views/Hacking/LevelOne.cshtml");
        }

        public IActionResult LevelTwo()
        {
            return View();
        }

        public IActionResult CheckAnswerForLevelTwo(string numberInput)
        {
            Random randome = new Random();
            int randomeNumber = randome.Next(int.MaxValue);
            int inputAsInt;
            if (numberInput == null)
            {
                ViewBag.GuessNumber = "Sorry, wrong number, try again";
                return View("~/Views/Hacking/LevelTwo.cshtml");
            }
            try
            {
               inputAsInt = int.Parse(numberInput);

                if (inputAsInt == randomeNumber)
                {
                    ViewBag.GuessNumber = "Good job! You're great at guessing";
                    return View("~/Views/Hacking/LevelThree.cshtml");

                }
                else
                {
                    ViewBag.GuessNumber = "Sorry, wrong number, try again";
                    return View("~/Views/Hacking/LevelTwo.cshtml");
                }

            }
            catch (Exception)
            {
                ViewBag.GuessNumber = "Good job! That code wasn't the best...";
                return View("~/Views/Hacking/LevelThree.cshtml");
            }
        }

        public IActionResult LevelThree()
        {
            return View();
        }

        public IActionResult LevelThreePassCheck(string password)
        {
            if (password == null)
            {
                ViewBag.LevelThree = "Sorry, wrong password";
                return View("~/Views/Hacking/LevelThree.cshtml");
            }
            if (password.ToUpper() == _repo.CheckLevelThreePassword().ToUpper())
            {
                return View("~/Views/Hacking/LevelFour.cshtml");
            }
            else
            {
                ViewBag.LevelThree = "Sorry, wrong password";
                return View("~/Views/Hacking/LevelThree.cshtml");
            }
        }

        public IActionResult LevelFour()
        {
            return View();
        }

        public IActionResult LevelFourPassCheck(string passForLevelFour)
        {
            if (passForLevelFour == "GoToNextLevel")
            {
                return View("~/Views/Hacking/LevelFive.cshtml");

            }
            else
            {
                ViewBag.LevelFour = "Sorry, wrong password";
                return View("~/Views/Hacking/LevelFour.cshtml");

            }

        }

        public IActionResult LevelFive()
        {
            return View();
        }

    }
}