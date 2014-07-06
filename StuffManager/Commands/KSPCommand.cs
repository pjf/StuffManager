using System;

namespace StuffManager.Commands
{
    public static class KSPCommand
    {
        public static int HandleCommandLine(string[] args, string[] options)
        {
            var version = KSP.GetInstalledVersion();
            var path = KSP.RootPath;
            Console.WriteLine("Running KSP version {0} installed at {1}",
                version, path);
            return 0;
        }
    }
}
