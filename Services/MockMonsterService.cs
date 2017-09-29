using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockMonsterService : IMonsterService
    {
        protected List<MonsterType> types;
        protected List<Monster> monsters;

        public MockMonsterService()
        {
            CreateMockData();
        }

        protected void CreateMockData()
        {
            types = new List<MonsterType>();
            types.Add(new MonsterType()
            {
                Id = 1,
                Element = MonsterElement.Fire,
                Class = MonsterClass.Construct,
                Name = "Magma Golem",
                Skills = new List<Skill>() { new Skill() { Id = 1, Name = "Burninate", Description = "Burninate the countryside", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 2, Name = "Flame On", Description = "Increase attack power", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack }
            },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 39 }, { Stat.PhysicalAttack, 52 }, { Stat.PhysicalDefense, 43 },
                    { Stat.MagicAttack, 60 }, { Stat.MagicDefense, 50 }, { Stat.Speed, 65 } }
            });
            types.Add(new MonsterType()
            {
                Id = 2,
                Element = MonsterElement.Iron,
                Class = MonsterClass.Humanoid,
                Name = "Dwarf",
                Skills = new List<Skill>() { new Skill() { Id = 3, Name = "Axe Attack", Description = "Attack with axe", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 4, Name = "Natural Sprinter", Description = "Dwarves are very dangerous over short distances", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 45 }, { Stat.PhysicalAttack, 49 }, { Stat.PhysicalDefense, 49 },
                    { Stat.MagicAttack, 65 }, { Stat.MagicDefense, 65 }, { Stat.Speed, 45 } }
            });
            types.Add(new MonsterType()
            {
                Id = 3,
                Element = MonsterElement.Water,
                Class = MonsterClass.Dragon,
                Name = "Leviathan",
                Skills = new List<Skill>() { new Skill() { Id = 5, Name = "Water Blast", Description = "Attack with a blast of water", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 6, Name = "Shroud of Mist", Description = "Hide yourself in cover of mist", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 44 }, { Stat.PhysicalAttack, 48 }, { Stat.PhysicalDefense, 65 },
                    { Stat.MagicAttack, 50 }, { Stat.MagicDefense, 64 }, { Stat.Speed, 43 } }
            });
            types.Add(new MonsterType()
            {
                Id = 4,
                Element = MonsterElement.Nature,
                Class = MonsterClass.Humanoid,
                Name = "Sasquatch",
                Skills = new List<Skill>() { new Skill() { Id = 7, Name = "Crushing blow", Description = "Attack with great power", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 8, Name = "Forest Camoflage", Description = "Hide yourself", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 63 }, { Stat.PhysicalAttack, 60 }, { Stat.PhysicalDefense, 55 },
                    { Stat.MagicAttack, 50 }, { Stat.MagicDefense, 50 }, { Stat.Speed, 71 } }
            });
            types.Add(new MonsterType()
            {
                Id = 5,
                Element = MonsterElement.Water,
                Class = MonsterClass.Spirit,
                Name = "Undine",
                Skills = new List<Skill>() { new Skill() { Id = 9, Name = "Flood", Description = "Lots of water", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 10, Name = "Big Splash", Description = "Area attack with water", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 40 }, { Stat.PhysicalAttack, 40 }, { Stat.PhysicalDefense, 35 },
                    { Stat.MagicAttack, 50 }, { Stat.MagicDefense, 100 }, { Stat.Speed, 70 } }
            });
            types.Add(new MonsterType()
            {
                Id = 6,
                Element = MonsterElement.Air,
                Class = MonsterClass.Beast,
                Name = "Griffin",
                Skills = new List<Skill>() { new Skill() { Id = 11, Name = "Diving Attack", Description = "Attack from above", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 12, Name = "Slash", Description = "Slash from sharp claws", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 52 }, { Stat.PhysicalAttack, 90 }, { Stat.PhysicalDefense, 55 },
                    { Stat.MagicAttack, 58 }, { Stat.MagicDefense, 62 }, { Stat.Speed, 60 } }
            });
            types.Add(new MonsterType()
            {
                Id = 7,
                Element = MonsterElement.Fae,
                Class = MonsterClass.Humanoid,
                Name = "Changeling",
                Skills = new List<Skill>() { new Skill() { Id = 13, Name = "Punch", Description = "Pow, biff, bam", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 14, Name = "Do Something", Description = "This skill does something", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 45 }, { Stat.PhysicalAttack, 49 }, { Stat.PhysicalDefense, 49 },
                    { Stat.MagicAttack, 65 }, { Stat.MagicDefense, 65 }, { Stat.Speed, 45 } }
            });
            types.Add(new MonsterType()
            {
                Id = 8,
                Element = MonsterElement.Iron,
                Class = MonsterClass.Construct,
                Name = "Living Armor",
                Skills = new List<Skill>() { new Skill() { Id = 15, Name = "Sword Strike", Description = "A quick slashing strike", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 16, Name = "Piercing Attack", Description = "Attack which pierces defenses", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 45 }, { Stat.PhysicalAttack, 49 }, { Stat.PhysicalDefense, 49 },
                    { Stat.MagicAttack, 65 }, { Stat.MagicDefense, 65 }, { Stat.Speed, 45 } }
            });
            types.Add(new MonsterType()
            {
                Id = 9,
                Element = MonsterElement.Fire,
                Class = MonsterClass.Insect,
                Name = "Giant Fire Ant",
                Skills = new List<Skill>() { new Skill() { Id = 17, Name = "Flame Blast", Description = "Attack with a blast of fire", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 18, Name = "Pinch", Description = "Attack with pinchers", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 55 }, { Stat.PhysicalAttack, 70 }, { Stat.PhysicalDefense, 45 },
                    { Stat.MagicAttack, 70 }, { Stat.MagicDefense, 50 }, { Stat.Speed, 60 } }
            });
            types.Add(new MonsterType()
            {
                Id = 10,
                Element = MonsterElement.Fae,
                Class = MonsterClass.Monster,
                Name = "Ogre",
                Skills = new List<Skill>() { new Skill() { Id = 19, Name = "Bash", Description = "Hit em with a club", AffectedStat=Stat.HpCurrent,
                Amount = -10, Operator = Operator.Add, RelatedStat = Stat.PhysicalAttack },
                new Skill() { Id = 20, Name = "Renegerate", Description = "Heal wounds and restore health", AffectedStat=Stat.PhysicalAttack,
                Amount = 10, Operator = Operator.Add, RelatedStat = Stat.MagicAttack } },
                BaseStats = new Dictionary<string, int>() { { Stat.HpMax, 45 }, { Stat.PhysicalAttack, 49 }, { Stat.PhysicalDefense, 49 },
                    { Stat.MagicAttack, 65 }, { Stat.MagicDefense, 65 }, { Stat.Speed, 45 } }
            });

            monsters = new List<Monster>();
            monsters.Add(new Monster() { Id = 1, Type = types[3], UserId = 1 });
            monsters.Add(new Monster() { Id = 2, Type = types[7], UserId = 1 });
            monsters.Add(new Monster() { Id = 3, Type = types[9], UserId = 1 });
            monsters.Add(new Monster() { Id = 4, Type = types[2], UserId = 2 });
            monsters.Add(new Monster() { Id = 5, Type = types[4], UserId = 2 });
            monsters.Add(new Monster() { Id = 6, Type = types[3], UserId = 2 });
            monsters.Add(new Monster() { Id = 7, Type = types[8], UserId = 3 });
            monsters.Add(new Monster() { Id = 8, Type = types[8], UserId = 3 });
        }

        public MonsterType GetMonsterKind(int id)
        {
            return types.FirstOrDefault(kind => kind.Id == id);
        }

        public IEnumerable<MonsterType> GetMonsterKinds()
        {
            return (IEnumerable<MonsterType>)types;
        }

        public IEnumerable<Monster> GetUserMonsters(int userId)
        {
            return monsters.Where(mon => mon.UserId == userId);
        }

        public Monster GetMonster(int id)
        {
            return monsters.FirstOrDefault(mon => mon.Id == id);
        }
    }
}
