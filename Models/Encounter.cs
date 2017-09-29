using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Encounter
    {
        public int Id { get; }
        private static int _nextId = 0;
        protected List<int> userIds;
        public List<Monster> Monsters;

        public Encounter(List<Monster> monsters)
        {
            Id = System.Threading.Interlocked.Increment(ref _nextId);

            userIds = new List<int>();
            Monsters = new List<Monster>(monsters);
        }

        public bool Join(int userId)
        {
            if(!HasUserJoined(userId))
            {
                userIds.Add(userId);
                return true;
            }
            return false;
        }

        // Checks with a user (specified by Id) is involved in this encounter
        public bool HasUserJoined(int userId)
        {
            return userIds.Contains(userId);
        }

        public string GetMonstersString()
        {
            var str = "";

            for(var i = 0; i < Monsters.Count; i++)
            {
                if (i > 0)
                    str += ", ";
                str += Monsters[i].Type.Name;
            }

            return str;
        }

        public int GetTotalUsers()
        {
            return userIds.Count;
        }
    }
}
