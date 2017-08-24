using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpatialRPGServer.Models;

namespace SpatialRPGServer
{
    public class UserService
    {
        protected List<User> users;

        public UserService()
        {
            CreateMockData();
        }

        protected void CreateMockData()
        {
            users = new List<User>();
            users.Add(new User() { Id = 1, Username = "testguy" });
            users.Add(new User() { Id = 2, Username = "testgal" });
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
