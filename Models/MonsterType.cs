using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class MonsterType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Element { get; set; }
        public List<Skill> Skills { get; set; }
        [JsonIgnore]
        public Dictionary<string, int> BaseStats;
    }

    public struct MonsterClass
    {
        public const string Beast = "Beast";
        public const string Construct = "Construct";
        public const string Dragon = "Dragon";
        public const string Spirit = "Spirit";
        public const string Humanoid = "Humanoid";
        public const string Insect = "Insect";
        public const string Monster = "Monster";
    }

    public struct MonsterElement
    {
        public const string Fire = "Fire";
        public const string Water = "Water";
        public const string Earth = "Earth";
        public const string Air = "Air";
        public const string Fae = "Fae";
        public const string Iron = "Iron";
        public const string Nature = "Nature";
    }
}
