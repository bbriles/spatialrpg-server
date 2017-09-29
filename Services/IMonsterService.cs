using System.Collections.Generic;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services 
{
    public interface IMonsterService
    {
        MonsterType GetMonsterKind(int id);
        IEnumerable<MonsterType> GetMonsterKinds();
        IEnumerable<Monster> GetUserMonsters(int userId);
        Monster GetMonster(int id);
    }
}