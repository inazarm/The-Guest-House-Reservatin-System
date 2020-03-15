using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.Security;
using TheHouse.Models;

namespace TheHouse.Controllers
{
    public class LoginController : Controller
    {
        TheHouseEntities db = new TheHouseEntities();
        // GET: Login
        public ActionResult Index()
        {
            return RedirectToAction("Index","Home",new {area="Site" });
        }
        public ActionResult Login()
        {
            Response.Cache.SetNoStore();
            return View();
        }

        [HttpPost]
        public ActionResult Login(tbl_User user)
        {
            try
            {
                tbl_User userlist = db.tbl_User.SingleOrDefault(x => x.UserEmail.Equals(user.UserEmail) && x.UserPass.Equals(user.UserPass));
                if (userlist != null)
                {
                    if (userlist.isActive == true)
                    {
                        Session["app"] = userlist;
                        return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                    }
                    {
                        ViewBag.Msg = "your account temprary suspended!";
                        return View(user);
                    }

                }
                else
                {
                    ViewBag.Msg = "Invalid UserName/Password!";
                    ModelState.Clear();
                    return View(user);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Msg = ex;
                return View();
            }

        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index","Home",new {area="Site" });
            
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(tbl_User NewUser)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isEmailAlreadyExists = db.tbl_User.Any(email => email.UserEmail == NewUser.UserEmail);
                    if (isEmailAlreadyExists)
                    {
                        ViewBag.Error="User with this email already exists";
                        return View(NewUser);
                    }
                    else
                    {
                        NewUser.UserImage = "defualt.png";
                        NewUser.CreatedDate = DateTime.Now.ToLongDateString();
                        NewUser.UserType = "User";
                        NewUser.isActive = true;
                        db.tbl_User.Add(NewUser);
                        db.SaveChanges();
                        return RedirectToAction("Login","Login");
                    }
                }
                else
                {
                    ViewBag.Error = "Image is null";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Exception error:"+ex.Message;
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(tbl_User CreateUser, HttpPostedFileBase UserImg)
        {

            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    var isEmailAlreadyExists = db.tbl_User.Any(i => i.UserEmail == CreateUser.UserEmail);
                    var filePath = Server.MapPath("~/ProfileImages/" + CreateUser.UserImage);
                    if (isEmailAlreadyExists)
                    {
                        ViewBag.EmailError = "This email is already registered!";
                        return View(CreateUser);
                    }
                    {
                        string ext = Path.GetExtension(UserImg.FileName);
                        if (ext == ".png" || ext == ".jpg")
                        {
                            var filename = Path.GetFileName(CreateUser.UserEmail + "" + ext);
                            UserImg.SaveAs(Path.Combine(Server.MapPath("~/ProfileImages/"), filename));
                            CreateUser.UserImage = CreateUser.UserEmail + "" + ext;
                            CreateUser.UserType = "User";
                            CreateUser.CreatedDate = DateTime.Now.ToShortDateString();
                            CreateUser.isActive = false;
                            db.tbl_User.Add(CreateUser);
                            db.SaveChanges();
                            return RedirectToAction("Login");
                        }
                    }
                }
                else
                {
                    ViewBag.Msg = "Something went wrong!";
                }
                return View(CreateUser);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
            return View();
        }
    }
}