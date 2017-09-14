using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTwitter.Models
{
    public  partial class GetTweet_Results1
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Tweet { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public int FavoritesCount { get; set; }
    }
}