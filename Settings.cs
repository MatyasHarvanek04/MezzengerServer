using System;
using System.IO;
using Newtonsoft.Json;

namespace MezzengerServer
{
    public class Settings
    {
        string ip = "not set";

        [JsonProperty("ip")]
        public string IP
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }


        string port ="not set";

        [JsonProperty("port")]
        public string Port
        {
            get
            {
                return port;
            } 
            set
            {
                port = value;
            }
        }
        string usersJsonPath = "not set";
        
        [JsonProperty("usersJsonPath")]
        public string UsersJsonPath
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
    }   
}
