using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class BattleRound
    {
        public List<BattleTurn> Turns { get; set; }

        public BattleRound(List<Monster> party, List<Monster> enemies, List<BattleAction> userActions)
        {
            Turns = new List<BattleTurn>();

            DoRound(party, enemies, userActions);
        }

        protected void DoRound(List<Monster> party, List<Monster> enemies, List<BattleAction> userActions)
        {
            var enemyActions = GetEnemyActions(enemies, party);

            // Add user and enemy actions to turn list
            // Sort turn list based on monster speed
            // Determine results of actions

        }

        protected List<BattleAction> GetEnemyActions(List<Monster> enemies, List<Monster> party)
        {
            var actions = new List<BattleAction>();

            for(var i = 0; i < enemies.Count; i++ )
            {
                actions.Add(enemies[i].GetBattleAction(i, enemies, party, BattleGroup.Enemies));
            }

            return actions;
        }
    }
}
