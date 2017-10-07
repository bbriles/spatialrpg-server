using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class BattleAction
    {
        public string MonsterGroup { get; set; }
        public int MonsterIndex { get; set; }
        public int SkillId { get; set; }
        public int TargetIndex { get; set; }
        public string TargetGroup { get; set; }
    }

    public struct BattleGroup
    {
        public const string Party = "Party";
        public const string Enemies = "Enemies";
    }
}
