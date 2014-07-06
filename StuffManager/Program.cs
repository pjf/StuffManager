using System;
using System.Collections.Generic;
using System.Linq;
using StuffManager.Commands;

namespace StuffManager
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            int ret = HandleArguments(args);
            if (ret != 0)
                return ret;
            return 0;
        }

        static int HandleArguments(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Try running `stuff --help`");
                return 1;
            }
            var command = args[0];
            var shifted = args.Skip(1).ToArray();
            var _options = new List<string>();
            int i;
            for (i = 0; i < args.Length; i++)
            {
                if (args[i] == "--")
                    break;
                else if (args[i].StartsWith("--"))
                    _options.Add(args[i]);
                else
                    break;
            }
            var options = _options.ToArray();
            switch (command)
            {
                case "search":
                case "s":
                    return SearchCommand.HandleCommandLine(shifted, options);
                case "ksp":
                    return KSPCommand.HandleCommandLine(shifted, options);
                case "info":
                    return InfoCommand.HandleCommandLine(shifted, options);
                case "changelog":
                    return ChangelogCommand.HandleCommandLine(shifted, options);
            }
            Console.WriteLine("Command not found. Try `stuff --help`.");
            return 1;
        }
    }
}
