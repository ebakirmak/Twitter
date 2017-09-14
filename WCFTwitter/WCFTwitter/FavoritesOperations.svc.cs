using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FavoritesOperations" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FavoritesOperations.svc or FavoritesOperations.svc.cs at the Solution Explorer and start debugging.
    public class FavoritesOperations : IFavoritesOperations
    {
        private TwitterEntities favoriteEdmx = new TwitterEntities();
        public bool FavoriteAdd(int TweetID, int UserID)
        {
            MyFavorites favorites = new MyFavorites();
            Tweets tweets = new Tweets();
            try
            {                
                tweets = favoriteEdmx.Tweets.Where(x => x.ID == TweetID).FirstOrDefault();
                tweets.FavoritesCount += 1;
                favorites.UserID = UserID;
                favorites.TweetID = TweetID;
                favoriteEdmx.MyFavorites.Add(favorites);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;   
            }
            finally
            {
                favoriteEdmx.SaveChanges();
            }
            return true;
        }

        public bool FavoriteDelete(int TweetID, int UserID)
        {

            MyFavorites favorites = new MyFavorites();
            Tweets tweets = new Tweets();
            try
            {
                tweets = favoriteEdmx.Tweets.Where(x => x.ID == TweetID).FirstOrDefault();
                tweets.FavoritesCount -= 1;
                favorites = favoriteEdmx.MyFavorites.Where(x => x.TweetID == TweetID && x.UserID == UserID).FirstOrDefault();
                favoriteEdmx.MyFavorites.Remove(favorites);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                favoriteEdmx.SaveChanges();
            }
            return true;
        }
    }
}
