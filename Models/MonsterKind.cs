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
        public string Type { get; set; }
        public MonsterElement Element { get; set; }
    }

    public struct MonsterType
    {
        public const string Beast = "Beast";
        public const string Construct = "Construct";
        public const string Dragon = "Dragon";
        public const string Spirit = "Spirit";
        public const string Humanoid = "Humanoid";
        public const string Insect = "Insect";
        public const string Monster = "Monster";
    }

    public enum MonsterElement
    {
        Fire,
        Water,
        Earth,
        Air,
        Fae,
        Iron,
        Nature
    }
}
