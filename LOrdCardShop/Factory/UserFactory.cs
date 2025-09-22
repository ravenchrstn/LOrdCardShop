using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Factory
{
	public class UserFactory
	{
        public User CreateUser(string username, string email, string password, string gender, string role)
        {
            User user = new User
            {
                UserName = username,
                UserEmail = email,
                UserPassword = password,
                UserGender = gender,
                UserRole = role
            };

            return user;
        }
    }
}