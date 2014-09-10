using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StuffManager
{
    public static class KerbalStuff
    {

        public static Package[] Search(string terms)
        {
            Console.WriteLine(string.Format(
                Settings.KS_MOD_SEARCH + "{0}", Uri.EscapeUriString(terms)));
            var request = (HttpWebRequest)WebRequest.Create(string.Format(
                Settings.KS_MOD_SEARCH + "{0}", Uri.EscapeUriString(terms)));
            
            var response = request.GetResponse();
            string text;
            using (var reader = new StreamReader(response.GetResponseStream()))
                text = reader.ReadToEnd();
            var results = JsonConvert.DeserializeObject<Package[]>(text);
            return results;
        }
    }
}
