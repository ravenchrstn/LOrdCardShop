using LOrdCardShop.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Repository
{
	public class UserRepository
	{

        private LOrdCardShopVBLEntities db;
        public UserRepository(LOrdCardShopVBLEntities vbl)
        {
            db = vbl;
        }

		public List<User> GetUsers()
		{
			return (from user in db.Users select user).ToList();
		}

		public User GetUserByID(int id)
		{
			return (from user in db.Users where user.UserID == id select user).FirstOrDefault();
		}

		public User GetUserByUsername(string username)
		{
			return (from user in db.Users where user.UserName == username select user).FirstOrDefault();
		}

		public User GetUserByEmail(string email)
		{
            return (from user in db.Users where user.UserEmail == email select user).FirstOrDefault();
		}

		public User GetUserByTransactionID(int transaction_id)
		{
			return (from user in db.Users
					join th in db.TransactionHeaders
					on user.UserID equals th.UserID
					where th.TransactionID == transaction_id select user).FirstOrDefault();
		}
		public void InsertUser(User user)
		{
			db.Users.Add(user);
			db.SaveChanges();
		}

		public void DeleteUser(User user)
		{
			db.Users.Remove(user);
			db.SaveChanges();
		}

		public void UpdateUser(User user, string username, string email, string gender)
		{
			User user_ = GetUserByID(user.UserID);
			user_.UserName = username;
			user_.UserEmail = email;
			user_.UserGender = gender;
            db.SaveChanges();
        }

        public void UpdateUserPassword(User user, string password)
		{
			User user_ = GetUserByID(user.UserID);
            user_.UserPassword = password;
			db.SaveChanges();
		}
    }
}