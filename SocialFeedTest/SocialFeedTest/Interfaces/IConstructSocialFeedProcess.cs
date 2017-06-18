using SocialFeedTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialFeedTest.Interfaces
{
    public interface IConstructSocialFeedProcess
    {
        Tuple<string, bool, string> PrintSocialFeed(List<User> users, List<Tweet> tweets);
    }
}
