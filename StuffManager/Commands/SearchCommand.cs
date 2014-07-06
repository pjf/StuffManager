using System;
using System.Linq;

namespace StuffManager.Commands
{
    public static class SearchCommand
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
            bool all = false;
            foreach (var option in options)
            {
                switch (option)
                {
                    case "--all":
                        all = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option: " + option);
                        return 1;
                }
            }
            var results = KerbalStuff.Search(string.Join(" ", args));
            if (!all)
            {
                // TODO: Filter out unsupported versions
            }
            foreach (var result in results)
            {
                Console.WriteLine("{0}/{1} [{2}]", result.Author, result.Name, result.Downloads);
                Console.WriteLine("\t" + Truncate(result.ShortDescription, Console.WindowWidth - 8));
            }
            return 0;
        }
    }
}
