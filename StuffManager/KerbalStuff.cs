using System;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace StuffManager
{
    public static class KerbalStuff
    {
        public static string RootPath = "http://beta.kerbalstuff.com/api";

        public static Package[] Search(string terms)
        {
            var request = (HttpWebRequest)WebRequest.Create(string.Format(
                RootPath + "/search/mod?query={0}", Uri.EscapeUriString(terms)));
            var response = request.GetResponse();
            string text;
            using (var reader = new StreamReader(response.GetResponseStream()))
                text = reader.ReadToEnd();
            var results = JsonConvert.DeserializeObject<Package[]>(text);
            return results;
        }
    }
}
