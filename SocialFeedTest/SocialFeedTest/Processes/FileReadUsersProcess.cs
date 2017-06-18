using SocialFeedTest.Interfaces;
using SocialFeedTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SocialFeedTest.Processes
{
    public class FileReadUsersProcess : Singleton<FileReadUsersProcess>, IReadUsersProcess
    {
        //Protected constructor to allow only inherited singlton access to instance creation
        protected FileReadUsersProcess() { }

        public Tuple<List<User>, bool, string> ReadUsers(string filePath)
        {
            SortedDictionary<string, List<string>> userFollows = new SortedDictionary<string, List<string>>();
            string[] textUserAndFollows = { };

            try
            {
                //Read in the User file line for line
                textUserAndFollows = File.ReadAllLines(filePath);

                //Create the line seperators for splitting on
                string[] stringSeparator1 = new string[] { "follows" };
                string[] stringSeperator2 = new string[] { ", " };

                //Process the file for each line that has been read in
                foreach (var line in textUserAndFollows)
                {
                    //Split the User from the people they are following using the first seperator
                    string[] userAndFollows = line.ToString().Split(stringSeparator1, StringSplitOptions.None);

                    string user = userAndFollows[0].Trim();
                    List<string> follows = userAndFollows[1].Split(stringSeperator2, StringSplitOptions.None).ToList().Select(x => x.Trim()).ToList();

                    //There are instances where people being followed are not following anyone else - ie. they are inactive users, therefore for the algorithem to work, people being followed can also be 'users' eg. Martin
                    //Therefore it follows that for each person being followed that is not in the 'Users' key, add them. In this case Martin will be picked up.
                    follows.Where(x => !userFollows.ContainsKey(x.Trim())).ToList().ForEach(y => userFollows.Add(y.Trim(), new List<string>()));

                    //Read into a sorted dictionary - key, value pair
                    if (!userFollows.ContainsKey(user))
                        //If the user name doesn't exist add it as a fresh entry into the dictionary
                        userFollows.Add(user, follows);
                    else
                        //If the user has been processed previously, just append the user and the people they following to his existing key
                        userFollows[user].AddRange(follows);
                }

                //Return the model together with some additional information regarding the success of the above execution
                return new Tuple<List<User>, bool, string>(userFollows.ToUserModel(), true, "Users File Successfully Processed");
            }
            catch (Exception ex)
            {
                return new Tuple<List<User>, bool, string>(null, false, String.Format("Error : {0}", ex.Message));
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}