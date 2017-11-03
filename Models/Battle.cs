using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SpatialRPGServer.Models
{
    public class Battle
    {
        private static int _nextId = 0;
        public int Id { get; }
        public User User { get; set; }
        public List<Monster> Enemies { get; set; }
        [JsonIgnore]
        public List<BattleRound> Rounds { get; protected set; }
        [JsonIgnore]
        public List<Monster> Monsters { get; set; }
        
        public Battle(Encounter encounter, User user)
        {
            Id = System.Threading.Interlocked.Increment(ref _nextId);

            User = user;
            Enemies = new List<Monster>(encounter.Monsters);
            Rounds = new List<BattleRound>();

            Monsters = new List<Monster>();
            Monsters.AddRange(User.Party.Monsters);
            Monsters.AddRange(Enemies);

            AssignBattleIds();
        }

        public BattleRound DoRound(List<BattleAction> userActions)
        {
            var round = new BattleRound(this, userActions);

            round.DoRound();

            Rounds.Add(round);

            return round;
        }

        protected void AssignBattleIds()
        {
            for (var i = 0; i < Monsters.Count; i++)
            {
                Monsters[i].BattleId = i + 10;
            }
        }

        public Monster GetMonsterByBattleId(int battleId)
        {
            return Monsters.Where(m => m.BattleId == battleId).FirstOrDefault();
        }
    }
}
