using System;
using System.Net;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyGenerator
{
    class Program
    {
        public static List<string> keys = new List<string>();
        public static string newKey = "";
        public static int keyLenght = 8;
        public static string  amountOfKeys;
        public const string DATA_URL = "http://esmondia.net/keygenerator.php";

        static void Main()
        {
            Console.WriteLine("Initializing Key Generator...");
            keys.Clear();
            Console.WriteLine("Enter the amount of keys to generate. ");
            amountOfKeys = Console.ReadLine();

            int result = 0;

            int.TryParse(amountOfKeys.ToString(), out result);

            Console.WriteLine("Creating {0} keys...", result.ToString());

            Random random = new Random();
            for (int i = 0; i < result; i++)
            {
                for(int j = 0; j < keyLenght; j++)
                {
                    newKey += random.Next(0, 10);
                }

                //Console.WriteLine("Created Key: " + newKey);
                keys.Add(newKey);
                newKey = "";
            }

            WebClient client = new WebClient();

            foreach(var key in keys)
            {
                Console.WriteLine(key);
                NameValueCollection form = new NameValueCollection();
                form.Add("key", key);
                client.UploadValues(DATA_URL, form);
            }
        }
    }
}
