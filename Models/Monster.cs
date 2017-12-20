using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace SpatialRPGServer.Models
{
    public class Monster
    {
        private readonly ILogger Logger = ApplicationLogging.CreateLogger<Monster>();

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
                if (Name == null)
                {
                    Name = _type.Name;
                }
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public Stats Stats { get; set; }
        public int BattleId { get; set; } // ID of monster in a battle

        public Monster()
        {
        }

        public bool IsAlive()
        {
            return Stats.GetStat(Stat.HpCurrent) > 0;
        }

        public BattleAction GetBattleAction(Battle battle)
        {
            var targetBattleId = -1;
            foreach(var monster in battle.User.Party.Monsters)
            {
                if(monster.IsAlive())
                {
                    targetBattleId = monster.BattleId;
                    break;
                }
            }
            return new BattleAction()
            { SkillId = Type.Skills[0].Id, MonsterBattleId = BattleId, TargetBattleId = targetBattleId, TargetGroup = null };
        }

        public List<BattleActionResult> DoAction(BattleAction action, Battle battle)
        {
            var skill = Type.Skills.FirstOrDefault(s => s.Id == action.SkillId);

            if (skill != null)
            {
                var results = new List<BattleActionResult>();

                // Determine target(s)
                if (skill.TargetType == TargetType.Single || skill.TargetType == TargetType.Self)
                {
                    var target = battle.GetMonsterByBattleId(action.TargetBattleId);

                    if (target != null)
                    {
                        return new List<BattleActionResult> { skill.DoSkillOnTarget(this, target) };
                    }
                    if(target == null)
                    {
                        Logger.LogError("Invalid Action Target", action);
                        return null;
                    }
                }
                else if (skill.TargetType == TargetType.Group)
                {
                    // TODO: Handle group targetting skills
                }
                else if (skill.TargetType == TargetType.All)
                {
                    // TODO: Handle all targetting skills
                }
                else
                {
                    Logger.LogError("Invalid Skill Target Type", skill);
                    return null;
                }
                // Execute skill on each target

                if (skill.Type == SkillType.Attack)
                {
                    //return new List<SkillResult> { Attack(skill, target) };
                }
            }

            return null;
        }
    }
}
