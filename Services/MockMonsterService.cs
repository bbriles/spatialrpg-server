using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockMonsterService : IMonsterService
    {
        protected List<MonsterKind> kinds;
        protected List<Monster> monsters;

        public MockMonsterService()
        {
            CreateMockData();
        }

        protected void CreateMockData()
        {
            kinds = new List<MonsterKind>();
            kinds.Add(new MonsterKind() { Id = 1, Element = MonsterElement.Fire, Type = MonsterType.Construct, Name = "Magma Golem" });
            kinds.Add(new MonsterKind() { Id = 2, Element = MonsterElement.Iron, Type = MonsterType.Humanoid, Name = "Dwarf" });
            kinds.Add(new MonsterKind() { Id = 3, Element = MonsterElement.Water, Type = MonsterType.Dragon, Name = "Leviathan" });
            kinds.Add(new MonsterKind() { Id = 4, Element = MonsterElement.Nature, Type = MonsterType.Humanoid, Name = "Sasquatch" });
            kinds.Add(new MonsterKind() { Id = 5, Element = MonsterElement.Water, Type = MonsterType.Spirit, Name = "Undine" });
            kinds.Add(new MonsterKind() { Id = 6, Element = MonsterElement.Air, Type = MonsterType.Beast, Name = "Griffin" });
            kinds.Add(new MonsterKind() { Id = 7, Element = MonsterElement.Fae, Type = MonsterType.Humanoid, Name = "Changeling" });
            kinds.Add(new MonsterKind() { Id = 8, Element = MonsterElement.Iron, Type = MonsterType.Construct, Name = "Living Armor" });
            kinds.Add(new MonsterKind() { Id = 9, Element = MonsterElement.Fire, Type = MonsterType.Insect, Name = "Giant Fire Ant" });
            kinds.Add(new MonsterKind() { Id = 10, Element = MonsterElement.Fae, Type = MonsterType.Monster, Name = "Ogre" });

            monsters = new List<Monster>();
            monsters.Add(new Monster() { Id = 1, Kind = kinds[3], UserId = 1 });
            monsters.Add(new Monster() { Id = 2, Kind = kinds[7], UserId = 1 });
            monsters.Add(new Monster() { Id = 3, Kind = kinds[9], UserId = 1 });
            monsters.Add(new Monster() { Id = 4, Kind = kinds[2], UserId = 2 });
            monsters.Add(new Monster() { Id = 5, Kind = kinds[4], UserId = 2 });
            monsters.Add(new Monster() { Id = 6, Kind = kinds[3], UserId = 2 });
            monsters.Add(new Monster() { Id = 7, Kind = kinds[8], UserId = 3 });
            monsters.Add(new Monster() { Id = 8, Kind = kinds[8], UserId = 3 });
        }

        public MonsterKind GetMonsterKind(int id)
        {
            return kinds.FirstOrDefault(kind => kind.Id == id);
        }

        public IEnumerable<MonsterKind> GetMonsterKinds()
        {
            return (IEnumerable<MonsterKind>)kinds;
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
