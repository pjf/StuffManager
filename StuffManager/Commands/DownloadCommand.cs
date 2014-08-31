using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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

            using (WebClient client = new WebClient())
            {

                string sOutput = String.Format("{0}-{1}.zip", mod.Name, mod.Versions.First().FriendlyVersion);
                Console.WriteLine("Downloading \"{0}\" to working directory...", sOutput);
                Console.WriteLine("\tPlease wait ...");

                client.DownloadFile("http://beta.kerbalstuff.com" + mod.Versions.First().DownloadPaths, sOutput);
                Console.WriteLine("\nDownload completed Successfully.");
            }
            return 0;
        }
    }
}
