using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCTwitter.Models
{
    public partial class GetUsers_Result
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}