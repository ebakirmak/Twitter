using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCTwitter.Models;

namespace MVCTwitter.Controllers
{
    public class UserController : Controller
    {
        ServiceUser.UserOperationsClient userOperation = new ServiceUser.UserOperationsClient();
       
        // GET: User
        public ActionResult Index(int? ID=null)
        {
           
            return View();
        } 
        
        public ActionResult Users()
        {
            var users = userOperation.GetUsers().ToList();
            return View(users);
        } 
       
        public ActionResult UsersDetails(int ID)
        {
            ServiceUser.GetUsers_Result user = userOperation.GetUsers().Where(x => x.ID == ID).FirstOrDefault();
            return View(user);
        }

        //Giriş: username,telefon veya mail ile giriş
        [HttpPost]
        public JsonResult Login(string Email, string Password)
        {
            int ID = 0;
            try
            {
                ID=userOperation.Login(Email, Password);
                if (ID!=0)
                {
                    //Oturum Yönetimi
                    Session.Add("usernameOrPhoneOrMail", Email);
                    Session.Add("ID", ID);
                    ViewBag.EMail = Email;
                 
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return Json(ex.Message);
            }
            
            return Json(ID);
        }

        /* Kayıt Ol: JsonResult ile sayfa değişmeden kayıt olma işlemi yapılıyor.*/        [HttpPost]
        public JsonResult SignUp(string Name, string Username, string Email, string Password)
        {
            bool durum = false;
            try
            {
                durum = userOperation.SignUp(Name, Name, Email, Password);

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);

            }
            return Json(durum.ToString());
        }

        /*Çıkış: Jsonresult ile session ile çıkış işlemi yapılıyor*/
        [HttpPost]
        public JsonResult Exit()
        {
            try
            {
             
                Session.Clear();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return Json("basarisiz");
            }
            
            return Json("basarili");
        }

      
     
     

    }
}