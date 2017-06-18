using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SocialFeedTest.Processes;
using System.Configuration;
using SocialFeedTest.Models;
using System.Collections.Generic;

namespace SocialFeedUnitTest
{
    [TestClass]
    public class SocialFeedTests
    {
        private string UsersFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["UserFilePath"];
            }
        }

        private string TweetFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["TweetFilePath"];
            }
        }

        private Tuple<List<User>, bool, string> GetUsers
        {
            get
            {
                var users = FileReadUsersProcess.Instance.ReadUsers(@UsersFilePath);
                return users;
            }
        }

        private Tuple<List<Tweet>, bool, string> GetTweets
        {
            get
            {
                var tweets = FileReadTweetsProcess.Instance.ReadTweets(@TweetFilePath);
                return tweets;
            }
        }

        private Tuple<string, bool, string> GetSocialFeed
        {
            get
            {
                return ConstructSocialFeedProcess.Instance.PrintSocialFeed(GetUsers.Item1, GetTweets.Item1);
            }   
        }

        [TestMethod]
        public void UsersExceptionTest()
        {
            Assert.IsTrue(GetUsers.Item2, GetUsers.Item3);
        }

        [TestMethod]
        public void UsersResultsTest()
        {
            Assert.IsNotNull(GetUsers.Item1);
        }

        [TestMethod]
        public void TweetsExceptionTest()
        {
            Assert.IsTrue(GetTweets.Item2, GetTweets.Item3);
        }
        
        [TestMethod]
        public void TweetsResultsTest()
        {
            Assert.IsNotNull(GetTweets.Item1);
        }

        [TestMethod]
        public void FeedConstructionExceptionTest()
        {
            Assert.IsTrue(GetSocialFeed.Item2, GetSocialFeed.Item3);
        }

        [TestMethod]
        public void FeedConstructionResultsTest()
        {   
            Assert.IsNotNull(GetSocialFeed.Item1);
        }
    }
}
