using LOrd_Card_Shop.Handlers;
using LOrd_Card_Shop.Models;
using LOrd_Card_Shop.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using static System.Collections.Specialized.BitVector32;
using System.Web.UI.WebControls;
using LOrd_Card_Shop.WebServices;

namespace LOrd_Card_Shop.Controllers
{
    public class UserController
    {
        public static Response<Users> LoginUser(string username, string password)
        {
            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return new Response<Users>
                {
                    Message = "All fields must be filled!",
                    Success = false,
                };
            }

            UserWebService userWS = new UserWebService();
            String jsonResponse = userWS.LoginUser(username, password);

            return Json.Decode<Response<Users>>(jsonResponse);
        }

        public static Response<Users> RegisterUser(string username, string email, string password, string confirmPassword, string gender)
        {
            if(string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(confirmPassword) || string.IsNullOrWhiteSpace(gender))
            {
                return new Response<Users>
                {
                    Message = "All fields must be filled!",
                    Success = false,
                };
            }

            if(username.Length < 5 || username.Length > 30)
            {
                return new Response<Users>
                {
                    Message = "Username must be between 5 and 30 characters long!",
                    Success = false,
                };
            }

            if(!isValidUsername(username))
            {
                return new Response<Users>
                {
                    Message = "username must only contain alphabet and white space only!",
                    Success = false,
                };
            }

            if(!email.Contains("@"))
            {
                return new Response<Users>
                {
                    Message = "email must contain @!",
                    Success = false,
                };
            }

            if(password.Length < 8)
            {
                return new Response<Users>
                {
                    Message = "password must be at least 8 characters long!",
                    Success = false,
                };
            }

            if(!isValidPassword(password))
            {
                return new Response<Users>
                {
                    Message = "password must be alphanumeric!",
                    Success = false,
                };
            }

            if(!gender.Equals("Male") && !gender.Equals("Female"))
            {
                return new Response<Users>
                {
                    Message = "gender must be male or female!",
                    Success = false,
                };
            }

            if(!confirmPassword.Equals(password))
            {
                return new Response<Users>
                {
                    Message = "password doesn't match!",
                    Success = false,
                };
            }

            UserWebService userWS = new UserWebService();
            String jsonResponse = userWS.RegisterUser(username, email, password, gender);

            return Json.Decode<Response<Users>>(jsonResponse);
        }

        public static Response<Users> UpdateUser(int userId, string username, string email, string oldPassword, string userPassword, string newPassword, string confirmPassword, string gender)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(gender))
            {
                return new Response<Users>
                {
                    Message = "Username, email, and gender must be filled!",
                    Success = false,
                };
            }

            if (username.Length < 5 || username.Length > 30)
            {
                return new Response<Users>
                {
                    Message = "Username must be between 5 and 30 characters long!",
                    Success = false,
                };
            }

            if (!isValidUsername(username))
            {
                return new Response<Users>
                {
                    Message = "username must only contain alphabet and white space only!",
                    Success = false,
                };
            }

            if (!email.Contains("@"))
            {
                return new Response<Users>
                {
                    Message = "email must contain @!",
                    Success = false,
                };
            }

            if(string.IsNullOrWhiteSpace(oldPassword))
            {
                return new Response<Users>
                {
                    Message = "You must fill the password to change profile!",
                    Success = false,
                };
            }

            if(!string.IsNullOrWhiteSpace(newPassword))
            {
                if (!oldPassword.Equals(userPassword))
                {
                    return new Response<Users>
                    {
                        Message = "Old password must match user password!",
                        Success = false,
                    };
                }

                if(newPassword.Length < 8)
                {
                    return new Response<Users>
                    {
                        Message = "Password must be at least 8 characters long!",
                        Success = false,
                    };
                }

                if (!isValidPassword(newPassword))
                {
                    return new Response<Users>
                    {
                        Message = "password must be alphanumeric!",
                        Success = false,
                    };
                }
                if (!confirmPassword.Equals(newPassword))
                {
                    return new Response<Users>
                    {
                        Message = "password doesn't match!",
                        Success = false,
                    };
                }
            }

            if (!gender.Equals("Male") && !gender.Equals("Female"))
            {
                return new Response<Users>
                {
                    Message = "gender must be male or female!",
                    Success = false,
                };
            }

            UserWebService userWS = new UserWebService();
            String jsonResponse = userWS.UpdateUser(userId, username, email, newPassword, gender);

            return Json.Decode<Response<Users>>(jsonResponse);
        }

        private static bool isValidUsername(string username)
        {
            foreach (char u in username)
            {
                if (!char.IsLetter(u) && !char.IsWhiteSpace(u))
                {
                    return false;
                }
            }
            return true;
        }

        private static bool isValidPassword(string password)
        {
            foreach (char p in password)
            {
                if(!char.IsLetterOrDigit(p))
                {
                    return false;
                }
            }
            return true;
        }

        public static Users GetUserFromCookie(HttpRequest Request, HttpResponse Response, HttpSessionState Session)
        {
            if (Session["user"] == null && Request.Cookies["user_cookie"] == null)
            {
                return null;
            }

            else if (Session["user"] != null)
            {
                return (Users)Session["user"];
            }

            else if (Session["user"] == null && Request.Cookies["user_cookie"] != null)
            {
                string userId = Request.Cookies["user_cookie"].Value;

                Response<Users> response = GetSession(userId);

                if (!response.Success)
                {
                    HttpCookie cookie = new HttpCookie("user_cookie");
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                    Session.Abandon();
                    return null;
                }
                else
                {
                    Session["user"] = response.Payload;
                    return response.Payload;
                }
            }
            else
            {
                return null;
            }
        }

        public static Response<Users> GetSession(string id)
        {
            int cookieId = int.Parse(id);
            UserWebService userWS = new UserWebService();
            String jsonResponse = userWS.GetSession(cookieId);

            return Json.Decode<Response<Users>>(jsonResponse);
        }

    }
}