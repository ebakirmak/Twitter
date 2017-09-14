using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFTwitter.Operations
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "TweetOperations" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select TweetOperations.svc or TweetOperations.svc.cs at the Solution Explorer and start debugging.
    public class TweetOperations : ITweetOperations
    {
        private readonly TwitterEntities twitterEdmx = new TwitterEntities();
        
        public bool TweetDelete(int UserID, int TweetID)
        {
            Tweets silinecekTweet = new Tweets();
            silinecekTweet = twitterEdmx.Tweets.Where(x => x.ID == TweetID && x.UserID== UserID).FirstOrDefault();
            try
            {
                twitterEdmx.Tweets.Remove(silinecekTweet);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
            finally
            {
                twitterEdmx.SaveChanges();
            }
            return true;
        }

        public bool TweetSend(int UserID, string Tweet)
        {
            Tweets eklenecekTweet = new Tweets();
          
            try
            {
                eklenecekTweet.UserID = UserID;
                eklenecekTweet.Tweet = Tweet;
                eklenecekTweet.CreatedDate = DateTime.Now;
                eklenecekTweet.FavoritesCount = 0;
                twitterEdmx.Tweets.Add(eklenecekTweet);
            
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;               
            }
            finally
            {
                twitterEdmx.SaveChanges();                
            }
            return true;
            
        }

        public List<GetTweets_Result1> TweetView(int ID)
        {        

            /*Veritabanında yazmış olduğumuz store procedur ile IDsi alınan kişini takip ettiği arkadaşların tweetleri döndürülüyor.*/
            List<GetTweets_Result1> tweets = new List<GetTweets_Result1>();       
            try
            {               
                tweets = twitterEdmx.GetTweets(ID).ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
          
            return tweets;
        }
    }
}
