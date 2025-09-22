using LOrdCardShop.Factory;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Handler
{
	public class UserHandler
	{
        UserRepository ur = new UserRepository(new LOrdCardShopVBLEntities());
        UserFactory uf = new UserFactory();
        public List<User> GetUsers()
        {
            return ur.GetUsers();
        }

        public User GetUserByID(int id)
        {
            return ur.GetUserByID(id);
        }

        public User GetUserByUsername(string username)
        {
            return ur.GetUserByUsername(username);
        }

        public User GetUserByEmail(string email)
        {
            return ur.GetUserByEmail(email);
        }
        public User GetUserByTransactionID(int transaction_id)
        {
            return ur.GetUserByTransactionID(transaction_id);
        }

        public User CreateUser(string username, string email, string password, string gender, string confirmation_password, string role)
        {
            User user = uf.CreateUser(username, email, password, gender, role);
            ur.InsertUser(user);
            return user;
        }

        public void InsertUser(User user)
        {
            ur.InsertUser(user);
        }

        public void DeleteUser(User user)
        {
            ur.DeleteUser(user);
        }

        public void UpdateUser(User user, string username, string email, string gender)
        {
            ur.UpdateUser(user, username, email, gender);
        }

        public void UpdateUserPassword(User user, string password)
        {
            ur.UpdateUserPassword(user, password);
        }
    }
}