using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Encounter
    {
        protected User[] users;
        protected Monster[] monsters;

        // Checks with a user (specified by Id) is involved in this encounter
        public bool IsUserEncounter(int userId)
        {
            return true;
        }
    }
}
