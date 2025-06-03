using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Repositories
{
    public class UserRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();
        public static Users GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

        public static Users GetUserByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.UserEmail == email);
        }

        public static void CreateUser(Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static void updateUser(int id, string name, string email, string password, string gender)
        {
            Users user = db.Users.FirstOrDefault(i => i.UserID == id);

            if(user != null)
            {
                user.UserName = name;
                user.UserEmail = email;
                if(!string.IsNullOrWhiteSpace(password)) {
                    user.UserPassword = password;
                }
                user.UserGender = gender;
                db.SaveChanges();
            }
        }

        public static Users GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.UserID == id);
        }
    }
}