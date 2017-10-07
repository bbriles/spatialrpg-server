using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class BattleTurn
    {
        public int Order { get; set; }
        public BattleAction Action { get; set; }
        public List<BattleActionResult> Results { get; set; }

        [JsonIgnore]
        public Monster Monster { get; set; }

        public BattleTurn(Monster monster, BattleAction action)
        {
            Monster = monster;
            Action = action;
        }
    }
}
