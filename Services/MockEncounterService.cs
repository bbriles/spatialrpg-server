using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockEncounterService : IEncounterService
    {
        private IMonsterService _monsterService;
        private IBattleService _battleService;
        protected List<Encounter> encounters;

        public MockEncounterService(IMonsterService monsterService, IBattleService battleService)
        {
            _monsterService = monsterService;
            _battleService = battleService;
            CreateMockData();
        }

        protected void CreateMockData()
        {
            encounters = new List<Encounter>();
        }

        public IEnumerable<Encounter> GetEncounters()
        {
            return (IEnumerable<Encounter>)encounters;
        }

        public Encounter GetEncounter(int id)
        {
            return encounters.FirstOrDefault(enc => enc.Id == id);
        }

        public void CreateRandomEncounter()
        {
            var encounter = new Encounter(GetEncounterMonsters());

            encounters.Add(encounter);
        }

        protected List<Monster> GetEncounterMonsters()
        {
            var monsters = new List<Monster>();
            monsters.Add(new Monster() { Type = _monsterService.GetMonsterKind(3) });
            monsters.Add(new Monster() { Type = _monsterService.GetMonsterKind(2) });
            monsters.Add(new Monster() { Type = _monsterService.GetMonsterKind(5) });

            return monsters;
        }

        // returns the ID of the battle created if successful, otherwise -1
        public int JoinEncounter(int encounterId, User user)
        {
            var encounter = encounters.FirstOrDefault(enc => enc.Id == encounterId);
            if(encounter != null)
            {
                // check to make sure the user is close enough to the encounter to battle
                if(encounter.Join(user.Id))
                {
                    return _battleService.StartBattle(encounter, user);
                }
            }
            return -1;
        }
    }
}
