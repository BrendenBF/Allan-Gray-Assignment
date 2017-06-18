using SocialFeedTest.Interfaces;
using SocialFeedTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SocialFeedTest.Processes
{
    public class ConstructSocialFeedProcess : Singleton<ConstructSocialFeedProcess>, IConstructSocialFeedProcess
    {
        protected ConstructSocialFeedProcess() { }

        public Tuple<string, bool, string> PrintSocialFeed(List<User> users, List<Tweet> tweets)
        {
            StringBuilder constructFeed = new StringBuilder();

            try
            {
                foreach (var user in users)
                {
                    constructFeed.AppendLine(user.Name);

                    foreach (var userTweet in tweets)
                    {
                        if (user.Follows.Any(x => x == userTweet.Name) || userTweet.Name == user.Name)
                        {
                            foreach (var tweet in userTweet.Text)
                            {
                                constructFeed.AppendLine(String.Format("       @{0}: {1}", userTweet.Name, tweet));
                            }
                        }
                    }

                    constructFeed.AppendLine();
                }
            }
            catch(Exception ex)
            {
                return new Tuple<string, bool, string>(null, false, String.Format("Error : {0}", ex.Message));
            }

            return new Tuple<string, bool, string>(constructFeed.ToString(), true, "Social feed was successfully constructed");
        }
    }
}
