using System;
using System.IO;
using Newtonsoft.Json;

namespace MezzengerServer
{
    public static class Files
    {
        public static Settings settings = JsonConvert.DeserializeObject<Settings>(File.ReadAllText(Environment.CurrentDirectory + "/Config/settings.json"));

        static string usersJsonPath; 

        public static string UsersJsonPath
        {
            get
            {
                return usersJsonPath;
            }
            set
            {
                usersJsonPath = value;
            }
        }

        static Files()
        {
            UsersJsonPath = settings.UsersJsonPath;
        }
    }
}