using SocialFeedTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialFeedTest
{
    public static class Extensions
    {
        //Extension method to convert the user dictionary into a more readable model that is easier to work with
        public static List<User>ToUserModel(this SortedDictionary<string, List<string>> users)
        {
            var userModel = new List<User>();

            foreach (var user in users)
            {
                userModel.Add(new User { Name = user.Key, Follows = user.Value });
            }

            return userModel;
        }

        //Extension method to convert the tweets dictionary into a more readable model that is easier to work with
        public static List<Tweet> ToTweetModel(this SortedDictionary<string, List<string>> tweets)
        {
            var tweetModel = new List<Tweet>();

            foreach(var tweet in tweets)
            {
                tweetModel.Add(new Tweet { Name = tweet.Key, Text = tweet.Value });
            }

            return tweetModel;
        }
    }
}
