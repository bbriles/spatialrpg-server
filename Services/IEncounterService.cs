using System.Collections.Generic;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services 
{
    public interface IEncounterService
    {
        IEnumerable<Encounter> GetEncounters();
        Encounter GetEncounter(int id);
        void CreateRandomEncounter();
        int JoinEncounter(int encounterId, User user);
    }
}