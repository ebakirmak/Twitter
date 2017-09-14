using MVCTwitter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTwitter.Controllers
{
    public class UserToUsersController : Controller
    {
        ServiceUserToUser.UserToUserOperationsClient userToUserEdmx = new ServiceUserToUser.UserToUserOperationsClient();

        public ActionResult Follow(int FollowingID)
        {
            bool durum = userToUserEdmx.Follow(FollowingID, (int) Session["ID"]);
            if (durum==true)
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Users", "Index");
            }
        }

       
    }
}