using System;
using System.Linq;

namespace StuffManager.Commands
{
    public static class ChangelogCommand
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
            foreach (var version in mod.Versions)
            {
                Console.WriteLine("== Version {0} (for KSP {1})", version.FriendlyVersion, version.KSPVersion);
                if (string.IsNullOrEmpty(version.Changelog))
                    Console.WriteLine("The first version of {0}", mod.Name);
                else
                    Console.WriteLine(version.Changelog);
                Console.WriteLine();
            }
            return 0;
        }
    }
}
