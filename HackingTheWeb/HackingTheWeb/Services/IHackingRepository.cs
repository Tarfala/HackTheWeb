using HackingTheWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HackingTheWeb.Services
{
    public interface IHackingRepository
    {
        void UpdateDatabaseWithNewPassword(Login baseLogin);
        Login CheckIfPasswordIsCorrect(string password);
        string GetCorrectPassword();
        void SeedLevelThreePassword();
        string CheckLevelThreePassword();
    }
}
