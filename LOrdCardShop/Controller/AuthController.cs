using LOrdCardShop.Handler;
using LOrdCardShop;
using LOrdCardShop.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LOrdCardShop.Model;

namespace LOrdCardShop.Controller
{
	public class AuthController
	{
        UserController uc = new UserController();
        public void SetUserCookie(int id)
        {
            HttpCookie cookie = new HttpCookie("user_id", id.ToString());
            cookie.Expires = DateTime.Now.AddDays(7);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public User GetUserCookie()
        {
            if (HttpContext.Current.Request.Cookies["user_id"] != null)
            {
                string string_user_id = HttpContext.Current.Request.Cookies["user_id"].Value;
                if (int.TryParse(string_user_id, out int user_id))
                {
                    int id = int.Parse(string_user_id);
                    return uc.GetUserByID(id);

                }
                return null;
            }
            return null;
            
        }

        public void RemoveUserCookie()
        {
            HttpCookie cookie = HttpContext.Current.Response.Cookies["user_id"];
            if (cookie != null) cookie.Expires = DateTime.Now.AddDays(-1);
        }

        public void RemoveAllCookies()
        {
            string[] cookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string cookie in cookies)
            {
                HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Today.AddDays(-1);
            }
        }
        public void SetUserSession(User user)
        {
            HttpContext.Current.Session["user"] = user;
        }

        public User GetUserSession()
        {
            if (HttpContext.Current.Session["user"] != null)
            {
                int id = ((User) HttpContext.Current.Session["user"]).UserID;
                return uc.GetUserByID(id);
            }
            return null;
        }

        public void AbandonSession()
        {
            HttpContext.Current.Session.Abandon();
        }

        public void ClearSession()
        {
            HttpContext.Current.Session.Clear();
        }

        public void RedirectHomeAccordingToUserRole(User user)
        {
            if (user == null)
            {
                HttpContext.Current.Response.Redirect("~/View/Error.aspx");
                return;
            }
            string user_role = user.UserRole;
            if (user_role.Equals("Admin"))
            {
                HttpContext.Current.Response.Redirect("~/View/Home/Home_Admin.aspx");
            }
            else if (user_role.Equals("Customer"))
            {
                HttpContext.Current.Response.Redirect("~/View/Home/Home_Customer.aspx");
            }
        }

        public bool Authenticated()
        {
            User user_cookie = GetUserCookie();
            User user_session = GetUserSession();

            if (user_session != null) return true;
            else if (user_session == null && user_cookie != null) return true;
            return false;
        }

        public bool CheckingRole(string role)
        {
            User user = getUser();
            if (user.UserRole.Equals(role)) return true;
            return false;
        }

        public User getUser()
        {
            User user = GetUserSession();
            if (user == null) user = GetUserCookie();
            return user;
        }

        public void SyncCookieToSession()
        {
            User user_session = GetUserSession();
            User user_cookie = GetUserCookie();
            if (user_cookie != null && user_session == null) SetUserSession(getUser());
        }

        public void CustomerAuthentication(string path)
        {
            if (!Authenticated()) HttpContext.Current.Response.Redirect("~/View/Login.aspx");
            if (CheckingRole("Admin")) HttpContext.Current.Response.Redirect(path);
            SyncCookieToSession();
        }

        public void AdminAuthentication(string path)
        {
            if (!Authenticated()) HttpContext.Current.Response.Redirect("~/View/Login.aspx");
            if (CheckingRole("Customer")) HttpContext.Current.Response.Redirect(path);
            SyncCookieToSession();
        }
    }
}