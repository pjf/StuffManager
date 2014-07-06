using System;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace StuffManager
{
    public static class KSP
    {
        public static string RootPath
        {
            get
            {
                if (RuntimeInfo.IsLinux)
                {
                    var path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                        ".steam", "steam", "SteamApps", "common", "Kerbal Space Program");
                    return path;
                }
                return null; // TODO
            }
        }

        public static string GetInstalledVersion()
        {
            var assembly = Assembly.LoadFile(Path.Combine(RootPath, "KSP_Data", "Managed", "Assembly-CSharp.dll"));
            var attr = assembly.GetType("KSPAssembly");
            var ver = assembly.GetCustomAttribute(attr);
            var _major = attr.GetField("versionMajor");
            var major = (int)_major.GetValue(ver);
            var _minor = attr.GetField("versionMinor");
            var minor = (int)_minor.GetValue(ver);
            var version = major.ToString() + "." + minor.ToString();
            // Regex method as a shitty backup
            // We can use this to maybe get the patch number
            if (File.Exists(Path.Combine(RootPath, "readme.txt")))
            {
                var readme = File.ReadAllText(Path.Combine(RootPath, "readme.txt"));
                var regex = new Regex("Version (?<version>[0-9]+\\.[0-9]+(\\.[0-9]+)?)");
                var match = regex.Match(readme);
                if (match != null)
                {
                    var regexVersion = match.Groups["version"].Value;
                    if (regexVersion.StartsWith(version)) // We can assume the regex match adds a patch number
                        version = regexVersion;
                }
            }
            return version;
        }
    }
}
