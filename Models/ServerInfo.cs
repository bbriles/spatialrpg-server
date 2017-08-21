using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class ServerInfo
    {
        private static readonly ServerInfo instance = new ServerInfo();

        // Server values
        [JsonProperty]
        public const double ServerVersion = 0.1;


        static ServerInfo()
        {

        }

        public static ServerInfo Instance
        {
            get
            {
                return instance;
            }
        }
    }

    public struct ServerInfoResponse
    {
        public double version;   
    };
}
