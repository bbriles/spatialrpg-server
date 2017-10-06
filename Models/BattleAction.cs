using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class BattleAction
    {
        public int MonsterIndex { get; set; }
        public int SkillId { get; set; }
        public int TargetIndex { get; set; }
    }
}
