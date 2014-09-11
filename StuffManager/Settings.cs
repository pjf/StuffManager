using System;

namespace StuffManager
{
    static class Settings
    {
        // The root address of KerbalStuff
        public static String KS_ROOT = "https://www.kerbalstuff.com";

        //API String for KerbalStuff
        public static String KS_API = KS_ROOT + "/api";

        //String for getting a user via KS's API
        public static String KS_USER = KS_API + "/user";

        //String for getting a mod via KS's API
        public static String KS_MOD = KS_API + "/mod";

        //String to search for mods via KS's API
        public static String KS_MOD_SEARCH = KS_API + "/search/mod?query=";

        //String to search for users via KS's API
        public static String KS_USER_SEARCH = KS_API + "/search/user?query=";
    }
}
