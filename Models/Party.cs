using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Party
    {
        protected User User;
        public const int MaxPartySize = 3;

        public List<Monster> Monsters { get; set; }

        public Party(User user)
        {
            User = user;
            Monsters = new List<Monster>();
        }

        // Adds a monster to the party, returns true if monster was added
        public bool AddMonster(Monster monster)
        {
            if(Monsters.Count < MaxPartySize && monster.UserId == User.Id)
            {
                Monsters.Add(monster);
                return true;
            }
            return false;
        }

        // Removes monster from party, returns true if monster was removed
        public bool RemoveMonster(Monster monster)
        {
            if(Monsters.Contains(monster) && Monsters.Count > 1)
            {
                Monsters.Remove(monster);
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            var str = "";

            for(var i = 0; i < Monsters.Count; i++)
            {
                if (i > 0)
                    str += ", ";
                str += Monsters[i].Kind.Name;
            }

            return str;
        }
    }
}
