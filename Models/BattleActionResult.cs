using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class BattleActionResult
    {
        public int MonsterBattleId { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
    }

    public struct BattleActionResultType
    {
        public const string Damage = "Damage";
        public const string StatUp = "StatUp";
        public const string StatDown = "StatDown";
    }
}
