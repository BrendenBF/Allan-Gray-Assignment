using SocialFeedTest.Models;
using System;
using System.Collections.Generic;

namespace SocialFeedTest.Interfaces
{
    public interface IReadTweetsProcess
    {
        Tuple<List<Tweet>, bool, string> ReadTweets(string filePath);
    }
}
