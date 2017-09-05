using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public bool InBattle { get; protected set; } // is the user currently in battle
        public Battle Battle { get; protected set; } // the battle the user is currently in (null if not in battle)
        public bool CompletedIntro { get; set; } // has user completed the introduction, chosen a start monster, etc...

        public Party Party { get; protected set; }

        public User()
        {
            Party = new Party(this);

            InBattle = false;
        }

        public void SetBattle(Battle battle)
        {
            Battle = battle;
            if (Battle != null)
                InBattle = true;
            else
                InBattle = false;
        }
    }
}
