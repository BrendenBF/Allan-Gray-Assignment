using SocialFeedTest.Interfaces;
using SocialFeedTest.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace SocialFeedTest.Processes
{
    public class FileReadTweetsProcess : Singleton<FileReadTweetsProcess>, IReadTweetsProcess
    {
        //Protected constructor to allow only inherited singlton access to instance creation
        protected FileReadTweetsProcess() { }

        public Tuple<List<Tweet>, bool, string> ReadTweets(string filePath)
        {
            SortedDictionary<string, List<string>> userTweets = new SortedDictionary<string, List<string>>();

            try
            {
                //Read in the tweets file line for line
                string[] textTweets = File.ReadAllLines(filePath);

                //Process the file for each line that has been read in
                foreach (var line in textTweets)
                {
                    //Split the line on the '>' character, so that we can distinguish between the users name and the associated tweet
                    string[] userAndTweet = line.Split('>');

                    string user = userAndTweet[0].Trim();
                    string tweet = userAndTweet[1].Trim();
                    
                    if (tweet.Length > 140)
                        throw new Exception(String.Format("Invalid Tweet. Your character count exceeds the maximum allowed of 140. It is {0}", tweet.Length));

                    //Read into a sorted dictionary - key, value pair
                    if (!userTweets.ContainsKey(user))
                    {
                        //If the user name doesn't exist add it as a fresh entry into the dictionary
                        var tweets = new List<string>();
                        tweets.Add(tweet);

                        userTweets.Add(user, tweets);
                    }
                    else
                        //If the user has been processed previously, just append the tweet to his existing key
                        userTweets[user].Add(tweet);
                }

                //Return the model together with some additional information regarding the success of the above execution
                return new Tuple<List<Tweet>, bool, string>(userTweets.ToTweetModel(), true, "Tweets File Successfully Processed");
            }
            catch (Exception ex)
            {
                return new Tuple<List<Tweet>, bool, string>(null, false, String.Format("Error : {0}", ex.Message));
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
