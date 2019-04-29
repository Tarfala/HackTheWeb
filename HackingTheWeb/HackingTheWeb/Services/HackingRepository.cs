using HackingTheWeb.Data;
using HackingTheWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace HackingTheWeb.Services
{
    public class HackingRepository : IHackingRepository
    {
        private const string conString = "Server=(localdb)\\mssqllocaldb; Database=HackingTheWeb-Jonathan";
        private IHostingEnvironment _env;
        private readonly ApplicationDbContext _context;

        public HackingRepository(IHostingEnvironment env, ApplicationDbContext context)
        {
            _env = env;
            _context = context;
        }

        public void UpdateDatabaseWithNewPassword(Login baseLogin)
        {
            List<Login> listToCheckIfEmpty = _context.Login.AsNoTracking().ToList();
            if (listToCheckIfEmpty.Count() == 0)
            {
                _context.Login.Add(baseLogin);
                _context.SaveChanges();
            }
            else
            {
                _context.Login.Update(baseLogin);
                _context.SaveChanges();
            }           

        }

        public Login CheckIfPasswordIsCorrect(string password)
        {
            Login login = new Login();
            try
            {
                string Sql = $"select* from Login WHERE Username = 'Admin' and Password = {password}";
                using (SqlConnection connection = new SqlConnection(conString))
                using (SqlCommand command = new SqlCommand(Sql, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        login.Username = reader.GetSqlString(0).Value;
                        login.Password = reader.GetSqlString(1).Value;
                    }
                }
                return login;
            }
            catch (Exception)
            {
                return login;
            }          
            
        }

        public string GetCorrectPassword()
        {
            return _context.Login.SingleOrDefault().Password;
        }

        public void SeedLevelThreePassword()
        {
            LevelThree levelThree = new LevelThree();
            levelThree.PassWord = "Easy";

            List<LevelThree> listToCheckIfEmpty = _context.LevelThree.AsNoTracking().ToList();
            if (listToCheckIfEmpty.Count() == 0)
            {
                _context.LevelThree.Add(levelThree);
                _context.SaveChanges();
            }           
        }

        public string CheckLevelThreePassword()
        {
            LevelThree correctLevelThree = _context.LevelThree.FirstOrDefault();
            return correctLevelThree.PassWord;
        }

    }
}
