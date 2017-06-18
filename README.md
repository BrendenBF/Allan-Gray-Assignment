# Allan Gray Assignment

The application was identified to be divided into 3 distinct aspects of processing, with the final aspect of the application dependant on the outcome of the intial 2 steps in the execution of the application. These steps were as follows:
        
        ************************************************************************************************************
        *   1. Read in the list of users with their associated followers                                           *
        *   2. Read in the list of tweets with the name associated with the tweet, serving as its identifier       *
        *   3. Construct and print the social feed from the users and tweets that have been read in from the file  *
        ************************************************************************************************************
        
It was decided to use a Key-value pair to facilitate the construction of the algorithm as I felt that it suited the nature of what needed to be achieved quite well. After the users and their tweets were read in, these key-value pairs were then 're-constructed' into classes with suitable naming conventions, as this I felt was just easier and more intuative to work with and it facilitates readability better - A extension methods class facilitated this transformation.
         
Although a more simple solution was possible, using less code files, I felt that my approach, that being using various coding constructs, facilitates a design that is nicely seperates into their respective bodies of work and makes for more fuild and intuitive reading and as the models of tweet and user is seperated into their own classes, these code concepts can be expanded on at a later stage, without impacting of each other - So it also facilitates a bit of maintainability.
         
A singleton was used as the method for gaining assess to the 3 different processes, as creating instances at random without having control over this operation would create quite a lot of overhead where memory allocation is concerned, thus the singleton facilitates one piont of entry for this. And it just looks neater than having lots of instances floating around.

This is then injected into a feed manager class that uses the 3 respective processes to output the feed. Contracts were written for each of the processes, meaning that in the furture, the processes can read from a different store lke a sql database or no-sql databases with less impact on the overall structure of the application and the error handeling stays in tact.
         
The users.txt and tweets.txt files are within the bin directory of the debug folder, so that application should be able to execute as is. Click start and you should see output.
        
KIND RGS,
BRENDEN 
