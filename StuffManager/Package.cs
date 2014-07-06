using System;
using Newtonsoft.Json;

namespace StuffManager
{
    public class Package
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("short_description")]
        public string ShortDescription { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("downloads")]
        public int Downloads { get; set; }
        [JsonProperty("followers")]
        public int Followers { get; set; }
        [JsonProperty("author")]
        public string Author { get; set; }
        [JsonProperty("versions")]
        public PackageVersion[] Versions { get; set; }
    }
}
