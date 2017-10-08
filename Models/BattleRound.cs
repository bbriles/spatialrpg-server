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
            for (var i = 0; i < party.Count; i++)
            {
                var action = userActions.FirstOrDefault(a => a.MonsterIndex == i);
                if (action != null)
                {
                    Turns.Add(new BattleTurn(party[i], action));
                }
            }
            for (var i = 0; i < enemies.Count; i++)
            {
                var action = enemyActions.FirstOrDefault(a => a.MonsterIndex == i);
                if (action != null)
                {
                    Turns.Add(new BattleTurn(enemies[i], action));
                }
            }
            // Sort turn list based on monster speed
            // TODO: Sort turn list based on monster speed

            // Determine results of actions
            for (var i = 0; i < Turns.Count; i++)
            {
                var action = Turns[i].Action;
                Monster monster = null;
                Monster target = null;
                if (action.MonsterGroup == BattleGroup.Party)
                {
                    monster = party[action.MonsterIndex];
                    target = enemies[action.TargetIndex];
                }
                else
                {
                    monster = enemies[action.MonsterIndex];
                    target = party[action.TargetIndex];
                }
                // TODO: Handle skills other than single target
                monster.DoSkill(action.SkillId, target);
            }


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
