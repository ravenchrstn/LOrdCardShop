using LOrdCardShop.Handler;
using LOrdCardShop.Model;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LOrdCardShop.Controller
{
	public class UserController
	{
        UserHandler uh = new UserHandler();

        public List<User> GetUsers()
        {
            return uh.GetUsers();
        }

        public User GetUserByID(int id)
        {
            return uh.GetUserByID(id);
        }

        public User GetUserByUsername(string username)
        {
            return uh.GetUserByUsername(username);
        }

        public User GetUserByEmail(string email)
        {
            return uh.GetUserByEmail(email);
        }

        public User GetUserByTransactionID(int transaction_id)
        {
            return uh.GetUserByTransactionID(transaction_id);
        }
        public User CreateUser(string username, string email, string password, string gender, string confirmation_password, string role)
        {
            return uh.CreateUser(username, email, password, gender, confirmation_password, role);
        }

        public void InsertUser(User user)
        {
            uh.InsertUser(user);
        }

        public void DeleteUser(User user)
        {
            uh.DeleteUser(user);
        }

        public void UpdateUser(User user, string username, string email, string gender)
        {
            uh.UpdateUser(user, username, email, gender);
        }

        public void UpdateUserPassword(User user, string password)
        {
            uh.UpdateUserPassword(user, password);
        }

        protected bool IsAlphabetOrSpaceOnly(string text)
        {
            return text.All(c => char.IsLetter(c) || c == ' ');
        }

        protected bool DoesContainAt(string text)
        {
            return text.Contains("@");
        }

        protected bool IsAlphanumeric(string text)
        {
            return text.All(c => char.IsLetter(c) || char.IsDigit(c));
        }

        public string ValidateUsername(string username)
        {
            if (username.Length < 5 || username.Length > 30)
            {
                return "Username must be between 5 and 30 characters";
            }
            else if (!IsAlphabetOrSpaceOnly(username))
            {
                return "Username must only be alphabet and space only";
            }
            else if (uh.GetUserByUsername(username) != null) return "Username has been taken. Please choose a different one";
            else return "";
        }

        public string ValidateEmail(string email)
        {

            if (!DoesContainAt(email))
            {
                return "Email must contain @";
            }
            else if (uh.GetUserByEmail(email) != null) return "Email has been taken. Please use a different one";
            else return "";
        }

        public string ValidatePassword(string password)
        {

            if (password.Length < 8) return "Password must have at least 8 characters";
            else if (!IsAlphanumeric(password)) return "Password must only contain alphabet and number";
            else return "";
        }

        public string ValidateDOB(DateTime DOB)
        {
            if (DOB > DateTime.Today) return "Date of Birth must not exceed today's date.";
            return "";
        }

        public string ValidateGender(string gender)
        {

            if (gender.Equals("")) return "Gender must be choosen";
            else return "";
        }

        public string ValidateConfirmationPassword(string confirmation_password, string password)
        {

            if (confirmation_password.Length < 8) return "Confirmation password must have at least 8 characters";
            else if (!IsAlphanumeric(confirmation_password)) return "Confirmation password must only contain alphabet and number";
            else if (!confirmation_password.Equals(password)) return "Confirmation password must match the password";
            else return "";
        }

        public string ValidateRole(string role)
        {

            if (role.Equals(""))
            {
                return "Role must be choosen";
            }
            else return "";
        }

        public string IsPasswordSame(User user, string old_password)
        {
            if (!user.UserPassword.Equals(old_password)) return "Incorrect Password";
            return "";
        }

        public string IsPasswordSame(string first_password, string second_password)
        {
            if (!first_password.Equals(second_password)) return "The confirmation password must match the old password";
            return "";
        }
    }
}