using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MonsterService
    {
        protected List<MonsterKind> kinds;
        protected List<Monster> monsters;

        public MonsterService()
        {
            CreateMockData();
        }

        protected void CreateMockData()
        {
            kinds = new List<MonsterKind>();

            monsters = new List<Monster>();
        }

        public MonsterKind GetMonsterKind(int id)
        {
            return kinds.FirstOrDefault(kind => kind.Id == id);
        }

        public IEnumerable<Monster> GetUserMonsters(int userId)
        {
            return monsters.Where(mon => mon.UserId == userId);
        }
    }
}
