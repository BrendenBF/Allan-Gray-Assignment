using SocialFeedTest.Interfaces;
using System;
using System.Configuration;

namespace SocialFeedTest.Manager
{
    public class FeedManager
    {
        private string GetUserFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["UserFilePath"];
            }
        }

        private string GetTweetFilePath
        {
            get
            {
                return ConfigurationManager.AppSettings["TweetFilePath"];
            }
        }

        private IReadUsersProcess usersProcess;
        private IReadTweetsProcess tweetsProcess;
        private IConstructSocialFeedProcess feedProcess;

        public FeedManager(IReadUsersProcess readUserProcess, IReadTweetsProcess readTweetsProcess, IConstructSocialFeedProcess constructSocialFeedProcess)
        {
            this.usersProcess = readUserProcess;
            this.tweetsProcess = readTweetsProcess;
            this.feedProcess = constructSocialFeedProcess;   
        }

        public void BuildSocialFeed()
        {
            bool error = false;

            //Read in the Users and the people they are following
            var usersResult = usersProcess.ReadUsers(@GetUserFilePath);

            //Read in the tweets together with the names of the people associated with the tweets
            var tweetsResult = tweetsProcess.ReadTweets(@GetTweetFilePath);

            //Error handeling to check if the user file was read in correctly without problems and was successfully processed
            if (usersResult.Item2 == false)
            {
                Console.WriteLine(usersResult.Item3);
                error = true;
            }

            //Error handeling to check if the tweet file was read in correctly without problems and was succesfully processed
            if (tweetsResult.Item2 == false)
            {
                Console.WriteLine(tweetsResult.Item3);
                error = true;
            }

            //If no error on both occassions above, then it is safe to construct the feed
            if (!error)
            {
                var socialFeed = feedProcess.PrintSocialFeed(usersResult.Item1, tweetsResult.Item1);

                //Check successful construction of feed before printing
                if (socialFeed.Item2 == true)
                    Console.Write(socialFeed.Item1);
                else
                    Console.WriteLine(socialFeed.Item3);
            }

            //Prevent the console from closing before output is assessed
            Console.ReadLine();
        }
    }
}
