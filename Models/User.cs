using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public double LocationX { get; set; }
        public double LocationY { get; set; }
        public bool InBattle { get; set; } // is the user currently in battle
        public bool CompletedIntro { get; set; } // has user completed the introduction, chosen a start monster, etc...

        public Party Party { get; protected set; }

        public User()
        {
            Party = new Party(this);

            InBattle = false;
        }
    }
}
