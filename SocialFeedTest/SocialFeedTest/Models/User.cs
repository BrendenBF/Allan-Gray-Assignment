using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialFeedTest.Models
{
    //User specific attributes and behaviours 
    public class User : Person 
    {
        public List<string> Follows { get; set; }
    }
}
