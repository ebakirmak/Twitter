using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WCFTwitter
{
    public class Tweet
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string Name { get; set; }

        public string Twit { get; set; }

        public DateTime CreatedDate { get; set; }

        public int FavoritesCount { get; set; }


    }
}