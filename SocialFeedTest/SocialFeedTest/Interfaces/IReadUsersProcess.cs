using SocialFeedTest.Models;
using System;
using System.Collections.Generic;

namespace SocialFeedTest.Interfaces
{
    public interface IReadUsersProcess
    {
        Tuple<List<User>, bool, string> ReadUsers(string filePath);
    }
}
