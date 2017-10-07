using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class Monster
    {
        private MonsterType _type;
        public MonsterType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                Stats = new Stats(_type.BaseStats);
            }
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public Stats Stats { get; set; }

        public Monster()
        {
        }

        public bool IsAlive()
        {
            return Stats.GetStat(Stat.HpCurrent) > 0;
        }

        public BattleAction GetBattleAction(int index, List<Monster> friendly, List<Monster> enemies, string myGroup)
        {
            var action = new BattleAction() { MonsterGroup = myGroup, MonsterIndex = index, SkillId = Type.Skills[0].Id };

            if (myGroup == BattleGroup.Enemies)
                action.TargetGroup = BattleGroup.Party;
            else
                action.TargetGroup = BattleGroup.Enemies;

            for(var i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].IsAlive())
                {
                    action.TargetIndex = i;
                    break;
                }
            }

            // TODO: Add some AI here, probably a couple different kinds depending on the type of monster

            return action;
        }
    }
}
