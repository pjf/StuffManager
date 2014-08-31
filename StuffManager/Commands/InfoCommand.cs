using System;
using System.Linq;

namespace StuffManager.Commands
{
    public static class InfoCommand
    {
        private static string Truncate(string s, int l)
        {
            if (s.Length < l)
                return s;
            s = s.Substring(0, l - 3);
            return s + "...";
        }

        public static int HandleCommandLine(string[] args, string[] options)
        {
            var terms = string.Join(" ", args);
            var search = KerbalStuff.Search(terms);
            var results = search.Where(r => r.Name.ToUpper() == terms.ToUpper()
                       || r.Author.ToUpper() + "/" + r.Name.ToUpper() == terms.ToUpper());
            if (!results.Any())
                results = search;
            if (results.Count() > 1)
            {
                Console.WriteLine("Error: \"{0}\" is ambiguous between:");
                foreach (var m in results)
                    Console.WriteLine("{0}/{1} [{2}]", m.Author, m.Name, m.Downloads);
                return 1;
            }
            var mod = results.Single();
            Console.WriteLine("{0}/{1}", mod.Author, mod.Name);
            Console.WriteLine("Name: {0}", mod.Name);
            Console.WriteLine("Author: {0}", mod.Author);
            Console.WriteLine("URL: http://beta.kerbalstuff.com/mod/{0}", mod.Id);
            Console.WriteLine("Version: {0}", mod.Versions[0].FriendlyVersion);
            Console.WriteLine("Downloads: {0}", mod.Downloads);
            Console.WriteLine("Followers: {0}", mod.Followers);
            Console.WriteLine("Short Description: \n\t{0}", mod.ShortDescription);
            //Console.WriteLine("Default Version ID: \t{0}", mod.DefaultVersionID);
            return 0;
        }
    }
}
