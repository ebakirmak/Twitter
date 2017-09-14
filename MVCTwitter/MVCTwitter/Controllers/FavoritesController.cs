using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTwitter.Controllers
{
    public class FavoritesController : Controller
    {
        ServiceFavorite.FavoritesOperationsClient favoriteEdmx = new ServiceFavorite.FavoritesOperationsClient();

        [HttpPost]
      public JsonResult setFavorites(int TweetID,int UserID)
        {
            bool returnTo=favoriteEdmx.FavoriteAdd(TweetID, UserID);
            return Json(returnTo);
        }
    }
}