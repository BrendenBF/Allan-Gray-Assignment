using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialFeedTest.Models
{
    //Tweet specific attributes and behaviours 
    public class Tweet : Person
    {
        public List<string> Text { get; set; }
    }
}
