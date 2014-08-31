using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StuffManager.Commands
{
    class DownloadCommand
    {
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

            System.Diagnostics.Process.Start("http://beta.kerbalstuff.com" + mod.Versions.First().DownloadPaths);
            return 0;
        }
    }
}
