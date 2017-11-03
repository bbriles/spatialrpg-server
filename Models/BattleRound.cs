using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class BattleRound
    {
        public List<BattleTurn> Turns { get; set; }
        protected Battle Battle;
        protected List<BattleAction> UserActions;
        protected List<BattleAction> EnemyActions;

        public BattleRound(Battle battle, List<BattleAction> userActions)
        {
            Battle = battle;
           UserActions = userActions;
        }

        public List<BattleTurn> DoRound()
        {
            EnemyActions = GetEnemyActions();
            Turns = CreateTurnList();
            SortTurnList();

            // Determine results of turns
            for (var i = 0; i < Turns.Count; i++)
            {
                var action = Turns[i].Action;

                Turns[i].Results = Turns[i].Monster.DoAction(action, Battle);
            }

            return Turns;
        }

        protected List<BattleAction> GetEnemyActions()
        {
            var actions = new List<BattleAction>();

            foreach(var enemy in Battle.Enemies)
            {
                actions.Add(enemy.GetBattleAction(Battle));
            }

            return actions;
        }

        protected List<BattleTurn> CreateTurnList()
        {
            var turns = new List<BattleTurn>();
            // Add user and enemy actions to turn list
            foreach (var monster in Battle.User.Party.Monsters)
            {
                var action = UserActions.FirstOrDefault(a => a.MonsterBattleId == monster.BattleId);
                if (action != null)
                {
                    turns.Add(new BattleTurn(monster, action));
                }
            }
            foreach (var monster in Battle.Enemies)
            {
                var action = EnemyActions.FirstOrDefault(a => a.MonsterBattleId == monster.BattleId);
                if (action != null)
                {
                    turns.Add(new BattleTurn(monster, action));
                }
            }
            return turns;
        }

        protected void SortTurnList()
        {
            // TODO: Implement turn list sorting based on speed
        }
    }
}
