using System;
using Newtonsoft.Json;

namespace StuffManager
{
    public class PackageVersion
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("friendly_version")]
        public string FriendlyVersion { get; set; }
        [JsonProperty("ksp_version")]
        public string KSPVersion { get; set; }
        [JsonProperty("changelog")]
        public string Changelog { get; set; }
        [JsonProperty("download_path")]
        public string DownloadPaths { get; set; }
    }
}
