using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class BattleAction
    {
        public int MonsterBattleId { get; set; }
        public int SkillId { get; set; }
        public int TargetBattleId { get; set; }
        public string TargetGroup { get; set; }
    }

    public struct BattleGroup
    {
        public const string Party = "Party";
        public const string Enemies = "Enemies";
    }
}
