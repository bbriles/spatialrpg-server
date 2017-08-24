using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Party
    {
        public Monster[] Monsters { get; set; }

        // Adds a monster to the party, returns true if monster was added
        public bool AddMonster(Monster monster)
        {
            return false;
        }

        // Removes monster from party, returns true if monster was removed
        public bool RemoveMonster(Monster monster)
        {
            return false;
        }
    }
}
