using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialFeedTest
{
    //Generic Singlton - Helps give structure to the code and provides only one piont of access to enter the processing and reading in of both files
    public class Singleton<T> where T : class
    {
        private static T instance;
        private static object initLock = new object();

        public static T Instance
        {
            get
            {
                if (instance == null)
                    CreateInstance();

                return instance;
            }
        }

        private static void CreateInstance()
        {
            lock (initLock)
            {
                if (instance == null)
                {
                    Type t = typeof(T);

                    // Ensure there are no public constructors...
                    ConstructorInfo[] ctors = t.GetConstructors();
                    if (ctors.Length > 0)
                        throw new InvalidOperationException(String.Format("{0} has at least one accesible ctor making it impossible to enforce singleton behaviour", t.Name));

                    // Create an instance via the private constructor
                    instance = (T)Activator.CreateInstance(t, true);
                }
            }
        }

    }
}


