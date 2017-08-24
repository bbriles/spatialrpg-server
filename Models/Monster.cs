using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Monster
    {
        public MonsterKind Kind { get; set; }
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Health { get; set; }

        // Also need to have properties for other stats
    }
}
