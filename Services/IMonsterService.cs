using System.Collections.Generic;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services 
{
    public interface IMonsterService
    {
        MonsterKind GetMonsterKind(int id);
        IEnumerable<MonsterKind> GetMonsterKinds();
        IEnumerable<Monster> GetUserMonsters(int userId);
        Monster GetMonster(int id);
    }
}