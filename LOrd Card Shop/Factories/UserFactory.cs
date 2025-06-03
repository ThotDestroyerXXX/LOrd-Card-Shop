using LOrd_Card_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Factories
{
    public class UserFactory
    {
        public static Users CreateUser(string username, string email, string password, string gender, string role)
        {
            Users newUser = new Users();
            newUser.UserName = username;
            newUser.UserEmail = email;
            newUser.UserPassword = password;
            newUser.UserGender = gender;
            newUser.UserRole = role ?? "customer";

            return newUser;
        }
    }
}