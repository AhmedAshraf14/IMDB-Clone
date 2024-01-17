using IMDB_Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMDB_Final.Services
{
    public interface IAdminServices
    {
        int Login(string User, string Password);
    }

    public class AdminServices : IAdminServices
    {
        public AppDbContext context { get; set; }

        public AdminServices()
        {
            context = new AppDbContext();
        }


        public int Login(string User, string Password)
        {

            int Check_Validate;
            if (context.Admins.Where(a => a.AdminName == User && a.Password == Password).Any())
            {
                Check_Validate = 1;
            }
            else if (context.Users.Where(a => a.UserName == User && a.Password == Password).Any())
            {
                Check_Validate = 2;
            }
            else
            {
                Check_Validate = 0;
            }
            return (Check_Validate);
        }
    }
}