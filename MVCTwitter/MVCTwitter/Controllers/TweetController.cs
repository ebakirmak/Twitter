using MVCTwitter.Models;
using MVCTwitter.ServiceUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace MVCTwitter.Controllers
{
    public class TweetController : Controller
    {
        

        ServiceTweet.TweetOperationsClient tweetOperation = new ServiceTweet.TweetOperationsClient();
        /*Tweet Gönderme*/
        [HttpPost]
        public JsonResult Send(string tweet)
        {
            bool returnTo = false;
            try
            {
                returnTo=tweetOperation.TweetSend((int) Session["ID"],tweet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message + "\nMVC");
            }

            return Json(returnTo);
        }

    
        public new JsonResult View(int? SonTweetID)
         {
            if (Session["ID"] == null)
                return Json(0);
            int ID = (int) Session["ID"];
            //Eğer bir kullanıcı giriş yapmamışsa hiçbir tweet gönderilmeyecek.
            if (ID == 0)
                return Json(0);
           
            //Yazdığımız servis sayesinde vt'ındaki UserID girilen kullanıcının takip
            //ettiği arkadaşlarının tweetleri döndürülecek.
            
            var tweets = tweetOperation.TweetView(ID).ToList();
            List<object> sonTweets = new List<object>();
            //Döndürülen tweet sayısı, en son AJAX/Json çağrısından eşit değilse
            //yani yeni tweet gelmişse yeni gelen tweetleri alacağız.
            if (SonTweetID==null || SonTweetID != tweets.LastOrDefault().ID)
            {
                if (SonTweetID!=null)                  
                    tweets.Reverse();
                foreach (var sonTweetler in tweets)
                {
                    if (SonTweetID == sonTweetler.ID)
                        break;
                     sonTweets.Add(sonTweetler);
                   
                }
            
                if (tweets != null)
                    return Json(sonTweets);
                else
                    return Json(0);
            }
            else
                return Json(0);           
              
            
            
            
           
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   