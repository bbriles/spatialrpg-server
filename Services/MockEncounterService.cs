using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockEncounterService : IEncounterService
    {
        private IBattleService _battleService;
        protected List<Encounter> encounters;

        public MockEncounterService(IBattleService battleService)
        {
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
            var encounter = new Encounter();

            encounters.Add(encounter);
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
