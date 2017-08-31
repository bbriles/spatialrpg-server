using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer.Services
{
    public class MockUserService : IUserService
    {
        private IMonsterService _monsterService;
        protected List<User> users;

        public MockUserService(IMonsterService monsterService)
        {
            _monsterService = monsterService;
            CreateMockData();
        }

        protected void CreateMockData()
        {
            users = new List<User>();
            var user = new User() { Id = 1, Username = "testguy", CompletedIntro = true };
            user.Party.AddMonster(_monsterService.GetMonster(1));
            user.Party.AddMonster(_monsterService.GetMonster(2));
            user.Party.AddMonster(_monsterService.GetMonster(3));
            users.Add(user);
            user = new User() { Id = 2, Username = "testgal", CompletedIntro = true };
            user.Party.AddMonster(_monsterService.GetMonster(4));
            users.Add(user);
            user = new User() { Id = 3, Username = "frank", CompletedIntro = true };
            user.Party.AddMonster(_monsterService.GetMonster(7));
            user.Party.AddMonster(_monsterService.GetMonster(8));
            users.Add(user);
        }

        public User GetUser(int id)
        {
            return users.FirstOrDefault(user => user.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }
    }
}
