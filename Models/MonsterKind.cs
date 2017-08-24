using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class MonsterKind
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public MonsterType Type { get; set; }
        public MonsterElement Element { get; set; }
    }

    public enum MonsterType
    {
        Humanoid,
        Beast,
        Construct
    }

    public enum MonsterElement
    {
        Fire,
        Water,
        Earth,
        Air
    }
}
