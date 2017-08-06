using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public static class ServerInfo
    {
        public const double ServerVersion = 0.1;

        public static string toJson()
        {
            var resp = new ServerInfoResponse()
            {
                version = ServerVersion
            };

            return JsonConvert.SerializeObject(resp);
        }
    }

    public struct ServerInfoResponse
    {
        public double version;   
    };
}
