using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpatialRPGServer.Models
{
    public class Battle
    {
        private static int _nextId = 0;
        public int Id { get; }
        public User User { get; set; }
        public List<Monster> Enemies { get; set; }

        public Battle(Encounter encounter, User user)
        {
            Id = System.Threading.Interlocked.Increment(ref _nextId);

            User = user;
            Enemies = new List<Monster>(encounter.Monsters);
        }
    }
}
