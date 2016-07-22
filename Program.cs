using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1
            // Read and sort dictionary
            var d = Read();

            // 2
            // Read in user input and show anagrams
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                Show(d, line);
            }
        }
        static Dictionary<string, string> Read()
        {
            using (var client = new WebClient())
            {
          //      string result = client.DownloadString("http://norvig.com/ngrams/enable1.txt");
            




            var d = new Dictionary<string, string>();
            // using (WebRequest req = HttpWebRequest("https://github.com/dwyl/english-words/blob/master/words.txt"))

            using (StreamReader sr = new StreamReader(@"C:\Program Files (x86)\notforbidden.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string a = Alphabetize(line);
                    string v;
                    if (d.TryGetValue(a, out v))
                    {
                        d[a] = v + "," + line;
                    }
                    else
                    {
                        d.Add(a, line);
                    }
                }

            }
            return d;
        }
    }
        static string Alphabetize(string s)
        {
            char[] a = s.ToCharArray();
            Array.Sort(a);
            return new string(a);
        }
        static void Show(Dictionary<string, string> d, string w)
        {
            // Write value for alphabetized word
            string v;
            if (d.TryGetValue(Alphabetize(w), out v))
            {
                Console.WriteLine(v);
            }
            else
            {
                Console.WriteLine("-");
            }
        }
    }
}
