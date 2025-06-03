using LOrd_Card_Shop.Factories;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using LOrd_Card_Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrd_Card_Shop.Handlers
{
    public class UserHandler
    {
        public static Response<Users> LoginUser(string username, string password)
        {
            Users user = UserRepository.GetUserByUsername(username);
            
            if(user == null || user.UserPassword != password)
            {
                return new Response<Users>
                {
                    Message = "Invalid user!",
                    Success = false,
                };
            }
            return new Response<Users>
            {
                Message = "Login Success!",
                Success = true,
                Payload = user,
            };
        }

        public static Response<Users> RegisterUser(string username, string email, string password, string gender)
        {

            if(UserRepository.GetUserByUsername(username) != null)
            {
                return new Response<Users>
                {
                    Message = "Username Already taken!",
                    Success = false,
                };
            }

            if(UserRepository.GetUserByEmail(email) != null)
            {
                return new Response<Users>
                {
                    Message = "Email already exists!",
                    Success = false,
                };
            }

            Users newUser = UserFactory.CreateUser(username, email, password, gender, "customer");

            UserRepository.CreateUser(newUser);

            return new Response<Users>
            {
                Message = "Registration success!",
                Success = true,
                Payload = newUser,
            };
        }

        public static Response<Users> UpdateUser(int userId, string username, string email, string password, string gender)
        {

            if (UserRepository.GetUserById(userId) == null)
            {
                return new Response<Users>
                {
                    Message = "user id don't exist!",
                    Success = false,
                };
            }

            if (UserRepository.GetUserByUsername(username) != null)
            {
                return new Response<Users>
                {
                    Message = "Username Already taken!",
                    Success = false,
                };
            }

            if (UserRepository.GetUserByEmail(email) != null)
            {
                return new Response<Users>
                {
                    Message = "Email already exists!",
                    Success = false,
                };
            }

            UserRepository.updateUser(userId, username, email, password, gender);


            return new Response<Users>
            {
                Message = "Update User success!",
                Success = true,
                Payload = UserRepository.GetUserById(userId),
            };
        }

        public static Response<Users> GetSession(int cookieId)
        {
            Users user = UserRepository.GetUserById(cookieId);

            if (user == null)
            {
                return new Response<Users>
                {
                    Message = "user not found!",
                    Success = false,
                };
            }

            else
            {
                return new Response<Users>
                {
                    Message = "user found!",
                    Success = true,
                    Payload = user,
                };
            }
        }
    }
}